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
    
    public partial class BasketList
    {
        public string Id_BasketList { get; set; }
        public int Id_Product { get; set; }
        public int Id_Basket { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Basket Basket { get; set; }
        public virtual Products Products { get; set; }
    }
}
