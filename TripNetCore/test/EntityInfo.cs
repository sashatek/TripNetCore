using System;
using System.Collections.Generic;

namespace TripNetCore.test
{
    public partial class EntityInfo
    {
        public EntityInfo()
        {
            FieldInfo = new HashSet<FieldInfo>();
        }

        public int EntityId { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public bool Private { get; set; }
        public string TableName { get; set; }
        public int? PackageId { get; set; }

        public virtual PackageInfo Package { get; set; }
        public virtual ProjectInfo Project { get; set; }
        public virtual ICollection<FieldInfo> FieldInfo { get; set; }
    }
}
