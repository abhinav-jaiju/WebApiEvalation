using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentBook.Models;

namespace RentBook.Repository
{
    public interface IMemberTableRepository
    {
        Task<List<Member>> GetAllMember(); //ASynchronous

        //Add an member ----INSERT ----CREATE
        Task<int> AddMember(Member member);

        //update an member ----UPDATE ---UPDATE
        Task UpdateMember(Member member);

        //Find member
        Task<ActionResult<Member>> GetMemberId(int id);

        //Delete an member
        Task<int> DeleteMember(int? id);
    }
}
