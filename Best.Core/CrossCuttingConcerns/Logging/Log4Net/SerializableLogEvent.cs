﻿using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }


        public string UserName
        {
            get
            {
                return _loggingEvent.UserName;
            }
        }
        public DateTime DateTime => DateTime.Now;
        public object MessageObject
        {
            get
            {
                return _loggingEvent.MessageObject;
            }
        }

    }
}
