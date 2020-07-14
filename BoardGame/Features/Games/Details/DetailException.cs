using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Details
{
    public class DetailException: Exception
    {
        public DetailException(string message):base(message)
        {

        }
    }
}
