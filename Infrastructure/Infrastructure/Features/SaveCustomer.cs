using Application.Dtos;
using Application.Features;
using Application.Repositories;
using Domain.Entities;

namespace Infrastructure.Features;

public class SaveCustomer : ISaveCustomer
{
    private readonly ICustomerWriteRepository _writeRepository;
    private readonly ICustomerReadRepository _readRepository;

    public SaveCustomer(ICustomerWriteRepository writeRepository,
        ICustomerReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<Customer> Save(SaveCustomerRequest request)
    {
        try
        {
            if (!await _readRepository.CustomerExist(request.id))
            {
                Customer customer = new Customer();
                customer.Name = request.Name;
                customer.Id = request.id;
                await _writeRepository.AddAsync(customer);
                await _writeRepository.SaveAsync();
                return customer;
            }
            return await _readRepository.GetByIdAsync(request.id.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}