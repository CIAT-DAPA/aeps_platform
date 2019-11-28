using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.Users.Interfaces
{
    public interface IAEPSUsersRepository<T>
    {
        Task<T> InsertAsync(T entity);

        Task<bool> UpdateAsync(T entity);
        
        Task<List<T>> ToListAsync();

        Task<List<T>> ToListEnableAsync();

        Task<T> ByIdAsync(int id);

        T AddAsync(T entity);
    }
}
