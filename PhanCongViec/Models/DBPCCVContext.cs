using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace PhanCongViec.Models
{
    public class DBPCCVContext : DbContext
    {
        public DBPCCVContext() : base("DBConnectionString")
        {

        }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }

        public DbSet<CongViec> CongViecs { get; set; }

        public DbSet<PhanCong> PhanCongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }
    }
}