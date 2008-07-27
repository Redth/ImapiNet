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
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Imapi.Net.Interop;
using Imapi.Net.ObjectModel;
using Imapi.Net.Properties;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Exceptions;
using Imapi.Net.Interop.Interfaces;
using Imapi.Net;

#endregion Using Directives

namespace Imapi.Net
{
    /// <summary>
    /// Wrapper for an Imapi <c>IDiscRecorder</c> object for use in
    /// managed code.  This class allows information about the
    /// recorder and any media present to be obtained.  It also
    /// allows media to be erased and the disc drawer to be ejected.
    /// </summary>
    public class DiscRecorder : Disposable
    {
        private readonly NumberFormatInfo _numberIFormatProvider;
        private readonly string _product;
        private readonly string _revision;
        private readonly object _syncRoot = new object();
        private readonly string _vendor;
        private IDiscRecorder _recorder;

        #region Public Methods and Constructors

        /// <summary>
        /// Internal constructor; this class should only be constructed
        /// by an instance of the <see cref="COMException"/> class.
        /// </summary>
        /// <param name="recorder">Imapi recorder object to wrap</param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DiscMaster"></exception>
        internal DiscRecorder( IDiscRecorder recorder )
        {
            if ( recorder == null )
            {
                throw new ArgumentNullException( "recorder" );
            }

            _numberIFormatProvider = CultureInfo.CurrentCulture.NumberFormat;
            _recorder = recorder;

            try
            {
                _recorder.GetDisplayNames( ref _vendor, ref _product, ref _revision );
            }
            catch ( COMException ex )
            {
                if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTINITIALIZED )
                {
                    throw new RecorderNotInitializedException();
                }
                throw;
            }
        }

        /// <summary>
        /// This destructor will run only if the Dispose method 
        /// does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructors in types derived from this class.
        /// </summary>
        [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
        ~DiscRecorder()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose( false );
        }

