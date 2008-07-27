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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Imapi.Net.ObjectModel;
using Imapi.Net.Properties;

#endregion

namespace Imapi.Net.Interop
{
    /// <summary>
    /// A wrapper around a byte buffer which is pinned in memory
    /// for use in interop scenarios.	
    /// </summary>
    public sealed class PinnedByteBuffer : Disposable
    {
        #region Private Member Variables

        [AccessedThroughProperty( "Bytes" )]
        private byte[] _buffer;

        [AccessedThroughProperty( "Size" )]
        private int _currentSize;

        [AccessedThroughProperty( "BufferAddress" )]
        private GCHandle _handle;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PinnedByteBuffer"/> class.
        /// </summary>
        /// <param name="initialSize">The initial size.</param>
        public PinnedByteBuffer( int initialSize )
        {
            if ( initialSize <= 0 )
            {
                throw new ArgumentOutOfRangeException( "initialSize", initialSize,
                                                       Resources.Error_Msg_PinnedByteBuffer_BufferBiggerThanZero );
            }

            CreateBuffer( initialSize );
        }


        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="PinnedByteBuffer"/> is reclaimed by garbage collection.
        /// </summary>
        ~PinnedByteBuffer()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose( false );
        }

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
                ClearBuffer();
            }
            base.Dispose( disposing );
        }

        #region Private Methods

        /// <summary>
        /// Clears the buffer.
        /// </summary>
        [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
        private void ClearBuffer()
        {
            if ( _handle.IsAllocated )
            {
                _handle.Free();
            }

            _buffer = null;
            _currentSize = 0;
        }


        /// <summary>
        /// Creates the buffer.
        /// </summary>
        /// <param name="size">The size.</param>
        [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
        private void CreateBuffer( int size )
        {
            if ( size <= 0 )
            {
                throw new ArgumentOutOfRangeException( "size", size,
                                                       Resources.Error_Msg_PinnedByteBuffer_BufferBiggerThanZero );
            }

            if ( size <= _currentSize )
            {
                return;
            }

            ClearBuffer();
            _buffer = new Byte[size];
            _handle = GCHandle.Alloc( _buffer, GCHandleType.Pinned );
            _currentSize = size;
        }

        #endregion Private Methods

        #region Public Properties

        /// <summary>
        /// Gets the current size of the byte buffer, or sets the
        /// size to a larger size than it currently is.  Attempts
        /// to set the buffer to a smaller size will have no effect.
        /// </summary>
        public int Size
        {
            get { return _currentSize; }

            set
            {
                if ( value > _currentSize )
                {
                    CreateBuffer( value );
                }
            }
        }


        /// <summary>
        /// Get the array of bytes held by this class
        /// </summary>
        public byte[] Bytes
        {
            get { return _buffer; }
        }


        /// <summary>
        /// Get a pointer to the array of bytes held by this class, 
        /// for use with unmanaged code.
        /// </summary>
        public IntPtr BufferAddress
        {
            [EnvironmentPermission( SecurityAction.LinkDemand, Unrestricted = true )]
            get { return _handle.AddrOfPinnedObject(); }
        }

        #endregion Public Properties
    }
}