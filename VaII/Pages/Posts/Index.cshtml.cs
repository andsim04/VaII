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
using WebMatrix;


namespace VaII.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly VaII.Data.ApplicationDbContext _context;

        public IndexModel(VaII.Data.ApplicationDbContext context)
        {
            _context = context;
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
