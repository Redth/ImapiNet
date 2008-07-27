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

#endregion Using Directives

namespace Imapi.Net.Interop
{
    /// <summary>
    /// Summary description for ErrorCodes.
    /// </summary>
    public static class ErrorCodes
    {
        #region Standard Errors

        /// <summary>
        /// The operation was aborted because of an unspecified error. 
        /// </summary>
        public const uint E_ABORT = 0x80004004;

        /// <summary>
        /// A general access-denied error. 
        /// </summary>
        public const uint E_ACCESSDENIED = 0x80070005;

        /// <summary>
        /// An unspecified failure has occurred. 
        /// </summary>
        public const uint E_FAIL = 0x80004005;

        /// <summary>
        /// An invalid handle was used. 
        /// </summary>
        public const uint E_HANDLE = 0x80070006;

        /// <summary>
        /// One or more arguments are invalid. 
        /// </summary>
        public const uint E_INVALIDARG = 0x80070057;

        /// <summary>
        /// The QueryInterface method did not recognize the requested interface.
        /// The interface is not supported.
        /// </summary>
        public const uint E_NOINTERFACE = 0x80004002;

        /// <summary>
        /// The method is not implemented. 
        /// </summary>
        public const uint E_NOTIMPL = 0x80004001;

        /// <summary>
        /// The method failed to allocate necessary memory. 
        /// </summary>
        public const uint E_OUTOFMEMORY = 0x8007000E;

        /// <summary>
        /// The data necessary to Complete the operation is not yet available. 
        /// </summary>
        public const uint E_PENDING = 0x8000000A;

        /// <summary>
        /// An invalid pointer was used. 
        /// </summary>
        public const uint E_POINTER = 0x80004003;

        /// <summary>
        /// A catastrophic failure has occurred. 
        /// </summary>
        public const uint E_UNEXPECTED = 0x8000FFFF;

        /// <summary>
        /// A null reference pointer was passed to the stub
        /// </summary>
        public const uint RPC_X_NULL_REF_POINTER = 1780;

        /// <summary>
        /// The method succeeded and returned the boolean value FALSE. 
        /// </summary>
        public const uint S_FALSE = 0x00000001;

        /// <summary>
        /// The method succeeded. If a boolean return value is expected; the
        /// returned value is TRUE. 
        /// </summary>
        public const uint S_OK = 0; // Automatically set to 0. 

        #endregion Standard Errors

        #region IMAPI Errors

        /// <summary>
        /// SafeArrayRankMismatchException uses the
        /// HRESULT COR_E_SAFEARRAYRANKMISMATCH which has the value 0x80131538.
        /// The rank of a SAFEARRAY is the number of dimensions in that array.
        /// </summary>
        public const uint COR_E_SAFEARRAYRANKMISMATCH = 0x80131538;

        /// <summary>
        /// A call to IDiscMaster::Open has already been made against this 
        /// object by your application.
        /// </summary>
        public const uint IMAPI_E_ALREADYOPEN = 0x80040222;

        /// <summary>
        /// The application tried to add a badly named element to a disc.
        /// </summary>
        public const uint IMAPI_E_BADJOLIETNAME = 0x8004021D;

        /// <summary>
        /// Attempt to create a bootable image on a non-blank disc.
        /// </summary>
        public const uint IMAPI_E_BOOTIMAGE_AND_NONBLANK_DISC = 0x8004022E;

        /// <summary>
        /// Cannot write to the media.
        /// </summary>
        public const uint IMAPI_E_CANNOT_WRITE_TO_MEDIA = 0x8004022C;

        /// <summary>
        /// The stash is located on a Compressed volume and cannot be read.
        /// </summary>
        public const uint IMAPI_E_COMPRESSEDSTASH = 0x80040228;

        /// <summary>
        /// The recorder does not support an operation.
        /// </summary>
        public const uint IMAPI_E_DEVICE_INVALIDTYPE = 0x80040214;

        /// <summary>
        /// The recorder does not support any properties.
        /// </summary>
        public const uint IMAPI_E_DEVICE_NOPROPERTIES = 0x80040211;

        /// <summary>
        /// The device cannot be used or is already in use.
        /// </summary>
        public const uint IMAPI_E_DEVICE_NOTACCESSIBLE = 0x80040212;

