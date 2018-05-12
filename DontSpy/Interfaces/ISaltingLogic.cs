using System;
using System.Collections.Generic;
using System.Text;
using DontSpy.Model;

namespace DontSpy.Interfaces
{
    interface ISaltingLogic
    {
        Message Salting();
        Message Desalinating();
    }
}
