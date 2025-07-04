//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrnekProje.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Operation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public string OperationType { get; set; }
        public Nullable<decimal> CurrentValue { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Currency Currency { get; set; }
    }
}
