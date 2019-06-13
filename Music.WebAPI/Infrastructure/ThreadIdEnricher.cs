using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Serilog.Core;
using Serilog.Events;

namespace Music.WebAPI.Infrastructure
{
    /// <summary>
    /// Enricher class for serilog.
    /// </summary>
    public class ThreadIdEnricher : ILogEventEnricher
    {
        /// <summary>
        ///  Add threadId to logs
        /// </summary>
        /// <param name="logEvent"></param>
        /// <param name="propertyFactory"></param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                "ThreadId", Thread.CurrentThread.ManagedThreadId));
        }
    }
}
