using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Entities
{
    public class ResponseAPI<Tentity>
    {
        public Tentity Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}
