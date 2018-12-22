using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWebApplicatie.Models;
using System.Data.Entity;

namespace ProjectWebApplicatie.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();

        public void AddTicket(Ticket ticket)
        {
            db.Tickets.Add(ticket);
        }

        public void RemoveTicket(Ticket ticket)
        {
            db.Tickets.Remove(ticket);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Entry(Ticket ticket)
        {
            db.Entry(ticket).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public IEnumerable<Ticket> GetTicketsListDb()
        {
            return db.Tickets.ToList();
        }

        public Ticket GetTicket(int? id)
        {
            return db.Tickets.Find(id);
        }
    }
}