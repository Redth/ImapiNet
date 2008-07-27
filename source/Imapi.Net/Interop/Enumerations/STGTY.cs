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

#endregion Using Directives

namespace Imapi.Net.Interop.Enumerations
{
    /// <summary>
    /// STGTY enumeration values are used in the type member of the STATSTG structure
    /// to indicate the type of the storage element. A storage element is a storage
    /// object, a stream object, or a byte-array object (LOCKBYTES).
    /// 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/stgty.asp
    /// </summary>
    public enum STGTY
    {
        /// <summary>
        /// Indicates that the storage element is a storage object. 
        /// </summary>
        Storage = 1,


        /// <summary>
        /// Indicates that the storage element is a stream object. 
        /// </summary>
        Stream = 2,


        /// <summary>
        /// Indicates that the storage element is a byte-array object. 
        /// </summary>
        LockBytes = 3,


        /// <summary>
        /// Indicates that the storage element is a property storage object. 
        /// </summary>
        Property = 4
    } // End enum STGTY
} // End namespace Imapi.Net.Interop.Enumerations