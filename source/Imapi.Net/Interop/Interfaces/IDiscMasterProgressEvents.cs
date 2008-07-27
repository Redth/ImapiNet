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

#endregion Using Directives

namespace Imapi.Net.Interop.Interfaces
{
    /// <summary>
    /// IDiscMasterProgressEvents
    /// The IDiscMasterProgressEvents interface provides a single interface for
    /// all callbacks that can be made from Imapi to an application. An
    /// application implements this interface on one of its objects and
    /// then registers it using IDiscMaster::ProgressAdvise. All but one
    /// of the methods in this interface are related to progress during staging
    /// or burns. Even if an application is not interested in a particular
    /// callback, it must implement the callback function and return E_NOTIMPL
    /// on the call.
    /// Methods in Vtable Order
    /// The IDiscMasterProgressEvents interface inherits the methods of the
    /// standard Com interface IUnknown.  
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmasterprogressevents.asp
    /// </summary>
    [ComImport]
    [Guid( "EC9E51C1-4E5D-11D3-9144-00104BA11C5E" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IDiscMasterProgressEvents
    {
        //    MIDL_INTERFACE("EC9E51C1-4E5D-11D3-9144-00104BA11C5E")
        //    IDiscMasterProgressEvents : public IUnknown
        //    {
        //    public:
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE QueryCancel( 
        //            /* [retval][out] */ boolean *pbCancel) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE NotifyPnPActivity( void) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE NotifyAddProgress( 
        //            /* [in] */ long nCompletedSteps,
        //            /* [in] */ long nTotalSteps) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE NotifyBlockProgress( 
        //            /* [in] */ long nCompleted,
        //            /* [in] */ long nTotal) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE NotifyTrackProgress( 
        //            /* [in] */ long nCurrentTrack,
        //            /* [in] */ long nTotalTracks) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE NotifyPreparingBurn( 
        //            /* [in] */ long nEstimatedSeconds) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE NotifyClosingDisc( 
        //            /* [in] */ long nEstimatedSeconds) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE NotifyBurnComplete( 
        //            /* [in] */ HRESULT status) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE NotifyEraseComplete( 
        //            /* [in] */ HRESULT status) = 0;
        //    };

        /// <summary>
        /// IDiscMasterProgressEvents::QueryCancel
        /// The QueryCancel method is called by Imapi to check whether an
        /// AddData, AddAudioTrackBlocks, or RecordDisc operation should be
        /// canceled.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmasterprogressevents_querycancel.asp
        /// </summary>
        /// <param name="pbCancel">
        /// boolean* pbCancel
        /// [out] If this parameter is TRUE, cancel the burn. If this parameter
        /// is FALSE, continue the burn.
        /// </param>
        void QueryCancel( out int pbCancel );


        /// <summary>
        /// IDiscMasterProgressEvents::NotifyPnPActivity
        /// The NotifyPnPActivity method is called by Imapi to notify the
        /// application that there is a change to the list of valid disc
        /// recorders. (For example, a USB CD-R driver is removed from the
        /// system.)
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmasterprogressevents_notifypnpactivity.asp
        /// </summary>
        void NotifyPnPActivity();


        /// <summary>
        /// IDiscMasterProgressEvents::NotifyAddProgress
        /// The NotifyAddProgress method is called by Imapi to notify an
        /// application of its progress in response to calls to
        /// IRedbookDiscMaster::AddAudioTrackBlocks or
        /// IJolietDiscMaster::AddData. Notifications are sent for the
        /// first and last steps, and at points in between.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmasterprogressevents_notifyaddprogress.asp
        /// </summary>
        /// <param name="nCompletedSteps">
        /// long nCompletedSteps
        /// [in] Number of arbitrary steps that have been Completed in
        /// adding audio or data to a staged image.
        /// </param>
        /// <param name="nTotalSteps">
        /// long nTotalSteps
        /// [in] Total number of arbitrary steps that must be taken to
        /// add a full set of audio or data to the staged image.
        /// </param>
        void NotifyAddProgress( int nCompletedSteps, int nTotalSteps );


        /// <summary>
        /// IDiscMasterProgressEvents::NotifyBlockProgress
        /// The NotifyBlockProgress method is called by Imapi to notify an
        /// application of its progress in burning a disc on the active
        /// recorder. Notifications are sent for the first and last blocks,
        /// and at points in between.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmasterprogressevents_notifyblockprogress.asp
        /// </summary>
        /// <param name="nCompleted">
        /// long nCompleted
        /// [in] Number of blocks that have been burned onto a disc or
        /// track so far.
        /// </param>
        /// <param name="nTotal">
        /// long nTotal
        /// [in] Total number of blocks to be burned to finish a disc
        /// or track.
        /// </param>
        void NotifyBlockProgress( int nCompleted, int nTotal );


        /// <summary>
        /// IDiscMasterProgressEvents::NotifyTrackProgress
        /// The NotifyTrackProgress method is called by Imapi during
        /// the burn of an audio disc to notify an application that
        /// a track has started or finished.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmasterprogressevents_notifytrackprogress.asp
        /// </summary>
        /// <param name="nCurrentTrack">
        /// long nCurrentTrack
        /// [in] Number of tracks that have been Completely burned.
        /// </param>
        /// <param name="nTotalTrack">
        /// [in] Total number of tracks that must be burned.
        /// </param>
        void NotifyTrackProgress( int nCurrentTrack, int nTotalTrack );


        /// <summary>
        /// IDiscMasterProgressEvents::NotifyPreparingBurn
        /// The NotifyPreparingBurn method is called by Imapi to
        /// notify the application that it is preparing to burn a disc.
        /// No further notifications are sent until the burn starts.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmasterprogressevents_notifypreparingburn.asp
        /// </summary>
        /// <param name="nEstimatedSeconds">
        /// long nEstimatedSeconds
        /// [in] Number of seconds from notification that Imapi estimates
        /// it will take to prepare to burn the disc.
        /// </param>
        void NotifyPreparingBurn( int nEstimatedSeconds );


        /// <summary>
        /// IDiscMasterProgressEvents::NotifyClosingDisc
        /// The NotifyClosingDisc method is called by Imapi to notify the
        /// application that it is has started closing the disc. No further
        /// notifications are sent until the burn is finished.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmasterprogressevents_notifyclosingdisc.asp
        /// </summary>
        /// <param name="nEstimatedSeconds">
        /// long nEstimatedSeconds
        /// [in] Number of seconds from notification that Imapi estimates
        /// it will take to close the disc.
        /// </param>
        void NotifyClosingDisc( int nEstimatedSeconds );


        /// <summary>
        /// IDiscMasterProgressEvents::NotifyBurnComplete
        /// The NotifyBurnComplete method is called by Imapi to notify an
        /// application that a call to IDiscMaster::RecordDisc has finished.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmasterprogressevents_notifyburnComplete.asp
        /// </summary>
        /// <param name="status">
        /// HRESULT status
        /// [in] Status code to be returned from IDiscMaster::RecordDisc.
        /// </param>
        void NotifyBurnComplete( IntPtr status );


        /// <summary>
        /// IDiscMasterProgressEvents::NotifyEraseComplete
        /// The NotifyEraseComplete method is called by Imapi to notify an
        /// application that a call to IDiscRecorder::Erase has finished.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/idiscmasterprogressevents_notifyeraseComplete.asp
        /// </summary>
        /// <param name="status">
        /// HRESULT status
        /// [in] Status code to be returned from IDiscRecorder::Erase.
        /// </param>
        void NotifyEraseComplete( IntPtr status );
    }
}