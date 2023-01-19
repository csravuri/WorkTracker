using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WorkTracker.Pages.WorkItem
{
    public class IndexModel : PageModel
    {
        private readonly WorkTracker.Data.WorkTrackerContext _context;

        public IndexModel(WorkTracker.Data.WorkTrackerContext context)
        {
            _context = context;
        }

        public IList<Models.WorkItem> WorkItem { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.WorkItem != null)
            {
                WorkItem = await _context.WorkItem.ToListAsync();
            }
        }
    }
}
