using NTier.Model.Context;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectContext service = new ProjectContext();
            //b353d890-9a69-e811-b88c-d481d7b0c02c  

            AppUserInfo user = new AppUserInfo();
            user = service.Users.Find(Guid.Parse("b353d890-9a69-e811-b88c-d481d7b0c02c"));
            user.Email = "asdasda";
            user.Name = "Can";
            service.Entry(user).State = System.Data.Entity.EntityState.Modified;
            service.SaveChanges(Guid.Parse("b353d890-9a69-e811-b88c-d481d7b0c02c"));
        }
    }
}
