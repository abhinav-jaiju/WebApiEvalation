using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentBook.Models;

namespace RentBook.Repository
{
    public class MemberRepository : IMemberTableRepository
    {
        private readonly Phase1EvaluationContext _context;

        //Default Constructor
        //Constructor based dependency injection
        public MemberRepository(Phase1EvaluationContext context)
        {
            _context = context;
        }

        #region Get All Books
        public async Task<List<Member>> GetAllMember()
        {
            if (_context != null)
            {
                return await _context.Member.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region Add Member
        public async Task<int> AddMember(Member member)
        {
            if (_context != null)
            {
                await _context.Member.AddAsync(member);
                await _context.SaveChangesAsync();
                return member.MemberId;
            }
            return 0;
        }
        #endregion

        #region Update member
        public async Task UpdateMember(Member member)
        {
            if (_context != null)
            {
                _context.Entry(member).State = EntityState.Modified;
                _context.Member.Update(member);
                await _context.SaveChangesAsync(); //Commit the transaction

            }
        }
        #endregion

        #region Get member by Id
        public async Task<ActionResult<Member>> GetMemberId(int id)
        {
            if (_context != null)
            {
                var employee = await _context.Member.FindAsync(id);// concentrating on primary key
                return employee;
            }
            return null;
        }
        #endregion

        #region Delete an Member
        public async Task<int> DeleteMember(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var bookTable = await _context.Member.FirstOrDefaultAsync(emp => emp.MemberId == id);

                //check condition
                if (bookTable != null)
                {
                    _context.Member.Remove(bookTable);

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
