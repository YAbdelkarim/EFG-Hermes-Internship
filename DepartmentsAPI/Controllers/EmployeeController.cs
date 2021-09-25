using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web;
using AutoMapper;
using System.Net.Http;
using System.Net.Http.Headers;
using DepartmentsAPI.Models;
using System.Net.Http.Formatting;

namespace DepartmentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        static HttpClient client = null;

        public EmployeeController(){
            HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = 
                (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
            //client.BaseAddrress = new Uri("https://localhost:5001/api/Employee");
        }

        [HttpGet]
        public async Task<ActionResult> ReadEmployees(){
            List<Employee> _employeeList = null;
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Employee");
            if (response.IsSuccessStatusCode)
            {
                _employeeList = await response.Content.ReadAsAsync<List<Employee>>();
            }
            return Ok(_employeeList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ReadEmployeeWithId(int id){
            Employee employee = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5001/api/Employee/{id}");
            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<Employee>();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employee employee){
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:5001/api/Employee", employee);
            response.EnsureSuccessStatusCode();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(Employee employeeUpdate){
            HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:5001/api/Employee", employeeUpdate);
            response.EnsureSuccessStatusCode();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id){
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:5001/api/Employee/{id}");
            response.EnsureSuccessStatusCode();
            return Ok();
        }
    }
}