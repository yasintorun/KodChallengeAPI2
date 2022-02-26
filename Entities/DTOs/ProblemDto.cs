using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProblemDto
    {
        public Problem Problem{ get; set; }
        public List<ProblemInput> ProblemInputs { get; set; }
        public Track Track { get; set; }
    }
}
