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

#endregion

namespace Imapi.Net.Interop.Enumerations
{
    /// <summary>
    /// The STATFLAG enumeration values indicate whether the
    /// method should try to return a name in the pwcsName
    /// member of the STATSTG structure. The values are used
    /// in the ILockBytes::Stat, IStorage::Stat, and IStream::Stat
    /// methods to save memory when the pwcsName member is
    /// not required.
    ///  
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/statflag.asp
    /// </summary>
    [Flags]
    public enum StatFlag
    {
        /// <summary>
        /// Requests that the statistics include the pwcsName member
        /// of the STATSTG structure.
        /// </summary>
        Default = 0,


        /// <summary>
        /// Requests that the statistics not include the pwcsName
        /// member of the STATSTG structure. If the name is omitted,
        /// there is no need for the Stat methods to allocate and free
        /// memory for the string value of the name, therefore the method
        /// reduces time and resources used in an allocation and free operation.
        /// </summary>
        NoName = 1,


        /// <summary>
        /// Not implemented.
        /// </summary>
        NoOpen = 2
    } // End enum StatFlag
} // End namespace Imapi.Net.Interop.Enumerations