using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarySystemAPI.Modules.Authentication.Domain.Records
{
    public record SignUpBody (string userId, string username, string password, string email);
}