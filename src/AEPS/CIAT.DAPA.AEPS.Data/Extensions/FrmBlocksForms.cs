using CIAT.DAPA.AEPS.Data.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.Data.Database
{
    public partial class FrmBlocksForms
    {
        public override string ToString()
        {
            return StringOperations.Values(Form) + "|" +
                    StringOperations.Values(Block) + "|" +
                    StringOperations.Values(Order) + "|" +
                    StringOperations.Values(Enable) ;
        }
    }
}
