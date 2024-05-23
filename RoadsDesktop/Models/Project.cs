//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoadsDesktop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.ProjectHistory = new HashSet<ProjectHistory>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int HeadId { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime FactEnd { get; set; }
        public int Deviation { get; set; }
        public int StatusId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ProjectStatus ProjectStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectHistory> ProjectHistory { get; set; }
    }
}