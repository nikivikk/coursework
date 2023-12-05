using art_store.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace art_store.DataAccess.Repository.Contracts
{
    public interface IOrderRepository
    {
        Task<int> Delete(int id);
        Task<Order> GetById(int id);
        //Task<Order> GetByImo(string imo);
        Task<List<Order>> GetAll();
        Task<int> Create(Order order);
        Task<int> Update(Order order);
    }
}
