using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWebApplicatie.Models;
using System.Data.Entity;

namespace ProjectWebApplicatie.Repositories
{
    public interface IEventsRepository
    {
        void AddEvent(Event @event);
        void SaveChanges();
        void RemoveEvent(Event @event);
        void Dispose();

        DbEntityEntry Entry();
        Event GetEvent(int? id);
        IEnumerable<Event> GetEventListDb();
    }
}