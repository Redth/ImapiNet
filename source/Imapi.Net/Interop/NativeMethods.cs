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
using Imapi.Net.Interop.Enumerations;

#endregion

namespace Imapi.Net.Interop
{
    /// <summary>
    /// Used to define external OS native calls.
    /// </summary>
    internal static class NativeMethods
    {
        #region ole32

        /// <summary>
        /// Creates a single uninitialized object of the class associated
        /// with a specified CLSID. Call CoCreateInstance when you want to
        /// create only one object on the local system. To create a single
        /// object on a remote system, call CoCreateInstanceEx. To create
        /// multiple objects based on a single CLSID, refer to the CoGetClassObject
        /// function.
        /// 
        /// In the CLSCTX enumeration, you can specify the type of server used to
        /// manage the object. The constants can be ClsCtxInProcServer,
        /// ClsCtxInProcHandler, ClsCtxLocalServer, or any Combination
        /// of these values. The constant CLSCTX_ALL is defined as the
        /// Combination of all three. For more information about the use
        /// of one or a Combination of these constants, refer to CLSCTX.
        /// 
        /// STDAPI CoCreateInstance(REFCLSID rclsid,
        ///                         LPUNKNOWN pUnkOuter,
        ///                         DWORD dwClsContext,
        ///                         REFIID riid,
        ///                         LPVOID* ppv);
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/Com/html/7295a55b-12c7-4ed0-a7a4-9ecee16afdec.asp
        /// </summary>
        /// <param name="rclsid">
        /// [in] CLSID associated with the data and code that will be used to
        /// create the object. 
        /// </param>
        /// <param name="pUnkOuter">
        /// [in] If NULL, indicates that the object is not being created as
        /// part of an aggregate. If non-NULL, pointer to the aggregate object's
        /// IUnknown interface (the controlling IUnknown).
        /// </param>
        /// <param name="dwClsContext">
        /// [in] Context in which the code that manages the newly created object
        /// will run. The values are taken from the enumeration CLSCTX.
        /// </param>
        /// <param name="riid">
        /// [in] Reference to the identifier of the interface to be used to
        /// Communicate with the object.
        /// </param>
        /// <param name="ppv">
        ///  [out] Address of pointer variable that receives the interface pointer
        ///  requested in riid. Upon successful return, *ppv contains the requested
        ///  interface pointer. Upon failure, *ppv contains NULL.
        /// </param>
        /// <returns>
        /// S_OK
        /// An instance of the specified object class was successfully created. 
        /// 
        /// REGDB_E_CLASSNOTREG
        /// A specified class is not registered in the registration database.
        /// Also can indicate that the type of server you requested in the CLSCTX
        /// enumeration is not registered or the values for the server types in
        /// the registry are corrupt. 
        /// 
        /// CLASS_E_NOAGGREGATION
        /// This class cannot be created as part of an aggregate. 
        /// 
        /// E_NOINTERFACE
        /// The specified class does not implement the requested interface, or
        /// the controlling IUnknown does not expose the requested interface. 
        /// </returns>
        [DllImport( "ole32", CharSet = CharSet.Unicode )]
        internal static extern int CoCreateInstance( ref Guid rclsid, IntPtr pUnkOuter, ClsCtx dwClsContext,
                                                     ref Guid riid,
                                                     [MarshalAs( UnmanagedType.Interface )] out object ppv );

        #endregion

        #region kernel32

        /// <summary>
        /// Queries the dos device.
        /// </summary>
        /// <param name="lpDeviceName">Name of the lp device.</param>
        /// <param name="lpTargetPath">The lp target path.</param>
        /// <param name="ucchMax">The ucch max.</param>
        /// <returns></returns>
        [DllImport( "kernel32", CharSet = CharSet.Unicode, BestFitMapping = false, ThrowOnUnmappableChar = true )]
        internal static extern int QueryDosDevice( [MarshalAs( UnmanagedType.LPWStr )] string lpDeviceName,
                                                   [MarshalAs( UnmanagedType.LPWStr )] string lpTargetPath, int ucchMax );

        #endregion
    }
}