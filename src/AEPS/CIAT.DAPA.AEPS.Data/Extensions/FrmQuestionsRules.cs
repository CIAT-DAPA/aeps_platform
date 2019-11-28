using CIAT.DAPA.AEPS.Data.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.Data.Database
{
    public partial class FrmQuestionsRules
    {
        public override string ToString()
        {
            return StringOperations.Values(Id) + "|" +
                    StringOperations.Values(Question) + "|" +
                    StringOperations.Values(App) + "|" +
                    StringOperations.Values(Type) + "|" +
                    StringOperations.Values(Message) + "|" +
                    StringOperations.Values(Rule);
        }
    }
}
