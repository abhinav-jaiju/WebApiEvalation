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
    public class BookTableController : ControllerBase
    {

        private readonly IBookTableRepository _authorTableRepository;

        //constructor injection
        public BookTableController(IBookTableRepository authorTableRepository)
        {
            _authorTableRepository = authorTableRepository;
        }

        #region Get All Books
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<BookTable>>> GetAllBook()
        {
            return await _authorTableRepository.GetAllBook();
        }
        #endregion

        #region Add an Employee
        [HttpPost("addbook")]
        [Authorize]
        public async Task<IActionResult> AddBook([FromBody] BookTable authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var authorId = await _authorTableRepository.AddBook(authorTable);
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

        #region Update an Book
        [HttpPut("updatebook")]
        [Authorize]
        public async Task<IActionResult> UpdateBook([FromBody] BookTable authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _authorTableRepository.UpdateBook(authorTable);
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
        public async Task<ActionResult<BookTable>> GetBookId(int id)
        {
            try
            {
                var authorTable = await _authorTableRepository.GetBookId(id);
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
        public async Task<IActionResult> DeleteBook(int id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _authorTableRepository.DeleteBook(id);
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

        #region Get Book Details
        [HttpGet("bookdetails")]
        public async Task<IActionResult> GetBookDetails()
        {
            try
            {
                var book = await _authorTableRepository.GetBookDetails();
                if(book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
