using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My_Scripture_Journal.Data;
using My_Scripture_Journal.Model;

namespace My_Scripture_Journal
{
    public class DeleteModel : PageModel
    {
        private readonly My_Scripture_Journal.Data.My_Scripture_JournalContext _context;

        public DeleteModel(My_Scripture_Journal.Data.My_Scripture_JournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScriptureModel ScriptureModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScriptureModel = await _context.ScriptureModel.FirstOrDefaultAsync(m => m.ID == id);

            if (ScriptureModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScriptureModel = await _context.ScriptureModel.FindAsync(id);

            if (ScriptureModel != null)
            {
                _context.ScriptureModel.Remove(ScriptureModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
