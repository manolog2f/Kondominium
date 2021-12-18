using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class UserConfigEntity
    {

            public string UserId { get; set; }
            public string PropertyName { get; set; }
            public string PropertyValue { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<System.DateTime> ModifiedDate { get; set; }
            public string CreateByUserId { get; set; }
            public string ModifiedByUserId { get; set; }

        
    }
}
