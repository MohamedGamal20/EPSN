using System.ComponentModel.DataAnnotations;

namespace EPSN.Models
{
    public class TrainerModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email address is invalid!")]
        public string E_mail { get; set; }
        public string Description { get; set; }
        public System.DateTime Creation_Date { get; set; }
    }
}