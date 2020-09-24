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
    public class AddressController : ControllerBase
    {
        private readonly ApplicationContext _work;
        public AddressController( ApplicationContext applicationContext )
        {
            _work = applicationContext;
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            var result =  await _work.Address
                .Include( x => x.Information)
                .ToListAsync();
            
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _work.Address.FindAsync(id);
            if(address == null)
            {
                return NotFound();
            }
            var result = _work.Address.Include( item => item.Information).FirstOrDefault( x => x.Id == id);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            if( address != null)
            {
                _work.Address.Add(address);
                await _work.SaveChangesAsync();
                return address;
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> UpdateAddress(int id, Address address)
        {
            if (id != address.Id)
                return BadRequest();
            var previousAddress = _work.Address.Find(id);
            if (previousAddress == null)
                return NotFound();

            previousAddress.Village = address.Village;
            previousAddress.PostOffice = address.PostOffice;
            previousAddress.PoliceStation = address.PoliceStation;
            previousAddress.District = address.District;
            previousAddress.InformationId = address.InformationId;
            _work.Address.Update(previousAddress);
            await _work.SaveChangesAsync();
            return previousAddress;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await _work.Address.FindAsync(id);
            if (address == null)
                return NotFound();
            _work.Address.Remove(address);
            await _work.SaveChangesAsync();
            return address;
        }
    }
}
