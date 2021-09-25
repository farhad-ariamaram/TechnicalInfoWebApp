using System;
using System.Collections.Generic;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TblReference
    {
        public TblReference()
        {
            TblReferenceTechnicalInfoGroups = new HashSet<TblReferenceTechnicalInfoGroup>();
            TblTechnicalInfoGroups = new HashSet<TblTechnicalInfoGroup>();
        }

        public Guid FldReferenceId { get; set; }
        public string FldReferenceTxt { get; set; }

        public virtual ICollection<TblReferenceTechnicalInfoGroup> TblReferenceTechnicalInfoGroups { get; set; }
        public virtual ICollection<TblTechnicalInfoGroup> TblTechnicalInfoGroups { get; set; }
    }
}
