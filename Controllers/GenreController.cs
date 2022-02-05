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
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _authorTableRepository;

        //constructor injection
        public GenreController(IGenreRepository authorTableRepository)
        {
            _authorTableRepository = authorTableRepository;
        }

        #region Get All Books
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Genre>>> GetAllGenre()
        {
            return await _authorTableRepository.GetAllGenre();
        }
        #endregion

        #region Add an Genre
        [HttpPost("addgenre")]
        [Authorize]
        public async Task<IActionResult> AddGenre([FromBody] Genre authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var authorId = await _authorTableRepository.AddGenre(authorTable);
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

        #region Update an Genre
        [HttpPut("updategenre")]
        [Authorize]
        public async Task<IActionResult> UpdateGenre([FromBody] Genre authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _authorTableRepository.UpdateGenre(authorTable);
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
        public async Task<ActionResult<Genre>> GetGenreId(int id)
        {
            try
            {
                var authorTable = await _authorTableRepository.GetGenreId(id);
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

        #region Delete An Book : 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _authorTableRepository.DeleteGenre(id);
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
