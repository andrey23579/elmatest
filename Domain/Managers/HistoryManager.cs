using Domain.Models;

using DomainModel.Repositories;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Managers
{
    public class HistoryManager : IHistoryManager
    {
        

        //    private IHistoryManager Manager { get; set; }


        public void Add(Models.History item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(item);
                    transaction.Commit();
                }
            }
        }



        public IEnumerable<Models.History> List()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(History));
              // criteria.Add(Restrictions.Ge("X", S));
                var docs = session.CreateCriteria(typeof(History)).List<History>();
                return docs;
            }
        }
    }
}