using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Details
{
    public class VisitViewModel
    {
        public VisitViewModel(Visit visit)
        {
            Date = visit.VisitTime.ToString("dd.MM.yyyy");
            Time = visit.VisitTime.ToString("hh:mm");
            Source = visit.VisitSource.ToString();
        }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Source { get; set; }

    }
}
