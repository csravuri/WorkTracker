using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WorkTracker.Pages.WorkItem
{
    public class DetailsModel : PageModel
    {
        private readonly WorkTracker.Data.WorkTrackerContext _context;

        public DetailsModel(WorkTracker.Data.WorkTrackerContext context)
        {
            _context = context;
        }

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
    }
}
