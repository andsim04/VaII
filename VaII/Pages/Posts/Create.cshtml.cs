using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VaII.Data;
using VaII_Sem.Models;

namespace VaII.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly VaII.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;


        [BindProperty] public FileViewModel FileUpload { get; set; }

        public CreateModel(VaII.Data.ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _hostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Post Post { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid || _context.Post == null || Post == null)
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
                        Published = Post.Published,
                        Latest = DateTime.Now,
                        ApplicationUserFk = await _userManager.GetUserIdAsync(user),
                        Content = memoryStream.ToArray()
                };
                    _context.Post.Add(file);
                    await _context.SaveChangesAsync();
            }
            }




            

            return RedirectToPage("./Index");
        }



    }
}

