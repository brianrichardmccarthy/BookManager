using Contracts;

namespace Services.Helpers;

public static class AuthorExtensions {
    public static Author ToContract(this Repository.Models.Author model) {
        throw new NotImplementedException();
    }
    
    public static IEnumerable<Author> ToContract(this IEnumerable<Repository.Models.Author> model) {
        throw new NotImplementedException();
    }
    
    public static Repository.Models.Author ToDomain(this Author contract) {
        throw new NotImplementedException();
    }
    
    public static IEnumerable<Repository.Models.Author> ToDomain(this IEnumerable<Author> model) {
        throw new NotImplementedException();
    }
}