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
using System.Runtime.InteropServices;
using Imapi.Net.Interop;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Interfaces;
using Imapi.Net;
using STATSTG=System.Runtime.InteropServices.ComTypes.STATSTG;

#endregion Using Directives

namespace Imapi.Net
{
    /// <summary>
    /// Summary description for JolietIEnumStatStg.
    /// </summary>
    [ComVisible( true )]
    [Guid( "90E97780-F7E9-4b46-9EF4-27E773459B92" )]
    internal class JolietEnumStatStg : IEnumSTATSTG
    {
        #region Private Member Variables

        private readonly JolietDiscMasterStorage _owner;
        private IEnumerator<string> _files;
        private IEnumerator<string> _subFolders;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JolietEnumStatStg"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public JolietEnumStatStg( JolietDiscMasterStorage owner )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( "owner" );
            }

            _owner = owner;
            _files = owner.Files;
            _subFolders = owner.Folders;
        } // End 

        #endregion Public Methods and Constructors

        #region IEnumSTATSTG Members

        /// <summary>
        /// The Next method retrieves a specified number of STATSTG structures,
        /// that follow in the enumeration sequence. If there are fewer than the
        /// requested number of STATSTG structures that remain in the enumeration
        /// sequence, it retrieves the remaining STATSTG structures.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatstg_next.asp
        /// </summary>
        /// <param name="celt">
        /// ULONG celt
        /// [in] The number of STATSTG structures requested.
        /// </param>
        /// <param name="rgelt">
        /// STATSTG* rgelt
        /// [out] An array of STATSTG structures returned.
        /// </param>
        /// <param name="pceltFetched">
        /// ULONG* pceltFetched
        /// [out] The number of STATSTG structures retrieved in the rgelt parameter.
        /// </param>
        public int Next( int celt, STATSTG[] rgelt, int[] pceltFetched )
        {
            int returned = 0;

            if ( celt == 1 )
            {
                if ( _files.MoveNext() )
                {
                    var name = _files.Current;
                    var stream = _owner.RequestIStream( name );
                    stream.Stat( out rgelt[0], (int) StatFlag.Default );
                    returned++;
                } // End if (_files.MoveNext())
                else if ( _subFolders.MoveNext() )
                {
                    var name = _subFolders.Current;
                    var storage = _owner.RequestStorage( name );
                    storage.Stat( out rgelt[0], StatFlag.Default );
                    returned++;
                } // End else if (_subFolders.MoveNext())
            } // End if (celt == 1)
            pceltFetched[0] = returned;
            if ( pceltFetched[0] == celt )
            {
                return (int) ErrorCodes.S_OK;
            }
            return (int) ErrorCodes.S_FALSE;
        } // End void Next(uint celt, ref STATSTG rgelt, out uint pceltFetched)


        /// <summary>
        /// The Skip method skips a specified number of STATSTG structures in the
        /// enumeration sequence.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatstg_skip.asp
        /// </summary>
        /// <param name="celt">
        /// ULONG celt
        /// [in] Number of elements to be skipped.
        /// </param>
        public int Skip( int celt )
        {
            int skipped = 0;
            while ( skipped < celt )
            {
                if ( !_files.MoveNext() )
                {
                    if ( !_subFolders.MoveNext() )
                    {
                        break;
                    } // End if(!_subFolders.MoveNext())
                } // End if(!_files.MoveNext())
                skipped++;
            } // End while (skipped < celt)

            if ( skipped == celt )
            {
                return (int) ErrorCodes.S_OK;
            }
            return (int) ErrorCodes.S_FALSE;
        } // End void Skip(uint celt)


        /// <summary>
        /// The Reset method resets the enumeration sequence to the beginning of
        /// the STATSTG structure array.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatstg_reset.asp
        /// </summary>
        public int Reset()
        {
            _files = _owner.Files;
            _subFolders = _owner.Folders;
            return (int) ErrorCodes.S_OK;
        } // End void Reset()


        /// <summary>
        /// The Clone method creates a new enumerator that contains the same
        /// enumeration state as the current STATSTG structure enumerator. Using
        /// this method, a client can record a particular point in the enumeration
        /// sequence and then return to that point at a later time. The new enumerator
        /// supports the same IEnumSTATSTG interface.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatstg_clone.asp
        /// </summary>
        /// <param name="ppenum">
        /// IEnumSTATSTG** ppenum
        /// [out] A pointer to the variable that receives the IEnumSTATSTG interface pointer.
        /// If the method is unsuccessful, the value of the ppenum parameter is undefined.
        /// </param>
        public void Clone( out IEnumSTATSTG ppenum )
        {
            var clone = new JolietEnumStatStg( _owner );
            ppenum = clone;
        }

        #endregion

// End void Clone(out IEnumSTATSTG ppenum)
    }
}

// End namespace Imapi.Net.Interop