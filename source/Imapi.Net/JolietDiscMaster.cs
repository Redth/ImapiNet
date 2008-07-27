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
using System.Security.Permissions;
using Imapi.Net.Interop;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Exceptions;
using Imapi.Net.Interop.Interfaces;
using Imapi.Net;
using Imapi.Net.ObjectModel;

#endregion Using Directives

namespace Imapi.Net
{
    /// <summary>
    /// Wrapper for an Imapi <c>IJolietDiscMaster</c> object for use in
    /// managed code.  This class allows a data (Joliet) disc image to
    /// be staged which can be later burnt using the <see cref="DiscMaster"/>
    /// object.
    /// Note  By setting the four boot image properties, IMAPI will create a
    /// bootable disc. No further work, beyond providing the boot image, is necessary.
    /// </summary>
    public class JolietDiscMaster : Disposable
    {
        #region Private Member Variables

        private readonly DiscMaster _owner;
        private readonly JolietDiscMasterStorage _rootStorage;
        private readonly object _syncRoot = new object();
        private IJolietDiscMaster _jolietDiscMaster;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Internal constructor.  Instances of this class should only
        /// be obtained from the <see cref="DiscMaster"/> object.
        /// </summary>
        /// <param name="owner">Disc master object which owns this object.</param>
        /// <param name="jolietDiscMaster">Imapi Joliet Disc</param>
        internal JolietDiscMaster( DiscMaster owner, IJolietDiscMaster jolietDiscMaster )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( "owner" );
            } // End if (owner == null)

            if ( jolietDiscMaster == null )
            {
                throw new ArgumentNullException( "jolietDiscMaster" );
            } // End if (jolietDiscMaster == null)

