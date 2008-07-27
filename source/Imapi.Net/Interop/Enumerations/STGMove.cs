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
    /// STGMOVE enumeration values indicate whether a storage element is to be moved or
    /// copied. They are used in the IStorage::MoveElementTo method.
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/stgmove.asp
    /// </summary>
    public enum STGMove : uint
    {
        /// <summary>
        /// Indicates that the method should move the data from the source to the destination. 
        /// </summary>
        Move = 0,


        /// <summary>
        /// Indicates that the method should copy the data from the source to the
        /// destination. A copy is the same as a move except that the source element
        /// is not removed after copying the element to the destination. Copying an
        /// element on top of itself is undefined. 
        /// </summary>
        Copy = 1,


        /// <summary>
        /// Not implemented. 
        /// </summary>
        ShallowCopy = 2
    } // End enum STGMove
} // End namespace Imapi.Net.Interop.Enumerations