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
    /// Property ID types. This is used when accessing IPropertyStorage properties
    /// which are identified by a name or property ID.
    /// </summary>
    public enum PrpSpec : uint
    {
        /// <summary>
        /// Used and set to a string property name.
        /// </summary>
        LPWStr = 0,


        /// <summary>
        /// Used and set to a property ID value.
        /// </summary>
        PropID = 1,


        /// <summary>
        /// Represents an invalid property ID type.
        /// </summary>
        Invalid = 0xffffffff
    } // End enum PrpSpec
} // End namespace Imapi.Net.Interop.Enumerations