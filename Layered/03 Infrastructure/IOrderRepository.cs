using Infrastructure.Models;

namespace Infrastructure
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
