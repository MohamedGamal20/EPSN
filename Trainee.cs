//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPSN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Trainee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainee()
        {
            this.Trainee_courses = new HashSet<Trainee_courses>();
        }
    
        public int ID { get; set; }
        [Required]
        [Display(Name ="Full name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string E_mail { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Extra notes")]
        public string Extra_Notes { get; set; }
        public Nullable<int> CouresName_Id { get; set; }
        [Display(Name = "Course name")]
        public virtual Courses_Name Courses_Name { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainee_courses> Trainee_courses { get; set; }
    }
}