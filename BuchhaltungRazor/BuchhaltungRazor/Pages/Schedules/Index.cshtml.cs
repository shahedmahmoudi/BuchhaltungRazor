using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuchhaltungRazor.Models;
using BuchhaltungRazor.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;



namespace BuchhaltungRazor.Pages.Schedules
{
    public class IndexModel : PageModel
    {
        private readonly BuchhaltungRazor.Models.BuchhaltungRazorContext _context;

        public IndexModel(BuchhaltungRazor.Models.BuchhaltungRazorContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public IList<Schedule> _schedule { get; private set; }
        public int? IDAufwand;

        //public void OnGetAsync(int? id)
        //{
        //    IDAufwand = id;
        //    var ShView = from x in _context.Schedules where x.AufwandID == IDAufwand select x;
        //    _schedule = ShView.ToList();
        //}
        private IHostingEnvironment _environment;

        [BindProperty]
        public IFormFile Upload { get; set; }

        public IList<Schedule> Schedule { get; private set; }

        public async Task OnGetAsync()
        {
            var p = _context.Schedules.ToListAsync();
            Schedule = await _context.Schedules.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            #region p
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            if (!ModelState.IsValid)
            {
                _schedule = await _context.Schedules.AsNoTracking().ToListAsync();
                return Page();
            }

            var publicScheduleData =
                 await FileHelpers.ProcessFormFile(FileUpload.UploadPublicSchedule, ModelState);

            var privateScheduleData =
                await FileHelpers.ProcessFormFile(FileUpload.UploadPrivateSchedule, ModelState);

            // Perform a second check to catch ProcessFormFile method
            // violations.
            if (!ModelState.IsValid)
            {
                _schedule = await _context.Schedules.AsNoTracking().ToListAsync();
                return Page();
            }

            var file = Path.Combine(_environment.ContentRootPath, "uploads", FileUpload.UploadPublicSchedule.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await FileUpload.UploadPublicSchedule.CopyToAsync(fileStream);
            }

            var schedule = new Schedule()
             {
                 PublicSchedule = publicScheduleData,
                 PublicScheduleSize = FileUpload.UploadPublicSchedule.Length,
                 PrivateSchedule = privateScheduleData,
                 PrivateScheduleSize = FileUpload.UploadPrivateSchedule.Length,
                 Titel = FileUpload.Title,
                 UploadDT = DateTime.UtcNow ,
                 AufwandID= FileUpload.AufwandID
             };

             _context.Schedules.Add(schedule);
             await _context.SaveChangesAsync();

            #endregion

      

            return RedirectToPage("./Index");
        }
    }
}