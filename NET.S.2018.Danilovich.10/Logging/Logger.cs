using NLog;

namespace Logging
{
    public class NLogger
    {
        private readonly Logger logger;

        public NLogger()
        {
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public void WriteInfo(string info)
        {
            logger.Info(info);
        }

        public void WriteError(string stackTrace)
        {
            logger.Error(stackTrace);
        }

        public void WriteDebug(string stackTrace)
        {
            logger.Debug(stackTrace);
        }

        public void WriteWarn(string stackTrace)
        {
            logger.Warn(stackTrace);
        }

        public void WriteFatal(string stackTrace)
        {
            logger.Fatal(stackTrace);
        }
    }
}
