﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CodeDto
    {
        public string Code { get; set; }
        public string Language { get; set; }
        public string Function_name { get; set; }
        public string Params { get; set; } = "";
    }
}
