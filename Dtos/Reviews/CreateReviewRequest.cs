namespace LibraryApi.Dtos.Reviews;

public record CreateReviewRequest(
    string UserName,
    int Rating,
    string Comment
);