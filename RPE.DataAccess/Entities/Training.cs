using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPE.DataAccess.Entities
{
    public class Training
    {
        public Training()
        {
            Notes = new List<Note>();
            Tags = new List<Tag>();
            Attachments = new List<Attachment>();
        }

        public Training(int priority, string attendee, string vendor, int hours, string can, DateTime startDate, double trainingAmount, string status)
            :this()
        {
            Priority = priority;
            Attendee = attendee;
            Vendor = vendor;
            Hours = hours;
            Can = can;
            StartDate = startDate;
            TrainingAmount = trainingAmount;
            Status = status;
        }

        [Key]
        public int id { get; set; }
        public int Priority { get; set; }
        [Required]
        [MaxLength(500)]
        public string Attendee { get; set; }
        [MaxLength(255)]
        public string Vendor { get; set; }
        public int Hours { get; set; }
        [Required]
        [MaxLength(255)]
        public string Can { get; set; }
        public DateTime StartDate { get; set; }
        public double TrainingAmount { get; set; }
        public DateTime ApprovedDate { get; set; }
        [MaxLength(100)]
        public string Status { get; set; }
        public List<Note> Notes { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
