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
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using Imapi.Net.Interop;
using Imapi.Net.ObjectModel;
using Imapi.Net.Properties;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Exceptions;
using Imapi.Net.Interop.Interfaces;

#endregion Using Directives

namespace Imapi.Net
{
    /// <summary>
    /// Summary description for DiscMaster.
    /// </summary>
    public class DiscMaster : Disposable
    {
        private readonly object _syncRoot = new object();
        private IDiscMaster _discMaster;
        private DiscRecorderCollection _discRecorders;
        private bool _jolietAddDataCancel;
        private JolietDiscMaster _jolietDiscMaster;
        private DiscMasterProgressEvents _progressEvents;
        private RedbookDiscMaster _redbookDiscMaster;

        #region Events

        /// <summary>
        /// Raised to request whether to cancel staging an image or burning a CD.
        /// </summary>
        public event EventHandler<QueryCancelEventArgs> QueryCancel;


        /// <summary>
        /// Raised when a Plug'n'Play event occurs on this system that changes
        /// the list of available drives.
        /// </summary>
        public event EventHandler<EventArgs> PnpActivity;


        /// <summary>
        /// Raised during staging of the disc as data is added to the staging area.
        /// </summary>
        public event EventHandler<ProgressEventArgs> AddProgress;


        /// <summary>
        /// Raised during writing of a disc as blocks are added to the disc.
        /// </summary>
        public event EventHandler<ProgressEventArgs> BlockProgress;


        /// <summary>
        /// Raised during writing of an audio disc as tracks are added to the disc.
        /// </summary>
        public event EventHandler<ProgressEventArgs> TrackProgress;


        /// <summary>
        /// Raised when disc is about to be prepared for burning.
        /// </summary>
        public event EventHandler<EstimatedTimeOperationEventArgs> PreparingBurn;


        /// <summary>
        /// Raised when the disc is about to be finalised.
        /// </summary>
        public event EventHandler<EstimatedTimeOperationEventArgs> ClosingDisc;


        /// <summary>
        /// Raised when a burn operation has Completed.
        /// </summary>
        public event EventHandler<CompletionStatusEventArgs> BurnComplete;


        /// <summary>
        /// Raised when an erase operation has Completed.
        /// </summary>
        public event EventHandler<CompletionStatusEventArgs> EraseComplete;

        #endregion

        #region Public Methods and Constructors

