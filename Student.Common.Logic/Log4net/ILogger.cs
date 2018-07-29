using System;
namespace Student.Common.Logic.Log4net
{
    public interface ILogger
    {
        #region Metodos
        void Debug(Object message);
        void Error(Object message);
        #endregion
    }
}
