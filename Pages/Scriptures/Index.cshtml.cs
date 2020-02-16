using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_Scripture_Journal.Data;
using My_Scripture_Journal.Model;

namespace My_Scripture_Journal
{
    public class IndexModel : PageModel
    {
        private readonly My_Scripture_Journal.Data.My_Scripture_JournalContext _context;

        public IndexModel(My_Scripture_Journal.Data.My_Scripture_JournalContext context)
        {
            _context = context;
        }

        public IList<ScriptureModel> ScriptureModel { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureBook { get; set; }
        public string SortOption { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from m in _context.ScriptureModel
                                           orderby m.Book
                                           select m.Book;
            IQueryable<int> allList = from d in _context.ScriptureModel
                                           orderby d.ID
                                           select d.ID;
            var scriptures = from m in _context.ScriptureModel
                             select m;
            if (!string.IsNullOrEmpty(SortOption))
            {
                if (SortOption == "Descending")
                {
                    
                }
            }
            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures = scriptures.Where(s => s.Book == ScriptureBook);
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(x => x.Notes.Contains(SearchString));
            }
            

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());

            ScriptureModel = await scriptures.ToListAsync();
        }
    }
}
