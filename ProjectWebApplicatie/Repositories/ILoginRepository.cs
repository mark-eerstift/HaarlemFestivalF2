using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWebApplicatie.Models;

namespace ProjectWebApplicatie.Repositories
{
    public interface ILoginRepository
    {
        void AddVrijwilliger(Vrijwilliger vrijwilliger);
        void RemoveVrijwilliger(Vrijwilliger vrijwilliger);
        void Dispose();
        void Entry(Vrijwilliger vrijwilliger);
        void SaveChanges();

        IEnumerable<Vrijwilliger> GetVrijWilligersListDb();
        Vrijwilliger GetVrijwilliger(int? id);
    }
}