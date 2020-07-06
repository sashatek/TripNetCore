using System;
using System.Collections.Generic;

namespace TripNetCore.test
{
    public partial class ControlInfo
    {
        public ControlInfo()
        {
            FieldInfo = new HashSet<FieldInfo>();
        }

        public int ControlId { get; set; }
        public string Name { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string Alighn { get; set; }
        public string Valign { get; set; }

        public virtual ICollection<FieldInfo> FieldInfo { get; set; }
    }
}
