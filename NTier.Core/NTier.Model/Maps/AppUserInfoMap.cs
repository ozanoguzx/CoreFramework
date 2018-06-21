using NTier.Core.Map;
using NTier.Model.Entities;


namespace NTier.Model.Maps
{
    public class AppUserInfoMap:CoreMap<AppUserInfo>
    {
        public AppUserInfoMap()
        {
            ToTable("dbo.Users");
            Property(x => x.Address).IsOptional();
            Property(x => x.Birthdate).HasColumnType("datetime2").IsOptional();
            Property(x => x.Email).HasMaxLength(50).IsOptional();
            Property(x => x.ImagePath).IsOptional();
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.Surname).HasMaxLength(50).IsOptional();

            HasRequired(x => x.AppUserLoginInfo).WithOptional(x => x.AppUserInfo);
        }
    }
}
