using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentBook.Models;

namespace RentBook.Repository
{
    public interface IGenreRepository
    {
        // All data should be 
        Task<List<Genre>> GetAllGenre(); //ASynchronous

        //Add an Genre ----INSERT ----CREATE
        Task<int> AddGenre(Genre employee);

        //update an Genre ----UPDATE ---UPDATE
        Task UpdateGenre(Genre employee);

        //Find Genre
        Task<ActionResult<Genre>> GetGenreId(int id);

        //Delete an Genre
        Task<int> DeleteGenre(int? id);
    }
}
