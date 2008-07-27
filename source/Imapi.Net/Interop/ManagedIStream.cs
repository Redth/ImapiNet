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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Imapi.Net.ObjectModel;
using Imapi.Net.Properties;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Exceptions;
using Imapi.Net.Interop.Util;
using STATSTG=System.Runtime.InteropServices.ComTypes.STATSTG;

#endregion Using Directives

namespace Imapi.Net.Interop
{
    /// <summary>
    /// Wrapper around a managed <c>Stream</c> to convert it to an <c>IStream</c>.
    /// </summary>
    [ComVisible( true )]
    internal class ManagedIStream<TStream> : Disposable, IStream where TStream : Stream
    {
        #region Private Member Variables

        private PinnedByteBuffer _buffer;
        private string _streamName;

        #endregion Private Member Variables

        #region Protected Member Variables

        /// <summary>
        /// The underlying stream passed in to the constructor
        /// </summary>
        protected TStream _stream;

        #endregion Protected Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedIStream{TStream}"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="streamName">Name of the stream.</param>
        public ManagedIStream( TStream stream, string streamName )
        {
            if ( stream == null )
            {
                throw new ArgumentNullException( "stream" );
            }

            _stream = stream;
            _streamName = streamName;
        }


        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="ManagedIStream{TStream}"/> is reclaimed by garbage collection.
        /// </summary>
        ~ManagedIStream()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose( false );
        }

        #endregion Public Methods and Constructors

        #region IStream Members

        /// <summary>
        /// Reads a specified number of bytes from the stream object into memory starting at the current seek pointer.
        /// </summary>
        /// <param name="pv">When this method returns, contains the data read from the stream. This parameter is passed uninitialized.</param>
        /// <param name="cb">The number of bytes to read from the stream object.</param>
        /// <param name="pcbRead">A pointer to a ULONG variable that receives the actual number of bytes read from the stream object.</param>
        public virtual void Read( byte[] pv, int cb, IntPtr pcbRead )
        {
            EnsureBuffer( cb );
            try
            {
                pcbRead = (IntPtr) _stream.Read( _buffer.Bytes, 0, cb );
                Array.Copy( _buffer.Bytes, 0, pv, 0, (int) pcbRead );
            }
            catch ( Exception )
            {
                throw new COMException( Resources.Error_Msg_General_E_UNEXPECTED, (int) ErrorCodes.S_FALSE );
            }
        }

        /// <summary>
        /// Writes a specified number of bytes into the stream object starting at the current seek pointer.
        /// </summary>
        /// <param name="pv">The buffer to write this stream to.</param>
        /// <param name="cb">The number of bytes to write to the stream.</param>
        /// <param name="pcbWritten">On successful return, contains the actual number of bytes written to the stream object. If the caller sets this pointer to null, this method does not provide the actual number of bytes written..</param>
        public virtual void Write( byte[] pv, int cb, IntPtr pcbWritten )
        {
            EnsureBuffer( cb );
            try
            {
                Array.Copy( pv, _buffer.Bytes, cb );
                _stream.Write( _buffer.Bytes, 0, cb );
                pcbWritten = (IntPtr) cb;
            }
            catch ( Exception )
            {
                unchecked
                {
                    throw new COMException( Resources.Error_Msg_General_E_UNEXPECTED, (int) ErrorCodes.E_FAIL );
                }
            }
        }

        /// <summary>
        /// Changes the seek pointer to a new location relative to the beginning of the stream, to the end of the stream, or to the current seek pointer.
        /// </summary>
        /// <param name="dlibMove">The displacement to add to dwOrigin.</param>
        /// <param name="dwOrigin">The origin of the seek. The origin can be the beginning of the file, the current seek pointer, or the end of the file.</param>
        /// <param name="plibNewPosition">On successful return, contains the offset of the seek pointer from the beginning of the stream.</param>
        public virtual void Seek( long dlibMove, int dwOrigin, IntPtr plibNewPosition )
        {
            var seekOrigin = SeekOrigin.Current;
            switch ( dwOrigin )
            {
                case (int) StreamSeek.Set:
                    seekOrigin = SeekOrigin.Begin;
                    break;
                case (int) StreamSeek.End:
                    seekOrigin = SeekOrigin.End;
                    break;
            }

            try
            {
                plibNewPosition = (IntPtr) _stream.Seek( dlibMove, seekOrigin );
            }
            catch ( Exception )
            {
                throw new COMException( Resources.Error_Msg_General_E_UNEXPECTED, (int) ErrorCodes.S_FALSE );
            }
        }


        /// <summary>
        /// Changes the size of the stream object.
        /// </summary>
        /// <param name="libNewSize">The new size of the stream as a number of bytes.</param>
        public virtual void SetSize( long libNewSize )
        {
            try
            {
                _stream.SetLength( libNewSize );
                if ( _stream.Length == libNewSize )
                {
                    return;
                }
                unchecked
                {
                    throw new COMException( Resources.Error_Msg_General_E_UNEXPECTED, (int) ErrorCodes.E_FAIL );
                }
            }
            catch ( Exception )
            {
                unchecked
                {
                    throw new COMException( Resources.Error_Msg_General_E_UNEXPECTED, (int) ErrorCodes.E_FAIL );
                }
            }
        }


