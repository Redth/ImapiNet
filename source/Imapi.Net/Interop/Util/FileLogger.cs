#region Using Directives

using System;
using System.Diagnostics;
using System.IO;
using System.Text;

#endregion Using Directives

////////////////////////////////////////////////////////////////////////////////
//   Coder:         Ian Davis
//   FileName:      FileLogger.cs
//   Namespace:     Imapi.Net.Util
//   Superclass:    
//   Last Modified: 04/23/2006
//   Description:   
//   TODO:          
////////////////////////////////////////////////////////////////////////////////

namespace Imapi.Net.Interop.Util
{
    internal class FileLogger : ILogger
    {
        private string _fileLocation;
        private string _fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        public FileLogger()
        {
            FileName = "Imapi.Net.log";
            FileLocation = Environment.CurrentDirectory;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public FileLogger( string fileName )
        {
            FileName = fileName;
            FileLocation = Environment.CurrentDirectory;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileLocation">The file location.</param>
        public FileLogger( string fileName, string fileLocation )
        {
            FileName = fileName;
            FileLocation = fileLocation;
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string FileLocation
        {
            get { return _fileLocation; }
            set
            {
                _fileLocation = value;
                if ( _fileLocation.LastIndexOf( "\\" ) != ( _fileLocation.Length - 1 ) )
                {
                    _fileLocation += "\\";
                }
            }
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
            FileStream fileStream = null;
            StreamWriter writer = null;
            var entry = new StringBuilder();

            try
            {
                fileStream = new FileStream( _fileLocation + _fileName, FileMode.OpenOrCreate, FileAccess.Write );
                writer = new StreamWriter( fileStream );

                // Set the file pointer to the end of the file
                writer.BaseStream.Seek( 0, SeekOrigin.End );

                // Create the message
                entry.Append( "<Event>" + Environment.NewLine );

                entry.Append( "\t<Type>" );
                entry.Append( type.ToString() );
                entry.Append( "</Type>" + Environment.NewLine );

                entry.Append( "\t<Time>" );
                entry.Append( DateTime.Now.ToString() );
                entry.Append( "</Time>" + Environment.NewLine );

                entry.Append( "\t<Message>" );
                entry.Append( message );
                entry.Append( "</Message>" + Environment.NewLine );

                entry.Append( "</Event>" + Environment.NewLine );

                // Force the write to the underlying file
                writer.WriteLine( entry.ToString() );
                writer.Flush();
            }
            finally
            {
                if ( writer != null )
                {
                    writer.Close();
                }
            }
        }

        #endregion
    }
}