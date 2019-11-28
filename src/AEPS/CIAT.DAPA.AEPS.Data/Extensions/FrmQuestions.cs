using CIAT.DAPA.AEPS.Data.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.Data.Database
{
    public partial class FrmQuestions
    {
        public override string ToString()
        {
            return StringOperations.Values(Id) + "|" +
                    StringOperations.Values(Block) + "|" +
                    StringOperations.Values(Name) + "|" +
                    StringOperations.Values(Label) + "|" +
                    StringOperations.Values(Description) + "|" +
                    StringOperations.Values(Type) + "|" +
                    StringOperations.Values(Order) + "|" +
                    StringOperations.Values(Enable) + "|" +
                    StringOperations.Values(ExtId);
        }
    }
}
