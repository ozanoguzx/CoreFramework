using NTier.Model.Entities;
using NTier.Service.Base;


namespace NTier.Service.Option
{
    public class AppUserLoginInfoService:BaseService<AppUserLoginInfo>
    {
        public bool CheckCredentials(string userName, string password)=>
            Any(x => x.UserName == userName && x.Password == password);
        
        public AppUserLoginInfo FindByUsername(string userName)=>
            GetByDefault(x => x.UserName == userName);
        
    }
}
