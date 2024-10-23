﻿using BookMasterDataManagement.Data;
using BookMasterDataManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace BookMasterDataManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IBReferenceDataContext _context;

        public BookRepository(IBReferenceDataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync() => await _context.Books.Include(b => b.Accounts).ToListAsync();

        public async Task<Book> GetByIdAsync(int id) => await _context.Books.FindAsync(id);

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
