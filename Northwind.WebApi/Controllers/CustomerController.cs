using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{
    //[EnableCors("ApiCorsPolicy")]
    [Route("api/Customer")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerLogic _logic;

        public CustomerController(ICustomerLogic logic)
        {
            _logic = logic;
        }



        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_logic.GetById(id));
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_logic.GetList());
        }


        [HttpGet]
        [Route("GetPaginatedCustomer/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedCustomer(int page, int rows)
        {
            // throw new Exception("Northwind Error"); PRUEBA 
            return Ok(_logic.CustomerPageList(page, rows));
        }



        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_logic.Insert(customer));
        }
        [HttpPut]
        public IActionResult Put([FromBody]Customer customer)
        {
            if (ModelState.IsValid && _logic.Update(customer))
            {
                return Ok(new { Message = "The customer is update" });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Customer customer)
        {
            if (customer.Id > 0)
            {
                return Ok(_logic.Delete(customer));
            }
            return BadRequest();

        }
    }
}
