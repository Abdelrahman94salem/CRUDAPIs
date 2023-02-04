using DataModel;
using DataModel.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CRUDController : ControllerBase
    {


        private readonly ILogger<CRUDController> _logger;
        private readonly CRUDFile<Driver> action=new CRUDFile<Driver>();
        public CRUDController(ILogger<CRUDController> logger )
        {
            _logger = logger;
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult<bool> Create(Driver driver)
        {
             
            try 
            {
                action.Create(driver);
                return Ok();
            }
            catch (Exception e) 
            {
                return BadRequest(e.ToString());
            }
            
        }

        [Route("ReadAll")]
        [HttpGet]
        public ActionResult<List<Driver>> ReadAll()
        {
            try
            {
                return Ok(action.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [Route("ReadId/{driverIds}")]
        [HttpGet]
        public ActionResult<List<Driver>> Read(int driverIds)
        {
            try
            {
                return Ok(action.ReadById(driverIds));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

      

        [Route("Update")]
        [HttpPut]
        public ActionResult<bool> Update(Driver driver)
        {
            try
            {
                action.Update(driver);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [Route("Delete/{driverId}")]
        [HttpDelete]
        public ActionResult<bool> Delete(int driverId)
        {
            try
            {
                action.Delete(driverId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}