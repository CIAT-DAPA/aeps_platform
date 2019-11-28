using CIAT.DAPA.AEPS.Data.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.Data.Database
{    
    public partial class FrmOptions
    {
        public override string ToString()
        {
            return StringOperations.Values(Id) + "|" +
                    StringOperations.Values(Question) + "|" +
                    StringOperations.Values(Name) + "|" +
                    StringOperations.Values(Label) + "|" +
                    StringOperations.Values(Enable) + "|" +
                    StringOperations.Values(ExtId);
        }

    }
}

