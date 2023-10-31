namespace server.Exceptions;

public class SupplierInvalidDateException : Exception {
    public SupplierInvalidDateException(string typeOfDate) : base($"Invalid date for {typeOfDate}.") { }
}
