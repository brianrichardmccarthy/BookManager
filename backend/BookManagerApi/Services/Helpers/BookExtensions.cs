using Contracts;

namespace Services.Helpers;

public static class BookExtensions {
    public static Book ToContract(this Repository.Models.Book model) {
        throw new NotImplementedException();
    }
    
    public static IEnumerable<Book> ToContract(this IEnumerable<Repository.Models.Book> model) {
        throw new NotImplementedException();
    }
    
    public static Repository.Models.Book ToDomain(this Book contract) {
        throw new NotImplementedException();
    }
    
    public static IEnumerable<Repository.Models.Book> ToDomain(this IEnumerable<Book> model) {
        throw new NotImplementedException();
    }
}