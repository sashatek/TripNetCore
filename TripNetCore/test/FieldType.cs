using System;
using System.Collections.Generic;

namespace TripNetCore.test
{
    public partial class FieldType
    {
        public FieldType()
        {
            FieldInfo = new HashSet<FieldInfo>();
        }

        public int FieldTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FieldInfo> FieldInfo { get; set; }
    }
}
