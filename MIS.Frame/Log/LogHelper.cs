using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace MIS.Frame.Log
{
    /// <summary>
    /// log4net 日志帮助类
    /// </summary>
   public class LogHelper
    {

        public static readonly ILog loginfo = LogManager.GetLogger("loginfo");
        public static readonly ILog logerror = LogManager.GetLogger("logerror");

        public LogHelper()
        {

        }

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// 手动设置日志的配置信息
        /// </summary>
        /// <param name="configFile">配置文件</param>
        public static void SetConfig(System.IO.FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }


        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }


        public static void WriteLog(string info, Exception e)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, e);
            }
        }

    }
}
