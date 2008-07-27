#region Using Directives

using System;
using System.Diagnostics;

#endregion Using Directives

namespace Imapi.Net.Interop.Util
{
    /// <summary>
    /// 
    /// </summary>
    internal interface ILogger
    {
        void Log( Exception exception, EventLogEntryType type );

        void Log( string message, EventLogEntryType type );
    }
}