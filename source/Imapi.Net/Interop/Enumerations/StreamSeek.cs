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
    /// Stream seeking options
    /// The STREAM_SEEK enumeration values specify the origin from which
    /// to calculate the new seek-pointer location. They are used for the
    /// dworigin parameter in the IStream::Seek method. The new seek
    /// position is calculated using this value and the dlibMove parameter.
    /// 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/stream_seek.asp
    /// </summary>
    internal enum StreamSeek
    {
        /// <summary>
        /// The new seek pointer is an offset relative to the beginning
        /// of the stream. In this case, the dlibMove parameter is the
        /// new seek position relative to the beginning of the stream.
        /// </summary>
        Set = 0,


        /// <summary>
        /// The new seek pointer is an offset relative to the current
        /// seek pointer location. In this case, the dlibMove parameter
        /// is the signed displacement from the current seek position.
        /// </summary>
        Cur = 1,


        /// <summary>
        /// The new seek pointer is an offset relative to the end
        /// of the stream. In this case, the dlibMove parameter is
        /// the new seek position relative to the end of the stream.
        /// </summary>
        End = 2
    } // End enum STREAM_SEEK
} // End namespace Imapi.Net.Interop.Enumerations