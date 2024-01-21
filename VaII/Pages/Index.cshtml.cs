using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaII_Sem.Models;

namespace VaII.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IList<Post> Post { get; set; } = default!;

        public async Task OnGetAsync()
        {

            if (_context.Post != null)
            {

                IList<Post> UserPosts = new List<Post>();
                foreach (var post in _context.Posts)
                {
                   if (post.Published) {
                        UserPosts.Add(post);
                   }
                }

                Post = UserPosts.ToList();

            }
        }
    }
}