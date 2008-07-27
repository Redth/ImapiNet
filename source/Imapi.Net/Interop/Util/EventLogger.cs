#region Using Directives

using System;
using System.Diagnostics;
using System.Text;

#endregion Using Directives

////////////////////////////////////////////////////////////////////////////////
//   Coder:         Ian Davis
//   FileName:      EventLogger.cs
//   Namespace:     Imapi.Net.Util
//   Superclass:    
//   Last Modified: 04/23/2006
//   Description:   
//   TODO:          
////////////////////////////////////////////////////////////////////////////////

namespace Imapi.Net.Interop.Util
{
    /// <summary>
    /// 
    /// </summary>
    internal class EventLogger : ILogger
    {
        private string _eventLogName = "";


        private string _eventLogSource;


        private string _machineName = "";

        /// <summary>
        /// Constructor
        /// </summary>
        public EventLogger()
        {
            MachineName = Environment.MachineName;
            EventLogName = "Imapi.Net";
            EventLogSource = "Imapi.Net";
        }

        /// <summary>
        /// Gets or sets the name of the event log.
        /// </summary>
        /// <value>The name of the event log.</value>
        public string EventLogName
        {
            get { return _eventLogName; }
            set { _eventLogName = value; }
        }

        /// <summary>
        /// Gets or sets the event log source.
        /// </summary>
        /// <value>The event log source.</value>
        public string EventLogSource
        {
            get { return _eventLogSource; }
            set { _eventLogSource = value; }
        }

        /// <summary>
        /// Gets or sets the name of the machine.
        /// </summary>
        /// <value>The name of the machine.</value>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        #region ILogger Members

        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="type">The type.</param>
        public void Log( Exception exception, EventLogEntryType type )
        {
            Log( exception.Message + Environment.NewLine + exception.StackTrace, type );
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        public void Log( string message, EventLogEntryType type )
        {
            var entry = new StringBuilder();
            var eventLog = new EventLog();

            if ( !EventLog.SourceExists( _eventLogSource ) )
            {
                EventLog.CreateEventSource( _eventLogSource, _eventLogName );
            }

            eventLog.Source = _eventLogSource;
            eventLog.MachineName = _machineName;

            entry.Append( "Severity:\t" );
            entry.Append( type.ToString() );
            entry.Append( Environment.NewLine );
            entry.Append( "Time:\t" );
            entry.Append( DateTime.Now );
            entry.Append( Environment.NewLine );
            entry.Append( "Information:\t" );
            entry.Append( message );

            eventLog.WriteEntry( entry.ToString(), type );
        }

        #endregion
    }
}