//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjTravelDateT1
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductPhotoList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductPhotoList()
        {
            this.TripDetail = new HashSet<TripDetail>();
        }
    
        public int ProductPhotoListID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<bool> OnSlide { get; set; }
    
        public virtual ProductList ProductList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripDetail> TripDetail { get; set; }
    }
}
