using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentBook.Models;

namespace RentBook.Repository
{
    public interface IPublicationRepository
    {
        Task<List<Publication>> GetAllPublications(); //ASynchronous

        //Add an Publication ----INSERT ----CREATE
        Task<int> AddPublication(Publication publication);

        //update an Publication ----UPDATE ---UPDATE
        Task UpdatePublication(Publication publication);

        //Find Publication
        Task<ActionResult<Publication>> GetPublicationId(int id);

        //Delete an Publication
        Task<int> DeletePublication(int? id);
    }
}
