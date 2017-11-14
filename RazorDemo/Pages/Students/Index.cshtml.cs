using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorDemo.Models;

namespace RazorDemo.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly RazorDemo.Models.RazorDemoContext _context;

        public IndexModel(RazorDemo.Models.RazorDemoContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
