using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWebApplicatie.Models;

namespace ProjectWebApplicatie.Repositories
{
    public interface IEvenementsRepository
    {
        Evenement GetEvenement(int? evenementId);
        Evenement GetChildByParent(Evenement x);
        void AddEvenement(Evenement evenement);
        void EditEvenement(Evenement evenement);
        void DeleteEvenement(int id);
        void Dispose();


        IEnumerable<Evenement> GetEvenementListDb();
        IEnumerable<Evenement> GetAllDance();
        IEnumerable<Evenement> GetAllJazz();
        IEnumerable<Evenement> GetAllFood();
        IEnumerable<Evenement> GetAllHistory();
    }
}