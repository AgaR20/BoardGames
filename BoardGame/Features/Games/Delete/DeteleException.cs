using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Delete
{
    public class DeteleException : Exception
    {
        public DeteleException(string message) : base(message)
        {
        }
    }
}
