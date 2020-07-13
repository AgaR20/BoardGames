﻿using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//[assembly: JetBrains.Annotations.AspMvcViewLocationFormat(@"~\Features\{1}\{0}.cshtml")]
//[assembly: JetBrains.Annotations.AspMvcViewLocationFormat(@"~\Features\Shared\{0}.cshtml")]

namespace BoardGame.Infrastructure
{

    public class FeatureLocation : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {

            var expandViewLocations = new List<string>
            {
                "/Features/{1}/{0}.cshtml",
                "/Features/Shared/{0}.cshtml",
            };
            
                        return expandViewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
           
        }
    }
}
