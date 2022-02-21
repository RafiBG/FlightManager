using System;
using FlightManager.Model;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;


namespace FlightManager
{
    internal class ControllerConsumers
    {
        public List<Consumer> GetAllConsumers()
        {
            using (ConsumersEntities1 ex = new ConsumersEntities1())
            {
                return ex.Consumers.ToList();
            }
        }

        public void InsertConsumerss(Consumer consumers)
        {
            using (ConsumersEntities1 ex = new ConsumersEntities1())
            {
                var lastConsumers = ex.Consumers.OrderByDescending(e => e.Id).FirstOrDefault();
                if (lastConsumers == null)
                {
                    consumers.Id = 1;
                }
                else
                {
                    consumers.Id = lastConsumers.Id + 1;
                }
                ex.Consumers.Add(consumers);
                ex.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (ConsumersEntities1 ex = new ConsumersEntities1())
            {
                var consumersDelete = ex.Consumers.Where(u => u.Id == id).FirstOrDefault();
                if (consumersDelete != null)
                {
                    ex.Consumers.Remove(consumersDelete);
                    ex.SaveChanges();
                }
            }
        }
        public void Edit(Consumer consumers)
        {
            using (ConsumersEntities1 ex = new ConsumersEntities1())
            {
                ex.Consumers.AddOrUpdate(consumers);
                ex.SaveChanges();
            }
        }
    }
}

