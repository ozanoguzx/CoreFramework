using NTier.Core.Entity.Enum;
using System;

namespace NTier.Core.Entity
{
    public class CoreEntity : IEntity<Guid>
    {
       
        public Guid Id { get; set; }
        public Guid? MasterId { get; set; }
        public Status Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }
        public string CreatedADUserName { get; set; }
        public Guid? CreatedBy { get; set; }


        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp { get; set; }
        public string ModifiedADUserName { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
