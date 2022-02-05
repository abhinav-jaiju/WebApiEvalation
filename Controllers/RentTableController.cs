using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentBook.Models;
using RentBook.Repository;

namespace RentBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentTableController : ControllerBase
    {
        private readonly IRentTableRepository _authorTableRepository;

        //constructor injection
        public RentTableController(IRentTableRepository authorTableRepository)
        {
            _authorTableRepository = authorTableRepository;
        }

        #region Get All Rent
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<RentTable>>> GetAllRent()
        {
            return await _authorTableRepository.GetAllRent();
        }
        #endregion

        #region Add an Rent
        [HttpPost("addrent")]
        [Authorize]
        public async Task<IActionResult> AddRent([FromBody] RentTable authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var authorId = await _authorTableRepository.AddRent(authorTable);
                    if (authorId > 0)
                    {
                        return Ok(authorId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update an Rent
        [HttpPut("updaterent")]
        [Authorize]
        public async Task<IActionResult> UpdateRent([FromBody] RentTable authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _authorTableRepository.UpdateRent(authorTable);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Find An Rent
        [HttpGet("{id}")]
        public async Task<ActionResult<RentTable>> GetRentId(int id)
        {
            try
            {
                var authorTable = await _authorTableRepository.GetRentId(id);
                if (authorTable == null)
                {
                    return NotFound();
                }
                return authorTable;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Delete  a Rent : 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(int id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _authorTableRepository.DeleteRent(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
