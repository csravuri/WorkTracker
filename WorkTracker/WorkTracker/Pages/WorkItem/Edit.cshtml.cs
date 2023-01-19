using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WorkTracker.Pages.WorkItem
{
    public class EditModel : PageModel
    {
        private readonly WorkTracker.Data.WorkTrackerContext _context;

        public EditModel(WorkTracker.Data.WorkTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.WorkItem WorkItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.WorkItem == null)
            {
                return NotFound();
            }

            var workitem = await _context.WorkItem.FirstOrDefaultAsync(m => m.WI_ID == id);
            if (workitem == null)
            {
                return NotFound();
            }
            WorkItem = workitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WorkItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkItemExists(WorkItem.WI_ID))
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

        private bool WorkItemExists(Guid id)
        {
            return _context.WorkItem.Any(e => e.WI_ID == id);
        }
    }
}
