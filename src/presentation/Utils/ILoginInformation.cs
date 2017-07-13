using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.presentation.Utils
{
    public interface ILoginInformation
    {
        String Username { get; }
        String PasswordHash { get; }
    }
}
