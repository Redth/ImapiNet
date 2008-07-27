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
using System.Runtime.InteropServices;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Exceptions;

#endregion

namespace Imapi.Net.Interop.Interfaces
{
    /// <summary>
    /// IDiscRecorder
    /// The IDiscRecorder interface enables access to a single disc recorder
    /// device, labeled the active disc recorder. An Imapi object such as
    /// MSDiscMasterObj maintains an active disc recorder.
    /// An IDiscRecorder object represents a single hardware device, but
    /// there can be multiple instances of IDiscRecorder all referencing
    /// the same hardware device. In this case, use OpenExclusive to access
    /// that device.
    /// When To Use
    /// Use an instance of this object to select the recorder for a burn
    /// through IDiscMaster and to perform basic control tasks on a specific
    /// physical disc recorder.
    /// Note  An application does not call CoCreateInstance for one of these
    /// objects, but instead uses the IDiscMaster::EnumDiscRecorders method to
    /// retrieve an enumerator that returns pointers to all the recorders
    /// valid for a specific format.
    /// The IDiscRecorder interface inherits the methods of the standard Com
    /// interface IUnknown. 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder.asp
    /// </summary>
    [ComImport]
    [Guid( "85AC9776-CA88-4CF2-894E-09598C078A41" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IDiscRecorder
    {
        //    MIDL_INTERFACE("85AC9776-CA88-4cf2-894E-09598C078A41")
        //    IDiscRecorder : public IUnknown
        //    {
        //    public:
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Init( 
        //            /* [size_is][in] */ byte *pbyUniqueID,
        //            /* [in] */ ULONG nulIDSize,
        //            /* [in] */ ULONG nulDriveNumber) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetRecorderGUID( 
        //            /* [size_is][unique][out][in] */ byte *pbyUniqueID,
        //            /* [in] */ ULONG ulBufferSize,
        //            /* [out] */ ULONG *pulReturnSizeRequired) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetRecorderType( 
        //            /* [out] */ long *fTypeCode) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetDisplayNames( 
        //            /* [unique][out][in] */ BSTR *pbstrVendorID,
        //            /* [unique][out][in] */ BSTR *pbstrProductID,
        //            /* [unique][out][in] */ BSTR *pbstrRevision) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetBasePnPID( 
        //            /* [out] */ BSTR *pbstrBasePnPID) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetPath( 
        //            /* [out] */ BSTR *pbstrPath) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetRecorderProperties( 
        //            /* [out] */ IPropertyStorage **ppPropStg) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetRecorderProperties( 
        //            /* [in] */ IPropertyStorage *pPropStg) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetRecorderState( 
        //            /* [out] */ ULONG *pulDevStateFlags) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE OpenExclusive( void) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE QueryMediaType( 
        //            /* [out] */ long *fMediaType,
        //            /* [out] */ long *fMediaFlags) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE QueryMediaInfo( 
        //            /* [out] */ byte *pbSessions,
        //            /* [out] */ byte *pbLastTrack,
        //            /* [out] */ ULONG *ulStartAddress,
        //            /* [out] */ ULONG *ulNextWritable,
        //            /* [out] */ ULONG *ulFreeBlocks) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Eject( void) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Erase( 
        //            /* [in] */ boolean bFullErase) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Close( void) = 0;
        //        
        //    };


        /// <summary>
        /// Initializes the object for an underlying device.
        /// Used internally only. Also not documented.
        /// </summary>
        /// <param name="pbyUniqueID">
        /// Byte is what is said, but wrong size
        /// </param>
        /// <param name="nulIDSize">
        /// 
        /// </param>
        /// <param name="nulDriveNumber">
        /// 
        /// </param>
        void Init( ref IntPtr pbyUniqueID, uint nulIDSize, uint nulDriveNumber );


        /// <summary>
        /// IDiscRecorder::GetRecorderGUID
        /// TODO: Create accessor.
        /// The GetRecorderGUID method returns the GUID of the physical disc
        /// recorder currently associated with the recorder object.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_getrecorderguid.asp
        /// </summary>
        /// <param name="pbyUniqueID">
        /// byte* pbyUniqueID
        /// Byte is prescribed, but I need more data.
        /// [in] Pointer to a GUID buffer to be filled in with this
        /// recorder's current GUID information. To query the required
        /// buffer size, use NULL.
        /// </param>
        /// <param name="ulBufferSize">
        /// ULONG ulBufferSize
        /// [in] Size of the GUID buffer. If pbyUniqueID is NULL, this
        /// parameter must be zero.
        /// </param>
        /// <param name="pulReturnSizeRequired">
        /// ULONG* pulReturnSizeRequired
        /// [out] Size of the GUID information.
        /// </param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        void GetRecorderGUID( ref IntPtr pbyUniqueID, uint ulBufferSize, out uint pulReturnSizeRequired );


        /// <summary>
        /// IDiscRecorder::GetRecorderType
        /// The GetRecorderType method indicates whether the disc recorder is
        /// a CD-R or CD-RW type device. This does not indicate the type of
        /// media that is currently inserted in the device.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_getrecordertype.asp
        /// </summary>
        /// <param name="fTypeCode">
        /// long* fTypeCode
        /// [out] One of the following values.
        /// RECORDER_CDR 	0x1
        /// RECORDER_CDRW 	0x2
        /// </param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        void GetRecorderType( out RecorderType fTypeCode );


        /// <summary>
        /// IDiscRecorder::GetDisplayNames
        /// The GetDisplayNames method returns a formatted name for the
        /// recorder that can be displayed. The name consists of the
        /// manufacturer and product identifier of the device.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_getdisplaynames.asp
        /// </summary>
        /// <param name="pbstrVendorID">
        /// BSTR* pbstrVendorID
        /// [out] Vendor of the disc recorder. This parameter can be NULL.
        /// </param>
        /// <param name="pbstrProductID">
        /// BSTR* pbstrProductID
        /// [out] Product name of the disc recorder. This parameter can be NULL.
        /// </param>
        /// <param name="pbstrRevision">
        /// BSTR* pbstrRevision
        /// [out] Revision of the disc recorder. This is typically the revision
        /// of the recorder firmware, but it can be a revision for the entire
        /// device. This parameter can be NULL.
        /// </param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        void GetDisplayNames( [MarshalAs( UnmanagedType.BStr )] ref string pbstrVendorID,
                              [MarshalAs( UnmanagedType.BStr )] ref string pbstrProductID,
                              [MarshalAs( UnmanagedType.BStr )] ref string pbstrRevision );


        /// <summary>
        /// IDiscRecorder::GetBasePnPID
        /// The GetBasePnPID method returns a base PnP string that can be
        /// used to consistently identify a specific class of device by
        /// make and model. The string can be used by applications to
        /// customize their behavior according to the specific recorder type.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_getbasepnpid.asp
        /// </summary>
        /// <param name="pbstrBasePnPID">
        /// BSTR* pbstrBasePnPID
        /// [out] Base PnP ID string. The string is a concatenation of a
        /// recorder's manufacturer, product ID, and revision information
        /// (if available).
        /// </param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        void GetBasePnPID( [MarshalAs( UnmanagedType.BStr )] out string pbstrBasePnPID );


        /// <summary>
        /// IDiscRecorder::GetPath
        /// The GetPath method returns a path to the device within the
        /// operating system. This path should be used in conjunction
        /// with the display name to Completely identify an available
        /// disc recorder.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_getpath.asp
        /// </summary>
        /// <param name="pbstrPath">
        /// BSTR* pbstrPath
        /// [out] Path to the disc recorder. This path may be of the form
        /// \Device\CdRomX, but you should not rely on the path following
        /// this convention.
        /// </param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        void GetPath( [MarshalAs( UnmanagedType.BStr )] out string pbstrPath );


        /// <summary>
        /// IDiscRecorder::GetRecorderProperties
        /// The GetRecorderProperties method returns a pointer to an
        /// IPropertyStorage interface.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_getrecorderproperties.asp
        /// </summary>
        /// <param name="pPropStg">
        /// IPropertyStorage** pPropStg
        /// [out] Pointer to an IPropertyStorage interface to the property
        /// set with all current properties defined.
        /// </param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        void GetRecorderProperties( out IPropertyStorage pPropStg );


        /// <summary>
        /// IDiscRecorder::SetRecorderProperties
        /// The SetRecorderProperties method accepts an IPropertyStorage
        /// pointer for an object with all the properties that the
        /// application wishes to change. Sparse settings are supported.
        /// It is reCommended, however, to query for a property set using
        /// GetRecorderProperties, modify only those settings of interest,
        /// and then call SetRecorderProperties to change all values
        /// simultaneously.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_setrecorderproperties.asp
        /// </summary>
        /// <param name="pPropStg">
        /// IPropertyStorage* pPropStg
        /// [in] Pointer to the IPropertyStorage interface that the
        /// disc recorder can use to retrieve new settings on various
        /// properties.
        /// </param>
        /// <exception cref="COMException">IMAPI_S_PROPERTIESIGNORED must be logged.</exception>
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="ArgumentNullException">RPC_X_NULL_REF_POINTER, This calls fails because a NULL pointer was passed.</exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        void SetRecorderProperties( [In] IPropertyStorage pPropStg );


        /// <summary>
        /// IDiscRecorder::GetRecorderState
        /// The GetRecorderState method indicates the disc recorder state.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_getrecorderstate.asp
        /// </summary>
        /// <param name="pulDevStateFlags">
        /// ULONG* pulDevStateFlags
        /// [out] One of the following values.
        /// RECORDER_BURNING 	0x2
        /// RECORDER_DOING_NOTHING 	0x0
        /// RECORDER_OPENED 	0x1
        /// </param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        void GetRecorderState( out RecorderState pulDevStateFlags );


        /// <summary>
        /// IDiscRecorder::OpenExclusive
        /// The OpenExclusive method opens a disc recorder for exclusive access.
        /// This method blocks file system access to a recorder through applications
        /// such as Explorer. The recorder must be opened with this method before it
        /// is possible to use the following methods: QueryMediaType, Eject, Erase,
        /// and Close.
        /// It is important to close the recorder before calling IDiscMaster::RecordDisc,
        /// or it will fail with IMAPI_E_DEVICE_NOTACCESSIBLE. The device is exclusively
        /// Committed to access through either IDiscRecorder or IDiscMaster, but not
        /// both at the same time. This is to ensure that there is no confusion regarding
        /// allowed operations and ownership of a recorder during application control or
        /// a burn.
        /// An exclusive lock should be held for as short a time as possible. Requests
        /// that Come from other operating system Components are not queued for later
        /// execution. Instead, they are simply failed. This could cause confusion with
        /// users who don't think a burn is in progress.
        /// Any time that OpenExclusive is called, it appears to the file system that the
        /// disc has been removed. When the corresponding Close call is made, it appears
        /// to the file system that the media has reappeared. This may cause auto-run issues.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_openexclusive.asp
        /// </summary>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DeviceNotAccessibleException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        void OpenExclusive();


        /// <summary>
        /// IDiscRecorder::QueryMediaType
        /// The QueryMediaType method detects the type of media currently
        /// inserted in the recorder, if any.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_querymediatype.asp
        /// </summary>
        /// <param name="fMediaType">
        /// long* fMediaType
        /// [out] If there is no media, both fMediaType and fMediaFlags are
        /// zero. If there is media, fMediaType contains one or more of the
        /// following values.
        /// MEDIA_CD_EXTRA 	4
        /// MEDIA_CD_I 	3
        /// MEDIA_CD_OTHER 	5
        /// MEDIA_CD_ROM_XA 	2
        /// MEDIA_CDDA_CDROM 	1
        /// MEDIA_SPECIAL 	6
        /// </param>
        /// <param name="fMediaFlags">
        /// long* fMediaFlags
        /// [out] If there is media, this parameter contains one or more
        /// of the following values.
        /// MEDIA_BLANK 	0x1
        /// MEDIA_RW 	0x2
        /// MEDIA_WRITABLE 	0x4
        /// </param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        void QueryMediaType( out MediaType fMediaType, out MediaFlag fMediaFlags );


        /// <summary>
        /// IDiscRecorder::QueryMediaInfo
        /// The QueryMediaInfo method returns information about the currently
        /// mounted media, such as the total number of blocks used on the media.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_querymediainfo.asp
        /// </summary>
        /// <param name="pbsessions">
        /// byte* pbsessions
        /// [out] Number of sessions on the disc.
        /// </param>
        /// <param name="pblasttrack">
        /// byte* pblasttrack
        /// [out] Track number of the last track of the previous session.
        /// </param>
        /// <param name="ulstartaddress">
        /// ULONG* ulstartaddress
        /// [out] Start address of the last track of the previous session.
        /// </param>
        /// <param name="ulnextwritable">
        /// ULONG* ulnextwritable
        /// [out] Address at which writing is to begin.
        /// </param>
        /// <param name="ulfreeblocks">
        /// ULONG* ulfreeblocks
        /// [out] Number of blocks available for writing.
        /// </param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="MediaNotPresentException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        void QueryMediaInfo( out byte pbsessions, out byte pblasttrack, out uint ulstartaddress, out uint ulnextwritable,
                             out uint ulfreeblocks );


        /// <summary>
        /// IDiscRecorder::Eject
        /// The Eject method unlocks and ejects the tray of the disc recorder,
        /// if possible.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_eject.asp
        /// </summary>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        void Eject();


        /// <summary>
        /// IDiscRecorder::Erase
        /// The Erase method attempts to erase the CD-RW media if this is a CD-RW
        /// disc recorder. Both full and quick erases are supported.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_erase.asp
        /// </summary>
        /// <param name="bFullErase">
        /// boolean bFullErase
        /// [in] Indicates the erase type. If this parameter is FALSE, a quick
        /// erase is performed. If this parameter is TRUE, a full erase is performed.
        /// </param>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="GenericUnexpectedUnexplainedException"></exception>
        /// <exception cref="MediaNotPresentException"></exception>
        /// <exception cref="InvalidMediaException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        /// <exception cref="InvalidDeviceTypeException"></exception>
        void Erase( int bFullErase );


        /// <summary>
        /// IDiscRecorder::Close
        /// The Close method releases exclusive access to a disc recorder.
        /// This restores file system access to the drive.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscrecorder_close.asp
        /// </summary>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        void Close();
    }
}