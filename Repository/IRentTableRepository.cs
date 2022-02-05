using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentBook.Models;
using RentBook.ViewModel;

namespace RentBook.Repository
{
    public interface IRentTableRepository
    {
        Task<List<RentTable>> GetAllRent(); //ASynchronous

        //Add an rentTable ----INSERT ----CREATE
        Task<int> AddRent(RentTable rentTable);

        //update an rentTable----UPDATE ---UPDATE
        Task UpdateRent(RentTable rentTable);

        //Find rentTable
        Task<ActionResult<RentTable>> GetRentId(int id);

        //Delete an rentTable
        Task<int> DeleteRent(int? id);

        Task<List<MemberWithRent>> GetMemberWithRent();
    }
}
