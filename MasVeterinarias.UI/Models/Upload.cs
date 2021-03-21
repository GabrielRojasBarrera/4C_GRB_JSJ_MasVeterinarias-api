using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Models
{
    public class Upload
    {
        public IFormFile MyFile { get; set; }
    }
}
