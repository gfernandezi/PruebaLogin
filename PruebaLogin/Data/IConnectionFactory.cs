using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaLogin.Data
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}