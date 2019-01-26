/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;*/
using DataGovernanceTool.Data.Access;
using Microsoft.EntityFrameworkCore;
using DataGovernanceTool.Data;
using DataGovernanceTool.Data.Models.Metadata;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using DataGovernanceTool.Data.Models.Metadata.Relationships;

namespace DataGovernanceTool.Data.Access
{
    public class DataGovernanceDBContext: BaseDbContext
    {
        public DataGovernanceDBContext(DbContextOptions<DataGovernanceDBContext> options)
            : base(options) 
        {
            this.Database.EnsureCreated();
        }
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DataGTDb");
        }*/
        /* Implement tables. */
        public DbSet<Base> Bases { get; set; }
        public DbSet<Structured> Structureds { get; set; }
        public DbSet<Schema> Schemas { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<StructuredFile> StructuredFiles { get; set; }
        public DbSet<UnstructuredFile> UnstructuredFiles { get; set; }
        public DbSet<PostgresDatabase> PostgresDatabases { get; set; }
        public DbSet<MongoDatabase> MongoDatabases { get; set; }
        public DbSet<KeyRelationship> KeyRelationships { get; set; }
        public DbSet<CompositeKeyField> CompositeKeyFields { get; set; }
        public DbSet<Datastore> Datastores { get; set; }
        public DbSet<Annotation> Annotations { get; set; }
        public DbSet<AnnotationBase> AnnotationBases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            /* Configure many-to-many manually. */
            modelBuilder.Entity<KeyRelationship>()
                .HasAlternateKey(r => new { r.FromId, r.ToId });
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
                .HasAlternateKey(c => new { c.FieldId, c.CompositeKeyId });
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

            /* Annotations to bases many to-many. */
            modelBuilder.Entity<AnnotationBase>()
                .HasAlternateKey(a => new { a.AnnotationId, a.BaseId });
            modelBuilder.Entity<AnnotationBase>()
                .HasOne(a => a.Annotation)
                .WithMany(a => a.AnnotationBases)
                .HasForeignKey(r => r.AnnotationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AnnotationBase>()
                .HasOne(a => a.Base)
                .WithMany(b => b.AnnotationBases)
                .HasForeignKey(a => a.BaseId)
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

            modelBuilder.Entity<CompositeKey>()
                .HasOne(c => c.TableForeign)            
                .WithMany(t => t.ForeignKeys)
                .HasForeignKey(c => c.TableId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Table>()
                .HasOne(t => t.PrimaryKey)            
                .WithOne(c => c.TablePrimary)
                .HasForeignKey<CompositeKey>(c => c.TableId)
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

            modelBuilder.Entity<MongoDatabase>()
                .HasOne(d => d.Datastore)
                .WithMany(ds => ds.MongoDatabases)
                .HasForeignKey(d => d.DatastoreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostgresDatabase>()
                .HasOne(d => d.Datastore)
                .WithMany(ds => ds.PostgresDatabases)
                .HasForeignKey(d => d.DatastoreId)
                .OnDelete(DeleteBehavior.Cascade);

            /* Constraints: */
            /* Structured object can't have two Fields with equal name. */
            /* Dirty hack to achieve unique (Name, StructuredId) because */
            /* because HasAlternativeKey() does not work on derived classes!*/
            modelBuilder.Entity<Field>()
                 .HasIndex(f => new {f.Name, f.StructuredId})
                 .IsUnique()
                 .HasName("asdf");

            /* Datastore can have one unique filename. */
            modelBuilder.Entity<File>()
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