using DataAccess.Enum;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace DataAccess.Entities
{
    public class StudentContact
    {
        [Key]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string Address { get; set; }
    }
}
