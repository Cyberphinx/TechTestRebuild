using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories.Models;

namespace API.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();

        Person Get(int id);
        
        Person Update(Person person);
    }
}