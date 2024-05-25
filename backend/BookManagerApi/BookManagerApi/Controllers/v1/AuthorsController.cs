using Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagerApi.Controllers.v1;

[Route("api/v1/[controller]/")]
public class AuthorsController(IMediator mediator, IValidator<Author> authorValidator, IValidator<Guid> guidValidator) {
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    private readonly IValidator<Author> _authorvalidator = authorValidator ?? throw new ArgumentNullException(nameof(authorValidator));
    private readonly IValidator<Guid> _guidValidator = guidValidator ?? throw new ArgumentNullException(nameof(guidValidator));

    [HttpPost("create")]
    [ProducesResponseType<Guid>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Guid CreateAsync([FromBody] Author author, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }

    [HttpGet("{authorId}/get")]
    [ProducesResponseType<Author>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Author GetAsync([FromRoute] Guid authorId, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }

    [HttpPost("search")]
    [ProducesResponseType<IEnumerable<Author>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IEnumerable<Author> SearchAsync([FromBody] SearchAuthorRequest search, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }

    [HttpDelete("{authorId}/delete")]
    public void DeleteAsync([FromRoute] Guid authorId, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }
}