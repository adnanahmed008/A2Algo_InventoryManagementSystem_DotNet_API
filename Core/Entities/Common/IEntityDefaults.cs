using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Common
{
    public interface IEntityDefaults
    {
        string CreatedBy { get; set; }
        DateTime CreationDate { get; set; }

        string? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }

        bool IsDeleted { get; set; }
    }
}
