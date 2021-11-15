using _02_Domain.Models;

namespace _02_Domain
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
