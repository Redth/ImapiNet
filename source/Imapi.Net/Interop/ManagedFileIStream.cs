#region License

//
// Author: Ian Davis <ian.f.davis@gmail.com>
// Copyright (c) 2007-2008, Ian Davis.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

#endregion

#region Using Directives

using System;
using System.IO;
using System.Runtime.InteropServices;
using Imapi.Net.Properties;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Util;
using STATSTG=System.Runtime.InteropServices.ComTypes.STATSTG;

#endregion Using Directives

namespace Imapi.Net.Interop
{
    /// <summary>
    /// Wrapper around a managed FileStream to convert it into an IStream.
    /// </summary>
    [ComVisible( true )]
    internal class ManagedFileIStream : ManagedIStream<FileStream>
    {
        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedFileIStream"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="streamName">Name of the stream.</param>
        public ManagedFileIStream( FileStream stream, string streamName )
            : base( stream, streamName )
        {
        }

        /// <summary>
        /// Retrieves the <see cref="System.Runtime.InteropServices.ComTypes.STATSTG"></see> structure for this stream.
        /// </summary>
        /// <param name="pstatstg">When this method returns, contains a STATSTG structure that describes this stream object. This parameter is passed uninitialized.</param>
        /// <param name="grfStatFlag">Members in the STATSTG structure that this method does not return, thus saving some memory allocation operations.</param>
        public override void Stat( out STATSTG pstatstg, int grfStatFlag )
        {
            try
            {
                pstatstg = new STATSTG();
                if ( ( grfStatFlag == (int) StatFlag.Default ) ||
                     ( grfStatFlag == (int) StatFlag.NoName ) )
                {
                    pstatstg.type = (int) STGTY.Stream;
                    pstatstg.cbSize = _stream.Length;

                    pstatstg.mtime = ComUtilities.DateTimeToFiletime( File.GetLastWriteTime( _stream.Name ) );
                    pstatstg.ctime = ComUtilities.DateTimeToFiletime( File.GetCreationTime( _stream.Name ) );
                    pstatstg.atime = ComUtilities.DateTimeToFiletime( File.GetLastAccessTime( _stream.Name ) );
                    if ( grfStatFlag != (int) StatFlag.NoName )
                    {
                        pstatstg.pwcsName = StreamName;
                    }
                }
            }
            catch ( Exception )
            {
                unchecked
                {
                    throw new COMException( Resources.Error_Msg_General_E_UNEXPECTED, (int) ErrorCodes.E_UNEXPECTED );
                }
            }
        }


        /// <summary>
        /// Returns a <see cref="System.String"></see> that represents the current <see cref="System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"></see> that represents the current <see cref="System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return StreamName;
        }

        #endregion Public Methods and Constructors
    }
}