using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public int Username { get; set; }
        public int Email { get; set; }
        public int Password { get; set; }
        public int CreatedAt { get; set; }
        public int Status { get; set; }
    }
}
