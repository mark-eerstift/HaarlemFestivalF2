using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWebApplicatie.Models;

namespace ProjectWebApplicatie.Repositories
{
    public interface ITicketsRepository
    {
        void AddTicket(Ticket ticket);
        void RemoveTicket(Ticket ticket);
        void Dispose();
        void Entry(Ticket ticket);
        void SaveChanges();

        IEnumerable<Ticket> GetTicketsListDb();
        Ticket GetTicket(int? id);
    }
}