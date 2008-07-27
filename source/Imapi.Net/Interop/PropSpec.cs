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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Interfaces;

#endregion Using Directives

namespace Imapi.Net.Interop
{
    /// <summary>
    /// The PROPSPEC structure is used by many of the methods of
    /// <see cref="IPropertyStorage"/> to specify a property either by its property
    /// identifier (ID) or the associated string name. When the property name
    /// is used, i.e. <c>ulKind = PrpSpec.LPWStr</c>, a call must be made to 
    /// <see cref="System.Runtime.InteropServices.Marshal.StringToCoTaskMemUni"/>
    /// to return an <see cref="IntPtr"/> for ID_or_LPWSTR.
    /// 
    /// Microsoft Code Analysis Note: 
    /// This struct cannot implement <see cref="IDisposable"/>. The <see cref="IPropertyStorage"/>
    /// interface expects this struct to be an exact size and we get memory
    /// corruption if we make it any bigger. Also, there is another warning, CA2006,
    /// the UseSafeHandleToEncapsulateNativeResources warning. It wants to use
    /// a derived <see cref="SafeHandle"/> instead of <see cref="IntPtr"/> objects. This would take a great deal
    /// of refactoring to implement.
    /// 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/propspec.asp
    /// </summary>
    [SuppressMessage( "Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable" )]
    [StructLayout( LayoutKind.Sequential )]
    public struct PropSpec
    {
        // typedef struct tagPROPSPEC {
        //   ULONG ulKind;
        //   union {
        //       PROPID propid;
        //       LPOLESTR lpwstr;
        //   };
        // } PROPSPEC;


        /// <summary>
        /// Indicates the union member used. This member can be one of the following values.
        /// 
        /// PRSPEC_LPWSTR
        ///  Value: 0 The lpwstr member is used and set to a string name. 
        /// PRSPEC_PROPID
        ///  Value: 1 The propid member is used and set to a property ID value.
        /// </summary>
        public PrpSpec ulKind;


        /// <summary>
        /// propid 
        ///  Specifies the value of the property ID. Use either this value or the following lpwstr, not both. 
        ///  
        /// lpwstr 
        ///  Specifies the string name of the property as a null-terminated Unicode string.
        /// </summary>
        [SuppressMessage( "Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources" )]
        public IntPtr ID_or_LPWSTR;
    }
}