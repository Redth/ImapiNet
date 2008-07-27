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
using Imapi.Net.ObjectModel;
using Imapi.Net.Properties;
using Imapi.Net.Interop.Interfaces;
using Imapi.Net;

#endregion Using Directives

namespace Imapi.Net
{
    /// <summary>
    /// Implementation of IDiscMasterProgressEvents.  This implementation
    /// simply transfers the event calls to the owning <see cref="DiscMaster"/>
    /// object from where they are raised as events.  The cookie is also
    /// stored.  Effectively, this class is immutable, however, the cookie
    /// has to be written after construction and therefore there is  set
    /// method.
    /// </summary>
    [Guid( "0E817968-4B3F-42d5-B2F8-51E0113D12CE" )]
    [ComVisible( true )]
    internal class DiscMasterProgressEvents : Disposable, IDiscMasterProgressEvents
    {
        #region Private Member Variables

        private IntPtr _cookie;
        private DiscMaster _owner;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="owner">DiscMaster which will be called to receive
        /// events.</param>
        public DiscMasterProgressEvents( DiscMaster owner )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( "owner" );
            }

            _cookie = IntPtr.Zero;
            _owner = owner;
        } // End DiscMasterProgressEvents(DiscMaster owner)


        // End ~DiscMasterProgressEvents


        /// <summary>
        /// Called to request whether the burn event should be cancelled
        /// </summary>
        /// <param name="pbCancel"></param>
        public void QueryCancel( out int pbCancel )
        {
            _owner.QueryCancelRequest( out pbCancel );
        } // End QueryCancel(out int pbCancel)


        /// <summary>
        /// Notifies that a Plug and Play activity has occurred that has changed the list of recorders.
        /// </summary>
        public void NotifyPnPActivity()
        {
            _owner.NotifyPNPActivity();
        } // End NotifyPnPActivity()


        /// <summary>
        /// Notifies addition of data to the CD image in the stash.
        /// </summary>
        public void NotifyAddProgress( int nCompleted, int nTotal )
        {
            _owner.NotifyAddProgress( nCompleted, nTotal );
        } // End NotifyAddProgress(int nCompleted, int nTotal)


        /// <summary>
        /// Notifies an application of block progress whilst burning a disc.
        /// </summary>
        public void NotifyBlockProgress( int nCurrentBlock, int nTotalBlocks )
        {
            _owner.NotifyBlockProgress( nCurrentBlock, nTotalBlocks );
        } // End NotifyBlockProgress(int nCurrentBlock, int nTotalBlocks)


        /// <summary>
        /// Notifies an application of track progress whilst burning an audio disc.
        /// </summary>
        public void NotifyTrackProgress( int nCurrentTrack, int nTotalTracks )
        {
            _owner.NotifyTrackProgress( nCurrentTrack, nTotalTracks );
        } // End NotifyTrackProgress(int nCurrentTrack, int nTotalTracks)


        /// <summary>
        /// Notifies an application that Imapi is preparing to burn a disc.
        /// </summary>
        public void NotifyPreparingBurn( int nEstimatedSeconds )
        {
            _owner.NotifyPreparingBurn( nEstimatedSeconds );
        } // End NotifyPreparingBurn(int nEstimatedSeconds)


        /// <summary>
        /// Notifies an application that Imapi is closing a disc.
        /// </summary>
        public void NotifyClosingDisc( int nEstimatedSeconds )
        {
            _owner.NotifyClosingDisc( nEstimatedSeconds );
        } // End NotifyClosingDisc(int nEstimatedSeconds)


        /// <summary>
        /// Notifies an application that Imapi has Completed burning a disc.
        /// </summary>
        public void NotifyBurnComplete( IntPtr status )
        {
            _owner.NotifyBurnComplete( status );
        } // End NotifyBurnComplete(IntPtr status)


        /// <summary>
        /// Notifies an application that Imapi has Completed erasing a disc.
        /// </summary>
        public void NotifyEraseComplete( IntPtr status )
        {
            _owner.NotifyEraseComplete( status );
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Imapi.Net.DiscMasterProgressEvents"/> is reclaimed by garbage collection.
        /// </summary>
        ~DiscMasterProgressEvents()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose( false );
        }

// End NotifyEraseComplete(IntPtr status)

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
            if ( disposing && !IsDisposed )
            {
                // Dispose managed resources.
                _owner = null;
                _cookie = IntPtr.Zero;

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
            } // End if(!_disposed)
            base.Dispose( disposing );
        }

        #region Public Properties

        /// <summary>
        /// Gets/sets the cookie associated with this implementation.  A
        /// cookie is provided by Imapi whenever an IDiscMasterProgressEvents
        /// implementation is associated with an IDiscMaster object.  In
        /// order to release the implementation again, the cookie must
        /// be provided.  The cookie can only be set once in the lifetime
        /// of this object.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <value>The cookie.</value>
        public IntPtr Cookie
        {
            get { return _cookie; } // End get

            set
            {
                if ( !_cookie.Equals( IntPtr.Zero ) )
                {
                    throw new InvalidOperationException( Resources.Error_Msg_DiscMasterProgressEvents_CookiePrevSet );
                } // End if
                _cookie = value;
            } // End set
        } // End Property Cookie

        #endregion Public Properties
    }
}