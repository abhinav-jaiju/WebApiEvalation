using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentBook.Models;
using RentBook.ViewModel;

namespace RentBook.Repository
{
    public interface IBookTableRepository
    {
        Task<List<BookTable>> GetAllBook(); //ASynchronous

        //Add an Book ----INSERT ----CREATE
        Task<int> AddBook(BookTable bookTable);

        //update an Book----UPDATE ---UPDATE
        Task UpdateBook(BookTable bookTable);

        //Find Book
        Task<ActionResult<BookTable>> GetBookId(int id);

        //Delete an Book
        Task<int> DeleteBook(int? id);

        Task<IList<BookViewModel>> GetBookDetails();
    }
}

