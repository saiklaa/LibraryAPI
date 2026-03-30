namespace LibraryApi.Validation;

public static class ValidationConstants
{
    //Errors messages
    public const string RequiredMessage = "{0} is required.";
    public const string MinLengthMessage = "{0} must be at least {1} characters.";
    public const string MaxLengthMessage = "{0} cannot exceed more than {1} characters.";
    public const string RangeMessage = "{0} must be between {1} and {2}.";

    //String length
    public const int TitleMinLength = 2;
    public const int TitleMaxLength = 200;
    public const int AuthorMinLength = 2;
    public const int AuthorMaxLength = 150;
    public const int UserNameMinLength = 2;
    public const int UserNameMaxLength = 100;
    public const int CommentMinLength = 3;
    public const int CommentMaxLength = 1000;


    //Ranges
    public const int YearMin = 1440;
    public const int YearMax = 2100;
    public const int RatingMin = 0;
    public const int RatingMax = 5;

}


