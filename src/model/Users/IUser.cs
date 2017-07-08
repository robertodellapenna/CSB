using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Users
{
    public interface IUser
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }

    public interface IStaff : IUser
    {
        int AuthorizationLevel { get; } 
    }

    public interface ILoginUser : IUser
    {
        string Username { get; }
        string Password { get; }
    }

    public interface IClient : IUser
    {
        string FiscalCode { get; }
        DateTime BirthDate { get; }
    }
}
