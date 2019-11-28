using CIAT.DAPA.AEPS.Data.Resources;
using CIAT.DAPA.AEPS.Data.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    public partial class FrmBlocks
    {
        public override string ToString()
        {
            return StringOperations.Values(Id) + "|" +
                    StringOperations.Values(Name) + "|" +
                    StringOperations.Values(Title) + "|" +
                    StringOperations.Values(Description) + "|" +
                    StringOperations.Values(Repeat) + "|" +
                    StringOperations.Values(Times) + "|" +
                    StringOperations.Values(Enable) + "|" +
                    StringOperations.Values(ExtId) ;
        }
    }
}
