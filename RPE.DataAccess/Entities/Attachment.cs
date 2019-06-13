using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPE.DataAccess.Entities
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string MimeType { get; set; }
        [MaxLength(500)]
        public string Path { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
