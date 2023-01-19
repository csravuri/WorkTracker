using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkTracker.Models
{
    public class WorkItem
    {
        [Key]
        public Guid WI_ID { get; set; }
        [DisplayName("WI Number")]
        public string Number { get; set; }
        public string? Description { get; set; }
        public string? WebURL { get; set; }
        public string? SystemName { get; set; }
        public string? LocalPath { get; set; }
        public DateTime InvestigationStartDateUtc { get; set; }
        public DateTime? LastWorkedDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public string? Remarks { get; set; }
        public string Status { get; set; }
    }
}
