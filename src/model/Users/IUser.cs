using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Users
{
    public interface IUser
    {
        string FirstName { get; }
        string LastName { get; }
    }

    public interface ILoginUser : IUser
    {
        string Username { get; }
        string PasswordHash { get; }
        AuthorizationLevel AuthorizationLevel { get; set; }
    }

    public interface ICustomer : IUser
    {
        string FiscalCode { get; }
        DateTime BirthDate { get; }
    }

    public enum AuthorizationLevel
    {
        CUSTOMER,
        BASIC_STAFF,
        ADVANCED_STAFF
    }
}
