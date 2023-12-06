using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Web.Helpers;
using VaII.Data;
using VaII_Sem.Models;

namespace VaII.Pages.Posts
{
    public class EditModel : PageModel
    {
        private readonly VaII.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty] 
        public FileViewModel FileUpload { get; set; }

        public EditModel(VaII.Data.ApplicationDbContext context, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post =  await _context.Post.FirstOrDefaultAsync(m => m.ID == id);
            if (post == null)
            {
                return NotFound();
            }
            Post = post;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);
                if (memoryStream.Length < 2097152)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    var file = new Post()
                    {
                        Title = Post.Title,
                        Description = Post.Description,
                        ApplicationUserFk = await _userManager.GetUserIdAsync(user),
                        Content = memoryStream.ToArray()
                    };

                    _context.Attach(file).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PostExists(Post.ID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }

            

                return RedirectToPage("./Index");
            }
        

        private bool PostExists(int id)
        {
          return (_context.Post?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
