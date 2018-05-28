using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using DeskPowerApp.Model;

namespace DeskPowerApp.DataAcess
{
    public class DeskPowerAppContext : DbContext
    {
        public DeskPowerAppContext() : base("Data Source = donau.hiof.no; Initial Catalog = michaems; Persist Security Info=True;User ID = michaems; Password=M1qTc5")
        {
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DeskPowerAppIntializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Model.Draft>().Property(f => f.DraftCreatedDate).HasColumnType("datetime2");

            modelBuilder.Entity<Model.Draft>()
                .HasMany(a => a.Writter)
                .WithMany(b => b.Drafts)
                .Map(m =>
                {
                    m.ToTable("PersonDraft");
                    m.MapLeftKey("PersonId");
                    m.MapRightKey("DraftId");
                });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Draft> Drafts { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

    }
}
