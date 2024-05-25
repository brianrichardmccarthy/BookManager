using Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagerApi.Controllers.v1;

[Route("api/v1/[controller]/")]
public class BookListController(IMediator mediator, IValidator<string> isbnValidator) {
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    private readonly IValidator<string> _isbnValidator = isbnValidator ?? throw new ArgumentNullException(nameof(isbnValidator));
    
    [HttpGet("get")]
    [ProducesResponseType<IEnumerable<Book>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IEnumerable<Book> GetAsync(CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }

    [HttpDelete("{isbn}/delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public void DeleteBookAsync([FromRoute] string isbn, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }
    
    [HttpPatch("{isbn}/add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public void AddBookAsync([FromRoute] string isbn, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }

    [HttpGet("recommendations")]
    [ProducesResponseType<IEnumerable<Book>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IEnumerable<Book> GetRecommendedBooksAsync(CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }
}