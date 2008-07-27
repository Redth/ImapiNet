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

namespace Imapi.Net.Interop
{
    /// <summary>
    /// The STATPROPSTG structure contains data about a single property in a
    /// property set. This data is the property ID and type tag, and the
    /// optional string name that may be associated with the property.
    /// <see cref="IPropertyStorage.Enum"/> supplies a pointer to the <see cref="IEnumSTATPROPSTG"/>
    /// interface on an enumerator object that can be used to enumerate the
    /// STATPROPSTG structures for the properties in the current property set.
    /// STATPROPSTG is defined as:
    /// 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/statpropstg.asp
    /// </summary>
    [StructLayout( LayoutKind.Sequential )]
    public struct StatPropSTG
    {
        // typedef struct tagSTATPROPSTG
        // {
        //   LPWSTR lpwstrName;
        //   PROPID propid;
        //   VARTYPE vt;
        // } STATPROPSTG;


        /// <summary>
        /// A wide-character null-terminated Unicode string that contains the
        /// optional string name associated with the property. May be NULL. This member
        /// must be freed using CoTaskMemFree. 
        /// </summary>
        public IntPtr lpwstrName;


        /// <summary>
        /// A 32-bit identifier that uniquely identifies the property within the
        /// property set. All properties within property sets must have unique
        /// property identifiers. 
        /// </summary>
        public int propid;

        /// <summary>
        /// The property type. 
        /// </summary>
        public short vt;
    }
}