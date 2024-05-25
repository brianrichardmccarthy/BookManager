using FluentValidation;

namespace BookManagerApi.Validators;

public class GuidValidator : AbstractValidator<Guid> {
    public GuidValidator() {
        
    }
}