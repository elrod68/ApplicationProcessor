using System;
using System.Collections.Generic;
using System.Text;
using ULaw.ApplicationProcessor.Enums;

namespace Ulaw.ApplicationProcessor
{
    //interface to enable Dependency Injection later
    public interface IApplication
    {
        ApplicationResult AppResult();
        Boolean IsValid();
        string Process();
    }
}
