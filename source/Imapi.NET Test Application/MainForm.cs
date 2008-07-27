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
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Imapi.Net.Interop;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Exceptions;
using Imapi.Net.Test.Synchronization;

#endregion

namespace Imapi.Net.Test
{
    public partial class MainForm : Form
    {
        #region Enumerations

        private enum ActiveFormat
        {
            Data = 0,
            Audio = 1
        }

        #endregion Enumerations

        private readonly bool _overwrite;
        private ActiveFormat _activeFormat;
        private bool _cancel;

        private DiscMaster _discMaster;
        private bool _disposed;
        private int _ejectWhenComplete;
        private JolietDiscMaster _jolietDiscMaster;
        private bool _multisession;
        private bool _recurse;
        private RedbookDiscMaster _redbookDiscMaster;
        private int _simulate;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            try
            {
                _discMaster = new DiscMaster();
            }
            catch
            {
                LockGroups();
                return;
            }
            _discMaster.AddProgress += ThreadSafe.EventHandler<ProgressEventArgs>( this, _discMaster_AddProgress );
            _discMaster.BlockProgress += ThreadSafe.EventHandler<ProgressEventArgs>( this, _discMaster_BlockProgress );
            _discMaster.BurnComplete += ThreadSafe.EventHandler<CompletionStatusEventArgs>( this,
                                                                                            _discMaster_BurnComplete );
            _discMaster.ClosingDisc += ThreadSafe.EventHandler<EstimatedTimeOperationEventArgs>( this,
                                                                                                 _discMaster_ClosingDisc );
            _discMaster.EraseComplete += ThreadSafe.EventHandler<CompletionStatusEventArgs>( this,
                                                                                             _discMaster_EraseComplete );
            _discMaster.PnpActivity += ThreadSafe.EventHandler<EventArgs>( this, _discMaster_PNPActivity );
            _discMaster.PreparingBurn += ThreadSafe.EventHandler<EstimatedTimeOperationEventArgs>( this,
                                                                                                   _discMaster_PreparingBurn );
            _discMaster.QueryCancel += ThreadSafe.EventHandler<QueryCancelEventArgs>( this, _discMaster_QueryCancel );
            _discMaster.TrackProgress += ThreadSafe.EventHandler<ProgressEventArgs>( this, _discMaster_TrackProgress );
            _discMaster.DiscRecorders.ActiveRecorderChanged += ThreadSafe.EventHandler<EventArgs>( this,
                                                                                                   DiscRecorders_ActiveRecorderChanged );

            _jolietDiscMaster = _discMaster.JolietDiscMaster;

            if ( _discMaster.DiscRecorders.ActiveDiscRecorder == null )
            {
                LockGroups();
            }

            RefreshGroups();

