namespace server.Exceptions;

public class SupplierNotFoundException : Exception
{
    public SupplierNotFoundException() : base ("Supplier not found.") {}
}
