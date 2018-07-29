using log4net;
using System;
using System.Reflection;

namespace Student.Common.Logic.Log4net
{
    public class Log4netAdapter :ILogger
    {
        private readonly ILog log;
        public Log4netAdapter()
        {
            this.log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        public void Debug(Object message)
        {
            this.log.Debug(message);
        }
        public void Error(Object message)
        {
            this.log.Error(message);
        }


    }
}