        /// <summary>
        /// Constructs a new instance of this class.
        /// </summary>
        /// <exception cref="COMException">if the System's <c>Imapi</c> implementation cannot be instantiated</exception> 
        [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
        public DiscMaster()
        {
            InitializeImapi();
            //System.Threading.Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(DiscMaster_UnhandledException);
        }


        /// <summary>
        /// This destructor will run only if the Dispose method 
        /// does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructors in types derived from this class.
        /// </summary>
        [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
        ~DiscMaster()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose( false );
        }


        /// <summary>
        /// Records the image in the staging area built up with the Joliet
        /// or Redbook disc master classes onto the disc.
        /// </summary>
        /// <param name="simulate">Whether to simulate the burn without actually
        /// recording any data to the disc.</param>
        /// <param name="ejectWhenComplete">Whether to eject the drive tray once
        /// the burn or simulated burn has Completed.</param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="WrongDiscException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="NoActiveRecorderException"></exception>
        /// <exception cref="UserAbortException"></exception>
        /// <exception cref="GenericUnexpectedUnexplainedException"></exception>
        /// <exception cref="MediaNotPresentException"></exception>
        /// <exception cref="DeviceNotAccessibleException"></exception>
        /// <exception cref="DeviceNotPresentException"></exception>
        /// <exception cref="InitializeWriteException"></exception>
        /// <exception cref="InitializeCloseException"></exception>
        /// <exception cref="FileSystemAccessException"></exception>
        /// <exception cref="DiscInfoException"></exception>
        /// <exception cref="TrackOpenException"></exception>
        /// <exception cref="InvalidImageException"></exception>
        /// <exception cref="ContentStreamingException"></exception>
        /// <exception cref="CompressedStashException"></exception>
        /// <exception cref="EncryptedStashException"></exception>
        /// <exception cref="NotEnoughDiskForStashException"></exception>
        /// <exception cref="RemovableStashException"></exception>
        [SuppressMessage( "Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity" )]
        [MethodImpl( MethodImplOptions.Synchronized )]
        public void RecordDisc( int simulate, int ejectWhenComplete )
        {
            if ( !_jolietAddDataCancel )
            {
                try
                {
                    _discMaster.RecordDisc( simulate, ejectWhenComplete );
                }
                catch ( COMException ex )
                {
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_E_NOTOPENED:
                            throw new DiscMasterNotOpenedException();
                        case ErrorCodes.IMAPI_E_WRONGDISC:
                            throw new WrongDiscException();
                        case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                            throw new NoActiveFormatException();
                        case ErrorCodes.IMAPI_E_NOACTIVERECORDER:
                            throw new NoActiveRecorderException();
                        case ErrorCodes.IMAPI_E_USERABORT:
                            throw new UserAbortException();
                        case ErrorCodes.IMAPI_E_GENERIC:
                            throw new GenericUnexpectedUnexplainedException();
                        case ErrorCodes.IMAPI_E_MEDIUM_NOTPRESENT:
                            throw new MediaNotPresentException();
                        case ErrorCodes.IMAPI_E_DEVICE_NOTACCESSIBLE:
                            throw new DeviceNotAccessibleException();
                        case ErrorCodes.IMAPI_E_DEVICE_NOTPRESENT:
                            throw new DeviceNotPresentException();
                        case ErrorCodes.IMAPI_E_INITIALIZE_WRITE:
                            throw new InitializeWriteException();
                        case ErrorCodes.IMAPI_E_INITIALIZE_ENDWRITE:
                            throw new InitializeCloseException();
                        case ErrorCodes.IMAPI_E_FILESYSTEM:
                            throw new FileSystemAccessException();
                        case ErrorCodes.IMAPI_E_DISCINFO:
                            throw new DiscInfoException();
                        case ErrorCodes.IMAPI_E_TRACKOPEN:
                            throw new TrackOpenException();
                        case ErrorCodes.IMAPI_E_INVALIDIMAGE:
                            throw new InvalidImageException();
                        case ErrorCodes.IMAPI_E_LOSS_OF_STREAMING:
                            throw new ContentStreamingException();
                        case ErrorCodes.IMAPI_E_COMPRESSEDSTASH:
                            throw new CompressedStashException();
                        case ErrorCodes.IMAPI_E_ENCRYPTEDSTASH:
                            throw new EncryptedStashException();
                        case ErrorCodes.IMAPI_E_NOTENOUGHDISKFORSTASH:
                            throw new NotEnoughDiskForStashException();
                        case ErrorCodes.IMAPI_E_REMOVABLESTASH:
                            throw new RemovableStashException();
                        default:
                            throw;
                    }
                }
            }
        }


        /// <summary>
        /// Clears any content placed into the staging area by the Joliet or Redbook
        /// disc master classes.
        /// </summary>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public void ClearFormatContent()
        {
            try
            {
                Monitor.Enter( _discMaster );
                _jolietAddDataCancel = false;
                _discMaster.ClearFormatContent();
            }
            catch ( COMException ex )
            {
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                {
                    Trace.WriteLine( Resources.Error_Msg_IMAPI_E_NOTOPENED );
                    throw new DiscMasterNotOpenedException();
                }

                throw;
            }
            finally
            {
                Monitor.Exit( _discMaster );
            }
        } // End void ClearFormatContent()


