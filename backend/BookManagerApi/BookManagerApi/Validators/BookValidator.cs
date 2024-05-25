using Contracts;
using FluentValidation;

namespace BookManagerApi.Validators;

public class BookValidator : AbstractValidator<Book> {
    public BookValidator() {
        
    }
}