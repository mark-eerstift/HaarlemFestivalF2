using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectWebApplicatie.Models;

namespace ProjectWebApplicatie.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();

        public void AddVrijwilliger(Vrijwilliger vrijwilliger)
        {
            db.Vrijwilligers.Add(vrijwilliger);
        }

        public void RemoveVrijwilliger(Vrijwilliger vrijwilliger)
        {
            db.Vrijwilligers.Remove(vrijwilliger);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Entry(Vrijwilliger vrijwilliger)
        {
            db.Entry(vrijwilliger).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public IEnumerable<Vrijwilliger> GetVrijWilligersListDb()
        {
            return db.Vrijwilligers.ToList();
        }

        public Vrijwilliger GetVrijwilliger(int? id)
        {
            return db.Vrijwilligers.Find(id);
        }

        public Vrijwilliger GetVrijwilligerAccount(string username)
        {

            return db.Vrijwilligers.Where(u => u.Username == username).FirstOrDefault();
        }

        public Vrijwilliger GetVrijwilligerAccountByEmail(string email)
        {

            return db.Vrijwilligers.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}