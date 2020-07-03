using Gears.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gears.ViewModels
{
    public class HomeViewModel
    {
        public HomeContent HomeContent { get; set; }
        public IEnumerable<HomeSlider> HomeSlider { get; set; }
        public AboutUs AboutUs { get; set; }
        public IEnumerable<AboutWork> AboutWork { get; set; }
        public IEnumerable<OurWork> OurWork { get; set; }
        public VideoContent VideoContent { get; set; }
        public IEnumerable<CustomerOpinion> CustomerOpinion { get; set; }
        public ContactUs ContactUs { get; set; }

    }
}
