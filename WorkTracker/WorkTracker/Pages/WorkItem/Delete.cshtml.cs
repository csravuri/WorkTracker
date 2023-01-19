using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WorkTracker.Pages.WorkItem
{
    public class DeleteModel : PageModel
    {
        private readonly WorkTracker.Data.WorkTrackerContext _context;

        public DeleteModel(WorkTracker.Data.WorkTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.WorkItem WorkItem { get; set; }

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
            else
            {
                WorkItem = workitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.WorkItem == null)
            {
                return NotFound();
            }
            var workitem = await _context.WorkItem.FindAsync(id);

            if (workitem != null)
            {
                WorkItem = workitem;
                _context.WorkItem.Remove(WorkItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
