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
    public class EditModel : PageModel
    {
        private readonly My_Scripture_Journal.Data.My_Scripture_JournalContext _context;

        public EditModel(My_Scripture_Journal.Data.My_Scripture_JournalContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ScriptureModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptureModelExists(ScriptureModel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScriptureModelExists(int id)
        {
            return _context.ScriptureModel.Any(e => e.ID == id);
        }
    }
}
