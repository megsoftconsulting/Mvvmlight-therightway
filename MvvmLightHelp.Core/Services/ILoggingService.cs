using System;

namespace MvvmLightHelp.Core
{
    public interface ILoggingService
    {
        void LogInfo(string msg);

        void LogError(string msg);

        void LogError(string msg, Exception e);
    }
}

