using System;
using System.Collections.Generic;
using System.Text;
using ULaw.ApplicationProcessor.Enums;

namespace Ulaw.ApplicationProcessor
{
    public class DIApplication
    {
        private readonly IApplication _application;
        
        public DIApplication(IApplication application)
        {
            _application = application ?? throw new ArgumentNullException(nameof(application));
        }

    }
}
