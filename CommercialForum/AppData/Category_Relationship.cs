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
    
    public partial class Category_Relationship
    {
        public int Id_Relationship { get; set; }
        public Nullable<int> Id_Product { get; set; }
        public Nullable<int> Id_Category { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Products Products { get; set; }
    }
}
