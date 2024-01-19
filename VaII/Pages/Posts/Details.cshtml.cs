using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaII.Data;
using VaII.Models;
using VaII_Sem.Models;

namespace VaII.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly VaII.Data.ApplicationDbContext _context;

        public DetailsModel(VaII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Post Post { get; set; } = default!;
      public Location Location { get; set; } = default!;
      public AdvancedSettings AdvancedSettings { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FirstOrDefaultAsync(m => m.ID == id);
            if (post == null)
            {
                return NotFound();
            }
            else 
            {
               
                Post = post;
                Location? loc = await _context.Locations.FindAsync(Post.Location);
                Location = loc;
                AdvancedSettings? advancedSettings = await _context.AdvancedSettings.FindAsync(Post.Settings);
                AdvancedSettings = advancedSettings;
            }
            return Page();
        }
    }
}
