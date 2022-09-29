using Application.DTOs;
using Application.Interfaces;
using Application.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASFApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }


        [HttpDelete("deleteemployee")]
        public async Task<int> DelEmployee(int idEmployee)
        {
            return await _EmployeeRepository.DelEmployee(idEmployee);
        }

        [HttpPost("insertemployee")]
        public async Task<int> InsertEmployee(RequestEmployee employee)
        {
            return await _EmployeeRepository.InsertEmployee(employee);
        }

        [HttpPut("updateemployee")]
        public async Task<int> UpdateEmployee(RequestEmployee employee, int idEmployee)
        {
            return await _EmployeeRepository.UpdateEmployee(employee, idEmployee);
        }

        [HttpGet("listemployee")]
        public async Task<List<DtoEmployee>> ListEmployee([FromQuery]RequestEmployeeSearch employee)
        {
            if(employee.PageNumber==0|| employee.PageSize==0)
            {
                employee.PageNumber = 1;
                employee.PageSize = 10;
            }
            return await _EmployeeRepository.ListEmployee(employee);
        }
    }
}
