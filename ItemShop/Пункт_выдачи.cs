//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ItemShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Пункт_выдачи
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Пункт_выдачи()
        {
            this.Заказы = new HashSet<Заказы>();
        }
    
        public long id_Пункта_выдачи { get; set; }
        public string Индекс_пункта_выдачи { get; set; }
        public string Адрес_пункта_выдачи { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заказы> Заказы { get; set; }
    }
}
