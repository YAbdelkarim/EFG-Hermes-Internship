using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using EmployeesAPI.Dtos;
using EmployeesAPI.Services;

namespace EmployeesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeServices _employeeServices = null;

        public EmployeeController(IEmployeeServices employeeServices){
            this._employeeServices = employeeServices;
        }

        [HttpGet]
        public ActionResult ReadEmployees(){
            return Ok(_employeeServices.ReadEmployees());
        }

        [HttpGet("{id}")]
        public ActionResult ReadEmployeeWithId(int id){
            return Ok(_employeeServices.ReadEmployee(id));
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeReadDto employee){
            _employeeServices.CreateEmployee(employee);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateEmployee(EmployeeUpdateDto employeeUpdate){
            _employeeServices.UpdateEmployee(employeeUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id){
            _employeeServices.DeleteEmployee(id);
            return Ok();
        }
    }
}