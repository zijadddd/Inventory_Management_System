﻿namespace server.Exceptions;

public class UserNotFoundException : Exception {
    public UserNotFoundException() : base("User not found.") { }
}
