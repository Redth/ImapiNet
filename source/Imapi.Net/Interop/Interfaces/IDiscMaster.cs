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
using Imapi.Net.Interop.Exceptions;

#endregion Using Directives

namespace Imapi.Net.Interop.Interfaces
{
    /// <summary>
    /// The IDiscMaster interface allows an application to reserve an
    /// image mastering API, enumerate disc mastering formats and disc
    /// recorders supported by an image mastering object, and start a
    /// simulated or actual burn of a disc. Although an image mastering
    /// object can support several formats, it may not be possible to
    /// access all formats through a specific recorder. For this reason,
    /// you must select a recorder with SetActiveDiscRecorder after
    /// selecting a format with SetActiveDiscMasterFormat.
    /// Header Declared in Imapi.h.
    /// Library Link to Uuid.lib.
    /// DLL Requires Actxprxy.dll.  
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster.asp
    /// </summary>
    [ComImport]
    [Guid( "520CCA62-51A5-11D3-9144-00104BA11C5E" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IDiscMaster
    {
        //    MIDL_INTERFACE("520CCA62-51A5-11D3-9144-00104BA11C5E")
        //    IDiscMaster : public IUnknown
        //    {
        //    public:
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Open( void) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE EnumDiscMasterFormats( 
        //            /* [out] */ IEnumDiscMasterFormats **ppEnum) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetActiveDiscMasterFormat( 
        //            /* [out] */ LPIID lpiid) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetActiveDiscMasterFormat( 
        //            /* [in] */ REFIID riid,
        //            /* [iid_is][out] */ void **ppUnk) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE EnumDiscRecorders( 
        //            /* [out] */ IEnumDiscRecorders **ppEnum) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetActiveDiscRecorder( 
        //            /* [out] */ IDiscRecorder **ppRecorder) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetActiveDiscRecorder( 
        //            /* [in] */ IDiscRecorder *pRecorder) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ClearFormatContent( void) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ProgressAdvise( 
        //            /* [in] */ IDiscMasterProgressEvents *pEvents,
        //            /* [retval][out] */ UINT_PTR *pvCookie) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ProgressUnadvise( 
        //            /* [in] */ UINT_PTR vCookie) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE RecordDisc( 
        //            /* [in] */ boolean bSimulate,
        //            /* [in] */ boolean bEjectAfterBurn) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Close( void) = 0;
        //    };


        /// <summary>
        /// Opens an upper-level Imapi object for access by a client application.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_open.asp
        /// </summary>
        /// <exception cref="DiscMasterAlreadyOpenedException"></exception>
        void Open();


        /// <summary>
        /// Retrieves an enumerator for all disc mastering formats
        /// supported by this disc master object. A disc master format
        /// specifies the structure of the content in a staged image file
        /// (data/audio) and the interface that manages the staged image.
        /// MSDiscMasterObj returns an enumerator that identifies the supported
        /// formats by their interface IDs. Currently, there are two formats:
        /// IRedbookDiscMasterGUID ( <see cref="IRedbookDiscMaster"/>) and IJolietDiscMasterGUID
        /// ( <see cref="IJolietDiscMaster"/>).
        /// <see cref="IEnumDiscMasterFormats"/> is standard Com enumerator, as documented in
        /// <c>IEnumXXXX</c>. Each call to Next returns an array of IIDs, one IID per
        /// supported disc master format. To select the active format and retrieve
        /// a pointer to a format specific interface, use <see cref="SetActiveDiscMasterFormat"/>.
        /// (Do not use QueryInterface, because the interface will not be associated
        /// with the active format).
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_enumdiscmasterformats.asp
        /// </summary>
        /// <param name="ppEnum">
        /// IEnumDiscMasterFormats** ppEnum
        /// [out] Address of a pointer to the IEnumDiscMasterFormats enumerator.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void EnumDiscMasterFormats( out IEnumDiscMasterFormats ppEnum );


        /// <summary>
        /// Retrieves the active disc recorder format. The active format
        /// specifies both the structure of the staged image file content
        /// (audio/data) and the Com interface that must be used to manipulate
        /// that staged image.
        /// MSDiscMasterObj supports the IIDs for two formats:
        /// IRedbookDiscMasterGUID (<see cref="IRedbookDiscMaster"/>) and
        /// IJolietDiscMasterGUID (<see cref="IJolietDiscMaster"/>). To select the active
        /// format and retrieve a pointer to a format-specific interface, use
        /// SetActiveDiscMasterFormat.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_getactivediscmasterformat.asp
        /// </summary>
        /// <param name="lpiid">
        /// LPIID lpiid
        /// [out] IID of the currently active format.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        void GetActiveDiscMasterFormat( out Guid lpiid );


        /// <summary>
        /// Sets the currently active disc recorder format. The active format
        /// specifies both the structure of the staged image file content
        /// (audio/data) and the Com interface that must be used to manipulate
        /// that staged image.
        /// A successful call to this method clears the contents of the currently
        /// staged image. In addition, it may change the list of supported disc
        /// recorders. This is because not all recorders support all formats.
        /// Changes to the recorder list are announced with <see cref="IDiscMasterProgressEvents.NotifyPnPActivity"/>.
        /// If the currently selected recorder is not a member of the new set of supported
        /// devices, then there will no longer be an active recorder (similar to the state
        /// after the first call to Open). In this case, the application must select a new
        /// active recorder before initiating a burn.
        /// MSDiscMasterObj supports only the following IIDs: IRedbookDiscMasterGUID
        /// (<see cref="IRedbookDiscMaster"/>) and IJolietDiscMasterGUID (<see cref="IJolietDiscMaster"/>). If
        /// there is no format set, the default is <c>Joliet</c> format. It is the
        /// responsibility of every application to select a format master
        /// through the use of EnumDiscMasterFormats and this method.
        /// Note that a call to this method may change the list of available
        /// recorders. See the Remarks section of <see cref="EnumDiscRecorders"/> for more
        /// information.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_setactivediscmasterformat.asp
        /// </summary>
        /// <param name="riid">
        /// REFIID riid
        /// [in] IID of the currently active format.
        /// </param>
        /// <param name="ppUnk">
        /// void** ppUnk
        /// [out] Pointer to the Com interface for the new disc format.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void SetActiveDiscMasterFormat( ref Guid riid, [MarshalAs( UnmanagedType.IUnknown )] out object ppUnk );


        /// <summary>
        /// Retrieves an enumerator for all disc recorders supported by the
        /// active disc master format.
        /// The list of available recorders may change due to Plug and Play
        /// arrivals or departures, or a call to <see cref="SetActiveDiscMasterFormat"/>.
        /// An application is notified of these changes when it receives a
        /// call to <see cref="IDiscMasterProgressEvents.NotifyPnPActivity"/>. When a change
        /// occurs, the application should call this method again to retrieve
        /// a new enumerator, because each enumerator contains a snapshot of
        /// the devices supported at the time of the enumeration.
        /// When a device is removed, its pointer and <see cref="IDiscRecorder"/> interface
        /// must remain valid even though the underlying physical device is
        /// missing. In this case, operations on an <see cref="IDiscRecorder"/> or a request
        /// to record a disc may return IMAPI_E_DEVICE_NOTPRESENT.
        /// The MaxWriteSpeed property is updated when this method is called.
        /// The default setting is the highest available write speed.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_enumdiscrecorders.asp
        /// </summary>
        /// <param name="ppEnum">
        /// <see cref="IEnumDiscRecorders"/> ppEnum
        /// [out] Address of a pointer to the <see cref="IEnumDiscRecorders"/> enumerator.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        void EnumDiscRecorders( out IEnumDiscRecorders ppEnum );


        /// <summary>
        /// Retrieves an interface pointer to the active disc recorder. The active
        /// disc recorder is the recorder where a burn will occur when <see cref="RecordDisc"/>
        /// is called.
        /// There is no default active disc recorder. An application using this
        /// method must specifically select both an active mastering format and an
        /// active disc recorder before initiating a burn.
        /// Note: The active disc recorder can be invalidated by removing the device
        /// or changing the active disc mastering format. For example, a USB CD-R
        /// device may be disconnected from the machine while the application is still
        /// running (the application is alerted to this condition by a call to
        /// <see cref="IDiscMasterProgressEvents.NotifyPnPActivity"/>). In either case, you must select
        /// a new active disc recorder.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_getactivediscrecorder.asp
        /// </summary>
        /// <param name="ppRecorders">
        /// IDiscRecorder** ppRecorder
        /// [out] Pointer to the IDiscRecorder interface of the currently selected
        /// disc recorder.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="NoActiveRecorderException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        void GetActiveDiscRecorder( out IDiscRecorder ppRecorders );


        /// <summary>
        /// selects an active disc recorder. The active disc recorder is the recorder
        /// where a burn will occur when <see cref="RecordDisc"/> is called.
        /// SetActiveDiscRecorder must be called after the media to be used has been
        /// inserted, and before calling <see cref="IJolietDiscMaster.AddData"/>.
        /// Selecting a recorder while in an active Joliet format will cause Imapi to
        /// read information from the currently installed recorder disc. If this disc
        /// is a previous Imapi Joliet disc and has space for another session, Imapi
        /// automatically sets itself to multi-session mode. This disc must be in the
        /// active recorder when <see cref="RecordDisc"/> is called.
        /// The MaxWriteSpeed property is updated when this method is called. The
        /// default setting is the highest write speed.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_setactivediscrecorder.asp
        /// </summary>
        /// <param name="pRecorder">
        /// <see cref="IDiscRecorder"/> pRecorder
        /// [in] Pointer to the <see cref="IDiscRecorder"/> interface of a disc recorder object.
        /// This pointer should have been returned by a previous call to <see cref="EnumDiscRecorders"/>.
        /// </param>
        /// <exception cref="DeviceNotPresentException"></exception>
        /// <exception cref="DiscFullException"></exception>
        /// <exception cref="MediaNotPresentException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="StashInUseException"></exception>
        void SetActiveDiscRecorder( [In] IDiscRecorder pRecorder );


        /// <summary>
        /// Clears the contents of an unburned image (the current stash file).
        /// The stash file is an internal structure that is used to stage a disc before
        /// recording it to media.
        /// <see cref="SetActiveDiscRecorder"/> determines if there is an Imapi multi-session disc in
        /// the active drive. If so, Imapi enters multi-session mode automatically.
        /// Using ClearFormatContent after multi-session mode had been established causes
        /// Imapi to return to single-session mode. This means that a blank disc is
        /// required for a <see cref="RecordDisc"/> burn.
        /// Caution  Use care when calling this method. There is no confirmation and no
        /// recovery. If an application fills the image file with data, then calls this
        /// method, the data is gone.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_clearformatcontent.asp
        /// </summary>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void ClearFormatContent();


        /// <summary>
        /// Registers an application for progress notifications.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_progressadvise.asp
        /// </summary>
        /// <param name="pEvents">
        /// <see cref="IDiscMasterProgressEvents"/> pEvents
        /// [in] Pointer to an <see cref="IDiscMasterProgressEvents"/> interface that receives the
        /// progress notifications.
        /// </param>
        /// <param name="pnCookie">
        /// UINT_PTR* pnCookie
        /// Perhaps try uint - I have not seen UINT_PTR before so I default to <see cref="IntPtr"/>
        /// This must match nCookie from <see cref="ProgressUnadvise"/>
        /// [out] Uniquely identifies this registration. Save this value because it
        /// will be needed by the <see cref="ProgressUnadvise"/> method.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void ProgressAdvise( IDiscMasterProgressEvents pEvents, out IntPtr pnCookie );


        /// <summary>
        /// Cancels progress notifications for an application.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_progressunadvise.asp
        /// </summary>
        /// <param name="nCookie">
        /// UINT_PTR nCookie
        /// Perhaps try uint - I have not seen UINT_PTR before so I default to IntPtr
        /// This must match pnCookie from <see cref="ProgressAdvise"/>
        /// [in] Value returned by a previous call to the <see cref="ProgressAdvise"/> method.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void ProgressUnadvise( IntPtr nCookie );


        /// <summary>
        /// Burns the staged image to media in the active disc recorder.
        /// This method returns when the burn is Complete, although progress callbacks
        /// are made if registered with the <see cref="ProgressAdvise"/> method. Any errors cause
        /// this method to return, with little or no corrective action on the part of
        /// this method.
        /// The staged image data is not valid after a call to RecordDisc. This allows
        /// the application to perform either a simulated or actual burn of the media.
        /// For security, the contents of the stash file are cleared automatically after
        /// successful Completion of the first call to this method. A disc must be
        /// re-staged to burn it again.
        /// The RecordDisc method expects to work with blank media for audio. Otherwise,
        /// the media may need to be erased (for example, CD-RW media in a CD-RW drive).
        /// See <see cref="IDiscRecorder.Erase"/>.
        /// The <see cref="SetActiveDiscRecorder"/> method determines if there is an Imapi multi-session
        /// disc in the active drive upon setting. If so, Imapi goes into multi-session
        /// mode automatically. If in multi-session mode and a call is made to RecordDisc,
        /// the same disc that established multi-session mode must be in the active
        /// recorder or an error code of IMAPI_E_WRONGDISC will be returned.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_recorddisc.asp
        /// </summary>
        /// <param name="bSimulate">
        /// boolean <c>bSimulate</c>
        /// [in] Indicates whether the media is burned. If this parameter is TRUE,
        /// media in the active disc recorder is not actually burned. Instead, a simulated
        /// burn is performed. The simulation is a good test of a disc recorder, because
        /// most of the operations are performed as in a real burn. If this parameter is
        /// FALSE, then the media in the recorder is actually burned.
        /// </param>
        /// <param name="bEjectAfterBurn">
        /// boolean <c>bEjectAfterBurn</c>
        /// [in] Indicates whether to eject the media after the burn. If this parameter
        /// is TRUE, the media is ejected. If this parameter is FALSE, the media is not
        /// ejected.
        /// </param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException">
        /// The call failed because IMAPI has not been opened with Open.
        /// </exception>
        /// <exception cref="WrongDiscException">
        /// The call failed because when the active recorder was selected, a previous IMAPI disc was detected and a multi-session session was established. RecordDisc has detected that this disc is no longer in the active recorder.
        /// </exception>
        /// <exception cref="NoActiveFormatException">
        /// A disc mastering format has not been chosen using <see cref="SetActiveDiscMasterFormat"/>.
        /// </exception>
        /// <exception cref="NoActiveRecorderException">
        /// An active recorder has not been chosen using <see cref="SetActiveDiscRecorder"/>.
        /// </exception>
        /// <exception cref="UserAbortException">
        /// The recording was canceled during a progress callback by a TRUE return from a call to IDiscMasterProgressEvents::QueryCancel.
        /// </exception>
        /// <exception cref="GenericUnexpectedUnexplainedException">
        /// An unexpected and unexplained failure ended the recording.
        /// </exception>
        /// <exception cref="MediaNotPresentException">
        /// There is no media in the active disc recorder. The application should prompt for media from the user, then retry the call to RecordDisc. There is no preferred mechanism for performing this task. The media should be ejected and a dialog box should be presented to the user. The media status could be checked again once the dialog box is dismissed, or an application could poll (for example, once per second) to check if media has been inserted.
        /// </exception>
        /// <exception cref="DeviceNotAccessibleException">
        /// Another application or IMAPI engine has reserved the active disc recorder. Try again later.
        /// </exception>
        /// <exception cref="DeviceNotPresentException">
        /// The currently active disc recorder has been invalidated because the device was removed from the system. Choose a new active recorder using SetActiveDiscRecorder.
        /// </exception>
        /// <exception cref="InitializeWriteException">
        /// An error occurred while setting up the active disc recorder for a write.
        /// </exception>
        /// <exception cref="InitializeCloseException">
        /// An error occurred while setting up the active disc recorder to close the disc.
        /// </exception>
        /// <exception cref="FileSystemAccessException">
        /// Access to the active disc recorder through the operating system has prevented IMAPI from reserving the disc recorder for exclusive use. Try again later.
        /// </exception>
        /// <exception cref="DiscInfoException">
        /// An error occurred while attempting to access the media inserted into the active disc recorder.
        /// </exception>
        /// <exception cref="TrackOpenException">
        /// A audio track is currently open. Close the currently open track before recording the disc.
        /// </exception>
        /// <exception cref="InvalidImageException">
        /// The image file is empty or corrupted. In either case, there is no usable content and the record operation has been canceled.
        /// </exception>
        /// <exception cref="ContentStreamingException">
        /// Content streaming was lost; a buffer under-run may have occurred.
        /// </exception>
        /// <exception cref="CompressedStashException">
        /// The stash is located on a compressed volume and cannot be read.
        /// </exception>
        /// <exception cref="EncryptedStashException">
        /// The stash is located on an encrypted volume and cannot be read.
        /// </exception>
        /// <exception cref="NotEnoughDiskForStashException">
        /// There is not enough free space to create the stash file on the specified volume.
        /// </exception>
        /// <exception cref="RemovableStashException">
        /// The specified stash location is a removable media.
        /// </exception>
        void RecordDisc( int bSimulate, int bEjectAfterBurn );


        /// <summary>
        /// Closes the interface so other applications can use it.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmaster_close.asp
        /// </summary>
        void Close();
    }
}