        /// <summary>
        /// The device is not present or has been removed.
        /// </summary>
        public const uint IMAPI_E_DEVICE_NOTPRESENT = 0x80040213;

        /// <summary>
        /// Another application is already using this device; so Imapi cannot 
        /// access the device.
        /// </summary>
        public const uint IMAPI_E_DEVICE_STILL_IN_USE = 0x80040226;

        /// <summary>
        /// The disc cannot hold any more data.
        /// </summary>
        public const uint IMAPI_E_DISCFULL = 0x8004021C;

        /// <summary>
        /// An error occurred while trying to read disc data from the device.
        /// </summary>
        public const uint IMAPI_E_DISCINFO = 0x80040219;

        /// <summary>
        /// The stash is located on an encrypted volume and cannot be read.
        /// </summary>
        public const uint IMAPI_E_ENCRYPTEDSTASH = 0x80040229;

        /// <summary>
        /// An error occurred while writing the image file.
        /// </summary>
        public const uint IMAPI_E_FILEACCESS = 0x80040218;

        /// <summary>
        /// The file to add is already in the image file and the overwrite 
        /// flag was not set.
        /// </summary>
        public const uint IMAPI_E_FILEEXISTS = 0x80040224;

        /// <summary>
        /// "An error occurred while enabling/disabling file system access or during auto-insertion detection.
        /// </summary>
        public const uint IMAPI_E_FILESYSTEM = 0x80040217;

        /// <summary>
        /// A generic error occurred.
        /// </summary>
        public const uint IMAPI_E_GENERIC = 0x8004020E;

        /// <summary>
        /// The drive interface could not be initialized for closing.
        /// </summary>
        public const uint IMAPI_E_INITIALIZE_ENDWRITE = 0x80040216;

        /// <summary>
        /// The drive interface could not be initialized for writing.
        /// </summary>
        public const uint IMAPI_E_INITIALIZE_WRITE = 0x80040215;

        /// <summary>
        /// The staged image is not suitable for a burn. It has been 
        /// corrupted or cleared and has no usable content.
        /// </summary>
        public const uint IMAPI_E_INVALIDIMAGE = 0x8004021E;

        /// <summary>
        /// Content streaming was lost; a buffer under-run may have occurred.
        /// </summary>
        public const uint IMAPI_E_LOSS_OF_STREAMING = 0x80040227;

        /// <summary>
        /// The media is not a type that can be used.
        /// </summary>
        public const uint IMAPI_E_MEDIUM_INVALIDTYPE = 0x80040210;

        /// <summary>
        /// There is no disc in the device.
        /// </summary>
        public const uint IMAPI_E_MEDIUM_NOTPRESENT = 0x8004020F;

        /// <summary>
        /// An active format master has not been selected using 
        /// IDiscMaster::SetActiveDiscMasterFormat.
        /// </summary>
        public const uint IMAPI_E_NOACTIVEFORMAT = 0x8004021F;

        /// <summary>
        /// An active disc recorder has not been selected using 
        /// IDiscMaster::SetActiveDiscRecorder.
        /// </summary>
        public const uint IMAPI_E_NOACTIVERECORDER = 0x80040220;

        /// <summary>
        /// There is not enough free space to create the stash file on the specified volume.
        /// </summary>
        public const uint IMAPI_E_NOTENOUGHDISKFORSTASH = 0x8004022A;

        /// <summary>
        /// A recorder object has not been initialized.
        /// </summary>
        public const uint IMAPI_E_NOTINITIALIZED = 0x8004020C;

        /// <summary>
        /// A call to IDiscMaster::Open has not been made.
        /// </summary>
        public const uint IMAPI_E_NOTOPENED = 0x8004020B;

        /// <summary>
        /// The selected stash location is on a removable media.
        /// </summary>
        public const uint IMAPI_E_REMOVABLESTASH = 0x8004022B;

        /// <summary>
        /// Another application is already using the Imapi stash file required to 
        /// stage a disc image. Try again later.
        /// </summary>
        public const uint IMAPI_E_STASHINUSE = 0x80040225;

