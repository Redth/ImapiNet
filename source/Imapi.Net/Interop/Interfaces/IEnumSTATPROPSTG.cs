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

using System.Runtime.InteropServices;
using Imapi.Net.Interop.Structs;

#endregion Using Directives

namespace Imapi.Net.Interop.Interfaces
{
    /// <summary>
    /// IEnumSTATPROPSTG
    /// The IEnumSTATPROPSTG interface iterates through an array of
    /// STATPROPSTG structures. The STATPROPSTG structures contain
    /// statistical data about properties in a property set. IEnumSTATPROPSTG
    /// has the same methods as all enumerator interfaces: Next, Skip, Reset,
    /// and Clone.
    /// The implementation defines the order in which the properties in the
    /// set are enumerated. Properties that are present when the enumerator
    /// is created, and are not removed during the enumeration, will be
    /// enumerated only once. Properties added or deleted while the enumeration
    /// is in progress may or may not be enumerated, but will never be
    /// enumerated more than once.
    /// Reserved property identifiers, properties with a property ID of
    /// 0(dictionary), 1 (code page indicator), or greater than or equal
    /// to 0x80000000 are not enumerated.
    /// Enumeration of a nonsimple property does not necessarily indicate
    /// that the property can be read successfully through a call to
    /// IPropertyStorage::ReadMultiple. This is because the performance
    /// overhead of checking existence of the indirect stream or storage 
    /// is prohibitive during property enumeration.
    /// When To Implement
    /// Implement IEnumSTATPROPSTG to enumerate the properties within a property
    /// set. If using the Compound file implementation of the storage object, a
    /// pointer to which is available through a call to StgCreateDocfile, you
    /// can query for a pointer to IPropertySetStorage. After calling one of
    /// its methods either to open or create a property set, you can get a
    /// pointer to IEnumSTATPROPSTG with a call to IPropertyStorage::Enum.
    /// If performing a custom implementation of IPropertyStorage, implement
    /// IEnumSTATPROPSTG to fill a caller-allocated array of STATPROPSTG
    /// structures. Each STATPROPSTG structure contains data about a simple
    /// property.
    /// When To Use
    /// Applications that support storage objects, and persistent properties
    /// within those objects, call IPropertyStorage::Enum to return a pointer
    /// to IEnumSTATPROPSTG to enumerate the properties in the current property
    /// set.
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatpropstg.asp
    /// </summary>
    [ComImport]
    [Guid( "00000139-0000-0000-C000-000000000046" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IEnumSTATPROPSTG
    {
        /// <summary>
        /// The Next method retrieves a specified number of STATPROPSTG structures,
        /// that follow subsequently in the enumeration sequence. If fewer than
        /// the requested number of STATPROPSTG structures exist in the enumeration
        /// sequence, it retrieves the remaining STATPROPSTG structures.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatpropstg_next.asp
        /// </summary>
        /// <param name="celt">
        /// ULONG celt
        /// [in] The number of STATPROPSTG structures requested.
        /// This must be = 1
        /// </param>
        /// <param name="rgelt">
        /// STATPROPSTG* rgelt
        /// [out] STATPROPSTG structures returned.
        /// </param>
        /// <param name="pceltFetched">
        /// ULONG* pceltFetched
        /// [out] The number of STATPROPSTG structures retrieved in the rgelt parameter.
        /// </param>
        [PreserveSig]
        int Next( int celt, [Out] [MarshalAs( UnmanagedType.LPArray, SizeParamIndex = 0 )] StatPropSTG[] rgelt,
                  [Out] [MarshalAs( UnmanagedType.LPArray, SizeParamIndex = 0, SizeConst = 1 )] int[] pceltFetched );


        /// <summary>
        /// The Skip method skips the specified number of STATPROPSTG structures in
        /// the enumeration sequence.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatpropstg_skip.asp
        /// </summary>
        /// <param name="celt">
        /// ULONG celt
        /// The number of STATPROPSTG structures to skip.
        /// </param>
        [PreserveSig]
        int Skip( int celt );


        /// <summary>
        /// The Reset method resets the enumeration sequence to the beginning of
        /// the STATPROPSTG structure array.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatpropstg_reset.asp
        /// </summary>
        [PreserveSig]
        int Reset();


        /// <summary>
        /// The Clone method creates an enumerator that contains the same enumeration
        /// state as the current STATPROPSTG structure enumerator. Using this method
        /// a client can record a particular point in the enumeration sequence and
        /// then return to that point later. The new enumerator supports the same
        /// IEnumSTATPROPSTG interface.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatpropstg_clone.asp
        /// </summary>
        /// <param name="ppenum">
        /// IEnumSTATPROPSTG** ppenum
        /// [out] A pointer to the variable that receives the IEnumSTATPROPSTG
        /// interface pointer.
        /// If the method is unsuccessful, the value of the ppenum parameter
        /// is undefined.
        /// </param>
        void Clone( out IEnumSTATPROPSTG ppenum );
    }
}