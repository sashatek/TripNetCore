using System;
using System.Collections.Generic;

namespace TripNetCore.test
{
    public partial class PackageInfo
    {
        public PackageInfo()
        {
            EntityInfo = new HashSet<EntityInfo>();
        }

        public int PackageId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EntityInfo> EntityInfo { get; set; }
    }
}
