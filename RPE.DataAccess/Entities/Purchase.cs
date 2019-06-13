using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPE.DataAccess.Entities
{
    public class Purchase
    {
        public Purchase()
        {
            Notes = new List<Note>();
            Tags = new List<Tag>();
            Attachments = new List<Attachment>();
        }
        public Purchase(int priority, string description, string vendor, string can, string objectClass, double purchaseAmount, DateTime purchaseDate, string status)
            :this()
        {

            Priority = priority;
            Description = description;
            Vendor = vendor;
            Can = can;
            ObjectClass = objectClass;
            PurchaseAmount = purchaseAmount;
            PurchaseDate = purchaseDate;
            Status = status;
        }

        [Key]
        public int id { get; set; }
        public int Priority { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string Vendor { get; set; }
        [Required]
        [MaxLength(255)]
        public string Can { get; set; }
        [MaxLength(255)]
        public string ObjectClass { get; set; }
        [Required]
        public double PurchaseAmount { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [MaxLength(100)]
        public string Status { get; set; }
        public List<Note> Notes { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
