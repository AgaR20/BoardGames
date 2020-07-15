using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.EditView
{
    public class EditViewException: Exception
    {
        public EditViewException(string message):base(message)
        {

        }
    }
}
