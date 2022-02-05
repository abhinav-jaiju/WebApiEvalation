using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentBook.Models;

namespace RentBook.Repository
{
    public class AuthorTableRepository : IAuthorTableRepository
    {

        //data fields 
        private readonly Phase1EvaluationContext _context;

        //Default Constructor
        public AuthorTableRepository(Phase1EvaluationContext context)
        {
            _context = context;
        }
        #region Add Author

        public async Task<int> AddAuthor(AuthorTable authorTable)
        {
            if (_context != null)
            {
                await _context.AuthorTable.AddAsync(authorTable);
                await _context.SaveChangesAsync();
                return authorTable.AuthorId;
            }
            return 0;
        }
        #endregion

        #region Delete Author

        public async Task<int> DeleteAuthor(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var authorTable = await _context.AuthorTable.FirstOrDefaultAsync(emp => emp.AuthorId == id);

                //check condition
                if (authorTable != null)
                {
                    _context.AuthorTable.Remove(authorTable);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result; ;
        }
        #endregion

        #region Get Author
        public async Task<List<AuthorTable>> GetAllAuthor()
        {
            if (_context != null)
            {
                return await _context.AuthorTable.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Get Author By ID

        public async Task<ActionResult<AuthorTable>> GetAuthorId(int id)
        {
            if (_context != null)
            {
                var authorTable = await _context.AuthorTable.FindAsync(id);// concentrating on primary key
                return authorTable;
            }
            return null;
        }
        #endregion

        #region Update Author

        public async Task UpdateAuthor(AuthorTable authorTable)
        {
            if (_context != null)
            {
                _context.Entry(authorTable).State = EntityState.Modified;
                _context.AuthorTable.Update(authorTable);
                await _context.SaveChangesAsync(); //Commit the transaction

            }
        }
        #endregion
    }
}
