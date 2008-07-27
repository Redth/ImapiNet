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
using System.Runtime.Serialization;

#endregion

namespace Imapi.Net.Interop.Exceptions
{
    /// <summary>
    /// This class is used as a base for all IMAPI and IStorage exceptions.
    /// It cannot be instantiated and can only be called by implementing objects.
    /// This class's only purpose is to provide a 'catch all' exception type for
    /// applications which reference this library. Instead of trying to catch every
    /// single exception thrown by Imapi.Net, the type ImapiException can be used as
    /// catching the exact exception is not always needed.
    /// </summary>
    [Serializable]
    public abstract class ImapiException : Exception
    {
        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImapiException"/> class.
        /// </summary>
        protected ImapiException()
        {
        } // End ImapiException()


        /// <summary>
        /// Initializes a new instance of the <see cref="ImapiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        protected ImapiException( string message )
            : base( message )
        {
        } // End ImapiException(string message)


        /// <summary>
        /// Initializes a new instance of the <see cref="ImapiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        protected ImapiException( string message, Exception innerException )
            : base( message, innerException )
        {
        } // End ImapiException(string message, Exception innerException)


        /// <summary>
        /// Initializes a new instance of the <see cref="ImapiException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
        /// <exception cref="System.ArgumentNullException">The info parameter is null. </exception>
        protected ImapiException( SerializationInfo info, StreamingContext context )
            : base( info, context )
        {
        } // End ImapiException(SerializationInfo info, StreamingContext context)

        #endregion Public Methods and Constructors
    }
}