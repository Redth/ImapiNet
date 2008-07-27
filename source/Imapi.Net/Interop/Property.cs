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
using System.Runtime.InteropServices;
using Imapi.Net.ObjectModel;
using Imapi.Net.Properties;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Exceptions;
using Imapi.Net.Interop.Interfaces;

#endregion Using Directives

namespace Imapi.Net.Interop
{
    /// <summary>
    /// 
    /// </summary>
    public class Property : Disposable
    {
        #region Private Member Variables

        private readonly IntPtr _id;
        private readonly string _name;
        private readonly PropertyStorage _owner;
        private object _propValue;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="owner">The owner.</param>
        internal Property( string name, object value, PropertyStorage owner )
        {
            _id = Marshal.StringToCoTaskMemUni( name );
            _name = name;
            _propValue = value;
            _owner = owner;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="owner">The owner.</param>
        internal Property( IntPtr id, string name, object value, PropertyStorage owner )
        {
            _id = id;
            _name = name;
            _propValue = value;
            _owner = owner;
        }


        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Property"/> is reclaimed by garbage collection.
        /// </summary>
        ~Property()
        {
            Dispose( false );
        }

        #region Joliet

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="jolietDiscMaster">The joliet disc master.</param>
        /// <param name="propertyID">The property ID.</param>
        /// <returns></returns>
        /// <exception cref="COMException"></exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="WrongFormatException"></exception>
        internal static object GetJolietPropertyValue( IJolietDiscMaster jolietDiscMaster, string propertyID )
        {
            IPropertyStorage ppPropStg;
            PropSpec rgPropID;
            object rgPropVar;

            try
            {
                jolietDiscMaster.GetJolietProperties( out ppPropStg );
            }
            catch ( COMException ex )
            {
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                        throw new NoDevicePropertiesException();
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                        throw new NoActiveFormatException();
                    case ErrorCodes.IMAPI_E_WRONGFORMAT:
                        throw new WrongFormatException();
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
                return rgPropVar;
            }
            catch ( Exception ex )
            {
                Trace.WriteLine( string.Format( CultureInfo.CurrentCulture, "Error getting {0}.{1}{2}{3}{4}", propertyID, Environment.NewLine,
                                                ex.Message, Environment.NewLine, ex.StackTrace ) );
                throw;
            }
            finally
            {
                Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
            }
        }


        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="jolietDiscMaster">The joliet disc master.</param>
        /// <param name="propertyID">The property ID.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="WrongFormatException"></exception>
        internal static void SetJolietPropertyValue( IJolietDiscMaster jolietDiscMaster, string propertyID, object value )
        {
            IPropertyStorage ppPropStg;
            PropSpec rgPropID;
            object newValue;

            try
            {
                jolietDiscMaster.GetJolietProperties( out ppPropStg );
            }
            catch ( COMException ex )
            {
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                        throw new NoDevicePropertiesException();
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                        throw new NoActiveFormatException();
                    case ErrorCodes.IMAPI_E_WRONGFORMAT:
                        throw new WrongFormatException();
                    default:
                        throw;
                }
            }
            newValue = value;
            rgPropID = new PropSpec();

            rgPropID.ulKind = PrpSpec.LPWStr;
            rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni( propertyID );

            try
            {
                ppPropStg.WriteMultiple( 1, ref rgPropID, ref newValue, 8 );
            }
            catch ( Exception ex )
            {
                Trace.WriteLine( string.Format( CultureInfo.CurrentCulture, "Error setting {0}.{1}{2}{3}{4}", propertyID, Environment.NewLine,
                                                ex.Message, Environment.NewLine, ex.StackTrace ) );
                throw;
            }
            finally
            {
                Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
            }

            try
            {
                jolietDiscMaster.SetJolietProperties( ppPropStg );
            }
            catch ( COMException ex )
            {
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                        Trace.WriteLine( Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED );
                        break;
                    case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                        throw new NoDevicePropertiesException();
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                        throw new NoActiveFormatException();
                    case ErrorCodes.IMAPI_E_WRONGFORMAT:
                        throw new WrongFormatException();
                    default:
                        throw;
                }
            }
        }

        #endregion Joliet

        #region DiscRecorder

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="discRecorder">The disc recorder.</param>
        /// <param name="propertyID">The property ID.</param>
        /// <returns></returns>
        /// <exception cref="COMException"></exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal static object GetDiscRecorderPropertyValue( IDiscRecorder discRecorder, string propertyID )
        {
            IPropertyStorage ppPropStg;
            PropSpec rgPropID;
            object rgPropVar;

            try
            {
                discRecorder.GetRecorderProperties( out ppPropStg );
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
                Trace.WriteLine( CultureInfo.CurrentCulture, "Error getting AudioGapSize." );
                Trace.WriteLine( string.Format( CultureInfo.CurrentCulture, "{0}{1}{2}", ce.Message, Environment.NewLine, ce.StackTrace ) );
                return -1;
            }
            finally
            {
                Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
            }

            try
            {
                return Int32.Parse( rgPropVar.ToString(), CultureInfo.CurrentCulture );
            }
            catch ( Exception ex )
            {
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                return -1;
            }
        }


        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="discRecorder">The disc recorder.</param>
        /// <param name="propertyID">The property ID.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal static void SetDiscRecorderPropertyValue( IDiscRecorder discRecorder, string propertyID, object value )
        {
            IPropertyStorage ppPropStg;
            PropSpec rgPropID;
            object newValue;

            try
            {
                discRecorder.GetRecorderProperties( out ppPropStg );
            }
            catch ( COMException ex )
            {
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                        throw new NoDevicePropertiesException();
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                        throw new NoActiveFormatException();
                    case ErrorCodes.IMAPI_E_WRONGFORMAT:
                        throw new WrongFormatException();
                    default:
                        throw;
                }
            }
            newValue = value;
            rgPropID = new PropSpec();

            rgPropID.ulKind = PrpSpec.LPWStr;
            rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni( propertyID );

            try
            {
                ppPropStg.WriteMultiple( 1, ref rgPropID, ref newValue, 8 );
            } // End try
            catch ( Exception ex )
            {
                Trace.WriteLine( "Error setting " + propertyID + "." + Environment.NewLine + ex.Message +
                                 Environment.NewLine + ex.StackTrace );
                throw;
            }
            finally
            {
                Marshal.FreeCoTaskMem( rgPropID.ID_or_LPWSTR );
            }

            try
            {
                discRecorder.SetRecorderProperties( ppPropStg );
            }
            catch ( COMException ex )
            {
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                        Trace.WriteLine( Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED );
                        break;
                    case ErrorCodes.IMAPI_E_DEVICE_NOPROPERTIES:
                        throw new NoDevicePropertiesException();
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                        throw new NoActiveFormatException();
                    case ErrorCodes.IMAPI_E_WRONGFORMAT:
                        throw new WrongFormatException();
                    default:
                        throw;
                }
            }
        }

        #endregion

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
        protected override void Dispose( bool disposing )
        {
            // Check to see if Dispose has already been called.
            if ( !IsDisposed )
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if ( disposing )
                {
                    // Dispose managed resources.
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
                Marshal.FreeCoTaskMem( _id );
            }
            base.Dispose( disposing );
        }

        #region Public Properties

        /// <summary>
        /// Gets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public IntPtr ID
        {
            get { return _id; }
        }


        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return _name; }
        }


        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value
        {
            get { return _propValue; }


            set
            {
                _propValue = value;
                _owner.Update( this );
            }
        }

        #endregion Public Properties
    }
}