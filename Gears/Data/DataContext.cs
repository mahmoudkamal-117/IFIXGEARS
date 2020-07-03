using Gears.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gears.Data
{
    public class DataContext : IdentityDbContext
    {
        

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<HomeContent> HomeContents { get; set; }
        public DbSet<HomeSlider> HomeSliders { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<AboutWork> AboutWork { get; set; }
        public DbSet<OurWork> OurWork { get; set; }
        public DbSet<VideoContent> VideoContents { get; set; }
        public DbSet<CustomerOpinion> CustomerOpinion { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }
}
