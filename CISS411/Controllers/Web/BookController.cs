﻿using CISS411.Models.DomainModels;
using CISS411.Models.Miscellaneous;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace CISS411.Controllers.Web
{
    public class BookController : Controller
    {
        private UserManager<Member> _userManager;
        private ApplicationDbContext _context;

        public BookController(UserManager<Member> manager, ApplicationDbContext context)
        {
            _userManager = manager;
            _context = context;
        }


        public async Task<IActionResult> CheckOut(int bookId)
        {
            Book book = GetBookById(bookId);
            DecrementQuantity(book);
            Member user = await GetUser();
            user.CurrentBook = book;
            UpdateDatabase(book, user);
            Emailer.EmailParties(book, user);

            return View(book);
        }


        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(b => b.ID == bookId);
        }
        
        public void DecrementQuantity(Book book)
        {
            book.Quantity--;
        }

        public async Task<Member> GetUser()
        {
            Member member = await _userManager.GetUserAsync(User);
            return member;
        }

        private void UpdateDatabase(Book book, Member user)
        {
            _context.Update(user);
            _context.Update(book);
            _context.SaveChanges();
        }
    }
}
