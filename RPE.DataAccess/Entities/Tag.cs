using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPE.DataAccess.Entities
{
    public class Tag
    {
        public Tag(string text, string createdBy, DateTime createdDate)
        {
            Text = text;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
