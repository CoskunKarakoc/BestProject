using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.Core.CrossCuttingConcerns.Logging.Log4Net.Layout
{
    //Log4Net.Layout içindeki LayoutSkeleton'u using bloğuna ekledim
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            throw new NotImplementedException();
        }
        //LogEvent'ini Json'a çevirip writer'a yazıyoruz.
        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent,Formatting.Indented);//Nugget'ten Newtonsoft.Json'ı kuruyoruz.
            writer.WriteLine(json);
        }
    }
}
