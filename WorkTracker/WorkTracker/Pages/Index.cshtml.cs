using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WorkTracker.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly WorkTracker.Data.WorkTrackerContext _context;

        public DashboardModel(WorkTracker.Data.WorkTrackerContext context)
        {
            _context = context;
        }

        public IList<Models.DashboardItem> DashBoardItems { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.WorkItem != null)
            {
                var workItems = await _context.WorkItem.ToListAsync();
                DashBoardItems = workItems.Select(x => new Models.DashboardItem()
                {
                    Description = x.Description,
                    InvestigationStartDateUtc = x.InvestigationStartDateUtc,
                    EndDateUtc = x.EndDateUtc,
                    LastWorkedDateUtc = x.LastWorkedDateUtc,
                    LocalPath = x.LocalPath,
                    Number = x.Number,
                    Remarks = x.Remarks,
                    Status = x.Status,
                    SystemName = x.SystemName,
                    WebURL = x.WebURL
                }).ToList();
            }
        }
    }
}