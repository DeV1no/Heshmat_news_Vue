using System.Threading.Tasks;

namespace HeshmastNews.Contracts
{
    public interface IBaseService
    {
        Task SaveChangesAsync();
        void SaveChanges();
    }
}