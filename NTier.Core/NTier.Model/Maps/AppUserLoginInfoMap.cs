using NTier.Core.Map;
using NTier.Model.Entities;

namespace NTier.Model.Maps
{
    public class AppUserLoginInfoMap:CoreMap<AppUserLoginInfo>
    {
        public AppUserLoginInfoMap()
        {
            ToTable("dbo.UserLoginInformations");
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.Role).IsOptional();

            HasOptional(x => x.AppUserInfo).WithRequired(x => x.AppUserLoginInfo);
        }
    }
}
