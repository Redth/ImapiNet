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
    /// Flags describing media. Once media is insterted it will have one or more of these values.
    /// </summary>
    [Flags]
    public enum MediaFlag
    {
        // enum MEDIA_FLAGS
        // {
        //     MEDIA_BLANK	= 0x1,
        //     MEDIA_RW	= 0x2,
        //     MEDIA_WRITABLE = 0x4,
        //     MEDIA_FORMAT_UNUSABLE_BY_IMAPI = 0x8
        // };


        /// <summary>
        /// No Media
        /// </summary>
        None = 0x0,


        /// <summary>
        /// Blank media
        /// </summary>
        Blank = 0x1,


        /// <summary>
        /// Read/Write media
        /// </summary>
        RW = 0x2,


        /// <summary>
        /// Writable media
        /// </summary>
        Writable = 0x4,


        /// <summary>
        /// Unusable media
        /// </summary>
        FormatUnusable = 0x8
    } // End enum MediaFlags
} // End namespace Imapi.Net.Interop.Enumerations