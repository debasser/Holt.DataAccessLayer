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
    
    public partial class UserImpl
    {
        public UserImpl()
        {
            this.Groups = new HashSet<GroupImpl>();
            this.Notifications = new HashSet<NotificationImpl>();
        }
    
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public int Status { get; set; }
    
        public virtual UserStatusImpl UserStatu { get; set; }
        public virtual ICollection<GroupImpl> Groups { get; set; }
        public virtual ICollection<NotificationImpl> Notifications { get; set; }
    }
}
