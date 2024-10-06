using AutoMapper;
using Employee_Management_System.API.Data;
using Employee_Management_System.API.Models;
using Employee_Management_System.API.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private ResponseDto _response;

        public EmployeeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new ResponseDto();         
        }

        /// <summary>
        /// Returns all the employees
        /// </summary>
        /// <returns>List of Employees</returns>
        [HttpGet]
        public async Task<ResponseDto> GetAllEmployees()
        {
            try
            {
                var employees = await _context.Employees.ToListAsync();
                _response.Result = _mapper.Map<IEnumerable<EmployeeDto>>(employees); ;
                _response.IsSuccess = true;
            }
            catch (Exception ex) 
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="model">Employee Model</param>
        /// <returns>Created Employee</returns>
        [HttpPost]
        public async Task<ResponseDto> AddEmployee([FromBody] Employee employee)
        {
            try
            {
                employee.Id = Guid.NewGuid();
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                _response.Result = employee;
                _response.IsSuccess = true;
                _response.Message = "Employee added successfully..";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        /// <summary>
        /// Return the employee by id
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <returns>Employee</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ResponseDto> GetAllEmployeeById([FromRoute] Guid id)
        {
            try
            {
                var employee = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
                
                if (employee == null)
                {
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.Message = "Employee not found..";
                    return _response;
                }
                _response.Result = _mapper.Map<EmployeeDto>(employee);
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        /// <summary>
        /// Updates an existing employee
        /// </summary>
        /// <param name="id">Id of the employee to update</param>
        /// <param name="model">Employee Model</param>
        /// <returns>Updated Employee</returns>
        [HttpPut]
        //[Route("{id:Guid}")]
        public async Task<ResponseDto> UpdateEmployee([FromBody] Employee employeeRequest)
        {         
            try
            {
                var employee = await _context.Employees.Where(x => x.Id == employeeRequest.Id).FirstOrDefaultAsync();

                if (employee == null)
                {
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.Message = "Employee not found..";
                    return _response;
                }

                employee.Name = employeeRequest.Name;
                employee.Email = employeeRequest.Email;
                employee.Salary = employeeRequest.Salary;
                employee.Phone = employeeRequest.Phone;
                employee.Department = employeeRequest.Department;

                await _context.SaveChangesAsync();

                _response.Result = employee;
                _response.IsSuccess = true;
                _response.Message = "Employee updated successfully..";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        /// <summary>
        /// Deletes the employee
        /// </summary>
        /// <param name="id">Id of the employee to delete</param>
        /// <returns>Deleted Employee</returns>
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ResponseDto> DeleteEmployee([FromRoute] Guid id)
        {
            try
            {
                var employee = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (employee == null)
                {
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.Message = "Employee not found..";
                    return _response;
                }
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                _response.Result = employee;
                _response.IsSuccess = true;
                _response.Message = "Employee deleted successfully..";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

    }
}
