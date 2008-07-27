#region License

//
// Author: Ian Davis <ian.f.davis@gmail.com>
// Copyright (c) 2005-2008, Ian Davis.
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
using System.Windows.Forms;

#endregion

namespace Imapi.Net.Test
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SingleLineTextInputDialog : Form
    {
        private string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SingleLineTextInputDialog"/> class.
        /// </summary>
        public SingleLineTextInputDialog()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get { return _value; }

            set { _value = value; }
        }


        /// <summary>
        /// Handles the Click event of the buttonOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void buttonOK_Click( object sender, EventArgs e )
        {
            _value = textBox.Text.Trim();
            Close();
        }


        /// <summary>
        /// Handles the Click event of the buttonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void buttonCancel_Click( object sender, EventArgs e )
        {
            _value = String.Empty;
            Close();
        }
    }
}