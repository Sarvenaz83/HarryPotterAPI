﻿using Domain.Models;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly HarryPotterContext _context;

        public AuthorRepository(HarryPotterContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(Guid id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task UpdateAuthorByIdAsync(Guid id, Author updatedAuthor)
        {
            _context.Entry(updatedAuthor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Author?> DeleteAuthorByIdAsync(Guid authorId)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.AuthorId == authorId);
            if (author == null)
            {
                return null;
            }

            // Markera författaren som raderad
            author.IsDeleted = true;

            // Gå igenom och markera alla författarens böcker som raderade
            foreach (var book in author.Books)
            {
                book.IsDeleted = true;
            }

            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> GetAuthorByBookAsync(string bookTitle)
        {
            var author = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Books.Any(b => b.Title.Contains(bookTitle)));

            return author;
        }
    }
}
