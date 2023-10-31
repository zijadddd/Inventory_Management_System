namespace server.Exceptions;

public class SupplierAlreadyExistException : Exception {
    public SupplierAlreadyExistException() : base("Supplier with that name already exist.") { }
}
