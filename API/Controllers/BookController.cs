﻿using Application.Commands.BookCommands.CreateBook;
using Application.Commands.BookCommands.DeleteBook;
using Application.Commands.BookCommands.UpdateBook;
using Application.Dtos.BookDtos;
using Application.Queries.BookQueries.GetAllBooks;
using Application.Queries.BookQueries.GetBookByAuthorName;
using Application.Queries.BookQueries.GetBookById;
using Application.Queries.BookQueries.GetBookByTitle;
using Application.Queries.BookQueries.GetBooksByRating;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BookController : Controller
    {
        internal readonly IMediator _mediator;
        internal readonly BookValidator _bookValidator;
        internal readonly ILogger<BookController> _logger;

        public BookController(IMediator mediator, BookValidator bookValidator, ILogger<BookController> logger)
        {
            _mediator = mediator;
            _bookValidator = bookValidator;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllBooksQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetBookById/{bookId}")]
        public async Task<IActionResult> GetBookById(Guid bookId)
        {
            try
            {
                var result = await _mediator.Send(new GetBookByIdQuery(bookId));

                if (result != null)
                    return Ok(result);
                else
                    return NotFound($"Book with id {bookId} not found.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }


        [HttpGet]
        [Route("GetBookByAuthorName/{authorName}")]
        public async Task<IActionResult> GetBookByAuthorName(string authorName)
        {
            try
            {
                var query = new GetBookByAuthorNameQuery { AuthorName = authorName };
                var books = await _mediator.Send(query);

                return Ok(books);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }




        [HttpGet]
        [Route("GetBooksByRating/{minRating}")]
        public async Task<IActionResult> GetBooksByRating(decimal minRating)
        {
            try
            {
                var query = new GetBooksByRatingQuery(minRating);
                var books = await _mediator.Send(query);
                if (books != null)
                    return Ok(books);
                else
                    return NotFound($"No books found with minimal rating of {minRating}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while getting books by rating.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred processing your request.");
            }
        }

        [HttpGet]
        [Route("GetBookByTitle/{titleSubstring}")]
        public async Task<IActionResult> GetBookByTitle(string titleSubstring)
        {
            try
            {
                var query = new GetBookByTitleQuery(titleSubstring);
                var books = await _mediator.Send(query);

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting book by title.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred processing your request.");
            }
        }

        [HttpPost]
        [Route("CreateNewBook")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateNewBook([FromBody] BookDto newBook, int quantity)
        {
            try
            {
                var result = await _mediator.Send(new CreateBookCommand(newBook, quantity));
                if (result != null)
                    return Ok($"Successfully created new book: {newBook.Title}");
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("UpdateBook/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(Guid bookId, [FromBody] BookDto updateBook)
        {
            var validatorResult = _bookValidator.Validate(updateBook);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }
            var command = new UpdateBookByIdCommand(bookId, updateBook);
            try
            {
                var result = await _mediator.Send(command);

                if (result == null)
                    return NotFound($"Book with ID {bookId} not found");
                return Ok($"Successfully updated book's data to {updateBook.Title}");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred processing your request.");
            }
        }

        [HttpDelete]
        [Route("DeleteBook/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            try
            {
                var deleteBookResult = await _mediator.Send(new DeleteBookCommand(bookId));
                if (deleteBookResult != null)
                    return Ok($"{deleteBookResult.Title} was removed from the database.");
                else
                    return NotFound($"Book with id {bookId} was not found in the database.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
