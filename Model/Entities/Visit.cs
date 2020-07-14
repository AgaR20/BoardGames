using BoardGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Visit : Entity
    {
        public DateTime VisitTime { get; set; }
        public VisitSource VisitSource { get; set; }
        public Game VisitedGame { get; set; }
    }
    public enum VisitSource
    {
        Api,
        Web
    }
}
