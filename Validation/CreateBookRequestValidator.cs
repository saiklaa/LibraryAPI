using FluentValidation;
using LibraryApi.Dtos.Books;
using LibraryApi.Validation;

namespace LibraryApi.Validation;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Title)
        .NotEmpty().WithMessage(ValidationConstants.RequiredMessage)
        .MinimumLength(ValidationConstants.TitleMinLength).WithMessage(ValidationConstants.MinLengthMessage)
        .MaximumLength(ValidationConstants.TitleMaxLength).WithMessage(ValidationConstants.MaxLengthMessage);

        RuleFor(x => x.Author)
        .NotEmpty().WithMessage(ValidationConstants.RequiredMessage)
        .MinimumLength(ValidationConstants.AuthorMinLength).WithMessage(ValidationConstants.MinLengthMessage)
        .MaximumLength(ValidationConstants.AuthorMaxLength).WithMessage(ValidationConstants.MaxLengthMessage);

        RuleFor(x => x.YearOfPublication)
        .InclusiveBetween(ValidationConstants.YearMin, ValidationConstants.YearMax)
        .LessThanOrEqualTo(DateTime.UtcNow.Year);
    }
}