using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentBook.Models;

namespace RentBook.Repository
{
    public interface IAuthorTableRepository
    {
        Task<List<AuthorTable>> GetAllAuthor(); //ASynchronous

        //Add an Author ----INSERT ----CREATE
        Task<int> AddAuthor(AuthorTable authorTable);

        //update an Author ----UPDATE ---UPDATE
        Task UpdateAuthor(AuthorTable authorTable);

        //Find Author
        Task<ActionResult<AuthorTable>> GetAuthorId(int id);

        //Delete an Author
        Task<int> DeleteAuthor(int? id);
    }
}
