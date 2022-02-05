using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentBook.Models;
using RentBook.ViewModel;

namespace RentBook.Repository
{
    public class BookTableRepository : IBookTableRepository
    {
        //data fields
        private readonly Phase1EvaluationContext _context;

        //Default Constructor
        //Constructor based dependency injection
        public BookTableRepository(Phase1EvaluationContext context)
        {
            _context = context;
        }

        #region Get All Books
        public async Task<List<BookTable>> GetAllBook()
        {
            if (_context != null)
            {
                return await _context.BookTable.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region Add Books
        public async Task<int> AddBook(BookTable bookTable)
        {
            if (_context != null)
            {
                await _context.BookTable.AddAsync(bookTable);
                await _context.SaveChangesAsync();
                return bookTable.BookId;
            }
            return 0;
        }
        #endregion

        #region Update Books
        public async Task UpdateBook(BookTable bookTable)
        {
            if (_context != null)
            {
                _context.Entry(bookTable).State = EntityState.Modified;
                _context.BookTable.Update(bookTable);
                await _context.SaveChangesAsync(); //Commit the transaction

            }
        }
        #endregion

        #region Get Book by Id
        public async Task<ActionResult<BookTable>> GetBookId(int id)
        {
            if (_context != null)
            {
                var employee = await _context.BookTable.FindAsync(id);// concentrating on primary key
                return employee;
            }
            return null;
        }
        #endregion

        #region Delete an Book
        public async Task<int> DeleteBook(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var bookTable = await _context.BookTable.FirstOrDefaultAsync(emp => emp.BookId == id);

                //check condition
                if (bookTable != null)
                {
                    _context.BookTable.Remove(bookTable);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }
        #endregion

        public async Task<IList<BookViewModel>> GetBookDetails()
        {
            if (_context != null)
            {
                //LINQ
                //join post and category
                return await(from p in _context.AuthorTable
                             from c in _context.BookTable
                             from d in _context.Genre
                             from pub in _context.Publication
                             from r in _context.RentTable
                             where p.AuthorId == c.AuthorId
                             where d.GenreId == c.GenreId
                             where pub.PublicationId == c.PublicationId
                             where r.BookId == c.BookId
                             select new BookViewModel
                             {
                                 BookId = c.BookId,
                                 BookName = c.BookName,
                                 AuthorName = p.AuthorName,
                                 GenreName = d.GenreName,
                                 PublicationName = pub.PublicationName,
                                 Price = c.Price,
                                 RentPrice = r.RentPrice
                             }).ToListAsync();
            }
            return null;
        }
    }
}
