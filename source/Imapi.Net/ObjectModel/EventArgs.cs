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

namespace Imapi.Net.ObjectModel
{
    /// <summary>
    /// Provides a generic EventsArgs class which eliminates the need to derive classes from EventArgs.
    /// </summary>
    /// <typeparam name="TData">The data type to contain.</typeparam>
    public class EventArgs<TData> : EventArgs
    {
        public new static readonly EventArgs<TData> Empty;

        private readonly TData eventData;

        /// <summary>
        /// Initializes the <see cref="EventArgs&lt;T&gt;"/> class.
        /// </summary>
        static EventArgs()
        {
            Empty = new EventArgs<TData>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs&lt;T&gt;"/> class.
        /// </summary>
        private EventArgs()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        public EventArgs( TData eventData )
        {
            this.eventData = eventData;
        }

        /// <summary>
        /// Gets the event data.
        /// </summary>
        /// <value>The event data.</value>
        public TData EventData
        {
            get { return eventData; }
        }
    }
}