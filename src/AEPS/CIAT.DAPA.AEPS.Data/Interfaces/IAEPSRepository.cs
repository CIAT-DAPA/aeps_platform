using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.Data.Interfaces
{
    public interface IAEPSRepository<T>
    {
        Task<T> InsertAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<List<T>> ToListAsync();

        Task<List<T>> ToListEnableAsync();

        Task<T> ByIdAsync(int id);

        T AddAsync(T entity);
    }
}
