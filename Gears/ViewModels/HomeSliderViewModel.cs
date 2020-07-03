using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gears.ViewModels
{
    public class HomeSliderViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public IFormFile Upload { get; set; }
    }
}
