namespace server.Exceptions;

public class EmployeeAlreadyExistException : Exception
{
    public EmployeeAlreadyExistException() : base ("Employee already exist.") {}
}
