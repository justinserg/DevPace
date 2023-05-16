using DevPace.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPace.Core.Repositories.Base
{
    public interface IRepository<T>: IRepositoryBase<T, int> where T: IEntityBase<int> 
    {
    }
}
