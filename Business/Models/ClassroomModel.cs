using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Business.Models
{
    public class ClassroomModel:RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        public string Name { get; set; }
    }
}
