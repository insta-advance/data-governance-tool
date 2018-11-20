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


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            /* Configure many-to-many manually. */
            modelBuilder.Entity<KeyRelationship>()
                .HasKey(r => new { r.BaseFromId, r.BaseToId });
            modelBuilder.Entity<KeyRelationship>()
                .HasOne(r => r.BaseFrom)
                .WithMany(r => r.KeyRelationshipFrom)
                .HasForeignKey(r => r.BaseFromId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<KeyRelationship>()
                .HasOne(r => r.BaseTo)
                .WithMany(r => r.KeyRelationshipTo)
                .HasForeignKey(r => r.BaseToId)
                /* For now RESTRICT: cascading doesn't work on SQL server. */
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }

}