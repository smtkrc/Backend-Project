using GeneralClass.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralClass.Utilities.Security.JeasonWebToken
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
