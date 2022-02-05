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
    public class MemberController : ControllerBase
    {
        private readonly IMemberTableRepository _authorTableRepository;

        //constructor injection
        public MemberController(IMemberTableRepository authorTableRepository)
        {
            _authorTableRepository = authorTableRepository;
        }

        #region Get All Member
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Member>>> GetAllMember()
        {
            return await _authorTableRepository.GetAllMember();
        }
        #endregion

        #region Add an Member
        [HttpPost("addmember")]
        [Authorize]
        public async Task<IActionResult> AddGenre([FromBody] Member authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var authorId = await _authorTableRepository.AddMember(authorTable);
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

        #region Update an Member
        [HttpPut("updatemember")]
        [Authorize]
        public async Task<IActionResult> UpdateMember([FromBody] Member authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _authorTableRepository.UpdateMember(authorTable);
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

        #region Find An Genre
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMemberId(int id)
        {
            try
            {
                var authorTable = await _authorTableRepository.GetMemberId(id);
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

        #region Delete An Member : 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _authorTableRepository.DeleteMember(id);
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
