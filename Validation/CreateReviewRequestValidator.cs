using FluentValidation;
using System.Data;
using LibraryApi.Dtos;
using LibraryApi.Validation;
using LibraryApi.Dtos.Reviews;

namespace LibraryApi.Validation;

public class CreateReviewRequestValidator : AbstractValidator<CreateReviewRequest>
{
    public CreateReviewRequestValidator()
    {
        RuleFor(CreateReviewRequest => CreateReviewRequest.UserName)
        .NotEmpty().WithMessage(ValidationConstants.RequiredMessage)
        .MinimumLength(ValidationConstants.UserNameMinLength).WithMessage(ValidationConstants.MinLengthMessage)
        .MaximumLength(ValidationConstants.UserNameMaxLegth).WithMessage(ValidationConstants.MaxLengthMessage);

        RuleFor(CreateReviewRequest => CreateReviewRequest.Rating)
        .InclusiveBetween(ValidationConstants.RatingMin, ValidationConstants.RatingMax);

        RuleFor (CreateReviewRequest => CreateReviewRequest.Comment)
        .NotEmpty().WithMessage(ValidationConstants.RequiredMessage)
        .MinimumLength(ValidationConstants.CommentMinLength).WithMessage(ValidationConstants.MinLengthMessage)
        .MaximumLength(ValidationConstants.CommentMaxLength).WithMessage(ValidationConstants.MaxLengthMessage);
    }
}