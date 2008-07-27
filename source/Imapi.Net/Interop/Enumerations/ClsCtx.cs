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

#endregion Using Directives

namespace Imapi.Net.Interop.Enumerations
{
    /// <summary>
    /// CLSCTX enumeration are used in activation calls to
    /// indicate the execution contexts in which an object
    /// is to be run. These values are also used in calls
    /// to CoRegisterClassObject to indicate the set of
    /// execution contexts in which a class object is to
    /// be made available for requests to construct instances.
    /// This enum supplies contexts for CoCreateInstance.
    /// 
    /// Values are hex.
    /// 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/Com/html/dcb82ff2-56e4-4c7e-a621-7ffd0f1a9d8e.asp
    /// </summary>
    [Flags]
    internal enum ClsCtx : uint
    {
        /// <summary>
        /// The code that creates and manages objects
        /// of this class is a DLL that runs in the
        /// same process as the caller of the function
        /// specifying the class context.
        /// </summary>
        ClsCtxInProcServer = 0x1,


        /// <summary>
        /// The code that manages objects of this class is an
        /// in-process handler. This is a DLL that runs in the
        /// client process and implements client-side structures
        /// of this class when instances of the class are accessed
        /// remotely.
        /// </summary>
        ClsCtxInProcHandler = 0x2,


        /// <summary>
        /// The EXE code that creates and manages objects of this
        /// class runs on same machine but is loaded in a separate
        /// process space.
        /// </summary>
        ClsCtxLocalServer = 0x4,


        /// <summary>
        /// Deprecated.
        /// </summary>
        ClsCtxInProcServer16 = 0x8,


        /// <summary>
        /// A remote machine context. The LocalServer32 or LocalService
        /// code that creates and manages objects of this class is run
        /// on a different machine.
        /// </summary>
        ClsCtxRemoteServer = 0x10,


        /// <summary>
        /// Deprecated.
        /// </summary>
        ClsCtxInProcHandler16 = 0x20,


        /// <summary>
        /// Deprecated.
        /// </summary>
        ClsCtxReserved1 = 0x40,


        /// <summary>
        /// Deprecated.
        /// </summary>
        ClsCtxReserved2 = 0x80,


        /// <summary>
        /// Deprecated.
        /// </summary>
        ClsCtxReserved3 = 0x100,


        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ClsCtxReserved4 = 0x200,


        /// <summary>
        /// Disallows the downloading of code from the Directory Service
        /// or the Internet. This flag cannot be set at the same time as
        /// ClsCtxEnableCodeDownload. If the ComClassStore policy
        /// enables automatic installation, ClsCtxNoCodeDownload can
        /// be used to explicitly disallow download for an activation.
        /// If either of the following registry keys is enabled, automatic
        /// download of missing classes is enabled:
        /// * HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\App Management
        ///   Value Name: ComClassStore, ValueType: DWORD. 1 = enabled, 0 = disabled (default = 0)
        /// * HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\App Management
        ///   Value Name: ComClassStore, ValueType: DWORD. 1 = enabled, 0 = disabled (default = 0)
        /// </summary>
        ClsCtxNoCodeDownload = 0x400,


        /// <summary>
        /// Deprecated.
        /// </summary>
        ClsCtxReserved5 = 0x800,


        /// <summary>
        /// Specify if you want the activation to fail if it uses custom marshalling.
        /// </summary>
        ClsCtxNoCustomMarshal = 0x1000,


        /// <summary>
        /// Allows the downloading of code from the Directory Service or the
        /// Internet. This flag cannot be set at the same time as ClsCtxNoCodeDownload.
        /// </summary>
        ClsCtxEnableCodeDownload = 0x2000,


        /// <summary>
        /// The CLSCTX_NO_FAILURE_LOG can be used to override the
        /// logging of failures in CoCreateInstanceEx. If the
        /// ActivationFailureLoggingLevel is created, the following
        /// values can determine the status of event logging:
        ///  HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Ole
        ///  Value Name: ActivationFailureLoggingLevel,
        ///  ValueType: DWORD.
        ///  * 0 = Discretionary logging. Log by default, but clients
        ///        can override by specifying CLSCTX_NO_FAILURE_LOG in CoCreateInstanceEx.
        ///  * 1 = Always log all failures no matter what the client specified.
        ///  * 2 = Never log any failures no matter what client specified.
        ///        If the registry entry is missing, the default is 0. If you
        ///        need to control customer applications, it is reCommended that
        ///        you set this value to 0 and write the client code to override
        ///        failures. It is strongly reCommended that you do not set the 
        ///        value to 2. If event logging is disabled, it is more difficult
        ///        to diagnose problems.
        /// </summary>
        ClsCtxNoFailureLog = 0x4000,


        /// <summary>
        /// Disables activate-as-activator (AAA) activations for this activation only.
        /// This flag overrides the setting of the EOAC_DISABLE_AAA flag from the
        /// EOLE_AUTHENTICATION_CAPABILITIES enumeration. This flag cannot be set at
        /// the same time as CLSCTX_ENABLE_AAA. It can be used with Microsoft Windows
        /// XP and later versions. Any activation where a server process would be
        /// launched under the caller's identity is known as an activate-as-activator
        /// (AAA) activation. Disabling AAA activations allows an application that runs
        /// under a privileged account (such as LocalSystem) to help prevent its
        /// identity from being used to launch untrusted Components. Library applications
        /// that use activation calls should always set this flag during those calls.
        /// This helps prevent the library application from being used in an
        /// escalation-of-privilege security attack. This is the only way to disable AAA
        /// activations in a library application because the EOAC_DISABLE_AAA flag from
        /// the EOLE_AUTHENTICATION_CAPABILITIES enumeration is applied only to the server
        /// process and not to the library application.
        /// </summary>
        ClsCtxDisableAAA = 0x8000,


        /// <summary>
        /// Enables activate-as-activator (AAA) activations for this activation only.
        /// This flag overrides the setting of the EOAC_DISABLE_AAA flag from the
        /// EOLE_AUTHENTICATION_CAPABILITIES enumeration. This flag cannot be set at
        /// the same time as CLSCTX_DISABLE_AAA. It can be used with Windows XP and
        /// later versions. Any activation where a server process would be launched under
        /// the caller's identity is known as an activate-as-activator (AAA) activation.
        /// Enabling this flag allows an application to transfer its identity to an
        /// activated Component.
        /// </summary>
        ClsCtxEnableAAA = 0x10000,


        /// <summary>
        /// Begin this activation from the default context of the current apartment.
        /// </summary>
        ClsCtxFromDefaultContext = 0x20000,


        /// <summary>
        /// Activate or connect to a 32-bit version of the server; fail if one is not registered.
        /// </summary>
        ClsCtxActivate32BitServer = 0x40000,


        /// <summary>
        /// Activate or connect to a 64 bit version of the server; fail if one is not registered.
        /// </summary>
        ClsCtxActivate64BitServer = 0x80000,


        //////////////////
        // User defined //
        //////////////////


        /// <summary>
        /// All INPROC flags Combined.
        /// </summary>
        ClsCtxInProc = ClsCtxInProcServer | ClsCtxInProcHandler,


        /// <summary>
        /// All SERVER flags Combined.
        /// </summary>
        ClsCtxServer = ClsCtxInProcServer | ClsCtxLocalServer | ClsCtxRemoteServer,


        /// <summary>
        /// All flags Combined.
        /// </summary>
        ClsCtxAll = ClsCtxServer | ClsCtxInProc
    } // End enum ClsCtx
} // End namespace Imapi.Net.Interop.Enumerations