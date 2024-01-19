using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaII.Data;
using VaII.Models;
using VaII_Sem.Models;

namespace VaII.Pages.Posts
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
  
        }

        [BindProperty]
        public Post Post { get; set; } = default!;
        [BindProperty] 
        public Location Location { get; set; } = default!;
        [BindProperty] 
        public AdvancedSettings AdvancedSettings { get; set; } = default!;

        [BindProperty] 
        public FileViewModel FileUpload { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post =  await _context.Posts.FirstOrDefaultAsync(m => m.ID == id);
            
            if (post == null)
            {
                return NotFound();
            }
            Post = post;

            var loc = await _context.Locations.FindAsync(Post.Location);
            Location = loc;
            var advancedSettings = await _context.AdvancedSettings.FindAsync(Post.Settings);
            AdvancedSettings = advancedSettings;
            Post.Content = post.Content;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {


            var post = await _context.Posts.FirstOrDefaultAsync(m => m.ID == id);

            if (post != null)
            {
                _context.Entry(post).State = EntityState.Detached;
            }
            Post.Location = post.Location;
            Location.ID = (Guid)Post.Location;
            Post.Settings = post.Settings;
            AdvancedSettings.ID = (Guid)Post.Settings;
            Post.Settings = post.Settings;
            Post.Content = post.Content;
            Post.Latest = DateTime.Now;
            
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            Post.ApplicationUserFk = await _userManager.GetUserIdAsync(user);
            Post.Author = user.UserName;
            Post.Content = post.Content;






            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Location).State = EntityState.Modified;
            _context.Attach(AdvancedSettings).State = EntityState.Modified;
            _context.Attach(Post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Post.ID) || !LocationExists(Post.Location))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        private bool LocationExists(Guid? id)
        {
            return (_context.Locations?.Any(e => e.ID == Post.Location)).GetValueOrDefault();
        }

        private bool SettingsExists(Guid? id)
        {
            return (_context.AdvancedSettings?.Any(e => e.ID == Post.Settings)).GetValueOrDefault();
        }
    }
}
