
using System.ComponentModel.DataAnnotations;

namespace WestCoastEducation2.web.Models
{
    public class Teacher
    {
        [Key]
        public int userId{ get; set; }
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public string phoneNumber { get; set; } = "";
        public string emailAddress { get; set; } = "";
        public string address { get; set; } = "";
        public string coursesTaught { get; set; } = "";
    }
}