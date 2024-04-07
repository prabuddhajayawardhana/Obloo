using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obloo.Domain.Primitives;

public interface IAuditableEntity
{
    public DateTimeOffset CreatedOnUtc { get; set; }
    public DateTimeOffset ModifiedOnUtc { get; set; }
}
