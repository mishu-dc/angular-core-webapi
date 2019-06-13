using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPE.DataAccess.Entities
{
    public class Travel
    {
        public Travel()
        {
            Notes = new List<Note>();
            Tags = new List<Tag>();
            Attachments = new List<Attachment>();
        }

        public Travel(int priority, string travelername, string city, string state, string country, string can, DateTime startDate, string travelStatus)
            :this()
        {
            Priority = priority;
            Travelername = travelername;
            City = city;
            State = state;
            Country = country;
            Can = can;
            StartDate = startDate;
            TravelStatus = travelStatus;
        }

        [Key]
        public int id { get; set; }
        public int Priority { get; set; }
        [Required]
        [MaxLength(500)]
        public string Travelername { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [Required]
        [MaxLength(100)]
        public string Can { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        [MaxLength(100)]
        public string AuthNumber { get; set; }
        public double AuthAmount { get; set; }
        public double VoucherAmount { get; set; }
        public DateTime VoucherApprovedDate { get; set; }
        [MaxLength(100)]
        public string TravelStatus { get; set; }
        public List<Note> Notes { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
