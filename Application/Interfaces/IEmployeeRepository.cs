using Application.DTOs;
using Application.Request;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<int> DelEmployee(int idEmployee);
        Task<int> InsertEmployee(RequestEmployee employee);
        Task<List<DtoEmployee>> ListEmployee(RequestEmployeeSearch employee);
        Task<int> UpdateEmployee(RequestEmployee employee, int IdEmployee);

    }
}
