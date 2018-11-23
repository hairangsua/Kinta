using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTestAuthentication
{
    public interface ISomeService
    {
        SomeThingEntity Insert(SomeThingEntity entity);
        List<SomeThingEntity> GetAll();
    }

    public class SomeService : ISomeService
    {
        private DataContext _context;

        public SomeService(DataContext context)
        {
            _context = context;
        }

        public List<SomeThingEntity> GetAll()
        {
            return _context.SomeThing.ToList();
        }

        public SomeThingEntity Insert(SomeThingEntity entity)
        {
            _context.SomeThing.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
