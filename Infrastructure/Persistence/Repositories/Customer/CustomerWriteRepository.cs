using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(NotificationServiceDbContext context) : base(context)
    {
    }
}