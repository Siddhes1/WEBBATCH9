using System.ComponentModel.DataAnnotations;

namespace ConsumingAPIWithKey.Models
{
    public class RegisterModel
    {
        [Key]
        public int RollNo { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Cours { get; set; }
        public decimal marks { get; set; }
        public DateTime dob { get; set; }
        public string addr { get; set; }
    }
}