        /// <summary>
        /// Erases CD-RW media.
        /// </summary>
        /// <param name="fullErase"><c>true</c> to fully erase the
        /// media, <c>false</c> otherwise.</param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="GenericUnexpectedUnexplainedException"></exception>
        /// <exception cref="MediaNotPresentException"></exception>
        /// <exception cref="InvalidMediaException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        /// <exception cref="InvalidDeviceTypeException"></exception>
        public void EraseCdrw( int fullErase )
        {
            try
            {
                _recorder.Erase( fullErase );
            }
            catch ( COMException ex )
            {
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                        throw new RecorderNotInitializedException();
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_GENERIC:
                        throw new GenericUnexpectedUnexplainedException();
                    case ErrorCodes.IMAPI_E_MEDIUM_NOTPRESENT:
                        throw new MediaNotPresentException();
                    case ErrorCodes.IMAPI_E_MEDIUM_INVALIDTYPE:
                        throw new InvalidMediaException();
                    case ErrorCodes.IMAPI_E_DEVICE_NOTPRESENT:
                        throw new DeviceNotPresentException();
                    case ErrorCodes.IMAPI_E_DEVICE_INVALIDTYPE:
                        throw new InvalidDeviceTypeException();
                    default:
                        throw;
                }
            }
        } // End 


        /// <summary>
        /// Ejects the CD tray.
        /// </summary>
        /// <exception cref="COMException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        public void Eject()
        {
            try
            {
                _recorder.Eject();
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
        } // End 


        /// <summary>
        /// Opens the recorder for exclusive access.  Required to determine
        /// the media contained within the recorder.
        /// </summary>
        /// <exception cref="COMException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DeviceNotAccessibleException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        public void OpenExclusive()
        {
            try
            {
                _recorder.OpenExclusive();
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
        } // End 


        /// <summary>
        /// Closes the recorder if previously opened using <see cref="OpenExclusive"/>.
        /// </summary>
        /// <exception cref="COMException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        public void CloseExclusive()
        {
            try
            {
                _recorder.Close();
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
        } // End 

        #endregion Public Methods and Constructors

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
        [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
        protected override void Dispose( bool disposing )
        {
            // Check to see if Dispose has already been called.
            if ( disposing && !IsDisposed )
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                // Dispose managed resources.
                if ( _recorder != null )
                {
                    Marshal.ReleaseComObject( _recorder );
                } // End if(_recorder != null)
                _recorder = null;

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            } // End if(!_disposed)
            base.Dispose( disposing );
        }

        #region Public Properties

        /// <summary>
        /// Gets the sync root.
        /// </summary>
        /// <value>The sync root.</value>
        public object SyncRoot
        {
            get { return _syncRoot; }
        }

        /// <summary>
        /// Gets the Plug and Play ID of this recorder. Typically this
        /// is a concatenation of the Vendor, Product and Revision
        /// information.
        /// </summary>
        /// <value>The PNPID.</value>
        /// <exception cref="COMException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        public string PnpId
        {
            get
            {
                string pnpId;
                try
                {
                    _recorder.GetBasePnPID( out pnpId );
                }
                catch ( COMException ex )
                {
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTINITIALIZED )
                    {
                        throw new RecorderNotInitializedException();
                    }
                    throw;
                }
                return pnpId;
            } // End 
        } // End 


        /// <summary>
        /// Gets the product name of this recorder.
        /// </summary>
        /// <value>The product.</value>
        public string Product
        {
            get { return _product; } // End 
        } // End 


        /// <summary>
        /// Gets the vendor name for this recorder.
        /// </summary>
        /// <value>The vendor.</value>
        public string Vendor
        {
            get { return _vendor; } // End 
        } // End 


        /// <summary>
        /// Gets the revision number of this recorder.
        /// </summary>
        /// <value>The revision.</value>
        public string Revision
        {
            get { return _revision; } // End 
        } // End 


        /// <summary>
        /// Gets the OS path for this recorder.
        /// </summary>
        /// <value>The OS path.</value>
        /// <exception cref="COMException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        public string OSPath
        {
            get
            {
                string path;
                try
                {
                    _recorder.GetPath( out path );
                }
                catch ( COMException ex )
                {
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTINITIALIZED )
                    {
                        throw new RecorderNotInitializedException();
                    }
                    throw;
                }
                return path;
            } // End 
        } // End 


        /// <summary>
        /// Returns the drive letter for this recorder.
        /// </summary>
        /// <value>The drive letter.</value>
        public string DriveLetter
        {
            get
            {
                string driveLetter = "";
                string osPath = OSPath;
                foreach ( string drive in Directory.GetLogicalDrives() )
                {
                    string driveTest = drive.Substring( 0, drive.Length - 1 );
                    var deviceName = new String( '\0', 260 );
                    int result = NativeMethods.QueryDosDevice( driveTest, deviceName, 260 );
                    deviceName = deviceName.Substring( 0, result - 2 ); // two trailing nulls
                    if ( deviceName.Equals( osPath ) )
                    {
                        driveLetter = drive;
                        break;
                    } // End 
                } // End 
                return driveLetter;
            } // End 
        } // End 


        /// <summary>
        /// Gets the type of this recorder.
        /// </summary>
        /// <value>The type of the recorder.</value>
        /// <exception cref="COMException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        public RecorderType RecorderType
        {
            get
            {
                RecorderType type = RecorderType.Invalid;
                try
                {
                    _recorder.GetRecorderType( out type );
                }
                catch ( COMException ex )
                {
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTINITIALIZED )
                    {
                        throw new RecorderNotInitializedException();
                    }
                    throw;
                }
                return type;
            } // End 
        } // End 


        /// <summary>
        /// Gets the current state of this recorder.
        /// </summary>
        /// <value>The state of the recorder.</value>
        /// <exception cref="COMException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        public RecorderState RecorderState
        {
            get
            {
                RecorderState state = RecorderState.DoingNothing;
                try
                {
                    _recorder.GetRecorderState( out state );
                }
                catch ( COMException ex )
                {
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTINITIALIZED )
                    {
                        throw new RecorderNotInitializedException();
                    }
                    throw;
                }
                return state;
            } // End 
        } // End 


        /// <summary>
        /// Gets an object describing the media in the recorder.
        /// </summary>
        /// <value>The media details.</value>
        /// <returns>object describing media details</returns>
        public MediaDetails MediaDetails
        {
            get { return new MediaDetails( _recorder ); } // End get
        } // End 


        /// <summary>
        /// Reads the maximum write speed for the currently selected recorder.
        /// This number will be 4, 8, 10, etc. representing a 4x, 8x, or 10x CD recorder drive.
        /// </summary>
        /// <value>The max write speed.</value>
        /// <exception cref="COMException"></exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        [CLSCompliant( false )]
        public uint MaxWriteSpeed
        {
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "MaxWriteSpeed";
                try
                {
                    _recorder.GetRecorderProperties( out ppPropStg );
                }
                catch ( COMException ex )
                {
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                            throw new NoDevicePropertiesException();
                        case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                            throw new RecorderNotInitializedException();
                        default:
                            throw;
                    }
                }

                rgPropID = new PropSpec();
                rgPropVar = null;
                rgPropID.ulKind = PrpSpec.LPWStr;
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni( propertyID );

                try
                {
                    ppPropStg.ReadMultiple( 1, ref rgPropID, out rgPropVar );
                }
                catch ( COMException ce )
                {
                    Trace.WriteLine( ce.Message + Environment.NewLine + ce.StackTrace );
                    return 0;
                }
                finally
                {
                    Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
                }

                try
                {
                    return UInt32.Parse( rgPropVar.ToString(), _numberIFormatProvider );
                }
                catch ( Exception ex )
                {
                    Trace.WriteLine( "Error getting MaxWriteSpeed." + Environment.NewLine + ex.Message +
                                     Environment.NewLine + ex.StackTrace );
                    throw;
                }
            }
        }


        /// <summary>
        /// Reads the currently selected recorder's write speed.  This is usually equal
        /// to the MaxWriteSpeed, however, it is occasionally lower if the CD recorder
        /// is unreliable at it's max speed.
        /// </summary>
        /// <value>The write speed.</value>
        /// <exception cref="COMException"></exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        public int WriteSpeed
        {
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "WriteSpeed";
                try
                {
                    _recorder.GetRecorderProperties( out ppPropStg );
                }
                catch ( COMException ex )
                {
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                            throw new NoDevicePropertiesException();
                        case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                            throw new RecorderNotInitializedException();
                        default:
                            throw;
                    }
                }

                rgPropID = new PropSpec();
                rgPropVar = null;
                rgPropID.ulKind = PrpSpec.LPWStr;
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni( propertyID );

                try
                {
                    ppPropStg.ReadMultiple( 1, ref rgPropID, out rgPropVar );
                    return Int32.Parse( rgPropVar.ToString(), CultureInfo.CurrentCulture );
                }
                catch ( COMException ce )
                {
                    Trace.WriteLine( ce.Message + Environment.NewLine + ce.StackTrace );
                    return 0;
                }
                finally
                {
                    Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
                }
            }

            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            set
            {
                if ( ( MaxWriteSpeed < value ) || ( value < 1 ) )
                {
                    throw new ArgumentOutOfRangeException( "value" );
                }
                else
                {
                    IPropertyStorage ppPropStg;
                    PropSpec rgPropID;
                    object newValue;
                    string propertyID;

                    propertyID = "WriteSpeed";
                    try
                    {
                        _recorder.GetRecorderProperties( out ppPropStg );
                    }
                    catch ( COMException ex )
                    {
                        switch ( (uint) ex.ErrorCode )
                        {
                            case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                                throw new NoDevicePropertiesException();
                            case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                                throw new RecorderNotInitializedException();
                            default:
                                throw;
                        }
                    }

                    newValue = value;
                    rgPropID = new PropSpec();

                    rgPropID.ulKind = PrpSpec.LPWStr;
                    rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni( propertyID );

                    ppPropStg.WriteMultiple( 1, ref rgPropID, ref newValue, 8 );

                    try
                    {
                        _recorder.SetRecorderProperties( ppPropStg );
                    }
                    catch ( COMException ex )
                    {
                        switch ( (uint) ex.ErrorCode )
                        {
                            case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                                Trace.WriteLine( Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED );
                                break;
                            case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                                throw new NoDevicePropertiesException();
                            case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                                throw new RecorderNotInitializedException();
                            case ErrorCodes.RPC_X_NULL_REF_POINTER:
                                throw new ArgumentNullException( "", Resources.Error_Msg_RPC_X_NULL_REF_POINTER );
                            default:
                                throw;
                        }
                    }
                    finally
                    {
                        Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
                    }
                }
            }
        }


        /// <summary>
        /// Gets a value indicating whether [buffer underrun free capable].
        /// Indicates whether the CD drive supports preventing data buffer underruns
        /// from occurring while recording a CD. This feature is built into the drive
        /// so that Windows will set this property when it detects the drive.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if buffer underrun free capable; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="COMException"></exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        public bool BufferUnderrunFreeCapable
        {
            // If this value is -1, the drive supports this
            // feature. If this value is 0, the drive does not. 

            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "BufferUnderrunFreeCapable";
                try
                {
                    _recorder.GetRecorderProperties( out ppPropStg );
                }
                catch ( COMException ex )
                {
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                            throw new NoDevicePropertiesException();
                        case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                            throw new RecorderNotInitializedException();
                        default:
                            throw;
                    }
                }

                rgPropID = new PropSpec();
                rgPropVar = null;
                rgPropID.ulKind = PrpSpec.LPWStr;
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni( propertyID );

                try
                {
                    ppPropStg.ReadMultiple( 1, ref rgPropID, out rgPropVar );
                }
                catch ( COMException ce )
                {
                    Trace.WriteLine( ce.Message + Environment.NewLine + ce.StackTrace );
                    return false;
                }
                finally
                {
                    Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
                }

                try
                {
                    return ( Int32.Parse( rgPropVar.ToString(), _numberIFormatProvider ) == -1 ) ? true : false;
                }
                catch ( ArgumentException ae )
                {
                    Trace.WriteLine( ae.Message + Environment.NewLine + ae.StackTrace );
                    return false;
                }
                catch ( OverflowException oe )
                {
                    Trace.WriteLine( oe.Message + Environment.NewLine + oe.StackTrace );
                    return false;
                }
                catch ( FormatException fe )
                {
                    Trace.WriteLine( fe.Message + Environment.NewLine + fe.StackTrace );
                    return false;
                }
            }
        }


        /// <summary>
        /// Gets a value indicating whether [enable buffer underrun free].
        /// Determines whether the buffer underrun protection feature of the drive is enabled.
        /// Setting this field does not garauntee beffer underrun. This field only enables the
        /// feature if the drive supports it.
        /// </summary>
        /// <see cref="BufferUnderrunFreeCapable"/>
        /// <value>
        /// 	<c>true</c> if [enable buffer underrun free]; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="COMException"></exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        public bool EnableBufferUnderrunFree
        {
            // If this value is -1 (default), the feature is used if the drive supports it.
            // If this value is 0, the feature is disabled. If this value is 1, the feature
            // is enabled if the drive supports it. 

            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "EnableBufferUnderrunFree";
                try
                {
                    _recorder.GetRecorderProperties( out ppPropStg );
                }
                catch ( COMException ex )
                {
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                            throw new NoDevicePropertiesException();
                        case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                            throw new RecorderNotInitializedException();
                        default:
                            throw;
                    }
                }

                rgPropID = new PropSpec();
                rgPropVar = null;
                rgPropID.ulKind = PrpSpec.LPWStr;
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni( propertyID );

                try
                {
                    ppPropStg.ReadMultiple( 1, ref rgPropID, out rgPropVar );
                    switch ( Int32.Parse( rgPropVar.ToString(), _numberIFormatProvider ) )
                    {
                        case -1:
                            return true;
                        case 0:
                            return false;
                        case 1:
                            return true;
                        default:
                            return false;
                    }
                }
                catch ( COMException ce )
                {
                    Trace.WriteLine( ce.Message + Environment.NewLine + ce.StackTrace );
                    throw;
                }
                catch ( Exception ex )
                {
                    Trace.WriteLine( "Error getting EnableBufferUnderrunFree." + Environment.NewLine + ex.Message +
                                     Environment.NewLine + ex.StackTrace );
                    throw;
                }
                finally
                {
                    Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
                }
            }

            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            set
            {
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object newValue;
                string propertyID;

                propertyID = "EnableBufferUnderrunFree";

                try
                {
                    _recorder.GetRecorderProperties( out ppPropStg );
                }
                catch ( COMException ex )
                {
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                            throw new NoDevicePropertiesException();
                        case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                            throw new RecorderNotInitializedException();
                        default:
                            throw;
                    }
                }

                newValue = Convert.ToInt32( value );
                rgPropID = new PropSpec();

                rgPropID.ulKind = PrpSpec.LPWStr;
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni( propertyID );

                ppPropStg.WriteMultiple( 1, ref rgPropID, ref newValue, 8 );

                try
                {
                    _recorder.SetRecorderProperties( ppPropStg );
                }
                catch ( COMException ex )
                {
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                            Trace.WriteLine( Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED );
                            break;
                        case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                            throw new NoDevicePropertiesException();
                        case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                            throw new RecorderNotInitializedException();
                        case ErrorCodes.RPC_X_NULL_REF_POINTER:
                            throw new ArgumentNullException( "", Resources.Error_Msg_RPC_X_NULL_REF_POINTER );
                        default:
                            throw;
                    }
                }
                finally
                {
                    Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
                }
            }
        }


        /// <summary>
        /// Gets or sets the size of the audio gap.
        /// Amount of blank audio blocks to place between tracks when using
        /// the Redbook interface. The maximum valid value for this is 225.
        /// Note that 75 blocks equals one second 
        /// Two additional blocks are always written at the end of each track,
        /// before the audio gap blocks of the next track. The number of block
        /// between the audio tracks is actually two more than is specified in
        /// this property. The default value for this property is
        /// 150 blocks (2 seconds). Most drives do not behave well if this is
        /// set to any other value.
        /// </summary>
        /// <value>The size of the audio gap.</value>
        /// <exception cref="COMException"></exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public int AudioGapSize
        {
            // Library method with link demand.
            // This method holds its immediate callers responsible for securing the information.
            // Because a caller must have unrestricted permission, the method asserts read permission
            // in case some caller in the stack does not have this permission. 
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "AudioGapSize";
                try
                {
                    _recorder.GetRecorderProperties( out ppPropStg );
                }
                catch ( COMException ex )
                {
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                            throw new NoDevicePropertiesException();
                        case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                            throw new RecorderNotInitializedException();
                        default:
                            throw;
                    }
                }

                rgPropID = new PropSpec();
                rgPropVar = null;
                rgPropID.ulKind = PrpSpec.LPWStr;
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni( propertyID );

                try
                {
                    ppPropStg.ReadMultiple( 1, ref rgPropID, out rgPropVar );
                }
                catch ( COMException ce )
                {
                    Trace.WriteLine( "Error getting AudioGapSize." );
                    Trace.WriteLine( ce.Message + Environment.NewLine + ce.StackTrace );
                    return -1;
                }
                finally
                {
                    Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
                }

                try
                {
                    return Int32.Parse( rgPropVar.ToString(), _numberIFormatProvider );
                }
                catch ( Exception ex )
                {
                    Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                    return -1;
                }
            }
            // Library method with link demand.
            // This method holds its immediate callers responsible for securing the information.
            // Because a caller must have unrestricted permission, the method asserts read permission
            // in case some caller in the stack does not have this permission. 
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            set
            {
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object newValue;
                string propertyID;

                propertyID = "AudioGapSize";
                try
                {
                    _recorder.GetRecorderProperties( out ppPropStg );
                }
                catch ( COMException ex )
                {
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                            throw new NoDevicePropertiesException();
                        case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                            throw new RecorderNotInitializedException();
                        default:
                            throw;
                    }
                }
                newValue = value;
                rgPropID = new PropSpec();

                rgPropID.ulKind = PrpSpec.LPWStr;
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni( propertyID );

                ppPropStg.WriteMultiple( 1, ref rgPropID, ref newValue, 8 );

                try
                {
                    _recorder.SetRecorderProperties( ppPropStg );
                }
                catch ( COMException ex )
                {
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                            Trace.WriteLine( Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED );
                            break;
                        case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                            throw new NoDevicePropertiesException();
                        case ErrorCodes.IMAPI_E_NOTINITIALIZED:
                            throw new RecorderNotInitializedException();
                        case ErrorCodes.RPC_X_NULL_REF_POINTER:
                            throw new ArgumentNullException( "", Resources.Error_Msg_RPC_X_NULL_REF_POINTER );
                        default:
                            throw;
                    }
                }
                finally
                {
                    Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
                }
            }
        }

        #endregion Public Properties

        #region Internal Properties

        /// <summary>
        /// Gets the I disc recorder.
        /// </summary>
        /// <value>The I disc recorder.</value>
        internal IDiscRecorder IDiscRecorder
        {
            get { return _recorder; } // End 
        } // End 

        #endregion Internal Properties

        // End void Dispose(bool disposing)
    }
}

// End namespace Imapi.Net.Interop