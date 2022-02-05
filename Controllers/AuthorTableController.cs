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
    public class AuthorTableController : ControllerBase
    {
        private readonly IAuthorTableRepository _authorTableRepository;

        //constructor injection
        public AuthorTableController(IAuthorTableRepository authorTableRepository)
        {
            _authorTableRepository = authorTableRepository;
        }

        #region Get All Author
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<AuthorTable>>> GetAllAuthor()
        {
            return await _authorTableRepository.GetAllAuthor();
        }
        #endregion

        #region Add an Employee
        [HttpPost("addauthor")]
        [Authorize]
        public async Task<IActionResult> AddEmployee([FromBody] AuthorTable authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var authorId = await _authorTableRepository.AddAuthor(authorTable);
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

        #region Update an Author
        [HttpPut("updateauthor")]
        [Authorize]
        public async Task<IActionResult> UpdateAuthor([FromBody] AuthorTable authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _authorTableRepository.UpdateAuthor(authorTable);
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

        #region Find An Author
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorTable>> GetAuthorId(int id)
        {
            try
            {
                var authorTable = await _authorTableRepository.GetAuthorId(id);
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

        #region Delete An Author : 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _authorTableRepository.DeleteAuthor(id);
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
