using log4net;

namespace Utility
{
    public class Logger
    {
        private static readonly ILog m_logInfo = LogManager.GetLogger("LogInfo");

        private static readonly ILog m_logError = LogManager.GetLogger("LogError");

        public static void WriteInfo(string info)
        {
            if (m_logInfo != null && m_logInfo.IsInfoEnabled)
            {
                m_logInfo.Info(info);
            }
        }

        public static void WriteInfo(string info, System.Exception err)
        {
            if (m_logInfo != null && m_logInfo.IsInfoEnabled)
            {
                m_logInfo.Info(info, err);
            }
        }

        public static void WriteError(string error)
        {
            if (m_logError != null && m_logError.IsErrorEnabled)
            {
                m_logError.Error(error);
            }
        }

        public static void WriteError(string error, System.Exception err)
        {
            if (m_logError != null && m_logError.IsErrorEnabled)
            {
                m_logError.Error(error, err);
            }
        }
    }
}
