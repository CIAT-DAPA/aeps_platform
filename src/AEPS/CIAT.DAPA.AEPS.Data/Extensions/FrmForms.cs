using CIAT.DAPA.AEPS.Data.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.Data.Database
{
    public partial class FrmForms
    {
        public override string ToString()
        {
            return StringOperations.Values(Id) + "|" +
                    StringOperations.Values(Name) + "|" +
                    StringOperations.Values(Title) + "|" +
                    StringOperations.Values(Description) + "|" +
                    StringOperations.Values(Enable) + "|" +
                    StringOperations.Values(ExtId);
        }
    }
}
