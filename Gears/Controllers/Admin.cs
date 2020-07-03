using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Gears.Data;
using Gears.Models;
using Gears.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gears.Controllers
{
    [Authorize]
    public class Admin : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hosting;
         

        public Admin(DataContext context, IWebHostEnvironment hosting )
        {
            _context = context;
            _hosting = hosting;
             
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HomeContentIndex()
        {
            return View(_context.HomeContents.First());
        }
        public IActionResult EditHomeContent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exist = _context.HomeContents.Single(h=>h.Id==id);
            if (exist == null)
            {
                return NotFound();
            }
            EditHomeContentViewModel viewmodel = new EditHomeContentViewModel
            {
                Paragraph=exist.Paragraph,
                Image=exist.Image
               
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditHomeContent(int? id, EditHomeContentViewModel model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.File != null)
                    {
                        string upload = Path.Combine(_hosting.WebRootPath, @"image");
                        string fullpath = Path.Combine(upload, model.File.FileName);
                        model.File.CopyTo(new FileStream(fullpath, FileMode.Create));
                        model.Image = model.File.FileName;
                    }

                    var homecontent = new HomeContent
                    {
                        Id = model.Id,
                        Paragraph=model.Paragraph,
                        Image=model.Image

                    };
                    _context.Entry(homecontent).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {                    
                        throw;
                }
                return RedirectToAction(nameof(HomeContentIndex));

            }
            return View(model);
        }

        public IActionResult HomeSliderIndex()
        {
            return View(_context.HomeSliders.ToList());
        }
        [HttpGet]
        public IActionResult CreateHomeSlider()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateHomeSlider(HomeSliderViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Upload != null)
                {
                    string upload = Path.Combine(_hosting.WebRootPath, @"image");
                    string fullpath = Path.Combine(upload, model.Upload.FileName);
                    model.Upload.CopyTo(new FileStream(fullpath, FileMode.Create));
                }

                HomeSlider slider = new HomeSlider
                {                  
                    Image = model.Upload.FileName
                };
                _context.HomeSliders.Add(slider);
                _context.SaveChanges();
                return RedirectToAction(nameof(HomeSliderIndex));

            }
            return View(model);
        }
        public IActionResult EditHomeSlider(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var slid = _context.HomeSliders.Single(s=>s.Id==id);
            if (slid == null)
            {
                return NotFound();
            }
            HomeSliderViewModel slidviewmodel = new HomeSliderViewModel
            {
                Image = slid.Image
            };
            return View(slidviewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateHomeSlider(int? id, HomeSliderViewModel viewmodel)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (viewmodel.Upload != null)
                    {
                        string upload = Path.Combine(_hosting.WebRootPath, @"image");
                        string fullpath = Path.Combine(upload, viewmodel.Upload.FileName);
                        viewmodel.Upload.CopyTo(new FileStream(fullpath, FileMode.Create));
                        viewmodel.Image = viewmodel.Upload.FileName;
                    }

                    var homeslider = new HomeSlider
                    {
                        Id = viewmodel.Id,                       
                        Image = viewmodel.Image
                    };
                    _context.Entry(homeslider).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {                    
                        throw;                    
                }
                return RedirectToAction(nameof(HomeSliderIndex));
            }
            return View(viewmodel);
        }

        public IActionResult DeleteHomeSlider(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delslid = _context.HomeSliders.SingleOrDefault(s => s.Id == id); 
            if (delslid == null)
            {
                return NotFound();
            }
            return View(delslid);

        }

        [HttpPost, ActionName("DeleteHomeSlider")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteHomeSliderConfirm(HomeSlider model)
        {

            _context.HomeSliders.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(HomeSliderIndex));
        }


        public IActionResult AboutUsIndex()
        {
            return View(_context.AboutUs.First());
        }

        public IActionResult EditAboutUs(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exist = _context.AboutUs.Single(h => h.Id == id);
            if (exist == null)
            {
                return NotFound();
            }          
            return View(exist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAboutUs(int? id, AboutUs model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(AboutUsIndex));

            }
            return View(model);
        }

        public IActionResult AboutWorkIndex()
        {
            return View(_context.AboutWork.ToList());
        }


        public IActionResult CreateAboutWork()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAboutWork(AboutWork model)
        {
            if (ModelState.IsValid)
            {
                _context.AboutWork.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(AboutWorkIndex));

            }
            return View(model);
        }

        public IActionResult EditAboutWork(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var about = _context.AboutWork.Single(s => s.Id == id);
            if (about == null)
            {
                return NotFound();
            }
           
            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAboutWork(int? id, AboutWork model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(AboutWorkIndex));
            }
            return View(model);
        }

        public IActionResult DeleteAboutWork(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var aboutwork = _context.AboutWork.SingleOrDefault(s => s.Id == id);
            if (aboutwork == null)
            {
                return NotFound();
            }
            return View(aboutwork);

        }

        [HttpPost, ActionName("DeleteAboutWork")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAboutWorkConfirm(AboutWork model)
        {

            _context.AboutWork.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(AboutWorkIndex));
        }


        public IActionResult OurWorkIndex()
        {
            return View(_context.OurWork.ToList());
        }

        [HttpGet]
        public IActionResult CreateOurWork()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOurWork(OurWorkViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UploadBefore != null)
                {
                    string upload = Path.Combine(_hosting.WebRootPath, @"image");
                    string fullpath = Path.Combine(upload, model.UploadBefore.FileName);
                    model.UploadBefore.CopyTo(new FileStream(fullpath, FileMode.Create));
                    model.Before = model.UploadBefore.FileName;

                }
                if (model.UploadAfter != null)
                {
                    string upload = Path.Combine(_hosting.WebRootPath, @"image");
                    string fullpath = Path.Combine(upload, model.UploadAfter.FileName);
                    model.UploadAfter.CopyTo(new FileStream(fullpath, FileMode.Create));
                    model.After = model.UploadAfter.FileName;
                }

                OurWork work = new OurWork
                {
                    Before = model.Before,
                    After = model.After
                };
                _context.OurWork.Add(work);
                _context.SaveChanges();
                return RedirectToAction(nameof(OurWorkIndex));

            }
            return View(model);
        }
        public IActionResult EditOurWork(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var work = _context.OurWork.Single(s => s.Id == id);
            if (work == null)
            {
                return NotFound();
            }
            OurWorkViewModel workviewmodel = new OurWorkViewModel
            {
                Before = work.Before,
                After =work.After
            };
            return View(workviewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOurWork(int? id, OurWorkViewModel viewmodel)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (viewmodel.UploadBefore != null)
                    {
                        string upload = Path.Combine(_hosting.WebRootPath, @"image");
                        string fullpath = Path.Combine(upload, viewmodel.UploadBefore.FileName);
                        
                        viewmodel.UploadBefore.CopyTo(new FileStream(fullpath, FileMode.Create));
                        
                        viewmodel.Before = viewmodel.UploadBefore.FileName;
                        
                    }
                    if (viewmodel.UploadAfter != null)
                    {
                        string upload = Path.Combine(_hosting.WebRootPath, @"image");
                        string fullpath = Path.Combine(upload, viewmodel.UploadAfter.FileName);
                        viewmodel.UploadAfter.CopyTo(new FileStream(fullpath, FileMode.Create));
                        viewmodel.After = viewmodel.UploadAfter.FileName;
                    }

                    var ourwork = new OurWork
                    {
                        Id = viewmodel.Id,
                        Before = viewmodel.Before,
                        After=viewmodel.After
                    };
                    _context.Entry(ourwork).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(OurWorkIndex));
            }
            return View(viewmodel);
        }

        public IActionResult DeleteOurWork(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delwork = _context.OurWork.SingleOrDefault(s => s.Id == id);
            if (delwork == null)
            {
                return NotFound();
            }
            return View(delwork);

        }

        [HttpPost, ActionName("DeleteOurWork")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOurWorkConfirm(OurWork model)
        {

            _context.OurWork.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(OurWorkIndex));
        }


        public IActionResult VideoContentIndex()
        {
            return View(_context.VideoContents.First());
        }

        public IActionResult EditVideoContent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exist = _context.VideoContents.Single(h => h.Id == id);
            if (exist == null)
            {
                return NotFound();
            }
            return View(exist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditVideoContent(int? id, VideoContent model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(VideoContentIndex));

            }
            return View(model);
        }

        public IActionResult CustomerOpinionIndex()
        {
            return View(_context.CustomerOpinion.ToList());
        }


        public IActionResult CreateCustomerOpinion()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomerOpinion(CustomerOpinion model)
        {
            if (ModelState.IsValid)
            {
                _context.CustomerOpinion.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(CustomerOpinionIndex));

            }
            return View(model);
        }

        public IActionResult EditCustomerOpinion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var about = _context.CustomerOpinion.Single(s => s.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomerOpinion(int? id, CustomerOpinion model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(CustomerOpinionIndex));
            }
            return View(model);
        }

        public IActionResult DeleteCustomerOpinion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _context.CustomerOpinion.SingleOrDefault(s => s.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);

        }

        [HttpPost, ActionName("DeleteCustomerOpinion")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomerOpinionConfirm(CustomerOpinion model)
        {

            _context.CustomerOpinion.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(CustomerOpinionIndex));
        }
        public IActionResult ContactUsIndex()
        {
            return View(_context.ContactUs.First());
        }

        public IActionResult EditContactUs(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exist = _context.ContactUs.Single(c => c.Id == id);
            if (exist == null)
            {
                return NotFound();
            }
            return View(exist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditContactUs(int? id, ContactUs model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(ContactUsIndex));

            }
            return View(model);
        }
    }
}
