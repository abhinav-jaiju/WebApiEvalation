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
    public class RentTableRepository : IRentTableRepository
    {
        private readonly Phase1EvaluationContext _context;

        //Default Constructor
        //Constructor based dependency injection
        public RentTableRepository(Phase1EvaluationContext context)
        {
            _context = context;
        }

        #region Get All Books
        public async Task<List<RentTable>> GetAllRent()
        {
            if (_context != null)
            {
                return await _context.RentTable.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region Add Rent
        public async Task<int> AddRent(RentTable rentTable)
        {
            if (_context != null)
            {
                await _context.RentTable.AddAsync(rentTable);
                await _context.SaveChangesAsync();
                return rentTable.RentId;
            }
            return 0;
        }
        #endregion

        #region Update Rent
        public async Task UpdateRent(RentTable rentTable)
        {
            if (_context != null)
            {
                _context.Entry(rentTable).State = EntityState.Modified;
                _context.RentTable.Update(rentTable);
                await _context.SaveChangesAsync(); //Commit the transaction

            }
        }
        #endregion

        #region Get Rent by Id
        public async Task<ActionResult<RentTable>> GetRentId(int id)
        {
            if (_context != null)
            {
                var rentTable = await _context.RentTable.FindAsync(id);// concentrating on primary key
                return rentTable;
            }
            return null;
        }
        #endregion

        #region Delete an Book
        public async Task<int> DeleteRent(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var rentTable = await _context.RentTable.FirstOrDefaultAsync(emp => emp.RentId == id);

                //check condition
                if (rentTable != null)
                {
                    _context.RentTable.Remove(rentTable);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }
        #endregion

        public async Task<List<MemberWithRent>> GetMemberWithRent()
        {
            //if(_context != null)
            //{
            //    //LinQ
            //    return await (
            //                 from ph in _context.RentTable
            //                 join me in _context.Member
            //                 on ph.MemberId equals me.MemberId
            //                 join bo in _context.BookTable
            //                 on ph.BookId equals bo.BookId

            //                 where DbFunctions.DiffDays(ph.BookTakenDate , ph.BookReturnDate) > 10
            //                 select new MemberWithRent
            //                 {
 
            //                     BookName = bo.BookName,
            //                     MemberName = me.MemberName,
            //                     MemberId = me.MemberId,
            //                     RentPrice = ph.RentPrice
                                 
            //                 }).ToListAsync();
            //}
            return null;
        }
    }
}
