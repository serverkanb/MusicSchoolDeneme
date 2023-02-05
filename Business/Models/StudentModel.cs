using AppCore.Records.Bases;
using DataAccess.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Business.Models
{
    #region Entityden gelen özellikler
    public class StudentModel:RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50)]
        [DisplayName("Student Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50)]
        [DisplayName("Student Surname")]
        public string Surname { get; set; }

        public DateTime? Birthday { get; set; }

        [DisplayName("Gender")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage ="{0} is required!")]
        [StringLength(50)]
        [DisplayName("Parent Name")]

        public string ParentName { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50)]
        [DisplayName("Parent Surname")]
        public string ParentSurname { get; set; }

        public int TakenLessonCount { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Registration Date")]
        public DateTime RegistrationDate { get; set; }

        #endregion
        #region Entity dışı özellikler

        public List<int> LessonIds { get; set; }

        public List<int> ClassroomIds { get; set; }

        public List<int>  TeacherIds { get; set; }
        public StudentContactModel StudentContact { get; set; }

        #endregion

    }
}