            _owner = owner;
            _jolietDiscMaster = jolietDiscMaster;
            _rootStorage = new JolietDiscMasterStorage( owner );
        } // End JolietDiscMaster(DiscMaster owner, IJolietDiscMaster jolietDiscMaster)


        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Imapi.Net.JolietDiscMaster"/> is reclaimed by garbage collection.
        /// </summary>
        ~JolietDiscMaster()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose( false );
        } // End ~JolietDiscMaster


        /// <summary>
        /// Adds data to the Joliet Disc Master cache from a JolietDiscMasterStorage
        /// instance.
        /// </summary>
        /// <param name="overwrite"><c>true</c> if overwriting should occur, <c>false</c>
        /// otherwise.</param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="FileExistsException"></exception>
        /// <exception cref="DiscFullException"></exception>
        /// <exception cref="BadJolietNameException"></exception>
        public void AddData( bool overwrite )
        {
            _owner.ResetJolietAddDataCancel();
            int cancel = 0;
            _owner.QueryCancelRequest( out cancel );

            if ( cancel == 0 )
            {
                IStorage istorage = _rootStorage.IStorage;
                try
                {
                    _jolietDiscMaster.AddData( istorage, ( overwrite ? 1 : 0 ) );
                }
                catch ( COMException ex )
                {
                    Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_E_NOTOPENED:
                            throw new DiscMasterNotOpenedException();
                        case ErrorCodes.IMAPI_E_FILEEXISTS:
                            throw new FileExistsException();
                        case ErrorCodes.IMAPI_E_DISCFULL:
                            throw new DiscFullException();
                        case ErrorCodes.IMAPI_E_BADJOLIETNAME:
                            throw new BadJolietNameException();
                        case ErrorCodes.IMAPI_E_FILESYSTEM:
                            throw new FileSystemAccessException();
                        default:
                            throw;
                    }
                }
            } // End if (cancel == 0)
        } // End void AddData(bool overwrite)

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
                // Dispose managed resources.
                _rootStorage.Dispose();
                Marshal.ReleaseComObject( _jolietDiscMaster );
                _jolietDiscMaster = null;
            }
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
        /// Gets the storage class which holds the files and folders
        /// to be written to the CD.
        /// </summary>
        public JolietDiscMasterStorage RootStorage
        {
            get { return _rootStorage; } // End get
        } // End Property RootStorage


        /// <summary>
        /// Gets the size of data block in the image in bytes (2048 bytes).
        /// </summary>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public int DataBlockSize
        {
            get
            {
                int blockSize;
                try
                {
                    _jolietDiscMaster.GetDataBlockSize( out blockSize );
                }
                catch ( COMException ex )
                {
                    Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                    {
                        throw new DiscMasterNotOpenedException();
                    }
                    throw;
                }
                return blockSize;
            } // End get
        } // End Property DataBlockSize


        /// <summary>
        /// Gets the total number of data blocks on the disc.
        /// </summary>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public int TotalDataBlocks
        {
            get
            {
                int totalBlocks;
                try
                {
                    _jolietDiscMaster.GetTotalDataBlocks( out totalBlocks );
                }
                catch ( COMException ex )
                {
                    Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                    {
                        throw new DiscMasterNotOpenedException();
                    }
                    throw;
                }
                return totalBlocks;
            } // End get
        } // End Property TotalDataBlocks


        /// <summary>
        /// Gets the number of used data blocks on the disc.
        /// </summary>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public int UsedDataBlocks
        {
            get
            {
                int dataBlocks;
                try
                {
                    _jolietDiscMaster.GetUsedDataBlocks( out dataBlocks );
                }
                catch ( COMException ex )
                {
                    Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                    {
                        throw new DiscMasterNotOpenedException();
                    }
                    throw;
                }
                return dataBlocks;
            } // End get
        } // End Property UsedDataBlocks

        #endregion Public Properties

        #region IJolietDiscMaster Properties

        /// <summary>
        /// The volume name of the disc after recording. Default is the current date.
        /// </summary>
        /// <exception cref="COMException"></exception> 
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="WrongFormatException"></exception>
        public string VolumeName
        {
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                return Property.GetJolietPropertyValue( _jolietDiscMaster, "VolumeName" ).ToString();
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "VolumeName";

                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.ReadMultiple(1, ref rgPropID, out rgPropVar);
                    return rgPropVar.ToString();
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error getting VolumeName." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally*/
            } // End get


            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            set
            {
                Property.SetJolietPropertyValue( _jolietDiscMaster, "VolumeName", value );
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object newValue;
                string propertyID;

                propertyID = "VolumeName";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.WriteMultiple(1, ref rgPropID, ref newValue, 8);
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error setting VolumeName." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.InnerException);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally

                try
                {
                    _jolietDiscMaster.SetJolietProperties(ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
                    {
                        case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                            System.Diagnostics.Trace.WriteLine(Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED);
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
                }*/
            } // End set
        } // End Property VolumeName


        /// <summary>
        /// A Boolean value that indicates whether a boot image is to be placed on the disc.
        /// </summary>
        /// <exception cref="COMException"></exception> 
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="WrongFormatException"></exception>
        public bool PlaceBootImageOnDisc
        {
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                return
                    Boolean.Parse(
                        Property.GetJolietPropertyValue( _jolietDiscMaster, "PlaceBootImageOnDisc" ).ToString() );
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "PlaceBootImageOnDisc";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.ReadMultiple(1, ref rgPropID, out rgPropVar);
                    return Boolean.Parse(rgPropVar.ToString());
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error getting PlaceBootImageOnDisc." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally
                */
            } // End get


            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            set
            {
                Property.SetJolietPropertyValue( _jolietDiscMaster, "PlaceBootImageOnDisc", value );
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object newValue;
                string propertyID;

                propertyID = "PlaceBootImageOnDisc";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.WriteMultiple(1, ref rgPropID, ref newValue, 8);
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error setting PlaceBootImageOnDisc." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.InnerException);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally

                try
                {
                    _jolietDiscMaster.SetJolietProperties(ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
                    {
                        case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                            System.Diagnostics.Trace.WriteLine(Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED);
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
                }*/
            } // End set
        } // End Property PlaceBootImageOnDisc


        /// <summary>
        /// A BString value (maximum of 24 bytes) that contains identification information for the creator of the boot image. 
        /// </summary>
        /// <exception cref="COMException"></exception> 
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="WrongFormatException"></exception>
        public string BootImageManufacturerIdString
        {
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                return Property.GetJolietPropertyValue( _jolietDiscMaster, "BootImageManufacturerIdString" ).ToString();
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "BootImageManufacturerIdString";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.ReadMultiple(1, ref rgPropID, out rgPropVar);
                    return rgPropVar.ToString();
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error getting BootImageManufacturerIdString." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally
                */
            } // End get


            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            set
            {
                Property.SetJolietPropertyValue( _jolietDiscMaster, "BootImageManufacturerIdString", value );
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object newValue;
                string propertyID;

                propertyID = "BootImageManufacturerIdString";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.WriteMultiple(1, ref rgPropID, ref newValue, 8);
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error setting BootImageManufacturerIdString." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.InnerException);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally

                try
                {
                    _jolietDiscMaster.SetJolietProperties(ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
                    {
                        case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                            System.Diagnostics.Trace.WriteLine(Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED);
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
                }*/
            } // End set
        } // End Property BootImageManufacturerIdString


        /// <summary>
        /// Gets or sets the boot image platform.
        /// </summary>
        /// <value>The boot image platform.</value>
        /// <exception cref="COMException"></exception> 
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="WrongFormatException"></exception>
        public BootImagePlatform BootImagePlatform
        {
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                //Property.GetPropertyValue<int>(_jolietDiscMaster, "BootImagePlatform");
                switch (
                    Int32.Parse( Property.GetJolietPropertyValue( _jolietDiscMaster, "BootImagePlatform" ).ToString(),
                                 NumberStyles.Integer, CultureInfo.CurrentCulture.NumberFormat ) )
                {
                    case 0:
                        return BootImagePlatform.X86;
                    case 1:
                        return BootImagePlatform.PowerPC;
                    case 2:
                        return BootImagePlatform.Mac;
                    default:
                        return BootImagePlatform.Undefined;
                }
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "BootImagePlatform";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.ReadMultiple(1, ref rgPropID, out rgPropVar);
                    switch ()
                    {
                        case 0:
                            return BootImagePlatform.X86;
                        case 1:
                            return BootImagePlatform.PowerPC;
                        case 2:
                            return BootImagePlatform.Mac;
                        default:
                            return BootImagePlatform.Undefined;
                    } // End switch (Int32.Parse(rgPropVar.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture.NumberFormat))
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error getting BootImagePlatform." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally
                 * */
            } // End get


            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            set
            {
                Property.SetJolietPropertyValue( _jolietDiscMaster, "BootImagePlatform", value );
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object newValue;
                string propertyID;

                propertyID = "BootImagePlatform";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.WriteMultiple(1, ref rgPropID, ref newValue, 8);
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error setting BootImagePlatform." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.InnerException);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally

                try
                {
                    _jolietDiscMaster.SetJolietProperties(ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
                    {
                        case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                            System.Diagnostics.Trace.WriteLine(Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED);
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
                }*/
            } // End set
        } // End Property BootImagePlatform


        /// <summary>
        /// Gets or sets the type of the boot image emulation.
        /// </summary>
        /// <value>The type of the boot image emulation.</value>
        /// <exception cref="COMException"></exception> 
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="WrongFormatException"></exception>
        public BootImageEmulationType BootImageEmulationType
        {
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                switch (
                    Int32.Parse(
                        Property.GetJolietPropertyValue( _jolietDiscMaster, "BootImageEmulationType" ).ToString(),
                        NumberStyles.Integer, CultureInfo.CurrentCulture.NumberFormat ) )
                {
                    case 0:
                        return BootImageEmulationType.NoEmulation;
                    case 1:
                        return BootImageEmulationType.DisketteImage12MB;
                    case 2:
                        return BootImageEmulationType.DisketteImage144Inch;
                    case 3:
                        return BootImageEmulationType.DisketteImage288MB;
                    case 4:
                        return BootImageEmulationType.HardDiskEmulation;
                    default:
                        return BootImageEmulationType.NoEmulation;
                }
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "BootImageEmulationType";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.ReadMultiple(1, ref rgPropID, out rgPropVar);
                    switch (Int32.Parse(rgPropVar.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture.NumberFormat))
                    {
                        case 0:
                            return BootImageEmulationType.NoEmulation;
                        case 1:
                            return BootImageEmulationType.DisketteImage12MB;
                        case 2:
                            return BootImageEmulationType.DisketteImage144Inch;
                        case 3:
                            return BootImageEmulationType.DisketteImage288MB;
                        case 4:
                            return BootImageEmulationType.HardDiskEmulation;
                        default:
                            return BootImageEmulationType.NoEmulation;
                    } // End switch (Int32.Parse(rgPropVar.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture.NumberFormat))
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error getting BootImageEmulationType." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally
                 * */
            } // End get


            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            set
            {
                Property.SetJolietPropertyValue( _jolietDiscMaster, "BootImageEmulationType", value );
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object newValue;
                string propertyID;

                propertyID = "BootImageEmulationType";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.WriteMultiple(1, ref rgPropID, ref newValue, 8);
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error setting BootImageEmulationType." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.InnerException);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally

                try
                {
                    _jolietDiscMaster.SetJolietProperties(ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
                    {
                        case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                            System.Diagnostics.Trace.WriteLine(Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED);
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
                }*/
            } // End set
        } // End Property BootImageEmulationType

        /// <summary>
        /// The IStream object where the IMAPI client stores the boot image to be burned on the CD.
        /// </summary>
        /// <exception cref="COMException"></exception> 
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="WrongFormatException"></exception>
        public object /*IStream*/ BootImage
        {
            // Library method with link demand.
            // This method holds its immediate callers responsible for securing the information.
            // Because a caller must have unrestricted permission, the method asserts read permission
            // in case some caller in the stack does not have this permission. 
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get
            {
                return Property.GetJolietPropertyValue( _jolietDiscMaster, "BootImage" );
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object rgPropVar;
                string propertyID;

                propertyID = "BootImage";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.ReadMultiple(1, ref rgPropID, out rgPropVar);
                    return rgPropVar;
                } // End try
                catch (COMException ce)
                {
                    System.Diagnostics.Trace.WriteLine("Error getting BootImage." + Environment.NewLine + ce.Message + Environment.NewLine + ce.StackTrace);
                    return new object();
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally
                 * */
            } // End get


            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            set
            {
                Property.SetJolietPropertyValue( _jolietDiscMaster, "BootImage", value );
                /*
                IPropertyStorage ppPropStg;
                PropSpec rgPropID;
                object newValue;
                string propertyID;

                propertyID = "BootImage";
                try
                {
                    _jolietDiscMaster.GetJolietProperties(out ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
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
                rgPropID.ID_or_LPWSTR = Marshal.StringToCoTaskMemUni(propertyID);

                try
                {
                    ppPropStg.WriteMultiple(1, ref rgPropID, ref newValue, 8);
                } // End try
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error setting BootImage." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.InnerException);
                    throw;
                } // End try...catch
                finally
                {
                    Marshal.FreeCoTaskMem(rgPropID.ID_or_LPWSTR);
                } // End try...catch...finally

                try
                {
                    _jolietDiscMaster.SetJolietProperties(ppPropStg);
                }
                catch (COMException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    switch ((uint)ex.ErrorCode)
                    {
                        case ErrorCodes.IMAPI_S_PROPERTIESIGNORED:
                            System.Diagnostics.Trace.WriteLine(Resources.Error_Msg_IMAPI_S_PROPERTIESIGNORED);
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
                }*/
            } // End set
        } // End Property BootImage

        #endregion IJolietDiscMaster Properties

        // End void Dispose(bool disposing)
    }
}

// End namespace Imapi.Net.Interop