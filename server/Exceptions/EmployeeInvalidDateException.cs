namespace server.Exceptions;

public class EmployeeInvalidDateException : Exception {
    public EmployeeInvalidDateException(string typeOfDate) : base($"Invalid date for {typeOfDate}.") { }
}
