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
    /// Progress event information.  Provides the currently
    /// Completed versus total amount to perform for various
    /// progress operations during staging and burning.
    /// </summary>
    public sealed class ProgressEventArgs : EventArgs
    {
        #region Private Member Variables

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="completed">
        /// Amount Completed for this operation
        /// </param>
        /// <param name="total">
        /// Total amount for this operation
        /// </param>
        public ProgressEventArgs( int completed, int total )
        {
            Completed = completed;
            Total = total;
            PercentComplete = (int) ( 100 * ( (float) completed ) / ( total ) );
        }

        #endregion Public Methods and Constructors

        #region Public Properties

        /// <summary>
        /// Gets the amount Completed for this operation.
        /// </summary>
        /// <value>The completed.</value>
        public int Completed { get; private set; }

        /// <summary>
        /// Gets the total for this operation.
        /// </summary>
        /// <value>The total.</value>
        public int Total { get; private set; }

        /// <summary>
        /// Get the % of the total that has been completed.
        /// </summary>
        /// <value>The percent complete.</value>
        public int PercentComplete { get; private set; }

        #endregion Public Properties
    }
}