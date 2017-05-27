using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthAdviser.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHealthAdviser.DataContext
{
    public class EntityContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("User");
            modelBuilder.Entity<UserEntity>().HasKey(p => p.UserId);
            modelBuilder.Entity<UserEntity>().Property(p => p.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<UserEntity>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<InformationEntity>().ToTable("UserInformation");
            modelBuilder.Entity<InformationEntity>().HasKey(p => p.StatisticsId);
            modelBuilder.Entity<InformationEntity>().Property(p => p.StatisticsId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }
        public EntityContext() : base("EntityContext")
        {
            Database.SetInitializer<EntityContext>(new CreateDatabaseIfNotExists<EntityContext>());
        }
    }
}
