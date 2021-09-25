using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web;
using Microsoft.AspNetCore.Http;
using DepartmentsAPI.Services;
using DepartmentsAPI.Models;
using DepartmentsAPI.Dtos;

namespace DepartmentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        IDepartmentServices _departmentServices;
        public DepartmentController(IDepartmentServices departmentServices)
        {
            this._departmentServices = departmentServices;
        }

        [HttpGet]
        public ActionResult ReadDepartments(){
            return Ok(_departmentServices.ReadDepartments());
        }

        [HttpGet("{id}")]
        public ActionResult ReadDepartmentWithId(int id){
            return Ok(_departmentServices.ReadDepartment(id));
        }

        [HttpPost]
        public ActionResult CreateDepartment(DepartmentReadDto department){
            _departmentServices.CreateDepartment(department);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateDepartment(DepartmentUpdateDto departmentUpdate){
            _departmentServices.UpdateDepartment(departmentUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDepartment(int id){
            _departmentServices.DeleteDepartment(id);
            return Ok();
        }
    }
}