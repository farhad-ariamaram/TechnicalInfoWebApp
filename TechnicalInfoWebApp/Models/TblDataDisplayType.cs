using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblDataDisplayType
    {
        public TblDataDisplayType()
        {
            TblTechnicalInfoDataTypes = new HashSet<TblTechnicalInfoDataType>();
        }

        public Guid FldDataDisplayTypeId { get; set; }

        [Required(ErrorMessage ="an")]
        public string FldDataDisplayTypeTxt { get; set; }

        public virtual ICollection<TblTechnicalInfoDataType> TblTechnicalInfoDataTypes { get; set; }
    }
}
