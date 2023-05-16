using DevPace.Core.Entities;
using DevPace.Core.Paging;
using DevPace.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPace.Core.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<IEnumerable<Customer>> GetAsync(PageSearchArgs id);
    }
}
