using NTier.Core.Entity;
using NTier.Model.Entities;
using NTier.Model.Maps;
using NTier.Model.Utility;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;

namespace NTier.Model.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "server=.;database=;uid=;pwd=;";
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserLoginInfoMap());
            modelBuilder.Configurations.Add(new AppUserInfoMap());
      
            base.OnModelCreating(modelBuilder);
        }

    
        public DbSet<AppUserInfo> Users { get; set; }
        public DbSet<AppUserLoginInfo> UserLoginInformations { get; set; }


        public int SaveChanges(Guid UserID)
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string Identity = WindowsIdentity.GetCurrent().Name;
            string ComputerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            string ip = RemoteIp.GetIpAddress();

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedADUserName = Identity;
                        entity.CreatedComputerName = ComputerName;
                        entity.CreatedDate = dateTime;
                        entity.CreatedBy = UserID;
                        entity.CreatedIp = ip;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedADUserName = Identity;
                        entity.ModifiedBy = UserID;
                        entity.ModifiedComputerName = ComputerName;
                        entity.ModifiedDate = dateTime;
                        entity.ModifiedIp = ip;

                    }
                }
            }
            return base.SaveChanges();
        }
        public override int SaveChanges()
        {
            throw new InvalidOperationException("User ID must be provided");
        }



    }

}

