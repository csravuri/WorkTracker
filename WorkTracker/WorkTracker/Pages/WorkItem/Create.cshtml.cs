using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkTracker.Pages.WorkItem
{
    public class CreateModel : PageModel
    {
        private readonly WorkTracker.Data.WorkTrackerContext _context;

        public CreateModel(WorkTracker.Data.WorkTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.WorkItem WorkItem { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WorkItem.Add(WorkItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
