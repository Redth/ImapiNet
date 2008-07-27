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
    /// The IRedbookDiscMaster interface enables the staging of an
    /// audio CD image. It represents one of the formats supported by
    /// MSDiscMasterObj, and it allows the creation of multi-track audio
    /// discs in Track-at-Once mode (fixed-size audio gaps).
    /// Tracks are created in the stash file, data is added to them, 
    /// and then they are closed. Only one track is staged at a time;
    /// this is called the open track. The remaining tracks are closed and
    /// Committed to the image, while the open track has available to it
    /// all the blocks that are not in use by closed tracks.
    /// When To Use
    /// Use this interface to stage a Redbook audio image.
    /// The IRedbookDiscMaster interface inherits the methods of the
    /// standard Com interface IUnknown.
    /// Imapi's IRedbookMaster is only capable of accepting 44.1,
    /// KHz 16 bit raw audio. This is essentially a typical PCM wav file.
    /// Header Declared in Imapi.h.
    /// Library Link to Uuid.lib.
    /// DLL Requires Actxprxy.dll.  
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/iredbookdiscmaster.asp
    /// </summary>
    [ComImport]
    [Guid( "E3BC42CD-4E5C-11D3-9144-00104BA11C5E" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IRedbookDiscMaster
    {
        //    MIDL_INTERFACE("E3BC42CD-4E5C-11D3-9144-00104BA11C5E")
        //    IRedbookDiscMaster : public IUnknown
        //    {
        //    public:
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetTotalAudioTracks( 
        //            /* [retval][out] */ long *pnTracks) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetTotalAudioBlocks( 
        //            /* [retval][out] */ long *pnBlocks) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetUsedAudioBlocks( 
        //            /* [retval][out] */ long *pnBlocks) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetAvailableAudioTrackBlocks( 
        //            /* [retval][out] */ long *pnBlocks) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetAudioBlockSize( 
        //            /* [retval][out] */ long *pnBlockBytes) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CreateAudioTrack( 
        //            /* [in] */ long nBlocks) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE AddAudioTrackBlocks( 
        //            /* [size_is][in] */ byte *pby,
        //            /* [in] */ long cb) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CloseAudioTrack( void) = 0;
        //    };

        /// <summary>
        /// Returns the total number of tracks that have either
        /// been staged or are being staged.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/iredbookdiscmaster_gettotalaudiotracks.asp
        /// </summary>
        /// <param name="pnTracks">
        /// long* pnTracks
        /// [out] Total number of closed and open tracks.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void GetTotalAudioTracks( out int pnTracks );


        /// <summary>
        /// Returns the total number of blocks available for
        /// staging audio tracks. The total includes all block
        /// types, including blocks that may need to be allocated
        /// for track gaps.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/iredbookdiscmaster_gettotalaudioblocks.asp
        /// </summary>
        /// <param name="pnBlocks">
        /// long* pnBlocks
        /// [out] Total number of audio blocks available on a disc.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void GetTotalAudioBlocks( out int pnBlocks );


        /// <summary>
        /// Returns the total number of audio blocks in use.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/iredbookdiscmaster_getusedaudioblocks.asp
        /// </summary>
        /// <param name="pnBlocks">
        /// long* pnBlocks
        /// [out] Total number of blocks in use, in both closed and open tracks.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void GetUsedAudioBlocks( out int pnBlocks );


        /// <summary>
        /// Retrieves the current number of blocks that can be added to
        /// the track before an additional add will cause a failure for
        /// lack of space.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/iredbookdiscmaster_getavailableaudiotrackblocks.asp
        /// </summary>
        /// <param name="pnBlocks">
        /// long* pnBlocks
        /// [out] Number of audio blocks that can be added to the open
        /// track before it must be closed.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void GetAvailableAudioTrackBlocks( out int pnBlocks );


        /// <summary>
        /// Returns the size, in bytes, of an audio block.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/iredbookdiscmaster_getaudioblocksize.asp
        /// </summary>
        /// <param name="pnBlockBytes">
        /// long* pnBlockBytes
        /// [out] Total size, in bytes, of a single audio block.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void GetAudioBlockSize( out int pnBlockBytes );


        /// <summary>
        /// Called to begin staging a new audio track. It can be called
        /// only when there are no open audio tracks in the image.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/iredbookdiscmaster_createaudiotrack.asp
        /// </summary>
        /// <param name="nBlocks">
        /// long nBlocks
        /// [in] Number of audio blocks to be added to this track. You can
        /// create up to 99 tracks, and the open track may consume all
        /// remaining available audio blocks.
        /// The nBlocks parameter is advisory only. It does not force the
        /// track length to this size.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="rackOpenException"></exception>
        void CreateAudioTrack( int nBlocks );


        /// <summary>
        /// Adds blocks of audio data to the currently open track. This
        /// method can be called repeatedly until there is no space available
        /// or the track is full.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/iredbookdiscmaster_addaudiotrackblocks.asp
        /// </summary>
        /// <param name="pby">
        /// byte* pby
        /// Although the marshal site says Byte, we need an array.
        /// TODO: Follow up and test.
        /// [in] Pointer to an array of track blocks. The format is 44.1 KHz,
        /// 16-bit stereo RAW audio samples, in the same format as used by WAV
        /// in the data section.
        /// </param>
        /// <param name="cb">
        /// [in] Size of the array, in bytes. This count must be a multiple
        /// of the audio block size.
        /// </param>
        /// <exception cref="COMException">The byte count is wrong</exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="TrackNotOpenException"></exception>
        /// <exception cref="DiscFullException"></exception>
        void AddAudioTrackBlocks( IntPtr pby, int cb );


        /// <summary>
        /// Closes a currently open audio track. All audio tracks must
        /// be closed before the IDiscMaster::RecordDisc method can be
        /// called.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/iredbookdiscmaster_closeaudiotrack.asp
        /// </summary>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="TrackNotOpenException"></exception>
        void CloseAudioTrack();
    }
}