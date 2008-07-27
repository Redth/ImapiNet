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

namespace Imapi.Net
{
    /// <summary>
    /// Information about an event in which only an estimated
    /// time to Complete can be provided (Preparing and
    /// Finalising the disc).
    /// </summary>
    public sealed class EstimatedTimeOperationEventArgs : EventArgs
    {
        #region Private Member Variables

        private readonly int _estimatedSeconds;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="estimatedSeconds">Estimated time for this operation.</param>
        public EstimatedTimeOperationEventArgs( int estimatedSeconds )
        {
            _estimatedSeconds = estimatedSeconds;
        } // End EstimatedTimeOperationEventArgs(int estimatedSeconds)

        #endregion Public Methods and Constructors

        #region Public Properties

        /// <summary>
        /// Gets the estimated length of this operation in seconds.
        /// </summary>
        /// <value>The estimated seconds.</value>
        public int EstimatedSeconds
        {
            get { return _estimatedSeconds; } // End get
        } // End EstimatedSeconds

        #endregion Public Properties
    }
}

// End namespace Imapi.Net.Interop