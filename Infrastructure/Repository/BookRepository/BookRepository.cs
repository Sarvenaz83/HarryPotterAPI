﻿using Domain.Models;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly HarryPotterContext _context;

        public BookRepository(HarryPotterContext context)
        {
            _context = context;
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<List<Book>> GetBooksByAuthorName(string authorName)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Where(b => b.Author!.AuthorName!.Contains(authorName))
                .ToListAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.Author).Where(b => !b.IsDeleted).ToListAsync();
        }

        public async Task<List<Book>> GetBooksByRatingAsync(decimal minRating)
        {
            return await _context.Books
                .Include(book => book.Author)
                .Where(book => book.Rating >= minRating)
                .OrderBy(book => book.Rating).ToListAsync();
        }

        public async Task<List<Book>> GetBooksByTitleContainsAsync(string titleSubstring)
        {
            var bookList = await _context.Books
                .Include(book => book.Author)
                .Where(book => book.Title.Contains(titleSubstring))
                .OrderByDescending(book => book.Rating)
                .ToListAsync();
            return bookList;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateBookByIdAsync(Book updateBook)
        {
            _context.Books.Update(updateBook);
            await _context.SaveChangesAsync();
            return updateBook;
        }

        public async Task<Book?> DeleteBookAsync(Guid bookId)
        {
            Book? bookToDelete = await _context.Books.FirstOrDefaultAsync(book => book.BookId == bookId);
            if (bookToDelete != null)
            {
                bookToDelete.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            return bookToDelete;
        }
    }
}
