//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.EHealth
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exercise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercise()
        {
            this.Trainings = new HashSet<Training>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid MuscleGroupId { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Training> Trainings { get; set; }
        public virtual MuscleGroup MuscleGroup { get; set; }
    }
}
