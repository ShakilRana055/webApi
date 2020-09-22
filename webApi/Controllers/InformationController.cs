using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.EntityModel;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private ApplicationContext _work;
        public InformationController(ApplicationContext applicationContext)
        {
            _work = applicationContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Information>>> GetInformation()
        {
            return await _work.Information.ToListAsync();
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Information>> GetInformation(int id)
        {
            var information = await _work.Information.FindAsync(id);
            if (information == null)
                return NotFound();
            
            return information;
        }

        [HttpPost]
        public async Task<ActionResult<Information>> PostInformation(Information information)
        {
            _work.Information.Add(information);
            await _work.SaveChangesAsync();
            return information;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Information>> UpdateInformation(int id, Information information)
        {
            var previousData = _work.Information.FirstOrDefault( item => item.Id == id);
            if(previousData != null)
            {
                previousData.Name = information.Name;
                previousData.Designation = information.Designation;
                _work.Information.Update(previousData);
                await _work.SaveChangesAsync();
                return previousData;
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Information>> DeleteInformation(int id)
        {
            var information = _work.Information.FirstOrDefault(item => item.Id == id);
            if(information != null)
            {
                _work.Information.Remove(information);
                await _work.SaveChangesAsync();
                return information;
            }
            return NotFound();
        }

    }
}