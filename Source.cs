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
    
    public partial class Source
    {
        public int Source_ID { get; set; }
        public string Source_Name { get; set; }
        public string Source_Tag { get; set; }
        public int Article_Id { get; set; }
    
        public virtual Article Article { get; set; }
    }
}
