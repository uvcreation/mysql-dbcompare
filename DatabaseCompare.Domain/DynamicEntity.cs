using System.Collections.Generic;
using System.Dynamic;

namespace DatabaseCompare.Domain
{
    public class DynamicEntity : DynamicObject
    {
        private IDictionary<string, object> _values;

        public DynamicEntity(IDictionary<string, object> values)
        {
            _values = values;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_values.ContainsKey(binder.Name))
            {
                result = _values[binder.Name];
                return true;
            }
            result = null;
            return false;
        }
    }
}
