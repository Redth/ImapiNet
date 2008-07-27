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
using STATSTG=System.Runtime.InteropServices.ComTypes.STATSTG;

#endregion

namespace Imapi.Net.Interop.Interfaces
{
    /// <summary>
    /// IEnumSTATSTG
    /// The IEnumSTATSTG interface enumerates an array of STATSTG structures.
    /// These structures contain statistical data about open storage, stream,
    /// or byte array objects. IEnumSTATSTG has the same methods as all enumerator
    /// interfaces: Next, Skip, Reset, and Clone.
    /// When To Implement
    /// Implement IEnumSTATSTG to enumerate the elements of a storage object. If
    /// you are using the Compound file implementation of the storage object, a
    /// pointer to which is available through a call to StgCreateDocfile,
    /// IEnumSTATSTG is implemented on that object, and a pointer is returned
    /// through a call to IStorage::EnumElements. If you are doing a custom
    /// implementation of a storage object, you must implement IEnumSTATSTG
    /// to fill a caller-allocated array of STATSTG structures, each of which
    /// contains data about the nested elements in the storage object.
    /// When To Use
    /// Containers call methods that return a pointer to IEnumSTATSTG, so the
    /// container can manage its storage object and the elements within it.
    /// Calls to the IStorage::EnumElements method supply a pointer to IEnumSTATSTG.
    /// The caller allocates an array of STATSTG structures and the IEnumSTATSTG
    /// methods fill each structure with the statistics about one of the nested
    /// elements in the storage object. If present, the lpszName member of the
    /// STATSTG structure requires additional memory allocation through the IMalloc
    /// interface, and the caller must free this memory, if allocated, by calling
    /// the IMalloc::Free method. If the lpszName member is NULL, no memory is
    /// allocated, and, therefore, no memory must be freed.
    /// 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatstg.asp
    /// </summary>
    [ComImport]
    [Guid( "0000000D-0000-0000-C000-000000000046" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IEnumSTATSTG
    {
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
        [PreserveSig]
        int Next( int celt, [Out] [MarshalAs( UnmanagedType.LPArray, SizeParamIndex = 0 )] STATSTG[] rgelt,
                  [Out] [MarshalAs( UnmanagedType.LPArray, SizeParamIndex = 0, SizeConst = 1 )] int[] pceltFetched );


        /// <summary>
        /// The Skip method skips a specified number of STATSTG structures in the
        /// enumeration sequence.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatstg_skip.asp
        /// </summary>
        /// <param name="celt">
        /// ULONG celt
        /// [in] Number of elements to be skipped.
        /// </param>
        [PreserveSig]
        int Skip( int celt );


        /// <summary>
        /// The Reset method resets the enumeration sequence to the beginning of
        /// the STATSTG structure array.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ienumstatstg_reset.asp
        /// </summary>
        [PreserveSig]
        int Reset();


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
        void Clone( out IEnumSTATSTG ppenum );
    }
}