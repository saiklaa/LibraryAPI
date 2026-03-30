namespace LibraryApi.Dtos.Reviews;

public record ReviewResponse(
    Guid Id,
    string UserName,
    int Rating,
    string Comment
);