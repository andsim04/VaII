
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaII.Models;
using VaII_Sem.Models;

namespace VaII.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly VaII.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;

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
        [BindProperty] public Location Location { get; set; } = default!;
        [BindProperty] public AdvancedSettings AdvancedSettings { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid || _context.Post == null || Post == null || Location == null)
            {
                return Page();
            }


            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);
                if (memoryStream.Length < 2097152)
                {
                    Location.ID = new Guid();
                    _context.Add(Location);
                    var sett = new AdvancedSettings();
                    
                    sett = AdvancedSettings;
                    sett.ID = new Guid();
                    _context.Add(sett);
                    
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    var file = new Post()
                    {
                        Title = Post.Title,
                        Description = Post.Description,
                        Published = Post.Published,
                        Latest = DateTime.Now,
                        ApplicationUserFk = await _userManager.GetUserIdAsync(user),
                        Content = memoryStream.ToArray(),
                        Location = Location.ID,
                        Author = user.UserName
                };
                    
                        AdvancedSettings.ID = sett.ID;
                        file.Settings = sett.ID;
                    
                    _context.Post.Add(file);
                    await _context.SaveChangesAsync();
            }
            }




            

            return RedirectToPage("./Index");
        }



    }
}

