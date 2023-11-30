using art_store.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace art_store.DataAccess.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<int> Delete(int id);
        Task<User> GetById(int id);
        //Task<User> GetByImo(string imo);
        Task<List<User>> GetAll();
        Task<int> Create(User user);
        Task<int> Update(User user);
    }
}
