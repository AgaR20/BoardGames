using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Edit
{
    public class EditException:Exception
    {
        public EditException(string message):base(message)
        {
        }
    }
}
