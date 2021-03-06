﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectWebApplicatie.Models;
using Microsoft.Ajax.Utilities;

namespace ProjectWebApplicatie.Repositories
{
    public class EvenementsRepository : IEvenementsRepository

    {
        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();


        public Evenement GetChildByParent(Evenement x)
        {

            var q = db.Evenements.Where(u => u.EvenementID == x.EvenementID && u.Events.EventSoort == x.Events.EventSoort).FirstOrDefault();
            return q;
        }

        public IEnumerable<Dance> GetDanceObject(Evenement x)
        {
            return db.Dances.Where(u => u.EvenementID == x.EvenementID); 
        }

        public IEnumerable<Jazz> GetJazzObject(Evenement x)
        {

            return db.Jazzs.Where(u => u.EvenementID == x.EvenementID);
        }

        public IEnumerable<History> GetHistoryObject(Evenement x)
        {

            return db.Historys.Where(u => u.EvenementID == x.EvenementID);
        }

        public IEnumerable<Food> GetFoodObject(Evenement x)
        {

            return db.Foods.Where(u => u.EvenementID == x.EvenementID);
        }



        public void AddEvenement(Evenement evenement)
        {
            db.Evenements.Add(evenement);
            db.SaveChanges();
           
        }

        public void DeleteEvenement(int id)
        {
            Evenement evenement = db.Evenements.Find(id);
            db.Evenements.Remove(evenement);
            db.SaveChanges();
        }

        public void EditEvenement(Evenement evenement)
        {
            db.Entry(evenement).State = EntityState.Modified;
            db.SaveChanges();
        }

        // to-do
        public IEnumerable<Evenement> GetEvenementListDb()
        {
            return db.Evenements.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Evenement GetEvenement(int? id)
        {
            return db.Evenements.Find(id);
        }

        public IEnumerable<Evenement> GetAllDance()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evenement> GetAllFood()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evenement> GetAllHistory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evenement> GetAllJazz()
        {
            throw new NotImplementedException();
        }

    }
}