//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maxis.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ONNET_SRCH_NE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ONNET_SRCH_NE()
        {
            this.ONNET_SRCH_NE_ABE = new HashSet<ONNET_SRCH_NE_ABE>();
        }
    
        public string NE_ID { get; set; }
        public string NE_NAME { get; set; }
        public string NE_OT_ID { get; set; }
        public string NE_OT_NAME { get; set; }
        public string ROLE { get; set; }
        public string ST__AMOUNT { get; set; }
        public string CARD_DL_ID_LST { get; set; }
        public string MANUFACTURER { get; set; }
        public string STATUS { get; set; }
        public string STATE { get; set; }
        public string LRD { get; set; }
        public string ADDRESS { get; set; }
        public string Site_Long_Name { get; set; }
        public string ENGINEERING_REGION { get; set; }
        public string OPERATION_REGION { get; set; }
        public string GEODATA { get; set; }
        public string F17 { get; set; }
        public string F18 { get; set; }
        public string F19 { get; set; }
        public string F20 { get; set; }
        public string F21 { get; set; }
        public string F22 { get; set; }
        public string F23 { get; set; }
        public string F24 { get; set; }
        public string F25 { get; set; }
        public string F26 { get; set; }
        public string F27 { get; set; }
        public string F28 { get; set; }
        public string F29 { get; set; }
        public string F30 { get; set; }
        public string F31 { get; set; }
        public string F32 { get; set; }
        public string F33 { get; set; }
        public string F34 { get; set; }
        public string F35 { get; set; }
        public string F36 { get; set; }
        public string F37 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ONNET_SRCH_NE_ABE> ONNET_SRCH_NE_ABE { get; set; }
    }
}
