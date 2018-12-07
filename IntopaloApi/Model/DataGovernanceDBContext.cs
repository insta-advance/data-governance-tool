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
            : base(options) 
        {
            this.Database.EnsureCreated();
        }
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=IntopaloDb");
        }*/
        /* Implement tables. */
        public DbSet<Base> Bases { get; set; }
        public DbSet<Structured> Structureds { get; set; }
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
        public DbSet<Datastore> Datastores { get; set; }

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
                .OnDelete(DeleteBehavior.Cascade); 

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
                .OnDelete(DeleteBehavior.Cascade); 

            /* Configure Foreign key of Field(StructuredId)->Structured(Id).*/
             modelBuilder.Entity<Field>()
                .HasOne(f => f.Structured)
                .WithMany(s => s.Fields)
                .HasForeignKey(f => f.StructuredId)
                .OnDelete(DeleteBehavior.Cascade);

            /* Configure Foreign key of UnstructuredFile(StructuredId)->Datastore(Id).*/            
            modelBuilder.Entity<StructuredFile>()
                .HasOne(s => s.Datastore)
                .WithMany(d => d.StructuredFiles)
                .HasForeignKey(s => s.DatastoreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UnstructuredFile>()
                .HasOne(u => u.Datastore)
                .WithMany(d => d.UnstructuredFiles)
                .HasForeignKey(u => u.DatastoreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Collection>()
                .HasOne(c => c.Database)
                .WithMany(d => d.Collections)
                .HasForeignKey(c => c.DatabaseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Schema>()
                .HasOne(s => s.Database)
                .WithMany(d => d.Schemas)
                .HasForeignKey(d => d.DatabaseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Database>()
                .HasOne(d => d.Datastore)
                .WithMany(ds => ds.Databases)
                .HasForeignKey(d => d.DatastoreId)
                .OnDelete(DeleteBehavior.Cascade);

            /* Constraints: */
            /* Structured object can't have two Fields with equal name. */
            /* Dirty hack to achieve unique (Name, StructuredId) because */
            /* because HasAlternativeKey() does not work on derived classes!*/
            modelBuilder.Entity<Field>()
                 .HasIndex(f => new {f.Name, f.StructuredId})
                 .IsUnique();

            /* Datastore can have one unique filename. */
            modelBuilder.Entity<StructuredFile>()
                 .HasIndex(s => new {s.FilePath, s.DatastoreId})
                 .IsUnique();

            modelBuilder.Entity<UnstructuredFile>()
                 .HasIndex(u => new {u.FilePath, u.DatastoreId})
                 .IsUnique();

            modelBuilder.Entity<Collection>()
                 .HasIndex(c => new {c.Name, c.DatabaseId})
                 .IsUnique();

            modelBuilder.Entity<Schema>()
                 .HasIndex(s => new {s.Name, s.DatabaseId})
                 .IsUnique();

            modelBuilder.Entity<Database>()
                 .HasIndex(d => new {d.Name, d.DatastoreId})
                 .IsUnique();
            
             modelBuilder.Entity<Datastore>()
                .HasAlternateKey(ds => ds.Name);

                 
        }

    }

}