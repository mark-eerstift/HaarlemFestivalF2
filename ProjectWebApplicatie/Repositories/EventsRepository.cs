using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWebApplicatie.Models;
using System.Data.Entity;

namespace ProjectWebApplicatie.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();

        public void AddEvent(Event @event)
        {
            db.Events.Add(@event);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void RemoveEvent(Event @event)
        {
            db.Events.Remove(@event);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Event GetEvent(int? id)
        {
            return db.Events.Find(id);
        }

        public IEnumerable<Event> GetEventListDb()
        {
            return db.Events.ToList();
        }

    }
}