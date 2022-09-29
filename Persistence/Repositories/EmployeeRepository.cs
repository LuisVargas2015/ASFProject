using Application.DTOs;
using Application.Interfaces;
using Application.Request;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly IConfiguration _configuration;
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection _dbConnection
        {
            get { return new SqlConnection(_configuration.GetConnectionString("DbConnection")); }
        }

        public async Task<int> DelEmployee(int idEmployee)
        {
            using (var connection = _dbConnection)
            {
                try
                {
                    DynamicParameters parameterIdEmployee = new DynamicParameters();
                    parameterIdEmployee.Add("@ParamIdEmployee", idEmployee);

                    connection.Open();

                    var result = await connection.ExecuteAsync("SpDelEmployee", parameterIdEmployee, commandType: CommandType.StoredProcedure);

                    connection.Close();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

        }

        public async Task<int> InsertEmployee(RequestEmployee employee)
        {
            using (var connection = _dbConnection)
            {
                try
                {
                    DynamicParameters parameterIdEmployee = new DynamicParameters();
                    parameterIdEmployee.Add("@ParamName", employee.Name);
                    parameterIdEmployee.Add("@ParamSurName", employee.SurName);
                    parameterIdEmployee.Add("@ParamDateOfBirth", employee.DateOfBirth);
                    parameterIdEmployee.Add("@ParamDateOfEntry", employee.DateOfEntry);
                    parameterIdEmployee.Add("@ParamAFP", employee.AFP);
                    parameterIdEmployee.Add("@ParamRol", employee.Rol);
                    parameterIdEmployee.Add("@ParamSalary", employee.Salary);

                    connection.Open();

                    var result = await connection.ExecuteScalarAsync<int>("SpInsertEmployee", parameterIdEmployee, commandType: CommandType.StoredProcedure);

                    connection.Close();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        public async Task<List<DtoEmployee>> ListEmployee(RequestEmployeeSearch employee)
        {
            using (var connection = _dbConnection)
            {
                try
                {
                    DynamicParameters parameterIdEmployee = new DynamicParameters();
                    parameterIdEmployee.Add("@ParamName", employee.Name);
                    parameterIdEmployee.Add("@ParamDateEntry", employee.DateEntry);
                    parameterIdEmployee.Add("@ParamMonth", employee.Month);
                    parameterIdEmployee.Add("@ParamYear", employee.Year);
                    parameterIdEmployee.Add("@ParamPageNumber", employee.PageNumber);
                    parameterIdEmployee.Add("@ParamPageSize", employee.PageSize);
                    parameterIdEmployee.Add("@ParamParamSortBy" ,employee.SortBy);
                    parameterIdEmployee.Add("@ParamParamSorting", employee.Sorting);
                    parameterIdEmployee.Add("@ParamPageCount", 0);                   
                    parameterIdEmployee.Add("@ParamQuantityRows", 0);

                    List<DtoEmployee> listEmployee;
                    connection.Open();       

                    var result = await connection.QueryAsync<DtoEmployee>("SpListEmployee", parameterIdEmployee, commandType: CommandType.StoredProcedure);
                    listEmployee = result.ToList();
                    connection.Close();

                    return listEmployee;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        public async Task<int> UpdateEmployee(RequestEmployee employee, int IdEmployee)
        {
            using (var connection = _dbConnection)
            {
                try
                {
                    DynamicParameters parameterIdEmployee = new DynamicParameters();
                    parameterIdEmployee.Add("@ParamIdEmployee", IdEmployee);
                    parameterIdEmployee.Add("@ParamName", employee.Name);
                    parameterIdEmployee.Add("@ParamSurName", employee.SurName);
                    parameterIdEmployee.Add("@ParamDateOfBirth", employee.DateOfBirth);
                    parameterIdEmployee.Add("@ParamDateOfEntry", employee.DateOfEntry);
                    parameterIdEmployee.Add("@ParamAFP", employee.AFP);
                    parameterIdEmployee.Add("@ParamRol", employee.Rol);
                    parameterIdEmployee.Add("@ParamSalary", employee.Salary);

                    connection.Open();

                    var result = await connection.ExecuteScalarAsync<int>("SpUpdateEmployee", parameterIdEmployee, commandType: CommandType.StoredProcedure);

                    connection.Close();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
    }
}
