using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gears.ViewModels
{
    public class EditHomeContentViewModel
    {
        public int Id { get; set; }
        public string Paragraph { get; set; }
        public string Image { get; set; }
        public IFormFile File { get; set; }
    }
}
