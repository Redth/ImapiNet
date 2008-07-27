#region License

//
// Author: Ian Davis <ian.f.davis@gmail.com>
// Copyright (c) 2005-2008, Ian Davis.
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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using Imapi.Net.Interop;
using Imapi.Net.ObjectModel;
using Imapi.Net.Properties;
using Imapi.Net.Interop.Exceptions;
using Imapi.Net.Interop.Interfaces;
using Imapi.Net;

#endregion Using Directives

namespace Imapi.Net
{
    /// <summary>
    /// Object for constructing a Redbook (audio) CD image
    /// in the staging area in preparation for a CD burn.
    /// </summary>
    public class RedbookDiscMaster : Disposable
    {
        #region Private Member Variables

        private const int BLOCK_MULTIPLE = 20;
        private readonly DiscMaster _owner;
        private PinnedByteBuffer _buffer;
        private IRedbookDiscMaster _redbookMaster;
        private int _track;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Internal constructor: instances of this object should
        /// be obtained from the <see cref="DiscMaster"/> object.
        /// </summary>
        /// <param name="owner">Disc master object which owns this object.</param>
        /// <param name="redbookMaster">Imapi redbook disc mastering object to wrap.</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal RedbookDiscMaster( DiscMaster owner, IRedbookDiscMaster redbookMaster )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( "owner" );
            } // End if (owner == null)

            if ( redbookMaster == null )
            {
                throw new ArgumentNullException( "redbookMaster" );
            } // End if (redbookMaster == null)

            _owner = owner;

