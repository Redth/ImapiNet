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

#endregion Using Directives

////////////////////////////////////////////////////////////////////////////////
//   TODO:          Is PreserveSig needed on Next(uint, out IDiscRecorder, out uint)?
////////////////////////////////////////////////////////////////////////////////

namespace Imapi.Net.Interop.Interfaces
{
    /// <summary>
    /// IEnumDiscRecorders is standard Com enumerator, as documented
    /// in IEnumXXXX. Each call to Next returns the next IDiscRecorder
    /// in the sequence.
    /// </summary>
    [ComImport]
    [Guid( "9B1921E1-54AC-11d3-9144-00104BA11C5E" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IEnumDiscRecorders
    {
        //    MIDL_INTERFACE("9B1921E1-54AC-11d3-9144-00104BA11C5E")
        //    IEnumDiscRecorders : public IUnknown
        //    {
        //    public:
        //        virtual HRESULT STDMETHODCALLTYPE Next( 
        //            /* [in] */ ULONG cRecorders,
        //            /* [length_is][size_is][out] */ IDiscRecorder **ppRecorder,
        //            /* [out] */ ULONG *pcFetched) = 0;
        //        
        //        virtual HRESULT STDMETHODCALLTYPE Skip( 
        //            /* [in] */ ULONG cRecorders) = 0;
        //        
        //        virtual HRESULT STDMETHODCALLTYPE Reset( void) = 0;
        //        
        //        virtual HRESULT STDMETHODCALLTYPE Clone( 
        //            /* [out] */ IEnumDiscRecorders **ppEnum) = 0;        
        //    };


        /// <summary>
        /// Retrieves the next celt items in the enumeration sequence. If there
        /// are fewer than the requested number of elements left in the sequence,
        /// it retrieves the remaining elements. The number of elements actually
        /// retrieved is returned through pceltFetched (unless the caller passed
        /// in NULL for that parameter).
        /// </summary>
        /// <param name="cRecorders">
        /// ULONG cRecorders
        /// Number of items to be retrieved.
        /// </param>
        /// <param name="ppRecorder">
        /// IDiscRecorder **ppRecorder
        /// Holder for the next item(s) in the sequence.
        /// </param>
        /// <param name="pcFetched">
        /// ULONG *pcFetched
        /// The number of elements actually retrieved
        /// </param>
        [PreserveSig]
        uint Next( uint cRecorders, out IDiscRecorder ppRecorder, out uint pcFetched );


        /// <summary>
        /// Skips over the next specified number of elements in the enumeration
        /// sequence.
        /// </summary>
        /// <param name="cRecorders">
        /// ULONG cRecorders
        /// [in] Number of elements to be skipped.
        /// </param>
        void Skip( uint cRecorders );


        /// <summary>
        /// Resets the enumeration sequence to the beginning.
        /// </summary>
        void Reset();


        /// <summary>
        /// Creates another enumerator that contains the same enumeration
        /// state as the current one. Using this function, a client can
        /// record a particular point in the enumeration sequence and then
        /// return to that point at a later time. The new enumerator supports
        /// the same interface as the original one.
        /// </summary>
        /// <param name="ppEnum">
        /// IEnumDiscRecorders **ppEnum
        /// Variable that receives the interface pointer to the enumeration object.
        /// If the method is unsuccessful, the value of this output variable is
        /// undefined.
        /// </param>
        void Clone( out IEnumDiscRecorders ppEnum );
    }
}