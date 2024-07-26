using Application.Dtos;
using Domain.Entities;

namespace Application.Features;

public interface ISaveCustomer
{
    Task<Customer> Save(SaveCustomerRequest request);
}