        /// <summary>
        /// Retrieves the <see cref="System.Runtime.InteropServices.ComTypes.STATSTG"></see> structure for this stream.
        /// </summary>
        /// <param name="pstatstg">When this method returns, contains a STATSTG structure that describes this stream object. This parameter is passed uninitialized.</param>
        /// <param name="grfStatFlag">Members in the STATSTG structure that this method does not return, thus saving some memory allocation operations.</param>
        public virtual void Stat( out STATSTG pstatstg, int grfStatFlag )
        {
            try
            {
                pstatstg = new STATSTG();
                if ( ( grfStatFlag == (int) StatFlag.Default ) || ( grfStatFlag == (int) StatFlag.NoName ) )
                {
                    pstatstg.type = (int) STGTY.Stream;
                    pstatstg.cbSize = _stream.Length;
                    var now = DateTime.Now;
                    pstatstg.mtime = ComUtilities.DateTimeToFiletime( now );
                    pstatstg.ctime = ComUtilities.DateTimeToFiletime( now );
                    pstatstg.atime = ComUtilities.DateTimeToFiletime( now );
                    if ( grfStatFlag != (int) StatFlag.NoName )
                    {
                        pstatstg.pwcsName = _streamName;
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

        #endregion

        #region IStream Unimplemented Methods

        /// <summary>
        /// Copies a specified number of bytes from the current seek pointer in the stream to the current seek pointer in another stream.
        /// </summary>
        /// <param name="pstm">A reference to the destination stream.</param>
        /// <param name="cb">The number of bytes to copy from the source stream.</param>
        /// <param name="pcbRead">On successful return, contains the actual number of bytes read from the source.</param>
        /// <param name="pcbWritten">On successful return, contains the actual number of bytes written to the destination.</param>
        public virtual void CopyTo( IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten )
        {
            pcbRead = (IntPtr) 0;
            pcbWritten = (IntPtr) 0;
            pstm = null;
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// Ensures that any changes made to a stream object that is open in transacted mode are reflected in the parent storage.
        /// </summary>
        /// <param name="grfCommitFlags">A value that controls how the changes for the stream object are committed.</param>
        public virtual void Commit( int grfCommitFlags )
        {
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// Discards all changes that have been made to a transacted stream since the last <see cref="M:System.Runtime.InteropServices.ComTypes.IStream.Commit(System.Int32)"></see> call.
        /// </summary>
        public virtual void Revert()
        {
            throw new MethodNotImplementedException();
        }


        /// <summary>
        /// Restricts access to a specified range of bytes in the stream.
        /// </summary>
        /// <param name="libOffset">The byte offset for the beginning of the range.</param>
        /// <param name="cb">The length of the range, in bytes, to restrict.</param>
        /// <param name="dwLockType">The requested restrictions on accessing the range.</param>
        public virtual void LockRegion( long libOffset, long cb, int dwLockType )
        {
            unchecked
            {
                throw new COMException( Resources.Error_Msg_STG_E_INVALIDFUNCTION,
                                        (int) ErrorCodes.STG_E_INVALIDFUNCTION );
            }
        }


        /// <summary>
        /// Removes the access restriction on a range of bytes previously restricted with the <see cref="M:System.Runtime.InteropServices.ComTypes.IStream.LockRegion(System.Int64,System.Int64,System.Int32)"></see> method.
        /// </summary>
        /// <param name="libOffset">The byte offset for the beginning of the range.</param>
        /// <param name="cb">The length, in bytes, of the range to restrict.</param>
        /// <param name="dwLockType">The access restrictions previously placed on the range.</param>
        public virtual void UnlockRegion( long libOffset, long cb, int dwLockType )
        {
            unchecked
            {
                throw new COMException( Resources.Error_Msg_STG_E_INVALIDFUNCTION,
                                        (int) ErrorCodes.STG_E_INVALIDFUNCTION );
            }
        }


        /// <summary>
        /// Creates a new stream object with its own seek pointer that references the same bytes as the original stream.
        /// </summary>
        /// <param name="ppstm">When this method returns, contains the new stream object. This parameter is passed uninitialized.</param>
        public virtual void Clone( out IStream ppstm )
        {
            ppstm = null;
            throw new MethodNotImplementedException();
        }

        #endregion IStream Unimplemented Methods

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals false, the method has been called by the 
        /// runtime from inside the finalizer and you should not reference 
        /// other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected override void Dispose( bool disposing )
        {
            // Check to see if Dispose has already been called.
            if ( disposing && !IsDisposed )
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                // Dispose managed resources.
                if ( _buffer != null )
                {
                    _buffer.Dispose();
                    _buffer = null;
                }
            }

            base.Dispose( disposing );
        }

        #region Private Methods

        /// <summary>
        /// Ensures the buffer.
        /// </summary>
        /// <param name="size">The size.</param>
        private void EnsureBuffer( int size )
        {
            if ( size <= 0 )
            {
                throw new ArgumentOutOfRangeException( "size", size,
                                                       Resources.Error_Msg_ManagedIStream_BufferBiggerThanZero );
            }

            if ( _buffer == null )
            {
                _buffer = new PinnedByteBuffer( size );
            }
            else
            {
                _buffer.Size = size;
            }
        }

        #endregion Private Methods

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the stream.
        /// </summary>
        /// <value>The name of the stream.</value>
        [SuppressMessage( "Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode" )]
        public string StreamName
        {
            get { return _streamName; }
            set { _streamName = value; }
        }

        #endregion
    }
}