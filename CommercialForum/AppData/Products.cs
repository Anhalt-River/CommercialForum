//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommercialForum.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            this.BasketList = new HashSet<BasketList>();
            this.Category_Relationship = new HashSet<Category_Relationship>();
        }
    
        public int Id_Product { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<double> Cost { get; set; }
        public byte[] Image { get; set; }
        public Nullable<int> Id_Trader { get; set; }
        public string DidPut { get; set; }
        public string IsAvailable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasketList> BasketList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category_Relationship> Category_Relationship { get; set; }
    }
}