            _redbookMaster = redbookMaster;
            SyncRoot = new object();
        } // End RedbookDiscMaster(DiscMaster owner, IRedbookDiscMaster redbookMaster)


        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Imapi.Net.RedbookDiscMaster"/> is reclaimed by garbage collection.
        /// </summary>
        [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
        ~RedbookDiscMaster()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose( false );
        } // End ~RedbookDiscMaster


        /// <summary>
        /// Creates a new audio track with the specified number of blocks.
        /// Audio CDs may have between 1 and 99 tracks.
        /// </summary>
        /// <param name="blocks">Number of audio blocks for this track.</param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="TrackOpenException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void CreateAudioTrack( int blocks )
        {
            if ( blocks < 1 )
            {
                throw new ArgumentOutOfRangeException( "blocks", blocks,
                                                       Resources.Error_Msg_RedbookDiscMaster_AtLeastOneAudioBlock );
            } // End if (blocks < 1)

            _owner.NotifyTrackProgress( _track, _track + 1 );

            Monitor.Enter( _redbookMaster );
            try
            {
                _redbookMaster.CreateAudioTrack( blocks );
            }
            catch ( COMException ex )
            {
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_TRACKOPEN:
                        throw new TrackOpenException();
                    default:
                        throw;
                }
            }
            finally
            {
                Monitor.Exit( _redbookMaster );
            }

            Monitor.Enter( _buffer );
            if ( _buffer == null )
            {
                _buffer = new PinnedByteBuffer( AudioBlockSize * BLOCK_MULTIPLE );
            } // End if (_buffer == null)
            Monitor.Exit( _buffer );
        } // End void CreateAudioTrack(int blocks)


        /// <summary>
        /// Closes an audio track previously opened with <c>CreateAudioTrack</c>.
        /// Call this method after you have added all of the data to the track.
        /// </summary>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="TrackNotOpenException"></exception>
        /// <exception cref="DiscFullException"></exception>
        public void CloseAudioTrack()
        {
            Monitor.Enter( _redbookMaster );
            try
            {
                _redbookMaster.CloseAudioTrack();
            }
            catch ( COMException ex )
            {
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_TRACKNOTOPEN:
                        throw new TrackNotOpenException();
                    case ErrorCodes.IMAPI_E_DISCFULL:
                        throw new DiscFullException();
                    default:
                        throw;
                }
            }
            finally
            {
                Monitor.Exit( _redbookMaster );
            }

            _track++;
            _owner.NotifyTrackProgress( _track, _track );
        } // End void CloseAudioTrack()


        /// <summary>
        /// Adds raw audio data to the track from a <c>Stream</c>.  Raw
        /// audio data must be presented as stereo, 16 bit signed L-R
        /// pairs of data, with a sampling frequency of 44.1kHz.
        /// The track must have been created using <see cref="CreateAudioTrack"/>.
        /// </summary>
        /// <param name="rawAudioStream">Stream containing raw audio
        /// data.</param>
        /// <param name="bytes">Number of bytes to add from the stream.
        /// This must be a multiple of the <c>AudioBlockSize</c>; if
        /// not this class will add padding 0s to the unused bytes
        /// (for the end of a track). There must be at least 1 byte to add.</param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="TrackNotOpenException"></exception>
        /// <exception cref="DiscFullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [CLSCompliant( false )]
        [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
        public void AddAudioTrackBlocks( Stream rawAudioStream, int bytes )
        {
            if ( rawAudioStream == null )
            {
                throw new ArgumentNullException( "rawAudioStream" );
            } // End if (rawAudioStream == null)

            if ( bytes < 1 )
            {
                throw new ArgumentOutOfRangeException( "bytes", bytes,
                                                       Resources.Error_Msg_RedbookDiscMaster_AddAtLeastOneByte );
            } // End if (bytes < 1)

            Monitor.Enter( _buffer );
            if ( bytes > _buffer.Size )
            {
                _buffer.Size = bytes;
            } // End if (bytes > _buffer.Size)

            // Read bytes in:
            rawAudioStream.Read( _buffer.Bytes, 0, bytes );
            Monitor.Exit( _buffer );

            bytes = ZeroTrailingBufferBytes( bytes );

            // Write the data to the staging area:
            Monitor.Enter( _redbookMaster );
            try
            {
                _redbookMaster.AddAudioTrackBlocks( _buffer.BufferAddress, bytes );
            }
            catch ( COMException ex )
            {
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_TRACKNOTOPEN:
                        throw new TrackNotOpenException();
                    case ErrorCodes.IMAPI_E_DISCFULL:
                        throw new DiscFullException();
                    default:
                        throw;
                }
            }
            finally
            {
                Monitor.Exit( _redbookMaster );
            }
        } // End void AddAudioTrackBlocks(Stream rawAudioStream, uint bytes)


        /// <summary>
        /// Adds a new audio track from a <c>Stream</c>.  Raw
        /// audio data must be presented as stereo, 16 bit signed L-R
        /// pairs of data, with a sampling frequency of 44.1kHz.
        /// </summary>
        /// <param name="rawAudioStream">Stream containing raw audio
        /// data.</param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="TrackNotOpenException"></exception>
        /// <exception cref="DiscFullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
        public void AddAudioTrackFromStream( Stream rawAudioStream )
        {
            if ( rawAudioStream == null )
            {
                throw new ArgumentNullException( "rawAudioStream" );
            } // End if (rawAudioStream == null)

            int cancel = 0;
            int Completed = 0;
            _owner.QueryCancelRequest( out cancel );

            if ( cancel == 0 )
            {
                if ( _buffer == null )
                {
                    _buffer = new PinnedByteBuffer( AudioBlockSize * BLOCK_MULTIPLE );
                } // End if (_buffer == null)

                var blocks = (int) Math.Ceiling( ( (double) rawAudioStream.Length ) / AudioBlockSize );
                CreateAudioTrack( blocks );
                _owner.QueryCancelRequest( out cancel );

                if ( cancel == 0 )
                {
                    var size = 0;
                    while ( ( size = rawAudioStream.Read( _buffer.Bytes, 0, _buffer.Size ) ) > 0 )
                    {
                        size = ZeroTrailingBufferBytes( size );
                        Monitor.Enter( _redbookMaster );
                        try
                        {
                            _redbookMaster.AddAudioTrackBlocks( _buffer.BufferAddress, size );
                        }
                        catch ( COMException ex )
                        {
                            switch ( (uint) ex.ErrorCode )
                            {
                                case ErrorCodes.IMAPI_E_NOTOPENED:
                                    throw new DiscMasterNotOpenedException();
                                case ErrorCodes.IMAPI_E_TRACKNOTOPEN:
                                    throw new TrackNotOpenException();
                                case ErrorCodes.IMAPI_E_DISCFULL:
                                    throw new DiscFullException();
                                default:
                                    throw;
                            }
                        }
                        finally
                        {
                            Monitor.Exit( _redbookMaster );
                        }
                        Completed += size / AudioBlockSize;
                        _owner.QueryCancelRequest( out cancel );
                        if ( cancel != 0 )
                        {
                            break;
                        } // End if (cancel != 0)
                    } // End while ((size = rawAudioStream.Read(_buffer.Bytes, 0, (int)_buffer.Size)) > 0)

                    CloseAudioTrack();
                } // End if (cancel == 0)
            } // End if (cancel == 0)
        } // End void AddAudioTrackFromStream(Stream rawAudioStream)


        /// <summary>
        /// Adds a new audio track from a file. Raw
        /// audio data must be presented as stereo, 16 bit signed L-R
        /// pairs of data, with a sampling frequency of 44.1kHz.
        /// </summary>
        /// <param name="fileName">
        /// PCM file containing raw audio data.
        /// </param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception">when a stream cannot be created from the file.</exception>
        public void AddAudioTrackFromFile( string fileName )
        {
            if ( String.IsNullOrEmpty( fileName ) )
            {
                throw new ArgumentNullException( "fileName" );
            } // End if (String.IsNullOrEmpty(fileName))

            if ( File.Exists( fileName ) )
            {
                try
                {
                    var fileStream = new FileStream( fileName, FileMode.Open, FileAccess.Read, FileShare.Read );
                    AddAudioTrackFromStream( fileStream );
                    fileStream.Dispose();
                } // End try
                catch ( Exception ex )
                {
                    Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                    throw;
                } // End try...catch
            } // End if (File.Exists(fileName))
            else
            {
                throw new FileNotFoundException( Resources.Error_Msg_RedbookDiscMaster_AudioFileNotFound, fileName );
            } // End if...else
        } // End void AddAudioTrackFromFile(string fileName)

        #endregion Public Methods and Constructors

        /// <summary>
        /// Disposes the specified disposing.
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
                // Dispose managed resources.
                Marshal.ReleaseComObject( _redbookMaster );
                _redbookMaster = null;
                if ( _buffer != null )
                {
                    _buffer.Dispose();
                    _buffer = null;
                } // End if
            }
            base.Dispose( disposing );
        }

        #region Private Methods

        /// <summary>
        /// Zeroes the trailing buffer bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private int ZeroTrailingBufferBytes( int bytes )
        {
            if ( bytes < 1 )
            {
                throw new ArgumentOutOfRangeException( "bytes", bytes,
                                                       Resources.Error_Msg_RedbookDiscMaster_AtLeastOneByte );
            } // End if (bytes < 1)

            // If we didn't read an even multiple of block size, then
            // zero out any bytes from the last read byte to the end:
            int blockSize = AudioBlockSize;
            if ( ( bytes % blockSize ) != 0 )
            {
                int end = (int) Math.Ceiling( ( (double) bytes ) / AudioBlockSize ) * AudioBlockSize;
                Monitor.Enter( _buffer );
                for ( int zeroByte = bytes; zeroByte < end; zeroByte++ )
                {
                    _buffer.Bytes[zeroByte] = 0;
                } // End for (int zeroByte = bytes; zeroByte < end; zeroByte++)
                Monitor.Exit( _buffer );
                bytes = end;
            } // End if ((bytes % blockSize) != 0)
            return bytes;
        } // End int ZeroTrailingBufferBytes(int bytes)

        #endregion Private Methods

        #region Public Properties

        /// <summary>
        /// Gets the sync root.
        /// </summary>
        /// <value>The sync root.</value>
        public object SyncRoot { get; private set; }

        /// <summary>
        /// Gets the number of available track blocks remaining on the disc.
        /// </summary>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public int AvailableTrackBlocks
        {
            get
            {
                var blocks = 0;
                Monitor.Enter( _redbookMaster );
                try
                {
                    _redbookMaster.GetAvailableAudioTrackBlocks( out blocks );
                }
                catch ( COMException ex )
                {
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                    {
                        throw new DiscMasterNotOpenedException();
                    }
                    throw;
                }
                finally
                {
                    Monitor.Exit( _redbookMaster );
                }
                return blocks;
            } // End get
        } // End Property AvailableTrackBlocks


        /// <summary>
        /// Gets the size of a single audio block (2352 bytes)
        /// </summary>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public int AudioBlockSize
        {
            get
            {
                var blockSize = 0;
                Monitor.Enter( _redbookMaster );
                try
                {
                    _redbookMaster.GetAudioBlockSize( out blockSize );
                }
                catch ( COMException ex )
                {
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                    {
                        throw new DiscMasterNotOpenedException();
                    }
                    throw;
                }
                finally
                {
                    Monitor.Exit( _redbookMaster );
                }
                return blockSize;
            } // End get
        } // End Property AudioBlockSize


        /// <summary>
        /// Gets the total number of audio blocks on the disc.
        /// </summary>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public int TotalAudioBlocks
        {
            get
            {
                var blocks = 0;
                Monitor.Enter( _redbookMaster );
                try
                {
                    _redbookMaster.GetTotalAudioBlocks( out blocks );
                }
                catch ( COMException ex )
                {
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                    {
                        throw new DiscMasterNotOpenedException();
                    }
                    throw;
                }
                finally
                {
                    Monitor.Exit( _redbookMaster );
                }
                return blocks;
            } // End get
        } // End Property TotalAudioBlocks


        /// <summary>
        /// Gets the used number of audio blocks on the disc.
        /// </summary>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public int UsedAudioBlocks
        {
            get
            {
                var blocks = 0;
                Monitor.Enter( _redbookMaster );
                try
                {
                    _redbookMaster.GetUsedAudioBlocks( out blocks );
                }
                catch ( COMException ex )
                {
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                    {
                        throw new DiscMasterNotOpenedException();
                    }
                    throw;
                }
                finally
                {
                    Monitor.Exit( _redbookMaster );
                }
                return blocks;
            } // End get
        } // End Property UsedAudioBlocks


        /// <summary>
        /// Gets the total number of audio tracks on the disc.
        /// </summary>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public int TotalAudioTracks
        {
            get
            {
                var tracks = 0;
                Monitor.Enter( _redbookMaster );
                try
                {
                    _redbookMaster.GetTotalAudioTracks( out tracks );
                }
                catch ( COMException ex )
                {
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                    {
                        throw new DiscMasterNotOpenedException();
                    }
                    throw;
                }
                finally
                {
                    Monitor.Exit( _redbookMaster );
                }
                return tracks;
            } // End get
        } // End Property TotalAudioTracks

        #endregion Public Properties

        // End void Dispose(bool disposing)
    }
}