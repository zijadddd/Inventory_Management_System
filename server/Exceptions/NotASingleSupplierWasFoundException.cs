namespace server.Exceptions;

public class NotASingleSupplierWasFoundException : Exception {
    public NotASingleSupplierWasFoundException() : base("Not a single supplier was found.") { }
}
