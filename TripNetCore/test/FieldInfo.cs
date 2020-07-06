using System;
using System.Collections.Generic;

namespace TripNetCore.test
{
    public partial class FieldInfo
    {
        public int FieldId { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public int? FieldTypeId { get; set; }
        public string FieldName { get; set; }
        public string Label { get; set; }
        public string TableLabel { get; set; }
        public string LookupTable { get; set; }
        public string LookupValue { get; set; }
        public string LookupText { get; set; }
        public int? ControlId { get; set; }

        public virtual ControlInfo Control { get; set; }
        public virtual EntityInfo Entity { get; set; }
        public virtual FieldType FieldType { get; set; }
    }
}
