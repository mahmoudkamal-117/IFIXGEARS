using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gears.ViewModels
{
    public class OurWorkViewModel
    {
        public int Id { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
        public IFormFile UploadBefore { get; set; }
        public IFormFile UploadAfter { get; set; }
    }
}
