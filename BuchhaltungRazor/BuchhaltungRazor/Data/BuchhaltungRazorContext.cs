using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuchhaltungRazor.Models;

namespace BuchhaltungRazor.Models
{
    public class BuchhaltungRazorContext : DbContext
    {
        public BuchhaltungRazorContext (DbContextOptions<BuchhaltungRazorContext> options)
            : base(options)
        {
        }

        public DbSet<BuchhaltungRazor.Models.Laden> Ladens { get; set; }
        public DbSet<Aufwand> Aufwands { get; set; }
        public DbSet<AufwandList> AufwandListes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
     //   public DbSet<BuchhaltungRazor.Models.FileUpload> FileUploads { get; set; }
    }
}
