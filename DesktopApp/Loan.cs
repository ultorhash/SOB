//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesktopApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Loan
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public byte PercentValue { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string CustomerID { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}