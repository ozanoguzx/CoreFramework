using NTier.Core.Entity;
using System;

namespace NTier.Model.Entities
{
    [Serializable]
    [Flags]
    public enum Role
    {
        None = 0,
        Member = 1,
        Admin = 3
    }
    public class AppUserLoginInfo:CoreEntity
    {
        public virtual AppUserInfo AppUserInfo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role? Role { get; set; }
    }
}
