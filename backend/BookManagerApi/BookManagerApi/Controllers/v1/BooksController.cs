using Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagerApi.Controllers.v1;

[Route("api/v1/[controller]/")]
public class BooksController(IMediator mediator, IValidator<Book> bookValidator, IValidator<string> isbnValidator) {
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    private readonly IValidator<Book> _bookValidator = bookValidator ?? throw new ArgumentNullException(nameof(bookValidator));
    private readonly IValidator<string> _isbnValidator = isbnValidator ?? throw new ArgumentNullException(nameof(isbnValidator));

    [HttpGet("{isbn}/get")]
    [ProducesResponseType<Book>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Book GetByIsbnAsync(string isbn, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }

    [HttpPatch("{isbn}/upsert")]
    [ProducesResponseType<string>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public string UpsertAsync([FromBody] Book book, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }

    [HttpDelete("{isbn}/delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public void DeleteAsync(string isbn, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }

    [HttpPost("search")]
    [ProducesResponseType<Book>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Book SearchAsync([FromBody] SearchBookRequest filter, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }
}