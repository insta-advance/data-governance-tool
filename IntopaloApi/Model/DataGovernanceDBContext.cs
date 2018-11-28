/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;*/
using Microsoft.EntityFrameworkCore;


namespace IntopaloApi.System_for_data_governance
{
    public class DataGovernanceDBContext: DbContext
    {
        public DataGovernanceDBContext(DbContextOptions<DataGovernanceDBContext> options)
            : base(options /*"name=DataGovernanceDBContext"*/)
        {
        }
        /* Implement tables. */
        public DbSet<Base> Bases { get; set; }
        public DbSet<StructuredBase> StructuredBases { get; set; }
        public DbSet<Schema> Schemas { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<StructuredFile> StructuredFiles { get; set; }
        public DbSet<UnstructuredFile> UnstructuredFiles { get; set; }
        public DbSet<Database> Databases { get; set; }
        public DbSet<KeyRelationship> KeyRelationships { get; set; }
        public DbSet<Annotation> Annotations { get; set; }
        public DbSet<CompositeKeyField> CompositeKeyFields { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            /* Configure many-to-many manually. */
            modelBuilder.Entity<KeyRelationship>()
                .HasKey(r => new { r.FromId, r.ToId });
            modelBuilder.Entity<KeyRelationship>()
                .HasOne(r => r.From)
                .WithMany(r => r.PrimaryKeyTo)
                .HasForeignKey(r => r.FromId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<KeyRelationship>()
                .HasOne(r => r.To)
                .WithMany(r => r.ForeignKeyTo)
                .HasForeignKey(r => r.ToId)
                /* For now RESTRICT: Cascading doesn't work on SQL server. */
                .OnDelete(DeleteBehavior.Restrict); 

            /* Composite key is a subset of fields. Configure many-to-many. */
            modelBuilder.Entity<CompositeKeyField>()
                .HasKey(c => new { c.FieldId, c.CompositeKeyId });
            modelBuilder.Entity<CompositeKeyField>()
                .HasOne(c => c.Field)
                .WithMany(c => c.CompositeKeyFields)
                .HasForeignKey(c => c.FieldId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CompositeKeyField>()
                .HasOne(c => c.CompositeKey)
                .WithMany(c => c.CompositeKeyFields)
                .HasForeignKey(c => c.CompositeKeyId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }

}