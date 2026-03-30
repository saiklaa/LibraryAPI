using System.ComponentModel.DataAnnotations;
using LibraryApi.Models;
using LibraryApi.Validation;

namespace LibraryApi.Dtos.Books;

public record CreateBookRequest(
    string Title,
    string Author,
    int YearOfPublication
 );