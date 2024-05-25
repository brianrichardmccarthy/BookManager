using Contracts;
using FluentValidation;

namespace BookManagerApi.Validators;

public class AuthorValidator : AbstractValidator<Author> {
    public AuthorValidator() {
        
    }
}