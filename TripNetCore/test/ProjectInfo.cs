using System;
using System.Collections.Generic;

namespace TripNetCore.test
{
    public partial class ProjectInfo
    {
        public ProjectInfo()
        {
            EntityInfo = new HashSet<EntityInfo>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string DatabaseName { get; set; }
        public string SchemeName { get; set; }

        public virtual ICollection<EntityInfo> EntityInfo { get; set; }
    }
}
