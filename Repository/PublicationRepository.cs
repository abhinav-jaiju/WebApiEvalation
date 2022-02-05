using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentBook.Models;

namespace RentBook.Repository
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly Phase1EvaluationContext _context;

        //Default Constructor
        //Constructor based dependency injection
        public PublicationRepository(Phase1EvaluationContext context)
        {
            _context = context;
        }

        #region Get All Books
        public async Task<List<Publication>> GetAllPublications ()
        {
            if (_context != null)
            {
                return await _context.Publication.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region Add Publication
        public async Task<int> AddPublication(Publication publication)
        {
            if (_context != null)
            {
                await _context.Publication.AddAsync(publication);
                await _context.SaveChangesAsync();
                return publication.PublicationId;
            }
            return 0;
        }
        #endregion

        #region Update Books
        public async Task UpdatePublication(Publication publication)
        {
            if (_context != null)
            {
                _context.Entry(publication).State = EntityState.Modified;
                _context.Publication.Update(publication);
                await _context.SaveChangesAsync(); //Commit the transaction

            }
        }
        #endregion

        #region Get Public 
        public async Task<ActionResult<Publication>> GetPublicationId(int id)
        {
            if (_context != null)
            {
                var employee = await _context.Publication.FindAsync(id);// concentrating on primary key
                return employee;
            }
            return null;
        }
        #endregion

        #region Delete an Publication
        public async Task<int> DeletePublication(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var publication = await _context.Publication.FirstOrDefaultAsync(emp => emp.PublicationId == id);

                //check condition
                if (publication != null)
                {
                    _context.Publication.Remove(publication);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }
        #endregion
    }
}
