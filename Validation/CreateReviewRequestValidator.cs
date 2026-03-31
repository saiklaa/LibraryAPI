using FluentValidation;
using LibraryApi.Dtos.Reviews;
using LibraryApi.Validation;

namespace LibraryApi.Validation;

public class CreateReviewRequestValidator : AbstractValidator<CreateReviewRequest>
{
    public CreateReviewRequestValidator()
    {
        RuleFor(x => x.UserName)
        .NotEmpty().WithMessage(ValidationConstants.RequiredMessage)
        .MinimumLength(ValidationConstants.UserNameMinLength).WithMessage(ValidationConstants.MinLengthMessage)
        .MaximumLength(ValidationConstants.UserNameMaxLength).WithMessage(ValidationConstants.MaxLengthMessage);

        RuleFor(x => x.Rating)
        .InclusiveBetween(ValidationConstants.RatingMin, ValidationConstants.RatingMax);

        RuleFor(x => x.Comment)
        .NotEmpty().WithMessage(ValidationConstants.RequiredMessage)
        .MinimumLength(ValidationConstants.CommentMinLength).WithMessage(ValidationConstants.MinLengthMessage)
        .MaximumLength(ValidationConstants.CommentMaxLength).WithMessage(ValidationConstants.MaxLengthMessage);
    }
}