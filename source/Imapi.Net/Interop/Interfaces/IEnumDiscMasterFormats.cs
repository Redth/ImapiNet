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
using Imapi.Net.Interop.Exceptions;

#endregion Using Directives

namespace Imapi.Net.Interop.Interfaces
{
    /// <summary>
    /// IEnumDiscMasterFormats is standard Com enumerator, as documented
    /// in IEnumXXXX. Each call to Next returns an array of IIDs, one IID
    /// per supported disc master format. To select the active format and
    /// retrieve a pointer to a format specific interface, use
    /// SetActiveDiscMasterFormat. (Do not use QueryInterface, because the
    /// interface will not be associated with the active format).
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/com/html/a384e79b-b6ea-4db9-b555-6080fd243260.asp
    /// </summary>
    [ComImport]
    [Guid( "DDF445E1-54BA-11d3-9144-00104BA11C5E" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IEnumDiscMasterFormats
    {
        //    MIDL_INTERFACE("DDF445E1-54BA-11d3-9144-00104BA11C5E")
        //    IEnumDiscMasterFormats : public IUnknown
        //    {
        //    public:
        //        virtual HRESULT STDMETHODCALLTYPE Next( 
        //            /* [in] */ ULONG cFormats,
        //            /* [length_is][size_is][out] */ LPIID lpiidFormatID,
        //            /* [out] */ ULONG *pcFetched) = 0;
        //        
        //        virtual HRESULT STDMETHODCALLTYPE Skip( 
        //            /* [in] */ ULONG cFormats) = 0;
        //        
        //        virtual HRESULT STDMETHODCALLTYPE Reset( void) = 0;
        //        
        //        virtual HRESULT STDMETHODCALLTYPE Clone( 
        //            /* [out] */ IEnumDiscMasterFormats **ppEnum) = 0;        
        //    };


        /// <summary>
        /// Retrieves the next cFormats items in the enumeration sequence. If there
        /// are fewer than the requested number of elements left in the sequence,
        /// it retrieves the remaining elements. The number of elements actually
        /// retrieved is returned through pcFetched (unless the caller passed
        /// in NULL for that parameter).
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/com/html/a384e79b-b6ea-4db9-b555-6080fd243260.asp
        /// </summary>
        /// <param name="cFormats">
        /// ULONG cFormats
        /// Number of items to be retrieved.
        /// </param>
        /// <param name="lpiidFormatID">
        /// LPIID lpiidFormatID
        /// Holder for the next item(s) in the sequence.
        /// </param>
        /// <param name="pcFetched">
        /// ULONG *pcFetched
        /// The number of elements actually retrieved
        /// </param>
        void Next( uint cFormats, out Guid lpiidFormatID, out uint pcFetched );

        /// <summary>
        /// Skips over the next specified number of elements in the enumeration sequence.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/com/html/a384e79b-b6ea-4db9-b555-6080fd243260.asp
        /// </summary>
        /// <param name="cFormats">
        /// ULONG cFormats
        /// [in] Number of elements to be skipped.
        /// </param>
        void Skip( uint cFormats );

        /// <summary>
        /// Resets the enumeration sequence to the beginning.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/com/html/a384e79b-b6ea-4db9-b555-6080fd243260.asp
        /// </summary>
        void Reset();

        /// <summary>
        /// Creates another enumerator that contains the same enumeration
        /// state as the current one. Using this function, a client can
        /// record a particular point in the enumeration sequence and then
        /// return to that point at a later time. The new enumerator supports
        /// the same interface as the original one.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/com/html/a384e79b-b6ea-4db9-b555-6080fd243260.asp
        /// </summary>
        /// <param name="ppEnum">
        /// IEnumDiscMasterFormats **ppEnum
        /// Variable that receives the interface pointer to the enumeration object.
        /// If the method is unsuccessful, the value of this output variable is
        /// undefined.
        /// </param>
        /// <exception cref="InvalidArgumentException"></exception>
        /// <exception cref="Exceptions.OutOfMemoryException"></exception>
        /// <exception cref="UnexpectedErrorException"></exception>
        void Clone( out IEnumDiscMasterFormats ppEnum );
    }
}