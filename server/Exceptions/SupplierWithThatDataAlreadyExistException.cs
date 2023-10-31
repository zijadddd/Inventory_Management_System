namespace server.Exceptions;

public class SupplierWithThatDataAlreadyExistException : Exception {
    public SupplierWithThatDataAlreadyExistException(string typeOfData) : base($"Supplier with that {typeOfData} already exist.") { }
}
