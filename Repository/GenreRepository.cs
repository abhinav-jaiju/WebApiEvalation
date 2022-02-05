using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentBook.Models;

namespace RentBook.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly Phase1EvaluationContext _context;

        //Default Constructor
        //Constructor based dependency injection
        public GenreRepository(Phase1EvaluationContext context)
        {
            _context = context;
        }

        #region Get All Genre
        public async Task<List<Genre>> GetAllGenre()
        {
            if (_context != null)
            {
                return await _context.Genre.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region Add Genre
        public async Task<int> AddGenre(Genre genre)
        {
            if (_context != null)
            {
                await _context.Genre.AddAsync(genre);
                await _context.SaveChangesAsync();
                return genre.GenreId;
            }
            return 0;
        }
        #endregion

        #region Update Genre
        public async Task UpdateGenre(Genre bookTable)
        {
            if (_context != null)
            {
                _context.Entry(bookTable).State = EntityState.Modified;
                _context.Genre.Update(bookTable);
                await _context.SaveChangesAsync(); //Commit the transaction

            }
        }
        #endregion

        #region Get Genre by Id
        public async Task<ActionResult<Genre>> GetGenreId(int id)
        {
            if (_context != null)
            {
                var employee = await _context.Genre.FindAsync(id);// concentrating on primary key
                return employee;
            }
            return null;
        }
        #endregion

        #region Delete an Genre
        public async Task<int> DeleteGenre(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var bookTable = await _context.Genre.FirstOrDefaultAsync(emp => emp.GenreId == id);

                //check condition
                if (bookTable != null)
                {
                    _context.Genre.Remove(bookTable);

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
