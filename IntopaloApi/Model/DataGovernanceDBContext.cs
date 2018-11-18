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
        public DbSet<Schema> Schemas { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Structured_File> Structured_Files { get; set; }
        public DbSet<Unstructured_File> Unstructured_Files { get; set; }

        public DbSet<RelationshipTable> RelationshipTables { get; set; }
        public DbSet<Database> Databases { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // primary key for collections
            modelBuilder.Entity<Collection>()
                .HasKey(c => new { c.CollectionId, c.TableType });

            // foreign key between field and collection

            modelBuilder.Entity<Field>()
                .HasRequired<Collection> (f => f.Collection)
                .WithMany(c => c.Fields)
                .HasForeignKey(f => new { f.OwnerId, f.OwnerType });

            //primary key for table
            modelBuilder.Entity<Table>()
                .HasKey(t => new { t.TableId, t.TableType });

            //foreign key between table and field
            modelBuilder.Entity<Field>()
                .HasRequired<Table>(f => f.Table)
                .WithMany(t => t.Fields)
                .HasForeignKey(f => new { f.OwnerId, f.OwnerType });

            //primary key for sf
            modelBuilder.Entity<Structured_File>()
                .HasKey(sf => new { sf.SFId, sf.TableType });

            //foreign key between sf and field
            modelBuilder.Entity<Field>()
                .HasRequired<Structured_File>(f => f.Structured_File)
                .WithMany(sf => sf.Field)
                .HasForeignKey(f => new { f.OwnerId, f.OwnerType });

            // primary key for uf
            modelBuilder.Entity<Unstructured_File>()
                .HasKey(uf => new { uf.USFId, uf.TableType });

            // primary key for database
            modelBuilder.Entity<Database>()
                .HasKey(db => new { db.DBId, db.TableType });

            // primary key for schema
            modelBuilder.Entity<Schema>()
                .HasKey(s => new { s.SchemaId, s.TableType });

            // primary key for field
            modelBuilder.Entity<Field>()
                .HasKey(f => new { f.FieldId, f.TableType });

            // primary key for relationtable
            modelBuilder.Entity<RelationshipTable>()
                .HasKey(rt => new { rt.RTId});

            //foreign key between relationtable and other tables

            //collection
            modelBuilder.Entity<RelationshipTable>()
                .HasRequired<Collection>(rt => rt.Collection)
                .WithMany(c => c.RelationshipTables)
                .HasForeignKey(rt => new { rt.TableId, rt.TableType });

            //field
            modelBuilder.Entity<RelationshipTable>()
                .HasRequired<Field>(rt => rt.Field)
                .WithMany(f => f.RelationshipTables)
                .HasForeignKey(rt => new { rt.TableId, rt.TableType });

            //table
            modelBuilder.Entity<RelationshipTable>()
                .HasRequired<Table>(rt => rt.Table)
                .WithMany(t => t.RelationshipTables)
                .HasForeignKey(rt => new { rt.TableId, rt.TableType });

            //uf
            modelBuilder.Entity<RelationshipTable>()
                .HasRequired<Unstructured_File>(rt => rt.Unstructured_File)
                .WithMany(uf => uf.RelationshipTables)
                .HasForeignKey(rt => new { rt.TableId, rt.TableType });

            //sf
            modelBuilder.Entity<RelationshipTable>()
                .HasRequired<Structured_File>(rt => rt.Structured_File)
                .WithMany(sf => sf.RelationshipTables)
                .HasForeignKey(rt => new { rt.TableId, rt.TableType });

            //database
            modelBuilder.Entity<RelationshipTable>()
                .HasRequired<Database>(rt => rt.Database)
                .WithMany(db => db.RelationshipTables)
                .HasForeignKey(rt => new { rt.TableId, rt.TableType });

            //schema
            modelBuilder.Entity<RelationshipTable>()
                .HasRequired<Schema>(rt => rt.Schema)
                .WithMany(s => s.RelationshipTables)
                .HasForeignKey(rt => new { rt.TableId, rt.TableType });
        }*/
    }

}