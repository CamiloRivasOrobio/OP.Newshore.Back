using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public DateTime? feregistro { get; set; }
        public DateTime? febaja { get; set; }
    }
}
