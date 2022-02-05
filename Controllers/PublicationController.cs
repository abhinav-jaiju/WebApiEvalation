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
    public class PublicationController : ControllerBase
    {
        private readonly IPublicationRepository _authorTableRepository;

        //constructor injection
        public PublicationController(IPublicationRepository authorTableRepository)
        {
            _authorTableRepository = authorTableRepository;
        }

        #region Get All Member
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Publication>>> GetAllPublications()
        {
            return await _authorTableRepository.GetAllPublications();
        }
        #endregion

        #region Add an Publication
        [HttpPost("addpublication")]
        [Authorize]
        public async Task<IActionResult> AddPublication([FromBody] Publication authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var authorId = await _authorTableRepository.AddPublication(authorTable);
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

        #region Update an Publication
        [HttpPut("updatepublication")]
        [Authorize]
        public async Task<IActionResult> UpdatePublication([FromBody] Publication authorTable)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _authorTableRepository.UpdatePublication(authorTable);
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

        #region Find An Publication
        [HttpGet("{id}")]
        public async Task<ActionResult<Publication>> GetPublicationId(int id)
        {
            try
            {
                var authorTable = await _authorTableRepository.GetPublicationId(id);
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

        #region Delete An Publication : 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublication(int id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _authorTableRepository.DeletePublication(id);
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
