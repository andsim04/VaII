using System;
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
using WebMatrix;


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

        protected string _appUserID;

        public async void  setAppUserID(string id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            _appUserID = await _userManager.GetUserIdAsync(user);
        }

        public string getAppUserID()
        {
            return _appUserID; 
        }

        public IList<Post> Post { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Post != null)
            {
                
                Post = await _context.Post.ToListAsync();
            }
        }
    }
}
