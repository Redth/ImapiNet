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
using System.Diagnostics;
using System.Runtime.InteropServices;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Exceptions;
using Imapi.Net.Interop.Interfaces;

#endregion Using Directives

namespace Imapi.Net.Interop
{
    /// <summary>
    /// Describes media (if available) in a recorder's drive.
    /// This class is thread-safe.
    /// </summary>
    public class MediaDetails
    {
        #region Private Member Variables

        private readonly MediaFlag _mediaFlags;
        private readonly bool _mediaPresent;
        private readonly MediaType _mediaType;
        private uint _freeBlocks;
        private byte _lastTrack;
        private uint _nextWritable;
        private byte _sessions;
        private uint _startAddress;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Internal constructor; instances of this class should be
        /// obtained from a <see cref="IDiscRecorder"/> object.
        /// </summary>
        /// <param name="recorder">Imapi disc recorder object to
        /// obtain media information for.  This must have been
        /// opened for exclusive access otherwise the information
        /// will not be retreived.</param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DeviceNotAccessibleException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        internal MediaDetails( IDiscRecorder recorder )
        {
            if ( recorder == null )
            {
                throw new ArgumentNullException( "recorder" );
            }

            MediaType mediaType = MediaType.CDRomXA;
            MediaFlag mediaFlags = MediaFlag.Blank;

            OpenRecorder( recorder );

            QueryMediaType( recorder, out mediaType, out mediaFlags );

            CloseRecorder( recorder );

            // Check the status of the media.
            // if both mediaType and MediaFlags
            // are None, then there is no disc inserted.
            // This is defined by the IDiscRecorder interface
            if ( ( mediaType == MediaType.None ) && ( mediaFlags == MediaFlag.None ) )
            {
                Trace.WriteLine( "NO MEDIA" );
            }
            else
            {
                _mediaPresent = true;
                _mediaType = mediaType;
                _mediaFlags = mediaFlags;

                OpenRecorder( recorder );

                QueryMediaInfo( recorder );

                CloseRecorder( recorder );
            }
        }

        #endregion Public Methods and Constructors

        #region Private Methods

        /// <summary>
        /// Opens the recorder.
        /// </summary>
        /// <param name="recorder">The recorder.</param>
        private static void OpenRecorder( IDiscRecorder recorder )
        {
            try
            {
                recorder.OpenExclusive();
            }
            catch ( COMException ex )
            {
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                        throw new RecorderNotInitializedException();
                    case ErrorCodes.IMAPI_E_DEVICE_NOTACCESSIBLE:
                        throw new DeviceNotAccessibleException();
                    case ErrorCodes.IMAPI_E_DEVICE_NOTPRESENT:
                        throw new DeviceNotPresentException();
                    default:
                        throw;
                }
            }
        }

        /// <summary>
        /// Queries the type of the media.
        /// </summary>
        /// <param name="recorder">The recorder.</param>
        /// <param name="mediaType">Type of the media.</param>
        /// <param name="mediaFlags">The media flags.</param>
        private static void QueryMediaType( IDiscRecorder recorder, out MediaType mediaType, out MediaFlag mediaFlags )
        {
            try
            {
                recorder.QueryMediaType( out mediaType, out mediaFlags );
            }
            catch ( COMException ex )
            {
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_DEVICE_NOTPRESENT:
                        throw new DeviceNotPresentException();
                    case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                        throw new RecorderNotInitializedException();
                    default:
                        throw;
                }
            }
        }

        /// <summary>
        /// Closes the recorder.
        /// </summary>
        /// <param name="recorder">The recorder.</param>
        private static void CloseRecorder( IDiscRecorder recorder )
        {
            try
            {
                recorder.Close();
            }
            catch ( COMException ex )
            {
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                        throw new RecorderNotInitializedException();
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_DEVICE_NOTPRESENT:
                        throw new DeviceNotPresentException();
                    default:
                        throw;
                }
            }
        }

        /// <summary>
        /// Queries the media info.
        /// </summary>
        /// <param name="recorder">The recorder.</param>
        private void QueryMediaInfo( IDiscRecorder recorder )
        {
            try
            {
                recorder.QueryMediaInfo( out _sessions, out _lastTrack, out _startAddress, out _nextWritable,
                                         out _freeBlocks );
            }
            catch ( COMException ex )
            {
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_MEDIUM_NOTPRESENT:
                        throw new MediaNotPresentException();
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_DEVICE_NOTPRESENT:
                        throw new DeviceNotPresentException();
                    case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                        throw new RecorderNotInitializedException();
                    default:
                        throw;
                }
            }
        }

        #endregion Private Methods

        #region Public Properties

        /// <summary>
        /// Gets whether there is media present in the drive.
        /// </summary>
        public bool MediaPresent
        {
            get { return _mediaPresent; }
        }

        /// <summary>
        /// Gets the number of sessions on the media.
        /// </summary>
        public byte Sessions
        {
            get { return _sessions; }
        }

        /// <summary>
        /// Gets the number of tracks on the media if it is an audio CD
        /// </summary>
        public byte LastTrack
        {
            get { return _lastTrack; }
        }

        /// <summary>
        /// Gets the start address for the media.
        /// </summary>
        [CLSCompliant( false )]
        public uint StartAddress
        {
            get { return _startAddress; }
        }

        /// <summary>
        /// Gets the next writable address on the media.
        /// </summary>
        [CLSCompliant( false )]
        public uint NextWritable
        {
            get { return _nextWritable; }
        }

        /// <summary>
        /// Gets the number of free blocks on the media.
        /// </summary>
        [CLSCompliant( false )]
        public uint FreeBlocks
        {
            get { return _freeBlocks; }
        }

        /// <summary>
        /// Gets the type of the media.
        /// </summary>
        /// <value>The type of the media.</value>
        public MediaType MediaType
        {
            get { return _mediaType; }
        }

        /// <summary>
        /// Gets information about the media such as whether it is blank,
        /// writable and so on.
        /// </summary>
        public MediaFlag MediaFlags
        {
            get { return _mediaFlags; }
        }

        #endregion Public Properties
    }
}