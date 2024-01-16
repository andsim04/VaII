using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaII.Data;
using VaII_Sem.Models;
using System.Drawing ;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using WebMatrix;
using Microsoft.Extensions.Hosting;


namespace VaII.Pages.Posts
{
    public class IndexModel : PageModel
    {
        
        private readonly VaII.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(VaII.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }

        public IList<Post> Post { get;set; } = default!;

        public async Task OnGetAsync()
        {
  
            if (_context.Post != null)
            {

                IList<Post> UserPosts = new List<Post>();
                foreach (var post in _context.Posts)
                {
                    if (_userManager.GetUserId(User) == post.ApplicationUserFk)
                    {
                        UserPosts.Add(post);
                    }
                }

                Post = UserPosts.ToList();

            }
        }
    }
}