        /// <summary>
        /// Cancels the burn.
        /// </summary>
        public void CancelBurn()
        {
            int cancel = 1;
            _jolietAddDataCancel = true;
            QueryCancelRequest( out cancel );
        } // End void CancelBurn()

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
        //[EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        private void Dispose( bool disposing )
        {
            // Check to see if Dispose has already been called.
            if ( disposing && !IsDisposed )
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if ( _jolietDiscMaster != null )
                {
                    _jolietDiscMaster.Dispose();
                }

                if ( _redbookDiscMaster != null )
                {
                    _redbookDiscMaster.Dispose();
                }

                // Dispose managed resources.
                if ( _discMaster != null )
                {
                    if ( _progressEvents != null )
                    {
                        try
                        {
                            _discMaster.ProgressUnadvise( _progressEvents.Cookie );
                        }
                        catch ( COMException ex )
                        {
                            if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                            {
                                // do not throw an exception in the dispose.
                                Trace.WriteLine( Resources.Error_Msg_IMAPI_E_NOTOPENED );
                            }
                            Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                        }

                        _progressEvents.Dispose();
                        _progressEvents = null;
                    }
                    _discMaster.Close();
                    Marshal.ReleaseComObject( _discMaster );
                    _discMaster = null;
                }

                if ( _discRecorders != null )
                {
                    _discRecorders.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Private Methods

        /// <summary>
        /// Instantiate the <c>MsDiscMasterObj</c> implementation, open
        /// it, create progress events and the recorder collection.
        /// </summary>
        /// <exception cref="COMException">if the <c>MsDiscMasterObj</c> implementation
        /// cannot be instantiated.</exception>
        /// <exception cref="DiscMasterAlreadyOpenedException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        private void InitializeImapi()
        {
            _discMaster = IDiscMaster;

            try
            {
                _discMaster.Open();
            }
            catch ( COMException ex )
            {
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_ALREADYOPEN )
                {
                    throw new DiscMasterAlreadyOpenedException();
                }
                throw;
            }

            // Set up progress events
            _progressEvents = new DiscMasterProgressEvents( this );
            IntPtr cookie = IntPtr.Zero;
            IDiscMasterProgressEvents iprgEvents = _progressEvents;

            try
            {
                _discMaster.ProgressAdvise( iprgEvents, out cookie );
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

            _progressEvents.Cookie = cookie;

            // Recorders collection
            _discRecorders = new DiscRecorderCollection( _discMaster );
        } // End void InitializeImapi()

        #endregion Private Methods

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="QueryCancel"/> event.
        /// </summary>
        /// <param name="args">Query cancel event arguments</param>
        protected virtual void OnQueryCancel( QueryCancelEventArgs args )
        {
            if ( QueryCancel != null )
            {
                QueryCancel( this, args );
            } // End if(QueryCancel != null)
        } // End void OnQueryCancel(QueryCancelEventArgs args)


        /// <summary>
        /// Raises the <see cref="PnpActivity "/> event.
        /// </summary>
        /// <param name="args">Not used.</param>
        protected virtual void OnPnpActivity( EventArgs args )
        {
            if ( PnpActivity != null )
            {
                PnpActivity( this, args );
            } // End if(PnpActivity != null)
        } // End void OnPnpActivity(EventArgs args)


        /// <summary>
        /// Raises the <see cref="AddProgress"/> event.
        /// </summary>
        /// <param name="args">Details of the add progress so far.</param>
        protected virtual void OnAddProgress( ProgressEventArgs args )
        {
            if ( AddProgress != null )
            {
                AddProgress( this, args );
            } // End if(AddProgress != null)
        } // End void OnAddProgress(ProgressEventArgs args)


        /// <summary>
        /// Raises the <see cref="BlockProgress"/> event.
        /// </summary>
        /// <param name="args">Details of the progress so far.</param>
        protected virtual void OnBlockProgress( ProgressEventArgs args )
        {
            if ( BlockProgress != null )
            {
                BlockProgress( this, args );
            } // End if(BlockProgress != null)
        } // End void OnBlockProgress(ProgressEventArgs args)


        /// <summary>
        /// Raises the <see cref="TrackProgress"/> event (if creating
        /// an audio CD).
        /// </summary>
        /// <param name="args">Details of progress so far</param>
        protected virtual void OnTrackProgress( ProgressEventArgs args )
        {
            if ( TrackProgress != null )
            {
                TrackProgress( this, args );
            } // End if(TrackProgress != null)
        } // End void OnTrackProgress(ProgressEventArgs args)


        /// <summary>
        /// Raises the <see cref="PreparingBurn"/> event.
        /// </summary>
        /// <param name="args">Details of the estimated time for the preparaion.</param>
        protected virtual void OnPreparingBurn( EstimatedTimeOperationEventArgs args )
        {
            if ( PreparingBurn != null )
            {
                PreparingBurn( this, args );
            } // End if (PreparingBurn != null)
        } // End void OnPreparingBurn(EstimatedTimeOperationEventArgs args)


        /// <summary>
        /// Raises the <see cref="ClosingDisc"/> event.
        /// </summary>
        /// <param name="args">Details of the estimated time to close the disc.</param>
        protected virtual void OnClosingDisc( EstimatedTimeOperationEventArgs args )
        {
            if ( ClosingDisc != null )
            {
                ClosingDisc( this, args );
            } // End if (ClosingDisc != null)
        } // End void OnClosingDisc(EstimatedTimeOperationEventArgs args)


        /// <summary>
        /// Raises the <see cref="BurnComplete"/> event.
        /// </summary>
        /// <param name="args">Status of the burn.</param>
        protected virtual void OnBurnComplete( CompletionStatusEventArgs args )
        {
            if ( BurnComplete != null )
            {
                BurnComplete( this, args );
            } // End if (BurnComplete != null)
        } // End void OnBurnComplete(CompletionStatusEventArgs args)


        /// <summary>
        /// Raises the <see cref="EraseComplete"/> event.
        /// </summary>
        /// <param name="args">Status of the erase.</param>
        protected virtual void OnEraseComplete( CompletionStatusEventArgs args )
        {
            if ( EraseComplete != null )
            {
                EraseComplete( this, args );
            } // End if (EraseComplete != null)
        } // End void OnEraseComplete(CompletionStatusEventArgs args)

        #endregion Protected Methods

        #region Internal Methods

        /// <summary>
        /// Called to request whether the burn event should be cancelled
        /// </summary>
        /// <param name="cancel">Set to <c>1</c> to cancel, otherwise
        /// set to <c>0</c>.</param>
        internal void QueryCancelRequest( out int cancel )
        {
            if ( _jolietAddDataCancel )
            {
                cancel = 1;
            } // End if(_jolietAddDataCancel)
            else
            {
                var queryCancelArgs = new QueryCancelEventArgs();
                OnQueryCancel( queryCancelArgs );
                cancel = ( queryCancelArgs.Cancel ? 1 : 0 );
                if ( cancel == 1 )
                {
                    _jolietAddDataCancel = true;
                } // End if(cancel == 1)
            } // End if...else
        } // End void QueryCancelRequest(out int cancel)


        /// <summary>
        /// Resets the joliet add data cancel.
        /// </summary>
        internal void ResetJolietAddDataCancel()
        {
            _jolietAddDataCancel = false;
        } // End void ResetJolietAddDataCancel()


        /// <summary>
        /// Notifies that a Plug and Play activity has occurred that has changed the list of recorders.
        /// </summary>
        internal void NotifyPNPActivity()
        {
            OnPnpActivity( new EventArgs() );
        } // End void NotifyPNPActivity()


        /// <summary>
        /// Notifies addition of data to the CD image in the stash.
        /// </summary>
        internal void NotifyAddProgress( int Completed, int total )
        {
            OnAddProgress( new ProgressEventArgs( Completed, total ) );
        } // End void NotifyAddProgress(int Completed, int total)


        /// <summary>
        /// Notifies an application of block progress whilst burning a disc.
        /// </summary>
        internal void NotifyBlockProgress( int currentBlock, int totalBlocks )
        {
            OnBlockProgress( new ProgressEventArgs( currentBlock, totalBlocks ) );
        } // End void NotifyBlockProgress(int currentBlock, int totalBlocks)


        /// <summary>
        /// Notifies an application of track progress whilst burning an audio disc.
        /// </summary>
        internal void NotifyTrackProgress( int currentTrack, int totalTracks )
        {
            OnTrackProgress( new ProgressEventArgs( currentTrack, totalTracks ) );
        } // End void NotifyTrackProgress(int currentTrack, int totalTracks)


        /// <summary>
        /// Notifies an application that Imapi is preparing to burn a disc.
        /// </summary>
        internal void NotifyPreparingBurn( int estimatedSeconds )
        {
            OnPreparingBurn( new EstimatedTimeOperationEventArgs( estimatedSeconds ) );
        } // End void NotifyPreparingBurn(int estimatedSeconds)


        /// <summary>
        /// Notifies an application that Imapi is closing a disc.
        /// </summary>
        internal void NotifyClosingDisc( int estimatedSeconds )
        {
            OnClosingDisc( new EstimatedTimeOperationEventArgs( estimatedSeconds ) );
        } // End void NotifyClosingDisc(int estimatedSeconds)


        /// <summary>
        /// Notifies an application that Imapi has Completed burning a disc.
        /// </summary>
        internal void NotifyBurnComplete( IntPtr status )
        {
            OnBurnComplete( new CompletionStatusEventArgs( status ) );
        } // End void NotifyBurnComplete(IntPtr status)


        /// <summary>
        /// Notifies an application that Imapi has Completed erasing a disc.
        /// </summary>
        internal void NotifyEraseComplete( IntPtr status )
        {
            OnEraseComplete( new CompletionStatusEventArgs( status ) );
        } // End void NotifyEraseComplete(IntPtr status)

        #endregion Internal Methods

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
        /// Gets the collection of disc recorders on this system.
        /// </summary>
        /// <value>The disc recorders.</value>
        public DiscRecorderCollection DiscRecorders
        {
            get { return _discRecorders; }
        }


        /// <summary>
        /// Gets the Redbook (audio) disc mastering object for this
        /// system.  Getting this may change the list of available
        /// recorders on the system as some recorders may not support
        /// audio CDs.
        /// </summary>
        /// <returns>Redbook disc mastering object.</returns>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public RedbookDiscMaster RedbookDiscMaster
        {
            get
            {
                if ( _redbookDiscMaster == null )
                {
                    Monitor.Enter( _discMaster );
                    object objRedbook = null;
                    Guid iidRedbook = new Guid( Resources.IRedbookDiscMasterGUID );

                    try
                    {
                        _discMaster.SetActiveDiscMasterFormat( ref iidRedbook, out objRedbook );
                    }
                    catch ( COMException ex )
                    {
                        Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                        if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                        {
                            Trace.WriteLine( Resources.Error_Msg_IMAPI_E_NOTOPENED );
                            throw new DiscMasterNotOpenedException();
                        }

                        throw;
                    }

                    _discRecorders.Refresh();

                    _redbookDiscMaster = new RedbookDiscMaster( this, (IRedbookDiscMaster) objRedbook );
                    Monitor.Exit( _discMaster );
                }

                return _redbookDiscMaster;
            }
        }


        /// <summary>
        /// Gets the Joliet (data) disc mastering object for this
        /// system.  Getting this may change the list of available
        /// recorders on the system.
        /// </summary>
        /// <returns>Joliet disc mastering object.</returns>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public JolietDiscMaster JolietDiscMaster
        {
            get
            {
                if ( _jolietDiscMaster == null )
                {
                    Monitor.Enter( _discMaster );
                    object objJoliet = null;
                    Guid iidJoliet = new Guid( Resources.IJolietDiscMasterGUID );

                    try
                    {
                        _discMaster.SetActiveDiscMasterFormat( ref iidJoliet, out objJoliet );
                    }
                    catch ( COMException ex )
                    {
                        Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                        if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTOPENED )
                        {
                            Trace.WriteLine( Resources.Error_Msg_IMAPI_E_NOTOPENED );
                            throw new DiscMasterNotOpenedException();
                        }

                        throw;
                    }

                    _discRecorders.Refresh();
                    _jolietDiscMaster = new JolietDiscMaster( this, (IJolietDiscMaster) objJoliet );
                    Monitor.Exit( _discMaster );
                }

                return _jolietDiscMaster;
            }
        }


        /// <summary>
        /// Gets the disc master formats.
        /// </summary>
        /// <value>The disc master formats.</value>
        public IEnumerator<Guid> DiscMasterFormats
        {
            get
            {
                IEnumDiscMasterFormats ppEnum;
                IDiscMaster.EnumDiscMasterFormats( out ppEnum );
                Guid lpiidFormatID;

                uint pcFetched = 1;
                ppEnum.Next( 1, out lpiidFormatID, out pcFetched );

                while ( pcFetched == 1 )
                {
                    if ( lpiidFormatID == new Guid( Resources.IJolietDiscMasterGUID ) ||
                         lpiidFormatID == new Guid( Resources.IRedbookDiscMasterGUID ) )
                    {
                        yield return lpiidFormatID;
                    }
                    ppEnum.Next( 1, out lpiidFormatID, out pcFetched );
                }
            }
        }

        #endregion Public Properties

        #region Internal Properties

        /// <summary>
        /// Creates a new instance of the <c>IDiscMaster</c> implementation
        /// on this system, if the system supports it.
        /// </summary>
        /// <returns>Implementating intance of <c>IDiscMaster</c></returns>
        /// <exception cref="COMException">if the system does not have an
        /// <c>IDiscMaster</c> implementation.</exception>
        internal IDiscMaster IDiscMaster
        {
            get
            {
                object discMaster = null;
                Guid clsIdDiscMaster = new Guid( Resources.MSDiscMasterObjGUID );
                Guid iidDiscMaster = new Guid( Resources.IDiscMasterGUID );
                int hResult = NativeMethods.CoCreateInstance(
                    ref clsIdDiscMaster,
                    IntPtr.Zero,
                    ClsCtx.ClsCtxInProcServer | ClsCtx.ClsCtxLocalServer,
                    ref iidDiscMaster,
                    out discMaster );

                if ( (uint) hResult != ErrorCodes.S_OK )
                {
                    throw new COMException( Resources.Error_Msg_DiscMaster_CoCreateFailed, hResult );
                } // End if ((uint)hResult != (uint)ErrorCodes.S_OK)
                return (IDiscMaster) discMaster;
            } // End get
        } // End Property IDiscMaster

        #endregion Internal Properties

        // End void Dispose(bool disposing)
    }
}

// End namespace Imapi.Net.Interop