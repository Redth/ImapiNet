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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Imapi.Net.Interop;
using Imapi.Net.Interop.Exceptions;
using Imapi.Net.Interop.Interfaces;
using Imapi.Net.Properties;

#endregion

namespace Imapi.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class DiscRecorderCollection : ReadOnlyCollectionBase, ICollection<DiscRecorder>, IDisposable
    {
        #region Events

        /// <summary>
        /// Occurs when the ActiveRecorder property is changed.
        /// </summary>
        public event EventHandler<EventArgs> ActiveRecorderChanged;

        #endregion Events

        #region Private Member Variables

        private readonly object _syncRoot = new object();
        private IDiscMaster _discMaster;
        private bool _disposed;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Prevent instantiation from outside the library.
        /// <c>InitializeCollection</c> is called instead of <c>Refresh</c> to follow
        /// Miscrosoft usage guidelines. For the most part the methods are the same,
        /// but the Refresh method triggers the <c>ActiveRecorderChanged</c> event. 
        /// This is turn eventually calls OnActiveDiscRecorderChanged which is a virtual
        /// method. This makes sense not to do as an implementor can override its behavior.
        /// See guideline CA2214 - Do not call overridable methods in constructors. I would
        /// rather have another private method than add variables/parameters and such to try to giude
        /// Refresh's execution path.
        /// </summary>
        /// <param name="discMaster">The disc master.</param>
        /// <exception cref="System.ArgumentNullException">
        /// When <c>discMaster</c> is null.
        /// </exception>
        internal DiscRecorderCollection( IDiscMaster discMaster )
        {
            if ( discMaster == null )
            {
                throw new ArgumentNullException( "discMaster" );
            } // End if (discMaster == null)

            _discMaster = discMaster;
            InitializeCollection();
        } // End DiscRecorderCollection(IDiscMaster discMaster)


        /// <summary>
        /// Refreshes the cached list of recorders.
        /// </summary>
        /// <exception cref="COMException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        public void Refresh()
        {
            // Empty the current list.
            InnerList.Clear();

            // Create a disc enumerator.
            IEnumDiscRecorders enumDiscRecorders = null;

            // Get an enumerator for the disc recorders from the
            // IDiscMaster object.
            try
            {
                _discMaster.EnumDiscRecorders( out enumDiscRecorders );
            }
            catch ( COMException ex )
            {
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                        throw new NoActiveFormatException();
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    default:
                        throw;
                }
            }

            // Make sure we got a valid enumerator.
            if ( enumDiscRecorders == null )
            {
                return;
            }

            // We initially have 0 recorders
            uint fetched = 0;

            // Create a var for our new recorder
            IDiscRecorder recorder = null;

            try
            {
                // Get the next recorder from the enumerator.
                // We try to get 1, if fetched = 1 then we got a 
                // recorder, otherwise there wasn't a next recorder.
                // The IDiscRecorder object is stored in recorder if
                // fetched = 1.
                enumDiscRecorders.Next( 1, out recorder, out fetched );

                // Get all of the recorders
                while ( fetched > 0 )
                {
                    Trace.WriteLine( fetched, "Adding Recorder" );
                    // Encapsulate the IDiscRecorder
                    var discRecorder = new DiscRecorder( recorder );
                    // Add it to the collection.
                    InnerList.Add( discRecorder );
                    // Get the next recorder
                    enumDiscRecorders.Next( 1, out recorder, out fetched );
                } // End while (fetched > 0)
            } // End try
            catch ( COMException ex )
            {
                // TODO: Derive error message
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
            } // End try...catch
            finally
            {
                // If we have a recorder, set the active recorder.
                // This will trigger the ActiveRecorderChanged event
                if ( InnerList.Count > 0 )
                {
                    ActiveDiscRecorder = this[0];
                } // End if (InnerList.Count > 0)
            } // End try...catch...finally
        }


        /// <summary>
        /// Sets the ActiveRecorder to the next available recorder.
        /// </summary>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="NoActiveRecorderException"></exception>
        /// <exception cref="DeviceNotPresentException"> </exception>
        /// <exception cref="DiscFullException"></exception>
        /// <exception cref="MediaNotPresentException"></exception>
        /// <exception cref="StashInUseException"></exception>
        public void NextDiscRecorder()
        {
            int index = IndexOf( ActiveDiscRecorder.IDiscRecorder );
            ActiveDiscRecorder = this[( index + 1 ) % Count];
        }

        #endregion Public Methods and Constructors

        #region ICollection<DiscRecorder> Members

        /// <summary>
        /// Adds an item to the <see cref="System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="System.Collections.Generic.ICollection`1"></see>.</param>
        /// <exception cref="System.NotSupportedException">The <see cref="System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
        public void Add( DiscRecorder item )
        {
            throw new NotSupportedException( Resources.Error_Msg_DiscRecorderCollection_ReadOnly );
        } // End void Add(DiscRecorder item)


        /// <summary>
        /// Removes all items from the <see cref="System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <exception cref="System.NotSupportedException">The <see cref="System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
        public void Clear()
        {
            throw new NotSupportedException( Resources.Error_Msg_DiscRecorderCollection_ReadOnly );
        } // End void Clear()


        /// <summary>
        /// Determines whether the <see cref="System.Collections.Generic.ICollection`1"></see> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if item is found in the <see cref="System.Collections.Generic.ICollection`1"></see>; otherwise, false.
        /// </returns>
        public bool Contains( DiscRecorder item )
        {
            for ( int i = 0; i < InnerList.Count; i++ )
            {
                if ( InnerList[i] == item )
                {
                    return true;
                } // End if (InnerList[i] == item)
            } // End for (int i = 0; i < InnerList.Count; i++)

            return false;
        } // End bool Contains(DiscRecorder item)


        /// <summary>
        /// Copies the elements of the <see cref="System.Collections.Generic.ICollection`1"></see> to an <see cref="System.Array"></see>, starting at a particular <see cref="System.Array"></see> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="System.Array"></see> that is the destination of the elements copied from <see cref="System.Collections.Generic.ICollection`1"></see>. The <see cref="System.Array"></see> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">arrayIndex is less than 0.</exception>
        /// <exception cref="System.ArgumentNullException">array is null.</exception>
        /// <exception cref="System.ArgumentException">array is multidimensional.-or-arrayIndex is equal to or greater than the length of array.-or-The number of elements in the source <see cref="System.Collections.Generic.ICollection`1"></see> is greater than the available space from arrayIndex to the end of the destination array.-or-Type T cannot be cast automatically to the type of the destination array.</exception>
        public void CopyTo( DiscRecorder[] array, int arrayIndex )
        {
            InnerList.CopyTo( array, arrayIndex );
        } // End void CopyTo(DiscRecorder[] array, int arrayIndex)


        /// <summary>
        /// Gets a value indicating whether the <see cref="System.Collections.Generic.ICollection`1"></see> is read-only.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="System.Collections.Generic.ICollection`1"></see> is read-only; otherwise, false.</returns>
        public bool IsReadOnly
        {
            get { return true; } // End get
        } // End Property IsReadOnly


        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if item was successfully removed from the <see cref="System.Collections.Generic.ICollection`1"></see>; otherwise, false. This method also returns false if item is not found in the original <see cref="System.Collections.Generic.ICollection`1"></see>.
        /// </returns>
        /// <exception cref="System.NotSupportedException">The <see cref="System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
        public bool Remove( DiscRecorder item )
        {
            throw new NotSupportedException( Resources.Error_Msg_DiscRecorderCollection_ReadOnly );
        } // End bool Remove(DiscRecorder item)

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Collections.Generic.IEnumerator`1"></see> that can be used to iterate through the collection.
        /// </returns>
        public new IEnumerator<DiscRecorder> GetEnumerator()
        {
            for ( int i = 0; i < InnerList.Count; i++ )
            {
                yield return (DiscRecorder) InnerList[i];
            } // End for (int i = 0; i < InnerList.Count; i++)
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose( true );
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize( this );
        }

        #endregion

        /// <summary>
        /// Disposes any resources associated with this object.
        /// </summary>
        /// <param name="disposing"><c>true</c> if disposing from the <c>Dispose</c>
        /// method, <c>false</c> otherwise.</param>
        private void Dispose( bool disposing )
        {
            if ( !_disposed )
            {
                InnerList.Clear();
                if ( disposing )
                {
                    _discMaster = null;
                } // End if (disposing)
                _disposed = true;
            } // End if (!_disposed)
        }

        #region Private Methods

        /// <summary>
        /// Initializes the collection.
        /// </summary>
        private void InitializeCollection()
        {
            // Create a disc enumerator.
            IEnumDiscRecorders enumDiscRecorders = null;

            // Get an enumerator for the disc recorders from the
            // IDiscMaster object.
            try
            {
                _discMaster.EnumDiscRecorders( out enumDiscRecorders );
            }
            catch ( COMException ex )
            {
                Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                switch ( (uint) ex.ErrorCode )
                {
                    case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                        throw new NoActiveFormatException();
                    case ErrorCodes.IMAPI_E_NOTOPENED:
                        throw new DiscMasterNotOpenedException();
                    default:
                        throw;
                }
            }

            // Make sure we got a valid enumerator.
            if ( enumDiscRecorders != null )
            {
                // We initially have 0 recorders
                uint fetched = 0;

                // Create a var for our new recorder
                IDiscRecorder recorder = null;

                try
                {
                    // Get the next recorder from the enumerator.
                    // We try to get 1, if fetched = 1 then we got a 
                    // recorder, otherwise there wasn't a next recorder.
                    // The IDiscRecorder object is stored in recorder if
                    // fetched = 1.
                    enumDiscRecorders.Next( 1, out recorder, out fetched );

                    // Get all of the recorders
                    while ( fetched > 0 )
                    {
                        Trace.WriteLine( fetched, "Adding Recorder" );
                        // Encapsulate the IDiscRecorder
                        var discRecorder = new DiscRecorder( recorder );
                        // Add it to the collection.
                        InnerList.Add( discRecorder );
                        // Get the next recorder
                        enumDiscRecorders.Next( 1, out recorder, out fetched );
                    } // End while (fetched > 0)
                } // End try
                catch ( COMException ex )
                {
                    // TODO: Derive error message
                    Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                } // End try...catch
                finally
                {
                    if ( InnerList.Count > 0 )
                    {
                        // Try to set the initial ActiveRecorder to
                        // be the first disc enumerated
                        IDiscRecorder discRecorder = this[0].IDiscRecorder;

                        try
                        {
                            _discMaster.SetActiveDiscRecorder( discRecorder );
                        } // End try
                        catch ( COMException ex )
                        {
                            Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                            switch ( (uint) ex.ErrorCode )
                            {
                                case ErrorCodes.IMAPI_E_DEVICE_NOTPRESENT:
                                    throw new DeviceNotPresentException();
                                case ErrorCodes.IMAPI_E_DISCFULL:
                                    throw new DiscFullException();
                                case ErrorCodes.IMAPI_E_MEDIUM_NOTPRESENT:
                                    throw new MediaNotPresentException();
                                case ErrorCodes.IMAPI_E_NOTOPENED:
                                    throw new DiscMasterNotOpenedException();
                                case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                                    throw new NoActiveFormatException();
                                case ErrorCodes.IMAPI_E_STASHINUSE:
                                    throw new StashInUseException();
                                default:
                                    throw;
                            }
                        } // End try...catch
                    } // End if (InnerList.Count > 0)
                } // End try...catch...finally
            } // End if (enumDiscRecorders != null)
        } // End void InitializeCollection()


        private int IndexOf( IDiscRecorder discRecorder )
        {
            for ( int i = 0; i < InnerList.Count; i++ )
            {
                if ( InnerList[i] == discRecorder )
                {
                    return i;
                } // End if (InnerList[i] == item)
            } // End for (int i = 0; i < InnerList.Count; i++)

            return -1;
        }

        #endregion Private Methods

        #region Protected Methods

        /// <summary>
        /// Raises the active disc recorder changed event.
        /// </summary>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnActiveDiscRecorderChanged( EventArgs args )
        {
            if ( ActiveRecorderChanged != null )
            {
                ActiveRecorderChanged( this, args );
            } // End if (ActiveRecorderChanged != null)
        } // End void OnActiveDiscRecorderChanged(EventArgs args)

        #endregion Protected Methods

        #region Internal Methods

        /// <summary>
        /// Notifies the active disc recorder changed.
        /// </summary>
        internal void NotifyActiveDiscRecorderChanged()
        {
            OnActiveDiscRecorderChanged( new EventArgs() );
        } // End void NotifyActiveDiscRecorderChanged()

        #endregion Internal Methods

        #region Public Properties

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="System.Collections.ICollection"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>An object that can be used to synchronize access to the <see cref="System.Collections.ICollection"></see>.</returns>
        public virtual object SyncRoot
        {
            get { return _syncRoot; }
        }


        /// <summary>
        /// Returns the <c>DiscRecorder</c> at the specified 0-based index.
        /// </summary>
        public DiscRecorder this[ int index ]
        {
            get { return (DiscRecorder) InnerList[index]; } // End get
        } // End Property this[int index]


        /// <summary>
        /// Gets/sets the active disc recorder on the system.
        /// </summary>
        /// <value>The active disc recorder.</value>
        /// <exception cref="COMException"></exception>
        /// <exception cref="RecorderNotInitializedException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="NoActiveRecorderException"></exception>
        /// <exception cref="DeviceNotPresentException"> </exception>
        /// <exception cref="DiscFullException"></exception>
        /// <exception cref="MediaNotPresentException"></exception>
        /// <exception cref="StashInUseException"></exception>
        public DiscRecorder ActiveDiscRecorder
        {
            get
            {
                // TODO: can I just do this?
                // IDiscRecorder recorder = null;
                // _discMaster.GetActiveDiscRecorder(out recorder);
                // return new DiscRecorder(recorder);

                // Create IDiscRecorder and its wrapper
                IDiscRecorder recorder = null;
                DiscRecorder activeRecorder = null;

                // Get the ActiveDiscRecorder from the DiscMaster
                try
                {
                    _discMaster.GetActiveDiscRecorder( out recorder );
                }
                catch ( COMException ex )
                {
                    Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                    switch ( (uint) ex.ErrorCode )
                    {
                        case ErrorCodes.IMAPI_E_NOTOPENED:
                            throw new DiscMasterNotOpenedException();
                        case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                            throw new NoActiveFormatException();
                        case ErrorCodes.IMAPI_E_NOACTIVERECORDER:
                            throw new NoActiveRecorderException();
                        case ErrorCodes.IMAPI_E_DEVICE_NOTPRESENT:
                            throw new DeviceNotPresentException();
                        default:
                            throw;
                    }
                }

                // We use drive letter to associate equivalence
                // Create a path holder
                string path;
                // Get the path from the current recorder.
                try
                {
                    recorder.GetPath( out path );
                }
                catch ( COMException ex )
                {
                    if ( (uint) ex.ErrorCode == ErrorCodes.IMAPI_E_NOTINITIALIZED )
                    {
                        throw new RecorderNotInitializedException();
                    }
                    throw;
                }

                // Enumerate over all of the recorders looking for a match
                foreach ( DiscRecorder CompareRecorder in InnerList )
                {
                    // Compare paths
                    if ( path.Equals( CompareRecorder.OSPath ) )
                    {
                        // paths match, get the recorder
                        activeRecorder = CompareRecorder;
                    } // End if (path.Equals(CompareRecorder.OSPath))
                } // End foreach (DiscRecorder CompareRecorder in InnerList)

                // returnt the recorder whose drive letter matches
                return activeRecorder;
            } // End get


            set
            {
                // Make sure null is not applied
                // value must be a valid DiscRecorder
                if ( value != null )
                {
                    // Get the DiscRecorders interface
                    IDiscRecorder discRecorder = value.IDiscRecorder;

                    // set the active recorder.
                    try
                    {
                        _discMaster.SetActiveDiscRecorder( discRecorder );
                    }
                    catch ( COMException ex )
                    {
                        Trace.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                        switch ( (uint) ex.ErrorCode )
                        {
                            case ErrorCodes.IMAPI_E_DEVICE_NOTPRESENT:
                                throw new DeviceNotPresentException();
                            case ErrorCodes.IMAPI_E_DISCFULL:
                                throw new DiscFullException();
                            case ErrorCodes.IMAPI_E_MEDIUM_NOTPRESENT:
                                throw new MediaNotPresentException();
                            case ErrorCodes.IMAPI_E_NOTOPENED:
                                throw new DiscMasterNotOpenedException();
                            case ErrorCodes.IMAPI_E_NOACTIVEFORMAT:
                                throw new NoActiveFormatException();
                            case ErrorCodes.IMAPI_E_STASHINUSE:
                                throw new StashInUseException();
                            default:
                                throw;
                        }
                    }
                    // Fire the changed event
                    NotifyActiveDiscRecorderChanged();
                } // End if (value != null)
            } // End set
        } // End Property ActiveDiscRecorder

        #endregion Public Properties

// End IEnumerator<DiscRecorder> GetEnumerator()
    }
}

// End namespace Imapi.Net.Interop