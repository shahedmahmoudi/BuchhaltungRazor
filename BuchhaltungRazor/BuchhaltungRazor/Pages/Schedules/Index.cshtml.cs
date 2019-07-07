using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuchhaltungRazor.Models;
using BuchhaltungRazor.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Entity;


namespace BuchhaltungRazor.Pages.Schedules
{
    public class IndexModel : PageModel
    {
        private readonly BuchhaltungRazor.Models.BuchhaltungRazorContext _context;

        public IndexModel(BuchhaltungRazor.Models.BuchhaltungRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public IList<Schedule> _schedule { get; private set; }

        public  void OnGetAsync()
        {
            _schedule =   _context.Schedules.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
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

            var schedule = new Schedule()
            {
                PublicSchedule = publicScheduleData,
                PublicScheduleSize = FileUpload.UploadPublicSchedule.Length,
                PrivateSchedule = privateScheduleData,
                PrivateScheduleSize = FileUpload.UploadPrivateSchedule.Length,
                Titel = FileUpload.Title,
                UploadDT = DateTime.UtcNow
            };

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}