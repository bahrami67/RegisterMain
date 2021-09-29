using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.DataAccessLayer
{
    public class RepositoryHuman : IRepositoryHuman
    {
        private readonly DB _db;
        public RepositoryHuman(DB db)
        {
            _db = db;
        }
        public void Create(Human human)
        {
            _db.Human.Add(human);
            _db.SaveChanges();
        }

        public void Delete(Human human)
        {
            _db.Human.Remove(human);
            _db.SaveChanges();

            //var q = from i in _db.HumanDb where i.Id == human.Id select i;
            //_db.HumanDb.Remove(q.Single());
        }

        public Human GetHumanById(int id)
        {
            return _db.Human.FirstOrDefault(t => t.Id == id);
        }
        public List<Human> GetHumanByNC(string nationalCode)
        {
            return _db.Human.Where(t => t.NationalCode == nationalCode).ToList();
        }
        
        public List<Human> ReadAll()
        {
            return _db.Human.ToList();
        }


        public void Update(Human human)
        {
            _db.Update(human);

            _db.SaveChanges();

            //var q = from i in _db.HumanDb where i.Id == human.Id select i;
            //if (q.Count() == 1)
            //{
            //    ServerHuman newhuman = new ServerHuman();
            //    newhuman = q.Single();
            //    newhuman.Id = human.Id;
            //    newhuman.Name = human.Name;
            //    newhuman.Family = human.Family;
            //    newhuman.Age = human.Age;
            //    newhuman.Gender = human.Gender;
            //    newhuman.NationalCode = human.NationalCode;
            //    newhuman.Phone = human.Phone;
            //    _db.SaveChanges();
            //}
        }
    }
}
