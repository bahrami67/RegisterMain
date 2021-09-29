using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.DataAccessLayer
{
    public interface IRepositoryHuman
    {
        void Create(Models.Human human);
        List<Models.Human> ReadAll();
        void Update(Models.Human human);
        void Delete(Models.Human human);
        Models.Human GetHumanById(int id);
        List<Models.Human> GetHumanByNC(string nationalCode);

    }
}
