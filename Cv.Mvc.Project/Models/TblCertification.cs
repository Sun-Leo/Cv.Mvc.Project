//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cv.Mvc.Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TblCertification
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Boş Geçemezsiniz")]
        public string Başlık { get; set; }
        public string Açıklama { get; set; }
    }
}
