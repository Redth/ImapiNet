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
using Imapi.Net.Interop.Interfaces;

#endregion Using Directives

namespace Imapi.Net.Interop.Structs
{
    /// <summary>
    /// The STATPROPSETSTG structure contains information about a property set.
    /// To get this information, call <see cref="IPropertyStorage.Stat"/>, which fills in a
    /// buffer containing the information describing the current property set.
    /// To enumerate the STATPROPSETSTG structures for the property sets in the
    /// current property-set storage, call <see cref="IPropertySetStorage.Enum"/> to get a
    /// pointer to an enumerator. You can then call the enumeration methods of
    /// the IEnumSTATPROPSETSTG interface on the enumerator. The structure is
    /// defined as follows:
    /// 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/statpropsetstg.asp
    /// </summary>
    [StructLayout( LayoutKind.Sequential )]
    public struct StatPropSetSTG
    {
        // typedef struct tagSTATPROPSETSTG
        // {
        //   FMTID fmtid;
        //   CLSID clsid;
        //   DWORD grfFlags;
        //   FILETIME mtime;
        //   FILETIME ctime;
        //   FILETIME atime;
        // } STATPROPSETSTG;

        /// <summary>
        /// FMTID of the current property set, specified when the property set
        /// was initially created.
        /// </summary>
        public Guid fmtid;


        /// <summary>
        /// CLSID associated with this property set, specified when the property
        /// set was initially created and possibly modified thereafter with
        /// <see cref="IPropertyStorage.SetClass"/>. If not set, the value will be CLSID_NULL. 
        /// </summary>
        public Guid clsid;


        /// <summary>
        /// Flag values of the property set, as specified in IPropertySetStorage::Create.
        /// </summary>
        public uint grfFlags;


        /// <summary>
        /// Time in Universal Coordinated Time (UTC) when the property set was last modified.
        /// </summary>
        public long mtime;


        /// <summary>
        /// Time in UTC when this property set was created.
        /// </summary>
        public long ctime;


        /// <summary>
        /// Time in UTC when this property set was last accessed. 
        /// </summary>
        public long atime;
    }
}