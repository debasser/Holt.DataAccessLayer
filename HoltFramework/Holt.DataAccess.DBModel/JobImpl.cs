//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Holt.DataAccess.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobImpl
    {
        public JobImpl()
        {
            this.Components = new HashSet<ComponentImpl>();
        }
    
        public int JobId { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
    
        public virtual ICollection<ComponentImpl> Components { get; set; }
        public virtual CustomerImpl Customer { get; set; }
    }
}
