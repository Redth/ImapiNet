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
using System.Globalization;
using System.Runtime.InteropServices;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Interfaces;

#endregion Using Directives

namespace Imapi.Net.Interop
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertyStorage : ReadOnlyCollectionBase
    {
        #region Private Member Variables

        private bool _disposed;
        private IPropertyStorage _storage;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyStorage"/> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        internal PropertyStorage( IPropertyStorage storage )
        {
            _storage = storage;
            ExtractProperties();
        }


        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="PropertyStorage"/> is reclaimed by garbage collection.
        /// </summary>
        ~PropertyStorage()
        {
            Dispose( false );
        }

        #endregion Public Methods and Constructors

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
        private void Dispose( bool disposing )
        {
            // Check to see if Dispose has already been called.
            if ( !_disposed )
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if ( disposing )
                {
                    // Dispose managed resources.
                    Marshal.ReleaseComObject( _storage );
                    _storage = null;
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
            }
            _disposed = true;
        }

        #region Private Methods

        /// <summary>
        /// Read the properties from the nasty IPropertyStorage instance.
        /// </summary>
        private void ExtractProperties()
        {
            IEnumSTATPROPSTG enumProps = null;
            _storage.Enum( ref enumProps );

            var propStg = new StatPropSTG[1];
            var fetched = new[] {1};

            while ( fetched[0] == 1 )
            {
                enumProps.Next( 1, propStg, fetched );

                // Get property value:
                var propSpecifier = new PropSpec
                                    {
                                        ID_or_LPWSTR = ( (IntPtr) propStg[0].propid ),
                                        ulKind = PrpSpec.PropID
                                    };

                object propValue;
                _storage.ReadMultiple( 1, ref propSpecifier, out propValue );
                string name;
                if ( propStg[0].lpwstrName != IntPtr.Zero )
                {
                    name = Marshal.PtrToStringUni( propStg[0].lpwstrName );
                }
                else
                {
                    name = String.Format( CultureInfo.CurrentCulture, "#{0}", propStg[0].propid );
                }

                var property = new Property( name, propValue, this );
                InnerList.Add( property );

                // have to do this, not a good design decision
                if ( propStg[0].lpwstrName != IntPtr.Zero )
                {
                    Marshal.FreeCoTaskMem( propStg[0].lpwstrName );
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        /// <summary>
        /// Updates the internal collection to reflect any changes
        /// made to the properties.
        /// </summary>
        internal void Update( Property prop )
        {
            var newValue = prop.Value;
            var propSpecifier = new PropSpec {ID_or_LPWSTR = prop.ID, ulKind = PrpSpec.PropID};
            _storage.WriteMultiple( 1, ref propSpecifier, ref newValue, 0 );
        }

        #endregion Internal Methods

        #region Public Properties

        /// <summary>
        /// Get the property at the specified 0-based index.
        /// </summary>
        public Property this[ int index ]
        {
            get
            {
                var prop = (Property) InnerList[index];
                return prop;
            }
        }

        #endregion Public Properties
    }
}