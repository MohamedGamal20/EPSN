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
    
    public partial class Trainee_courses
    {
        public int Trainee_Id { get; set; }
        public int Course_Id { get; set; }
        public System.DateTime Registration_date { get; set; }
    
        public virtual Cours Cours { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