            _simulate = 1;
            _ejectWhenComplete = 0;
            _overwrite = true;
            _activeFormat = ActiveFormat.Data;
        }


        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="T:Imapi.Net.Test.MainForm"/> is reclaimed by garbage collection.
        /// </summary>
        ~MainForm()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose( false );
        }

        #region DiscMaster Event Handlers

        /// <summary>
        /// Handles the AddProgress event of the _discMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:Imapi.Net.ProgressEventArgs"/> instance containing the event data.</param>
        private void _discMaster_AddProgress( object sender, ProgressEventArgs e )
        {
            UpdateProgressBarAddProgress( e );
        }

        /// <summary>
        /// Handles the BlockProgress event of the _discMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:Imapi.Net.ProgressEventArgs"/> instance containing the event data.</param>
        private void _discMaster_BlockProgress( object sender, ProgressEventArgs e )
        {
            UpdateProgressBarBlockProgress( e );
        }

        /// <summary>
        /// Handles the BurnComplete event of the _discMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:Imapi.Net.CompletionStatusEventArgs"/> instance containing the event data.</param>
        private void _discMaster_BurnComplete( object sender, CompletionStatusEventArgs e )
        {
            AppendLogText( "Method \"_discMaster_BurnComplete\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the ClosingDisc event of the _discMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:Imapi.Net.EstimatedTimeOperationEventArgs"/> instance containing the event data.</param>
        private void _discMaster_ClosingDisc( object sender, EstimatedTimeOperationEventArgs e )
        {
            AppendLogText( "Method \"_discMaster_ClosingDisc\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the EraseComplete event of the _discMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:Imapi.Net.CompletionStatusEventArgs"/> instance containing the event data.</param>
        private void _discMaster_EraseComplete( object sender, CompletionStatusEventArgs e )
        {
            AppendLogText( "Method \"_discMaster_EraseComplete\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the PNPActivity event of the _discMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _discMaster_PNPActivity( object sender, EventArgs e )
        {
            AppendLogText( "Method \"_discMaster_PNPActivity\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the PreparingBurn event of the _discMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:Imapi.Net.EstimatedTimeOperationEventArgs"/> instance containing the event data.</param>
        private void _discMaster_PreparingBurn( object sender, EstimatedTimeOperationEventArgs e )
        {
            AppendLogText( "Method \"_discMaster_PreparingBurn\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the QueryCancel event of the _discMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:Imapi.Net.QueryCancelEventArgs"/> instance containing the event data.</param>
        private void _discMaster_QueryCancel( object sender, QueryCancelEventArgs e )
        {
            e.Cancel = _cancel;

            if ( _progressBarQueryCancel.Value == _progressBarQueryCancel.Maximum )
            {
                SetProgressBarValue( 0 );
            }
            else
            {
                PerformQueryCancelUpdate();
            }
        }

        /// <summary>
        /// Handles the TrackProgress event of the _discMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:Imapi.Net.ProgressEventArgs"/> instance containing the event data.</param>
        private void _discMaster_TrackProgress( object sender, ProgressEventArgs e )
        {
            UpdateProgressBarTrackProgress( e );
        }

        /// <summary>
        /// Handles the ActiveRecorderChanged event of the DiscRecorders control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void DiscRecorders_ActiveRecorderChanged( object sender, EventArgs e )
        {
            AppendLogText( "Method \"DiscRecorders_ActiveRecorderChanged\" is not yet implemented" );
        }

        #endregion DiscMaster Event Handlers

        #region Background Burn Thread

        /// <summary>
        /// Handles the DoWork event of the _backgroundWorkerBurn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void _backgroundWorkerBurn_DoWork( object sender, DoWorkEventArgs e )
        {
            try
            {
                LockGroups();

                _discMaster.DiscRecorders.ActiveDiscRecorder = _discMaster.DiscRecorders[0];

                // Calling ClearFormatContent() requires an empty disc and destroys multisession mode.
                if ( _multisession == false )
                {
                    _discMaster.ClearFormatContent();
                }

                _jolietDiscMaster.AddData( _overwrite );
                _discMaster.RecordDisc( _simulate, _ejectWhenComplete );
            }
            catch ( InvalidMediaException ex )
            {
                AppendLogText( ex.Message + Environment.NewLine );
            }
            catch ( MediaNotPresentException ex )
            {
                AppendLogText( ex.Message + Environment.NewLine );
            }
        }

        /// <summary>
        /// Handles the ProgressChanged event of the _backgroundWorkerBurn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void _backgroundWorkerBurn_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
            AppendLogText( "Method \"_backgroundWorkerBurn_ProgressChanged\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the _backgroundWorkerBurn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void _backgroundWorkerBurn_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            _progressBarAddProgress.Maximum = 100;
            _progressBarBlockProgress.Maximum = 100;
            _progressBarTrackProgress.Maximum = 100;
            UnLockGroups();
        }


        /// <summary>
        /// Handles the DoWork event of the _backgroundWorkerBurnAudio control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void _backgroundWorkerBurnAudio_DoWork( object sender, DoWorkEventArgs e )
        {
            try
            {
                LockGroups();

                // Calling ClearFormatContent() requires an empty disc and destroys multisession mode.
                //_discMaster.ClearFormatContent();
                string[] tracks = GetTrackNamesFromListView();
                for ( int i = 0; i < tracks.Length; i++ )
                {
                    _redbookDiscMaster.AddAudioTrackFromFile( tracks[i] );
                }
                _discMaster.RecordDisc( _simulate, _ejectWhenComplete );
            }
            catch ( InvalidMediaException ex )
            {
                AppendLogText( ex.Message + Environment.NewLine );
            }
            catch ( MediaNotPresentException ex )
            {
                AppendLogText( ex.Message + Environment.NewLine );
            }
        }

        /// <summary>
        /// Handles the ProgressChanged event of the _backgroundWorkerBurnAudio control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void _backgroundWorkerBurnAudio_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
            AppendLogText( "Method \"_backgroundWorkerBurn_ProgressChanged\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the _backgroundWorkerBurnAudio control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void _backgroundWorkerBurnAudio_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            _progressBarAddProgress.Maximum = 100;
            _progressBarBlockProgress.Maximum = 100;
            _progressBarTrackProgress.Maximum = 100;
            UnLockGroups();
        }

        #endregion Background Burn Threads

        #region Event Subscription Changes

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxAddProgress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxAddProgress_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxAddProgress.Checked )
            {
                _discMaster.AddProgress += _discMaster_AddProgress;
            }
            else
            {
                _discMaster.AddProgress -= _discMaster_AddProgress;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxBlockProgress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxBlockProgress_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxBlockProgress.Checked )
            {
                _discMaster.BlockProgress += _discMaster_BlockProgress;
            }
            else
            {
                _discMaster.BlockProgress -= _discMaster_BlockProgress;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxTrackProgress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxTrackProgress_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxTrackProgress.Checked )
            {
                _discMaster.TrackProgress += _discMaster_TrackProgress;
            }
            else
            {
                _discMaster.TrackProgress -= _discMaster_TrackProgress;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxPNPActivity control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxPNPActivity_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxPNPActivity.Checked )
            {
                _discMaster.PnpActivity += _discMaster_PNPActivity;
            }
            else
            {
                _discMaster.PnpActivity -= _discMaster_PNPActivity;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxQueryCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxQueryCancel_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxQueryCancel.Checked )
            {
                _discMaster.QueryCancel += _discMaster_QueryCancel;
            }
            else
            {
                _discMaster.QueryCancel -= _discMaster_QueryCancel;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxPreparingBurn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxPreparingBurn_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxPreparingBurn.Checked )
            {
                _discMaster.PreparingBurn += _discMaster_PreparingBurn;
            }
            else
            {
                _discMaster.PreparingBurn -= _discMaster_PreparingBurn;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxClosingDisc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxClosingDisc_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxClosingDisc.Checked )
            {
                _discMaster.ClosingDisc += _discMaster_ClosingDisc;
            }
            else
            {
                _discMaster.ClosingDisc -= _discMaster_ClosingDisc;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxBurnComplete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxBurnComplete_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxBurnComplete.Checked )
            {
                _discMaster.BurnComplete += _discMaster_BurnComplete;
            }
            else
            {
                _discMaster.BurnComplete -= _discMaster_BurnComplete;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxEraseComplete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxEraseComplete_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxEraseComplete.Checked )
            {
                _discMaster.EraseComplete += _discMaster_EraseComplete;
            }
            else
            {
                _discMaster.EraseComplete -= _discMaster_EraseComplete;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxActiveRecorderChanged control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxActiveRecorderChanged_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxActiveRecorderChanged.Checked )
            {
                _discMaster.DiscRecorders.ActiveRecorderChanged += DiscRecorders_ActiveRecorderChanged;
            }
            else
            {
                _discMaster.DiscRecorders.ActiveRecorderChanged -= DiscRecorders_ActiveRecorderChanged;
            }
        }

        #endregion Event Subscription Changes

        #region Active Recorder Group Events

        /// <summary>
        /// Handles the Click event of the _buttonWriteSpeedIncrease control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonWriteSpeedIncrease_Click( object sender, EventArgs e )
        {
            try
            {
                int newSpeed = _discMaster.DiscRecorders.ActiveDiscRecorder.WriteSpeed + 1;
                _discMaster.DiscRecorders.ActiveDiscRecorder.WriteSpeed = newSpeed;
                RefreshGroups();
                AppendLogText( "Active disc recorder will now write at max " +
                               _discMaster.DiscRecorders.ActiveDiscRecorder.WriteSpeed + "x" );
            }
            catch ( ArgumentOutOfRangeException ex )
            {
                AppendLogText( ex.Message + Environment.NewLine + ex.StackTrace );
            }
        }

        /// <summary>
        /// Handles the Click event of the _buttonWriteSpeedDecrease control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonWriteSpeedDecrease_Click( object sender, EventArgs e )
        {
            try
            {
                int newSpeed = _discMaster.DiscRecorders.ActiveDiscRecorder.WriteSpeed -= 1;
                //_discMaster.DiscRecorders.ActiveDiscRecorder.WriteSpeed = newSpeed;
                RefreshGroups();
                AppendLogText( "Active disc recorder will now write at max " +
                               _discMaster.DiscRecorders.ActiveDiscRecorder.WriteSpeed + "x" );
            }
            catch ( ArgumentOutOfRangeException ex )
            {
                AppendLogText( ex.Message + Environment.NewLine + ex.StackTrace );
            }
        }

        #endregion Active Recorder Group Events

        #region Joliet Group Events

        /// <summary>
        /// Handles the Click event of the _buttonSetVolumeName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonSetVolumeName_Click( object sender, EventArgs e )
        {
            if ( !String.IsNullOrEmpty( _textBoxVolumeName.Text.Trim() ) )
            {
                _jolietDiscMaster.VolumeName = _textBoxVolumeName.Text.Trim();
                AppendLogText( "Set Volume Name to:\t" + _jolietDiscMaster.VolumeName );
            }
            else
            {
                AppendLogText( "Volume Name was empty. Could not Set Volume Name." );
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _radioButtonPlaceBootImageOnDiscYes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _radioButtonPlaceBootImageOnDiscYes_CheckedChanged( object sender, EventArgs e )
        {
            AppendLogText( "Method \"_radioButtonPlaceBootImageOnDiscYes_CheckedChanged\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _radioButtonPlaceBootImageOnDiscNo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _radioButtonPlaceBootImageOnDiscNo_CheckedChanged( object sender, EventArgs e )
        {
            AppendLogText( "Method \"_radioButtonPlaceBootImageOnDiscNo_CheckedChanged\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the _comboBoxBootImagePlatform control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _comboBoxBootImagePlatform_SelectedIndexChanged( object sender, EventArgs e )
        {
            AppendLogText( "Method \"_comboBoxBootImagePlatform_SelectedIndexChanged\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the _comboBoxlBootImageEmulationType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _comboBoxlBootImageEmulationType_SelectedIndexChanged( object sender, EventArgs e )
        {
            AppendLogText( "Method \"_comboBoxlBootImageEmulationType_SelectedIndexChanged\" is not yet implemented" );
        }

        #endregion Joliet Group Events

        #region IDiscMaster Group Events

        /// <summary>
        /// Handles the Click event of the _buttonNextRecorder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonNextRecorder_Click( object sender, EventArgs e )
        {
            _discMaster.DiscRecorders.NextDiscRecorder();
            RefreshGroups();
        }

        /// <summary>
        /// Handles the Click event of the _buttonSwitchActiveDiscMasterFormat control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonSwitchActiveDiscMasterFormat_Click( object sender, EventArgs e )
        {
            if ( _activeFormat == ActiveFormat.Data )
            {
                _jolietDiscMaster.Dispose();
                _jolietDiscMaster = null;
                _discMaster.Dispose();
                _discMaster = null;
                GC.Collect();
                _discMaster = new DiscMaster();
                _discMaster.AddProgress += _discMaster_AddProgress;
                _discMaster.BlockProgress += _discMaster_BlockProgress;
                _discMaster.BurnComplete += _discMaster_BurnComplete;
                _discMaster.ClosingDisc += _discMaster_ClosingDisc;
                _discMaster.EraseComplete += _discMaster_EraseComplete;
                _discMaster.PnpActivity += _discMaster_PNPActivity;
                _discMaster.PreparingBurn += _discMaster_PreparingBurn;
                _discMaster.QueryCancel += _discMaster_QueryCancel;
                _discMaster.TrackProgress += _discMaster_TrackProgress;
                _discMaster.DiscRecorders.ActiveRecorderChanged += DiscRecorders_ActiveRecorderChanged;
                _redbookDiscMaster = _discMaster.RedbookDiscMaster;
                _groupBoxJoliet.Enabled = false;
                _groupBoxJolietActions.Enabled = false;
                _groupBoxRedbook.Enabled = true;
                _groupBoxRedbookActions.Enabled = true;
                _activeFormat = ActiveFormat.Audio;
            }
            else
            {
                _redbookDiscMaster.Dispose();
                _redbookDiscMaster = null;
                _discMaster.Dispose();
                _discMaster = null;
                GC.Collect();
                _discMaster = new DiscMaster();
                _discMaster.AddProgress += _discMaster_AddProgress;
                _discMaster.BlockProgress += _discMaster_BlockProgress;
                _discMaster.BurnComplete += _discMaster_BurnComplete;
                _discMaster.ClosingDisc += _discMaster_ClosingDisc;
                _discMaster.EraseComplete += _discMaster_EraseComplete;
                _discMaster.PnpActivity += _discMaster_PNPActivity;
                _discMaster.PreparingBurn += _discMaster_PreparingBurn;
                _discMaster.QueryCancel += _discMaster_QueryCancel;
                _discMaster.TrackProgress += _discMaster_TrackProgress;
                _discMaster.DiscRecorders.ActiveRecorderChanged += DiscRecorders_ActiveRecorderChanged;
                _jolietDiscMaster = _discMaster.JolietDiscMaster;
                _groupBoxRedbook.Enabled = false;
                _groupBoxRedbookActions.Enabled = false;
                _groupBoxJoliet.Enabled = true;
                _groupBoxJolietActions.Enabled = true;
                _activeFormat = ActiveFormat.Data;
            }

            RefreshGroups();
        }

        #endregion IDiscMaster Group Events

        #region Universal Action Group Events

        /// <summary>
        /// Handles the Click event of the _buttonEraseCDRW control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonEraseCDRW_Click( object sender, EventArgs e )
        {
            try
            {
                if ( _discMaster.DiscRecorders.ActiveDiscRecorder.MediaDetails.MediaFlags == MediaFlag.RW )
                {
                    AppendLogText( "Erasing CDRW" );
                    _discMaster.DiscRecorders.ActiveDiscRecorder.EraseCdrw( 1 );
                }
                else
                {
                    AppendLogText( "The current disc is not a CDRW. It cannot be erased." );
                }
            }
            catch ( Exception ex )
            {
                AppendLogText( ex.Message + Environment.NewLine + ex.StackTrace );
            }
        }

        /// <summary>
        /// Handles the Click event of the _buttonEjectCD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonEjectCD_Click( object sender, EventArgs e )
        {
            AppendLogText( "Ejecting CD" );
            _discMaster.DiscRecorders.ActiveDiscRecorder.Eject();
            RefreshGroups();
        }

        /// <summary>
        /// Handles the Click event of the _buttonSaveLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonSaveLog_Click( object sender, EventArgs e )
        {
            var sfd = new SaveFileDialog();
            sfd.DefaultExt = "*.txt";
            if ( sfd.ShowDialog( this ) == DialogResult.OK )
            {
                try
                {
                    byte[] text = Encoding.ASCII.GetBytes( _richTextBoxLog.Text );
                    var fs = new FileStream( sfd.FileName, FileMode.OpenOrCreate );
                    fs.Write( text, 0, text.Length );
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                }
                catch ( Exception ex )
                {
                    AppendLogText( ex.Message + Environment.NewLine + ex.StackTrace );
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the _buttonClearLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonClearLog_Click( object sender, EventArgs e )
        {
            _richTextBoxLog.Text = "";
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxSimulate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxSimulate_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxSimulate.Checked )
            {
                _simulate = 1;
                AppendLogText( "Burn will be simulated." );
            }
            else
            {
                _simulate = 0;
                AppendLogText( "Burn will not be simulated." );
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxEjectWhenComplete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxEjectWhenComplete_CheckedChanged( object sender, EventArgs e )
        {
            if ( _checkBoxEjectWhenComplete.Checked )
            {
                _ejectWhenComplete = 1;
                AppendLogText( "CD will be ejected when burn is complete." );
            }
            else
            {
                _ejectWhenComplete = 0;
                AppendLogText( "CD will not be ejected when burn is complete." );
            }
        }


        /// <summary>
        /// Handles the Click event of the _buttonCancelBurn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonCancelBurn_Click( object sender, EventArgs e )
        {
            if ( _discMaster != null )
            {
                _discMaster.CancelBurn();
            }
            _cancel = true;
        }

        /// <summary>
        /// Handles the Click event of the _buttonRefresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonRefresh_Click( object sender, EventArgs e )
        {
            RefreshGroups();
        }

        /// <summary>
        /// Handles the Click event of the _checkBoxFullErase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxFullErase_Click( object sender, EventArgs e )
        {
        }

        #endregion Universal Action Group Events

        #region Joliet Action Group Events

        /// <summary>
        /// Handles the Click event of the _buttonClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonClear_Click( object sender, EventArgs e )
        {
            _jolietDiscMaster.RootStorage.Clear();
            _listViewTracks.Clear();
        }

        /// <summary>
        /// Handles the Click event of the _buttonNewSubfolder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonNewSubfolder_Click( object sender, EventArgs e )
        {
            var sltid = new SingleLineTextInputDialog();
            sltid.Text = "Enter a folder name.";
            if ( sltid.ShowDialog() == DialogResult.OK )
            {
                _jolietDiscMaster.RootStorage.CreateSubfolder( sltid.Value );
                _treeViewFiles.Nodes.Add( sltid.Value );
                AppendLogText( "Adding Folder: " + sltid.Value + Environment.NewLine + "at /" );
                RefreshGroups();
            }
        }

        /// <summary>
        /// Handles the Click event of the _buttonAddFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonAddFile_Click( object sender, EventArgs e )
        {
            var ofd = new OpenFileDialog();
            if ( ofd.ShowDialog() == DialogResult.OK )
            {
                var fi = new FileInfo( ofd.FileName );
                _jolietDiscMaster.RootStorage.AddFile( fi.FullName, fi.Name );
                _treeViewFiles.Nodes.Add( fi.Name );
                AppendLogText( "Adding File: " + fi.FullName + Environment.NewLine + "at /" );
                RefreshGroups();
            }
        }

        /// <summary>
        /// Handles the Click event of the _buttonAddFolder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonAddFolder_Click( object sender, EventArgs e )
        {
            AppendLogText( "Method \"_buttonAddFolder_Click\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the Click event of the _buttonBurnJolietCD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonBurnJolietCD_Click( object sender, EventArgs e )
        {
            _backgroundWorkerBurn.RunWorkerAsync();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _checkBoxMultiSession control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _checkBoxMultiSession_CheckedChanged( object sender, EventArgs e )
        {
            _multisession = !_multisession;
            AppendLogText( "Multisession: " + _multisession );
        }

        #endregion Joliet Action Group Events

        #region Redbook Action Group Events

        /// <summary>
        /// Handles the Click event of the _buttonAddTrack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonAddTrack_Click( object sender, EventArgs e )
        {
            var ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.wav";
            if ( ofd.ShowDialog( this ) == DialogResult.OK )
            {
                AppendLogText( "Adding File: " + ofd.FileName );
                try
                {
                    int temp = _redbookDiscMaster.TotalAudioTracks + 1;

                    _listViewTracks.Items.Add( new ListViewItem( new[] {temp.ToString(), ofd.FileName} ) );
                    _redbookDiscMaster.AddAudioTrackFromFile( ofd.FileName );
                }
                catch ( Exception ex )
                {
                    AppendLogText( ex.Message + Environment.NewLine + ex.StackTrace );
                }
                RefreshGroups();
            }
        }

        /// <summary>
        /// Handles the Click event of the _buttonMoveTrackUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonMoveTrackUp_Click( object sender, EventArgs e )
        {
            AppendLogText( "Method \"_buttonMoveTrackUp_Click\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the Click event of the _buttonMoveTrackDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonMoveTrackDown_Click( object sender, EventArgs e )
        {
            AppendLogText( "Method \"_buttonMoveTrackDown_Click\" is not yet implemented" );
        }

        /// <summary>
        /// Handles the Click event of the _buttonBurnRedbookCD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonBurnRedbookCD_Click( object sender, EventArgs e )
        {
            _backgroundWorkerBurnAudio.RunWorkerAsync();
        }

        #endregion Redbook Action Group Events

        #region Thread Safety Helpers

        /// <summary>
        /// Appends the log text.
        /// </summary>
        /// <param name="text">The text.</param>
        private void AppendLogText( string text )
        {
            // Add the text
            _richTextBoxLog.AppendText( text + Environment.NewLine );

            // Auto-Scroll
            _richTextBoxLog.Focus();
            string newText = _richTextBoxLog.Text;
            _richTextBoxLog.SelectionStart = newText.Length;
            _richTextBoxLog.SelectionLength = 0;
            _richTextBoxLog.ScrollToCaret();
        }


        /// <summary>
        /// Sets the progress bar value.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetProgressBarValue( int value )
        {
            _progressBarQueryCancel.Value = value;
        }


        /// <summary>
        /// Updates the progress bar add progress.
        /// </summary>
        /// <param name="e">The <see cref="T:Imapi.Net.ProgressEventArgs"/> instance containing the event data.</param>
        private void UpdateProgressBarAddProgress( ProgressEventArgs e )
        {
            if ( _progressBarAddProgress.Maximum == 100 )
            {
                _progressBarAddProgress.Maximum = e.Total;
                _progressBarAddProgress.Step = e.Completed;
            }
            int maximum = _progressBarAddProgress.Maximum;
            _progressBarAddProgress.Value = ( ( e.PercentComplete * maximum ) );
        }


        /// <summary>
        /// Updates the progress bar block progress.
        /// </summary>
        /// <param name="e">The <see cref="T:Imapi.Net.ProgressEventArgs"/> instance containing the event data.</param>
        private void UpdateProgressBarBlockProgress( ProgressEventArgs e )
        {
            if ( _progressBarBlockProgress.Maximum == 100 )
            {
                _progressBarBlockProgress.Maximum = e.Total;
                _progressBarBlockProgress.Step = e.Completed;
            }
            int maximum = _progressBarBlockProgress.Maximum;
            _progressBarBlockProgress.Value = ( ( e.PercentComplete * maximum ) / 100 );
        }


        /// <summary>
        /// Updates the progress bar track progress.
        /// </summary>
        /// <param name="e">The <see cref="T:Imapi.Net.ProgressEventArgs"/> instance containing the event data.</param>
        private void UpdateProgressBarTrackProgress( ProgressEventArgs e )
        {
            if ( _progressBarTrackProgress.Maximum == 100 )
            {
                _progressBarTrackProgress.Maximum = e.Total;
                _progressBarTrackProgress.Step = e.Completed;
            }
            int maximum = _progressBarTrackProgress.Maximum;
            _progressBarTrackProgress.Value = ( ( e.PercentComplete * maximum ) / 100 );
        }


        /// <summary>
        /// Performs the query cancel update.
        /// </summary>
        private void PerformQueryCancelUpdate()
        {
            _progressBarQueryCancel.PerformStep();
        }


        /// <summary>
        /// Updates the active recorder group.
        /// </summary>
        private void UpdateActiveRecorderGroup()
        {
            if ( _discMaster.DiscRecorders.ActiveDiscRecorder != null )
            {
                _textBoxPnPID.Text = _discMaster.DiscRecorders.ActiveDiscRecorder.PnpId;
                _textBoxProduct.Text = _discMaster.DiscRecorders.ActiveDiscRecorder.Product;
                _textBoxVendor.Text = _discMaster.DiscRecorders.ActiveDiscRecorder.Vendor;
                _textBoxRevision.Text = _discMaster.DiscRecorders.ActiveDiscRecorder.Revision;
                _textBoxOSPath.Text = _discMaster.DiscRecorders.ActiveDiscRecorder.OSPath;
                _textBoxDriveLetter.Text = _discMaster.DiscRecorders.ActiveDiscRecorder.DriveLetter;
                _textBoxRecorderType.Text = _discMaster.DiscRecorders.ActiveDiscRecorder.RecorderType.ToString();
                _textBoxRecorderState.Text = _discMaster.DiscRecorders.ActiveDiscRecorder.RecorderState.ToString();
                _textBoxMaxWriteSpeed.Text = _discMaster.DiscRecorders.ActiveDiscRecorder.MaxWriteSpeed.ToString();
                _textBoxWriteSpeed.Text = _discMaster.DiscRecorders.ActiveDiscRecorder.WriteSpeed.ToString();
            }
        }


        /// <summary>
        /// Updates the redbook group.
        /// </summary>
        private void UpdateRedbookGroup()
        {
            _textBoxAvailableTrackBlocks.Text = _redbookDiscMaster.AvailableTrackBlocks.ToString();
            _textBoxAudioBlockSize.Text = _redbookDiscMaster.AudioBlockSize.ToString();
            _textBoxTotalAudioBlocks.Text = _redbookDiscMaster.TotalAudioBlocks.ToString();
            _textBoxUsedAudioBlocks.Text = _redbookDiscMaster.UsedAudioBlocks.ToString();
            _textBoxTotalAudioTracks.Text = _redbookDiscMaster.TotalAudioTracks.ToString();
        }


        /// <summary>
        /// Updates the joliet group.
        /// </summary>
        private void UpdateJolietGroup()
        {
            _textBoxDataBlockSize.Text = _jolietDiscMaster.DataBlockSize.ToString();
            _textBoxlTotalDataBlocks.Text = _jolietDiscMaster.TotalDataBlocks.ToString();
            _textBoxlUsedDataBlocks.Text = _jolietDiscMaster.UsedDataBlocks.ToString();
            _textBoxVolumeName.Text = _jolietDiscMaster.VolumeName;
            _radioButtonPlaceBootImageOnDiscYes.Checked = _jolietDiscMaster.PlaceBootImageOnDisc;
            _textBoxBootImageManufacturerIdString.Text = _jolietDiscMaster.BootImageManufacturerIdString;
            _comboBoxBootImagePlatform.SelectedItem = _jolietDiscMaster.BootImagePlatform;
            _comboBoxlBootImageEmulationType.SelectedItem = _jolietDiscMaster.BootImageEmulationType;
        }


        /// <summary>
        /// Updates the IDiscMaster group.
        /// </summary>
        private void UpdateIDiscMasterGroup()
        {
            _textBoxActiveDiscMasterFormat.Text = _activeFormat.ToString();
        }


        /// <summary>
        /// Updates the media details group.
        /// </summary>
        private void UpdateMediaDetailsGroup()
        {
            if ( _discMaster.DiscRecorders.ActiveDiscRecorder != null )
            {
                MediaDetails mediaDetails = _discMaster.DiscRecorders.ActiveDiscRecorder.MediaDetails;
                _textBoxMediaPresent.Text = mediaDetails.MediaPresent.ToString();
                _textBoxSessions.Text = mediaDetails.Sessions.ToString();
                _textBoxLastTrack.Text = mediaDetails.LastTrack.ToString();
                _textBoxStartAddress.Text = mediaDetails.StartAddress.ToString();
                _textBoxNextWritable.Text = mediaDetails.NextWritable.ToString();
                _textBoxFreeBlocks.Text = mediaDetails.FreeBlocks.ToString();
                _textBoxMediaType.Text = mediaDetails.MediaType.ToString();
                _textBoxMediaFlags.Text = mediaDetails.MediaFlags.ToString();
            }
        }


        /// <summary>
        /// Locks the groups.
        /// </summary>
        private void LockGroups()
        {
            _groupBoxActiveRecorder.Enabled = false;
            _groupBoxEventSubscriptions.Enabled = false;
            _groupBoxIDiscMaster.Enabled = false;
            _groupBoxJoliet.Enabled = false;
            _groupBoxJolietActions.Enabled = false;
            _groupBoxMediaDetails.Enabled = false;
            _groupBoxRedbook.Enabled = false;
            _groupBoxRedbookActions.Enabled = false;
            _groupBoxUniversalActions.Enabled = false;
            /*_groupBoxActiveRecorder.Enabled = false;
            _groupBoxEventSubscriptions.Enabled = false;
            _groupBoxIDiscMaster.Enabled = false;
            _groupBoxJoliet.Enabled = false;
            _groupBoxJolietActions.Enabled = false;
            _groupBoxMediaDetails.Enabled = false;
            _groupBoxRedbook.Enabled = false;
            _groupBoxRedbookActions.Enabled = false;
            _groupBoxUniversalActions.Enabled = false;*/

            RefreshGroups();
        }


        /// <summary>
        /// Uns the lock groups.
        /// </summary>
        private void UnLockGroups()
        {
            _groupBoxActiveRecorder.Enabled = true;
            _groupBoxEventSubscriptions.Enabled = true;
            _groupBoxIDiscMaster.Enabled = true;
            _groupBoxMediaDetails.Enabled = true;
            _groupBoxUniversalActions.Enabled = true;

            if ( _activeFormat == ActiveFormat.Audio )
            {
                _groupBoxJoliet.Enabled = false;
                _groupBoxJolietActions.Enabled = false;
                _groupBoxRedbook.Enabled = true;
                _groupBoxRedbookActions.Enabled = true;
            }
            else
            {
                _groupBoxRedbook.Enabled = false;
                _groupBoxRedbookActions.Enabled = false;
                _groupBoxJoliet.Enabled = true;
                _groupBoxJolietActions.Enabled = true;
            }

            RefreshGroups();
        }

        /// <summary>
        /// Gets the track names from list view.
        /// </summary>
        /// <returns></returns>
        private string[] GetTrackNamesFromListView()
        {
            var files = new string[_listViewTracks.Items.Count];
            for ( int i = 0; i < _listViewTracks.Items.Count; i++ )
            {
                foreach ( ListViewItem track in _listViewTracks.Items )
                {
                    files[i] = _listViewTracks.Items[i].SubItems[1].Text;
                    AppendLogText( "Track file: " + files[i] );
                    //_redbookDiscMaster.AddAudioTrackFromFile(track.SubItems[1].ToString());
                }
            }
            return files;
        }

        #endregion Logging Helpers

        #region Group Refresh Calls

        /// <summary>
        /// Refreshes the groups.
        /// </summary>
        public void RefreshGroups()
        {
            RefreshActiveRecorderGroup();
            RefreshIDiscMasterGroup();
            RefreshMediaDetailsGroup();

            if ( _activeFormat == ActiveFormat.Audio )
            {
                RefreshRedbookGroup();
            }
            else
            {
                RefreshJolietGroup();
            }
        }

        /// <summary>
        /// Refreshes the active recorder group.
        /// </summary>
        private void RefreshActiveRecorderGroup()
        {
            try
            {
                UpdateActiveRecorderGroup();
            }
            catch ( Exception ex )
            {
                AppendLogText( ex.Message + Environment.NewLine + ex.StackTrace );
            }
        }

        /// <summary>
        /// Refreshes the redbook group.
        /// </summary>
        private void RefreshRedbookGroup()
        {
            try
            {
                UpdateRedbookGroup();
            }
            catch ( Exception ex )
            {
                AppendLogText( ex.Message + Environment.NewLine + ex.StackTrace );
            }
        }

        /// <summary>
        /// Refreshes the joliet group.
        /// </summary>
        private void RefreshJolietGroup()
        {
            try
            {
                UpdateJolietGroup();
            }
            catch ( Exception ex )
            {
                AppendLogText( ex.Message + Environment.NewLine + ex.StackTrace );
            }
        }

        /// <summary>
        /// Refreshes the I disc master group.
        /// </summary>
        private void RefreshIDiscMasterGroup()
        {
            try
            {
                UpdateIDiscMasterGroup();
            }
            catch ( Exception ex )
            {
                AppendLogText( ex.Message + Environment.NewLine + ex.StackTrace );
            }
        }

        /// <summary>
        /// Refreshes the media details group.
        /// </summary>
        private void RefreshMediaDetailsGroup()
        {
            try
            {
                UpdateMediaDetailsGroup();
            }
            catch ( Exception ex )
            {
                AppendLogText( ex.Message + Environment.NewLine + ex.StackTrace );
            }
        }

        #endregion Group Refresh Calls

        #region Logging

        /// <summary>
        /// Handles the 1 event of the _buttonSaveLog_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonSaveLog_Click_1( object sender, EventArgs e )
        {
            _richTextBoxLog.SaveFile( Math.Abs( DateTime.Now.ToBinary() ) + ".rtf" );
        }

        /// <summary>
        /// Handles the 1 event of the _buttonClearLog_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void _buttonClearLog_Click_1( object sender, EventArgs e )
        {
            _richTextBoxLog.Clear();
        }

        #endregion Logging

        // End ~MainForm()
    }
}