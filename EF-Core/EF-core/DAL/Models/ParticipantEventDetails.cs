using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("ParticipantEventDetails")]
    public class ParticipantEventDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ParticipantEmailId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        [RegularExpression("Yes|No", ErrorMessage = "IsAttended must be 'Yes' or 'No'.")]
        public string IsAttended { get; set; }
    }
}