        /// <summary>
        /// Track was too short.
        /// </summary>
        public const uint IMAPI_E_TRACK_NOT_BIG_ENOUGH = 0x8004022D;

        /// <summary>
        /// An audio track is not open for writing.
        /// </summary>
        public const uint IMAPI_E_TRACKNOTOPEN = 0x8004021A;

        /// <summary>
        /// An open audio track is already being staged.
        /// </summary>
        public const uint IMAPI_E_TRACKOPEN = 0x8004021B;

        /// <summary>
        /// The user canceled the operation.
        /// </summary>
        public const uint IMAPI_E_USERABORT = 0x8004020D;

        /// <summary>
        /// The Imapi multi-session disc has been removed from the active recorder.
        /// </summary>
        public const uint IMAPI_E_WRONGDISC = 0x80040223;

        /// <summary>
        /// A call to IJolietDiscMaster has been made when IRedbookDiscMaster is 
        /// the active format; or vice versa. To use a different format; change 
        /// the format and clear the image file contents.
        /// </summary>
        public const uint IMAPI_E_WRONGFORMAT = 0x80040221;

        /// <summary>
        /// Buffer too small
        /// </summary>
        public const uint IMAPI_S_BUFFER_TOO_SMALL = 0x80040201;

        /// <summary>
        /// An unknown property was passed in a property set and it was ignored.
        /// </summary>
        public const uint IMAPI_S_PROPERTIESIGNORED = 0x80040200;

        #endregion IMAPI Errors

        #region STG Errors

        /// <summary>
        /// Access Denied.
        /// </summary>
        public const uint STG_E_ACCESSDENIED = 0x80030005;

        /// <summary>
        /// File already exists.
        /// </summary>
        public const uint STG_E_FILEALREADYEXISTS = 0x80030050;

        /// <summary>
        /// A storage-related error has occurred; specifically; a requested file does not exist.
        /// </summary>
        public const uint STG_E_FILENOTFOUND = 0x80030002;

        /// <summary>
        /// There is insufficient memory available to complete operation.
        /// </summary>
        public const uint STG_E_INSUFFICIENTMEMORY = 0x80030008;

        /// <summary>
        /// The value for the grfCommitFlags parameter is not valid.
        /// </summary>
        public const uint STG_E_INVALIDFLAG = 0x800300FF;

        /// <summary>
        /// Locking is not supported at all or the specific type of lock requested is not supported.
        /// </summary>
        public const uint STG_E_INVALIDFUNCTION = 0x80030001;

        /// <summary>
        /// The file %1 is not a valid compound file.
        /// </summary>
        public const uint STG_E_INVALIDHEADER = 0x800300FB;

        /// <summary>
        /// The name %1 is not valid.
        /// </summary>
        public const uint STG_E_INVALIDNAME = 0x800300FC;

        /// <summary>
        /// Invalid parameter error.
        /// </summary>
        public const uint STG_E_INVALIDPARAMETER = 0x80030057;

        /// <summary>
        /// An invalid pointer was passed.
        /// </summary>
        public const uint STG_E_INVALIDPOINTER = 0x80030009;

        /// <summary>
        /// There is insufficient disk space to complete operation.
        /// </summary>
        public const uint STG_E_MEDIUMFULL = 0x80030070;

        /// <summary>
        /// The storage has been changed since the last commit.
        /// </summary>
        public const uint STG_E_NOTCURRENT = 0x80030101;

        /// <summary>
        /// Illegal write of non-simple property to simple property set.
        /// </summary>
        public const uint STG_E_PROPSETMISMATCHED = 0x800300F0;

        /// <summary>
        /// A disk error occurred during a read operation.
        /// </summary>
        public const uint STG_E_READFAULT = 0x8003001E;

        /// <summary>
        /// Attempted to use an object that has ceased to exist.
        /// </summary>
        public const uint STG_E_REVERTED = 0x80030102;

        /// <summary>
        /// There are insufficient resources to open another file.
        /// </summary>
        public const uint STG_E_TOOMANYOPENFILES = 0x80030004;

        /// <summary>
        /// A disk error occurred during a write operation.
        /// </summary>
        public const uint STG_E_WRITEFAULT = 0x8003001D;

        #endregion STG Errors
    }
}