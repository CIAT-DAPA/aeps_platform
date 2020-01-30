using CIAT.DAPA.AEPS.Data.Database;
using CIAT.DAPA.AEPS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.Data.Repositories
{
    public class AEPSFactory
    {   
        private AEPSContext Context { get; set; }

        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context"></param>
        public AEPSFactory(AEPSContext context)
        {
            Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Context"></param>
        /// <returns></returns>
        public IAEPSRepository<T> GetRepository<T>()
        {
            if (typeof(T) == typeof(FrmForms))
                return (IAEPSRepository<T>)new RepositoryFrmForms(Context);
            else if(typeof(T) == typeof(FrmBlocks))
                return (IAEPSRepository<T>)new RepositoryFrmBlocks(Context);
            else if (typeof(T) == typeof(FrmQuestions))
                return (IAEPSRepository<T>)new RepositoryFrmQuestions(Context);
            else if (typeof(T) == typeof(FrmOptions))
                return (IAEPSRepository<T>)new RepositoryFrmOptions(Context);
            else if (typeof(T) == typeof(FrmBlocksForms))
                return (IAEPSRepository<T>)new RepositoryFrmBlocksForms(Context);
            else if (typeof(T) == typeof(FrmQuestionsRules))
                return (IAEPSRepository<T>)new RepositoryFrmQuestionsRules(Context);
            else if (typeof(T) == typeof(FrmFormsSettings))
                return (IAEPSRepository<T>)new RepositoryFrmFormsSettings(Context);
            else if (typeof(T) == typeof(SocAssociations))
                return (IAEPSRepository<T>)new RepositorySocAssociations(Context);
            else if (typeof(T) == typeof(ConCountries))
                return (IAEPSRepository<T>)new RepositoryConCountries(Context);
            else
                return null;
        }
    }
}
