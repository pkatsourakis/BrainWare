using System;
using System.Collections.Generic;
using System.Text;

namespace BrainWare.Logger
{
    public interface ILog
    {
        void LogException(Exception e);
        void LogWarning(Exception e);
        void LogMessage(string message);
    }
}
