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

namespace Imapi.Net.Interop
{
    /// <summary>
    /// Completion status event information.
    /// </summary>
    public sealed class CompletionStatusEventArgs : EventArgs
    {
        #region Private Member Variables

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionStatusEventArgs"/> class.
        /// </summary>
        /// <param name="status">Status of the operation that has just Completed.</param>
        public CompletionStatusEventArgs( IntPtr status )
        {
            Status = status;
        }

        #endregion Public Methods and Constructors

        #region Public Properties

        /// <summary>
        /// Gets the status of this operation.
        /// </summary>
        /// <value>The status.</value>
        public IntPtr Status { get; private set; }

        #endregion Public Properties
    }
}