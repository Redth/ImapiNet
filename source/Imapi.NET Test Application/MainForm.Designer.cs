namespace Imapi.Net.Test
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._groupBoxStatus = new System.Windows.Forms.GroupBox();
            this._buttonCancelBurn = new System.Windows.Forms.Button();
            this._labelTrackProgress = new System.Windows.Forms.Label();
            this._labelBlockProgress = new System.Windows.Forms.Label();
            this._labelAddProgress = new System.Windows.Forms.Label();
            this._progressBarTrackProgress = new System.Windows.Forms.ProgressBar();
            this._labelQueryCancelFired = new System.Windows.Forms.Label();
            this._progressBarBlockProgress = new System.Windows.Forms.ProgressBar();
            this._progressBarQueryCancel = new System.Windows.Forms.ProgressBar();
            this._progressBarAddProgress = new System.Windows.Forms.ProgressBar();
            this._groupBoxRedbookActions = new System.Windows.Forms.GroupBox();
            this._buttonBurnRedbookCD = new System.Windows.Forms.Button();
            this._buttonMoveTrackDown = new System.Windows.Forms.Button();
            this._buttonMoveTrackUp = new System.Windows.Forms.Button();
            this._buttonAddTrack = new System.Windows.Forms.Button();
            this._listViewTracks = new System.Windows.Forms.ListView();
            this._columnHeaderTrack = new System.Windows.Forms.ColumnHeader();
            this._columnHeaderFileName = new System.Windows.Forms.ColumnHeader();
            this._groupBoxJolietActions = new System.Windows.Forms.GroupBox();
            this._checkBoxMultiSession = new System.Windows.Forms.CheckBox();
            this._buttonBurnJolietCD = new System.Windows.Forms.Button();
            this._buttonAddFolder = new System.Windows.Forms.Button();
            this._buttonAddFile = new System.Windows.Forms.Button();
            this._treeViewFiles = new System.Windows.Forms.TreeView();
            this._buttonNewSubfolder = new System.Windows.Forms.Button();
            this._buttonClear = new System.Windows.Forms.Button();
            this._groupBoxUniversalActions = new System.Windows.Forms.GroupBox();
            this._checkBoxFullErase = new System.Windows.Forms.CheckBox();
            this._buttonRefresh = new System.Windows.Forms.Button();
            this._checkBoxEjectWhenComplete = new System.Windows.Forms.CheckBox();
            this._checkBoxSimulate = new System.Windows.Forms.CheckBox();
            this._buttonEjectCD = new System.Windows.Forms.Button();
            this._buttonEraseCDRW = new System.Windows.Forms.Button();
            this._groupBoxEventSubscriptions = new System.Windows.Forms.GroupBox();
            this._checkBoxActiveRecorderChanged = new System.Windows.Forms.CheckBox();
            this._checkBoxEraseComplete = new System.Windows.Forms.CheckBox();
            this._checkBoxBurnComplete = new System.Windows.Forms.CheckBox();
            this._checkBoxClosingDisc = new System.Windows.Forms.CheckBox();
            this._checkBoxPreparingBurn = new System.Windows.Forms.CheckBox();
            this._checkBoxQueryCancel = new System.Windows.Forms.CheckBox();
            this._checkBoxPNPActivity = new System.Windows.Forms.CheckBox();
            this._checkBoxTrackProgress = new System.Windows.Forms.CheckBox();
            this._checkBoxBlockProgress = new System.Windows.Forms.CheckBox();
            this._checkBoxAddProgress = new System.Windows.Forms.CheckBox();
            this._groupBoxIDiscMaster = new System.Windows.Forms.GroupBox();
            this._buttonNextRecorder = new System.Windows.Forms.Button();
            this._buttonSwitchActiveDiscMasterFormat = new System.Windows.Forms.Button();
            this._textBoxActiveDiscMasterFormat = new System.Windows.Forms.TextBox();
            this._labelActiveDiscMasterFormat = new System.Windows.Forms.Label();
            this._groupBoxRedbook = new System.Windows.Forms.GroupBox();
            this._textBoxTotalAudioTracks = new System.Windows.Forms.TextBox();
            this._textBoxUsedAudioBlocks = new System.Windows.Forms.TextBox();
            this._textBoxTotalAudioBlocks = new System.Windows.Forms.TextBox();
            this._textBoxAudioBlockSize = new System.Windows.Forms.TextBox();
            this._textBoxAvailableTrackBlocks = new System.Windows.Forms.TextBox();
            this._labelTotalAudioTracks = new System.Windows.Forms.Label();
            this._labelUsedAudioBlocks = new System.Windows.Forms.Label();
            this._labelTotalAudioBlocks = new System.Windows.Forms.Label();
            this._labelAudioBlockSize = new System.Windows.Forms.Label();
            this._labelAvailableTrackBlocks = new System.Windows.Forms.Label();
            this._groupBoxJoliet = new System.Windows.Forms.GroupBox();
            this._comboBoxlBootImageEmulationType = new System.Windows.Forms.ComboBox();
            this._comboBoxBootImagePlatform = new System.Windows.Forms.ComboBox();
            this._buttonSetVolumeName = new System.Windows.Forms.Button();
            this._textBoxBootImageManufacturerIdString = new System.Windows.Forms.TextBox();
            this._textBoxVolumeName = new System.Windows.Forms.TextBox();
            this._radioButtonPlaceBootImageOnDiscNo = new System.Windows.Forms.RadioButton();
            this._radioButtonPlaceBootImageOnDiscYes = new System.Windows.Forms.RadioButton();
            this._textBoxlUsedDataBlocks = new System.Windows.Forms.TextBox();
            this._textBoxlTotalDataBlocks = new System.Windows.Forms.TextBox();
            this._textBoxDataBlockSize = new System.Windows.Forms.TextBox();
            this._labelBootImageEmulationType = new System.Windows.Forms.Label();
            this._labelBootImagePlatform = new System.Windows.Forms.Label();
            this._labelBootImageManufacturerIdString = new System.Windows.Forms.Label();
            this._labelPlaceBootImageOnDisc = new System.Windows.Forms.Label();
            this._labelVolumeName = new System.Windows.Forms.Label();
            this._labelUsedDataBlocks = new System.Windows.Forms.Label();
            this._labelTotalDataBlocks = new System.Windows.Forms.Label();
            this._labelDataBlockSize = new System.Windows.Forms.Label();
            this._groupBoxActiveRecorder = new System.Windows.Forms.GroupBox();
            this._buttonWriteSpeedDecrease = new System.Windows.Forms.Button();
            this._buttonWriteSpeedIncrease = new System.Windows.Forms.Button();
            this._textBoxWriteSpeed = new System.Windows.Forms.TextBox();
            this._textBoxMaxWriteSpeed = new System.Windows.Forms.TextBox();
            this._textBoxRecorderState = new System.Windows.Forms.TextBox();
            this._textBoxRecorderType = new System.Windows.Forms.TextBox();
            this._textBoxDriveLetter = new System.Windows.Forms.TextBox();
            this._textBoxOSPath = new System.Windows.Forms.TextBox();
            this._textBoxRevision = new System.Windows.Forms.TextBox();
            this._textBoxVendor = new System.Windows.Forms.TextBox();
            this._textBoxProduct = new System.Windows.Forms.TextBox();
            this._textBoxPnPID = new System.Windows.Forms.TextBox();
            this._labelWriteSpeed = new System.Windows.Forms.Label();
            this._labelMaxWriteSpeed = new System.Windows.Forms.Label();
            this._labelRecorderState = new System.Windows.Forms.Label();
            this._labelRecorderType = new System.Windows.Forms.Label();
            this._labelDriveLetter = new System.Windows.Forms.Label();
            this._labelOSPath = new System.Windows.Forms.Label();
            this._labelRevision = new System.Windows.Forms.Label();
            this._labelVendor = new System.Windows.Forms.Label();
            this._labelProduct = new System.Windows.Forms.Label();
            this._labelPnpID = new System.Windows.Forms.Label();
            this._groupBoxMediaDetails = new System.Windows.Forms.GroupBox();
            this._textBoxMediaFlags = new System.Windows.Forms.TextBox();
            this._textBoxMediaType = new System.Windows.Forms.TextBox();
            this._textBoxFreeBlocks = new System.Windows.Forms.TextBox();
            this._textBoxNextWritable = new System.Windows.Forms.TextBox();
            this._textBoxStartAddress = new System.Windows.Forms.TextBox();
            this._textBoxLastTrack = new System.Windows.Forms.TextBox();
            this._textBoxSessions = new System.Windows.Forms.TextBox();
            this._textBoxMediaPresent = new System.Windows.Forms.TextBox();
            this._labelMediaFlags = new System.Windows.Forms.Label();
            this._labelMediaType = new System.Windows.Forms.Label();
            this._labelFreeBlocks = new System.Windows.Forms.Label();
            this._labelNextWritable = new System.Windows.Forms.Label();
            this._labelStartAddress = new System.Windows.Forms.Label();
            this._labelLastTrack = new System.Windows.Forms.Label();
            this._labelSessions = new System.Windows.Forms.Label();
            this._labelMediaPresent = new System.Windows.Forms.Label();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._tabPageBurn = new System.Windows.Forms.TabPage();
            this._tabPageLog = new System.Windows.Forms.TabPage();
            this._buttonSaveLog = new System.Windows.Forms.Button();
            this._buttonClearLog = new System.Windows.Forms.Button();
            this._groupBoxLog = new System.Windows.Forms.GroupBox();
            this._richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this._backgroundWorkerBurnAudio = new System.ComponentModel.BackgroundWorker();
            this._backgroundWorkerBurn = new System.ComponentModel.BackgroundWorker();
            this._groupBoxStatus.SuspendLayout();
            this._groupBoxRedbookActions.SuspendLayout();
            this._groupBoxJolietActions.SuspendLayout();
            this._groupBoxUniversalActions.SuspendLayout();
            this._groupBoxEventSubscriptions.SuspendLayout();
            this._groupBoxIDiscMaster.SuspendLayout();
            this._groupBoxRedbook.SuspendLayout();
            this._groupBoxJoliet.SuspendLayout();
            this._groupBoxActiveRecorder.SuspendLayout();
            this._groupBoxMediaDetails.SuspendLayout();
            this._tabControl.SuspendLayout();
            this._tabPageBurn.SuspendLayout();
            this._tabPageLog.SuspendLayout();
            this._groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBoxStatus
            // 
            this._groupBoxStatus.Controls.Add(this._buttonCancelBurn);
            this._groupBoxStatus.Controls.Add(this._labelTrackProgress);
            this._groupBoxStatus.Controls.Add(this._labelBlockProgress);
            this._groupBoxStatus.Controls.Add(this._labelAddProgress);
            this._groupBoxStatus.Controls.Add(this._progressBarTrackProgress);
            this._groupBoxStatus.Controls.Add(this._labelQueryCancelFired);
            this._groupBoxStatus.Controls.Add(this._progressBarBlockProgress);
            this._groupBoxStatus.Controls.Add(this._progressBarQueryCancel);
            this._groupBoxStatus.Controls.Add(this._progressBarAddProgress);
            this._groupBoxStatus.Location = new System.Drawing.Point(520, 141);
            this._groupBoxStatus.Name = "_groupBoxStatus";
            this._groupBoxStatus.Size = new System.Drawing.Size(289, 112);
            this._groupBoxStatus.TabIndex = 20;
            this._groupBoxStatus.TabStop = false;
            this._groupBoxStatus.Text = "Status";
            // 
            // _buttonCancelBurn
            // 
            this._buttonCancelBurn.Location = new System.Drawing.Point(9, 92);
            this._buttonCancelBurn.Name = "_buttonCancelBurn";
            this._buttonCancelBurn.Size = new System.Drawing.Size(75, 19);
            this._buttonCancelBurn.TabIndex = 16;
            this._buttonCancelBurn.Text = "Cancel Burn";
            this._buttonCancelBurn.UseVisualStyleBackColor = true;
            this._buttonCancelBurn.Click += new System.EventHandler(this._buttonCancelBurn_Click);
            // 
            // _labelTrackProgress
            // 
            this._labelTrackProgress.AutoSize = true;
            this._labelTrackProgress.Location = new System.Drawing.Point(6, 74);
            this._labelTrackProgress.Name = "_labelTrackProgress";
            this._labelTrackProgress.Size = new System.Drawing.Size(79, 13);
            this._labelTrackProgress.TabIndex = 15;
            this._labelTrackProgress.Text = "TrackProgress:";
            // 
            // _labelBlockProgress
            // 
            this._labelBlockProgress.AutoSize = true;
            this._labelBlockProgress.Location = new System.Drawing.Point(6, 55);
            this._labelBlockProgress.Name = "_labelBlockProgress";
            this._labelBlockProgress.Size = new System.Drawing.Size(78, 13);
            this._labelBlockProgress.TabIndex = 14;
            this._labelBlockProgress.Text = "BlockProgress:";
            // 
            // _labelAddProgress
            // 
            this._labelAddProgress.AutoSize = true;
            this._labelAddProgress.Location = new System.Drawing.Point(6, 35);
            this._labelAddProgress.Name = "_labelAddProgress";
            this._labelAddProgress.Size = new System.Drawing.Size(70, 13);
            this._labelAddProgress.TabIndex = 13;
            this._labelAddProgress.Text = "AddProgress:";
            // 
            // _progressBarTrackProgress
            // 
            this._progressBarTrackProgress.Location = new System.Drawing.Point(112, 74);
            this._progressBarTrackProgress.Name = "_progressBarTrackProgress";
            this._progressBarTrackProgress.Size = new System.Drawing.Size(171, 13);
            this._progressBarTrackProgress.TabIndex = 12;
            // 
            // _labelQueryCancelFired
            // 
            this._labelQueryCancelFired.AutoSize = true;
            this._labelQueryCancelFired.Location = new System.Drawing.Point(6, 16);
            this._labelQueryCancelFired.Name = "_labelQueryCancelFired";
            this._labelQueryCancelFired.Size = new System.Drawing.Size(100, 13);
            this._labelQueryCancelFired.TabIndex = 3;
            this._labelQueryCancelFired.Text = "Query Cancel Fired:";
            // 
            // _progressBarBlockProgress
            // 
            this._progressBarBlockProgress.Location = new System.Drawing.Point(112, 54);
            this._progressBarBlockProgress.Name = "_progressBarBlockProgress";
            this._progressBarBlockProgress.Size = new System.Drawing.Size(171, 14);
            this._progressBarBlockProgress.TabIndex = 11;
            // 
            // _progressBarQueryCancel
            // 
            this._progressBarQueryCancel.Location = new System.Drawing.Point(112, 16);
            this._progressBarQueryCancel.Maximum = 5;
            this._progressBarQueryCancel.Name = "_progressBarQueryCancel";
            this._progressBarQueryCancel.Size = new System.Drawing.Size(171, 13);
            this._progressBarQueryCancel.Step = 1;
            this._progressBarQueryCancel.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._progressBarQueryCancel.TabIndex = 4;
            // 
            // _progressBarAddProgress
            // 
            this._progressBarAddProgress.Location = new System.Drawing.Point(112, 35);
            this._progressBarAddProgress.Name = "_progressBarAddProgress";
            this._progressBarAddProgress.Size = new System.Drawing.Size(171, 13);
            this._progressBarAddProgress.TabIndex = 10;
            // 
            // _groupBoxRedbookActions
            // 
            this._groupBoxRedbookActions.Controls.Add(this._buttonBurnRedbookCD);
            this._groupBoxRedbookActions.Controls.Add(this._buttonMoveTrackDown);
            this._groupBoxRedbookActions.Controls.Add(this._buttonMoveTrackUp);
            this._groupBoxRedbookActions.Controls.Add(this._buttonAddTrack);
            this._groupBoxRedbookActions.Controls.Add(this._listViewTracks);
            this._groupBoxRedbookActions.Enabled = false;
            this._groupBoxRedbookActions.Location = new System.Drawing.Point(313, 351);
            this._groupBoxRedbookActions.Name = "_groupBoxRedbookActions";
            this._groupBoxRedbookActions.Size = new System.Drawing.Size(496, 170);
            this._groupBoxRedbookActions.TabIndex = 19;
            this._groupBoxRedbookActions.TabStop = false;
            this._groupBoxRedbookActions.Text = "Redbook Actions";
            // 
            // _buttonBurnRedbookCD
            // 
            this._buttonBurnRedbookCD.Location = new System.Drawing.Point(6, 103);
            this._buttonBurnRedbookCD.Name = "_buttonBurnRedbookCD";
            this._buttonBurnRedbookCD.Size = new System.Drawing.Size(75, 23);
            this._buttonBurnRedbookCD.TabIndex = 11;
            this._buttonBurnRedbookCD.Text = "Burn CD";
            this._buttonBurnRedbookCD.UseVisualStyleBackColor = true;
            this._buttonBurnRedbookCD.Click += new System.EventHandler(this._buttonBurnRedbookCD_Click);
            // 
            // _buttonMoveTrackDown
            // 
            this._buttonMoveTrackDown.Location = new System.Drawing.Point(6, 74);
            this._buttonMoveTrackDown.Name = "_buttonMoveTrackDown";
            this._buttonMoveTrackDown.Size = new System.Drawing.Size(75, 23);
            this._buttonMoveTrackDown.TabIndex = 3;
            this._buttonMoveTrackDown.Text = "Move Down";
            this._buttonMoveTrackDown.UseVisualStyleBackColor = true;
            this._buttonMoveTrackDown.Click += new System.EventHandler(this._buttonMoveTrackDown_Click);
            // 
            // _buttonMoveTrackUp
            // 
            this._buttonMoveTrackUp.Location = new System.Drawing.Point(6, 45);
            this._buttonMoveTrackUp.Name = "_buttonMoveTrackUp";
            this._buttonMoveTrackUp.Size = new System.Drawing.Size(75, 23);
            this._buttonMoveTrackUp.TabIndex = 2;
            this._buttonMoveTrackUp.Text = "Move Up";
            this._buttonMoveTrackUp.UseVisualStyleBackColor = true;
            this._buttonMoveTrackUp.Click += new System.EventHandler(this._buttonMoveTrackUp_Click);
            // 
            // _buttonAddTrack
            // 
            this._buttonAddTrack.Location = new System.Drawing.Point(6, 16);
            this._buttonAddTrack.Name = "_buttonAddTrack";
            this._buttonAddTrack.Size = new System.Drawing.Size(75, 23);
            this._buttonAddTrack.TabIndex = 1;
            this._buttonAddTrack.Text = "Add Track";
            this._buttonAddTrack.UseVisualStyleBackColor = true;
            this._buttonAddTrack.Click += new System.EventHandler(this._buttonAddTrack_Click);
            // 
            // _listViewTracks
            // 
            this._listViewTracks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._listViewTracks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnHeaderTrack,
            this._columnHeaderFileName});
            this._listViewTracks.Dock = System.Windows.Forms.DockStyle.Right;
            this._listViewTracks.FullRowSelect = true;
            this._listViewTracks.GridLines = true;
            this._listViewTracks.Location = new System.Drawing.Point(106, 16);
            this._listViewTracks.Name = "_listViewTracks";
            this._listViewTracks.Size = new System.Drawing.Size(387, 151);
            this._listViewTracks.TabIndex = 0;
            this._listViewTracks.UseCompatibleStateImageBehavior = false;
            this._listViewTracks.View = System.Windows.Forms.View.Details;
            // 
            // _columnHeaderTrack
            // 
            this._columnHeaderTrack.Text = "Track";
            this._columnHeaderTrack.Width = 45;
            // 
            // _columnHeaderFileName
            // 
            this._columnHeaderFileName.Text = "File Name";
            this._columnHeaderFileName.Width = 240;
            // 
            // _groupBoxJolietActions
            // 
            this._groupBoxJolietActions.Controls.Add(this._checkBoxMultiSession);
            this._groupBoxJolietActions.Controls.Add(this._buttonBurnJolietCD);
            this._groupBoxJolietActions.Controls.Add(this._buttonAddFolder);
            this._groupBoxJolietActions.Controls.Add(this._buttonAddFile);
            this._groupBoxJolietActions.Controls.Add(this._treeViewFiles);
            this._groupBoxJolietActions.Controls.Add(this._buttonNewSubfolder);
            this._groupBoxJolietActions.Controls.Add(this._buttonClear);
            this._groupBoxJolietActions.Location = new System.Drawing.Point(313, 527);
            this._groupBoxJolietActions.Name = "_groupBoxJolietActions";
            this._groupBoxJolietActions.Size = new System.Drawing.Size(496, 173);
            this._groupBoxJolietActions.TabIndex = 18;
            this._groupBoxJolietActions.TabStop = false;
            this._groupBoxJolietActions.Text = "Joliet Actions";
            // 
            // _checkBoxMultiSession
            // 
            this._checkBoxMultiSession.AutoSize = true;
            this._checkBoxMultiSession.Location = new System.Drawing.Point(9, 150);
            this._checkBoxMultiSession.Name = "_checkBoxMultiSession";
            this._checkBoxMultiSession.Size = new System.Drawing.Size(88, 17);
            this._checkBoxMultiSession.TabIndex = 11;
            this._checkBoxMultiSession.Text = "Multi-Session";
            this._checkBoxMultiSession.UseVisualStyleBackColor = true;
            this._checkBoxMultiSession.CheckedChanged += new System.EventHandler(this._checkBoxMultiSession_CheckedChanged);
            // 
            // _buttonBurnJolietCD
            // 
            this._buttonBurnJolietCD.Location = new System.Drawing.Point(9, 126);
            this._buttonBurnJolietCD.Name = "_buttonBurnJolietCD";
            this._buttonBurnJolietCD.Size = new System.Drawing.Size(75, 20);
            this._buttonBurnJolietCD.TabIndex = 10;
            this._buttonBurnJolietCD.Text = "Burn CD";
            this._buttonBurnJolietCD.UseVisualStyleBackColor = true;
            this._buttonBurnJolietCD.Click += new System.EventHandler(this._buttonBurnJolietCD_Click);
            // 
            // _buttonAddFolder
            // 
            this._buttonAddFolder.Location = new System.Drawing.Point(9, 100);
            this._buttonAddFolder.Name = "_buttonAddFolder";
            this._buttonAddFolder.Size = new System.Drawing.Size(75, 20);
            this._buttonAddFolder.TabIndex = 9;
            this._buttonAddFolder.Text = "Add Folder";
            this._buttonAddFolder.UseVisualStyleBackColor = true;
            this._buttonAddFolder.Click += new System.EventHandler(this._buttonAddFolder_Click);
            // 
            // _buttonAddFile
            // 
            this._buttonAddFile.Location = new System.Drawing.Point(9, 46);
            this._buttonAddFile.Name = "_buttonAddFile";
            this._buttonAddFile.Size = new System.Drawing.Size(75, 20);
            this._buttonAddFile.TabIndex = 8;
            this._buttonAddFile.Text = "Add File";
            this._buttonAddFile.UseVisualStyleBackColor = true;
            this._buttonAddFile.Click += new System.EventHandler(this._buttonAddFile_Click);
            // 
            // _treeViewFiles
            // 
            this._treeViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._treeViewFiles.Dock = System.Windows.Forms.DockStyle.Right;
            this._treeViewFiles.Location = new System.Drawing.Point(106, 16);
            this._treeViewFiles.Name = "_treeViewFiles";
            this._treeViewFiles.Size = new System.Drawing.Size(387, 154);
            this._treeViewFiles.TabIndex = 7;
            // 
            // _buttonNewSubfolder
            // 
            this._buttonNewSubfolder.Location = new System.Drawing.Point(9, 74);
            this._buttonNewSubfolder.Name = "_buttonNewSubfolder";
            this._buttonNewSubfolder.Size = new System.Drawing.Size(75, 20);
            this._buttonNewSubfolder.TabIndex = 6;
            this._buttonNewSubfolder.Text = "New Folder";
            this._buttonNewSubfolder.UseVisualStyleBackColor = true;
            this._buttonNewSubfolder.Click += new System.EventHandler(this._buttonNewSubfolder_Click);
            // 
            // _buttonClear
            // 
            this._buttonClear.Location = new System.Drawing.Point(9, 19);
            this._buttonClear.Name = "_buttonClear";
            this._buttonClear.Size = new System.Drawing.Size(75, 20);
            this._buttonClear.TabIndex = 5;
            this._buttonClear.Text = "Clear";
            this._buttonClear.UseVisualStyleBackColor = true;
            this._buttonClear.Click += new System.EventHandler(this._buttonClear_Click);
            // 
            // _groupBoxUniversalActions
            // 
            this._groupBoxUniversalActions.Controls.Add(this._checkBoxFullErase);
            this._groupBoxUniversalActions.Controls.Add(this._buttonRefresh);
            this._groupBoxUniversalActions.Controls.Add(this._checkBoxEjectWhenComplete);
            this._groupBoxUniversalActions.Controls.Add(this._checkBoxSimulate);
            this._groupBoxUniversalActions.Controls.Add(this._buttonEjectCD);
            this._groupBoxUniversalActions.Controls.Add(this._buttonEraseCDRW);
            this._groupBoxUniversalActions.Location = new System.Drawing.Point(313, 59);
            this._groupBoxUniversalActions.Name = "_groupBoxUniversalActions";
            this._groupBoxUniversalActions.Size = new System.Drawing.Size(496, 76);
            this._groupBoxUniversalActions.TabIndex = 17;
            this._groupBoxUniversalActions.TabStop = false;
            this._groupBoxUniversalActions.Text = "Universal Actions";
            // 
            // _checkBoxFullErase
            // 
            this._checkBoxFullErase.AutoSize = true;
            this._checkBoxFullErase.Location = new System.Drawing.Point(92, 22);
            this._checkBoxFullErase.Name = "_checkBoxFullErase";
            this._checkBoxFullErase.Size = new System.Drawing.Size(72, 17);
            this._checkBoxFullErase.TabIndex = 8;
            this._checkBoxFullErase.Text = "Full Erase";
            this._checkBoxFullErase.UseVisualStyleBackColor = true;
            this._checkBoxFullErase.CheckedChanged += new System.EventHandler(this._checkBoxFullErase_Click);
            // 
            // _buttonRefresh
            // 
            this._buttonRefresh.Location = new System.Drawing.Point(410, 17);
            this._buttonRefresh.Name = "_buttonRefresh";
            this._buttonRefresh.Size = new System.Drawing.Size(80, 22);
            this._buttonRefresh.TabIndex = 7;
            this._buttonRefresh.Text = "Refresh";
            this._buttonRefresh.UseVisualStyleBackColor = true;
            this._buttonRefresh.Click += new System.EventHandler(this._buttonRefresh_Click);
            // 
            // _checkBoxEjectWhenComplete
            // 
            this._checkBoxEjectWhenComplete.AutoSize = true;
            this._checkBoxEjectWhenComplete.Location = new System.Drawing.Point(242, 49);
            this._checkBoxEjectWhenComplete.Name = "_checkBoxEjectWhenComplete";
            this._checkBoxEjectWhenComplete.Size = new System.Drawing.Size(129, 17);
            this._checkBoxEjectWhenComplete.TabIndex = 6;
            this._checkBoxEjectWhenComplete.Text = "Eject When Complete";
            this._checkBoxEjectWhenComplete.UseVisualStyleBackColor = true;
            this._checkBoxEjectWhenComplete.CheckedChanged += new System.EventHandler(this._checkBoxEjectWhenComplete_CheckedChanged);
            // 
            // _checkBoxSimulate
            // 
            this._checkBoxSimulate.AutoSize = true;
            this._checkBoxSimulate.Checked = true;
            this._checkBoxSimulate.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxSimulate.Location = new System.Drawing.Point(170, 49);
            this._checkBoxSimulate.Name = "_checkBoxSimulate";
            this._checkBoxSimulate.Size = new System.Drawing.Size(66, 17);
            this._checkBoxSimulate.TabIndex = 5;
            this._checkBoxSimulate.Text = "Simulate";
            this._checkBoxSimulate.UseVisualStyleBackColor = true;
            this._checkBoxSimulate.CheckedChanged += new System.EventHandler(this._checkBoxSimulate_CheckedChanged);
            // 
            // _buttonEjectCD
            // 
            this._buttonEjectCD.Location = new System.Drawing.Point(324, 17);
            this._buttonEjectCD.Name = "_buttonEjectCD";
            this._buttonEjectCD.Size = new System.Drawing.Size(80, 22);
            this._buttonEjectCD.TabIndex = 1;
            this._buttonEjectCD.Text = "Eject CD";
            this._buttonEjectCD.UseVisualStyleBackColor = true;
            this._buttonEjectCD.Click += new System.EventHandler(this._buttonEjectCD_Click);
            // 
            // _buttonEraseCDRW
            // 
            this._buttonEraseCDRW.Location = new System.Drawing.Point(6, 17);
            this._buttonEraseCDRW.Name = "_buttonEraseCDRW";
            this._buttonEraseCDRW.Size = new System.Drawing.Size(80, 22);
            this._buttonEraseCDRW.TabIndex = 0;
            this._buttonEraseCDRW.Text = "Erase CDRW";
            this._buttonEraseCDRW.UseVisualStyleBackColor = true;
            this._buttonEraseCDRW.Click += new System.EventHandler(this._buttonEraseCDRW_Click);
            // 
            // _groupBoxEventSubscriptions
            // 
            this._groupBoxEventSubscriptions.Controls.Add(this._checkBoxActiveRecorderChanged);
            this._groupBoxEventSubscriptions.Controls.Add(this._checkBoxEraseComplete);
            this._groupBoxEventSubscriptions.Controls.Add(this._checkBoxBurnComplete);
            this._groupBoxEventSubscriptions.Controls.Add(this._checkBoxClosingDisc);
            this._groupBoxEventSubscriptions.Controls.Add(this._checkBoxPreparingBurn);
            this._groupBoxEventSubscriptions.Controls.Add(this._checkBoxQueryCancel);
            this._groupBoxEventSubscriptions.Controls.Add(this._checkBoxPNPActivity);
            this._groupBoxEventSubscriptions.Controls.Add(this._checkBoxTrackProgress);
            this._groupBoxEventSubscriptions.Controls.Add(this._checkBoxBlockProgress);
            this._groupBoxEventSubscriptions.Controls.Add(this._checkBoxAddProgress);
            this._groupBoxEventSubscriptions.Location = new System.Drawing.Point(3, 238);
            this._groupBoxEventSubscriptions.Name = "_groupBoxEventSubscriptions";
            this._groupBoxEventSubscriptions.Size = new System.Drawing.Size(304, 121);
            this._groupBoxEventSubscriptions.TabIndex = 16;
            this._groupBoxEventSubscriptions.TabStop = false;
            this._groupBoxEventSubscriptions.Text = "Event Subscriptions";
            // 
            // _checkBoxActiveRecorderChanged
            // 
            this._checkBoxActiveRecorderChanged.AutoSize = true;
            this._checkBoxActiveRecorderChanged.Checked = true;
            this._checkBoxActiveRecorderChanged.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxActiveRecorderChanged.Location = new System.Drawing.Point(146, 98);
            this._checkBoxActiveRecorderChanged.Name = "_checkBoxActiveRecorderChanged";
            this._checkBoxActiveRecorderChanged.Size = new System.Drawing.Size(143, 17);
            this._checkBoxActiveRecorderChanged.TabIndex = 9;
            this._checkBoxActiveRecorderChanged.Text = "ActiveRecorderChanged";
            this._checkBoxActiveRecorderChanged.UseVisualStyleBackColor = true;
            this._checkBoxActiveRecorderChanged.CheckedChanged += new System.EventHandler(this._checkBoxActiveRecorderChanged_CheckedChanged);
            // 
            // _checkBoxEraseComplete
            // 
            this._checkBoxEraseComplete.AutoSize = true;
            this._checkBoxEraseComplete.Checked = true;
            this._checkBoxEraseComplete.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxEraseComplete.Location = new System.Drawing.Point(146, 77);
            this._checkBoxEraseComplete.Name = "_checkBoxEraseComplete";
            this._checkBoxEraseComplete.Size = new System.Drawing.Size(97, 17);
            this._checkBoxEraseComplete.TabIndex = 8;
            this._checkBoxEraseComplete.Text = "EraseComplete";
            this._checkBoxEraseComplete.UseVisualStyleBackColor = true;
            this._checkBoxEraseComplete.CheckedChanged += new System.EventHandler(this._checkBoxEraseComplete_CheckedChanged);
            // 
            // _checkBoxBurnComplete
            // 
            this._checkBoxBurnComplete.AutoSize = true;
            this._checkBoxBurnComplete.Checked = true;
            this._checkBoxBurnComplete.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxBurnComplete.Location = new System.Drawing.Point(146, 56);
            this._checkBoxBurnComplete.Name = "_checkBoxBurnComplete";
            this._checkBoxBurnComplete.Size = new System.Drawing.Size(92, 17);
            this._checkBoxBurnComplete.TabIndex = 7;
            this._checkBoxBurnComplete.Text = "BurnComplete";
            this._checkBoxBurnComplete.UseVisualStyleBackColor = true;
            this._checkBoxBurnComplete.CheckedChanged += new System.EventHandler(this._checkBoxBurnComplete_CheckedChanged);
            // 
            // _checkBoxClosingDisc
            // 
            this._checkBoxClosingDisc.AutoSize = true;
            this._checkBoxClosingDisc.Checked = true;
            this._checkBoxClosingDisc.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxClosingDisc.Location = new System.Drawing.Point(146, 35);
            this._checkBoxClosingDisc.Name = "_checkBoxClosingDisc";
            this._checkBoxClosingDisc.Size = new System.Drawing.Size(81, 17);
            this._checkBoxClosingDisc.TabIndex = 6;
            this._checkBoxClosingDisc.Text = "ClosingDisc";
            this._checkBoxClosingDisc.UseVisualStyleBackColor = true;
            this._checkBoxClosingDisc.CheckedChanged += new System.EventHandler(this._checkBoxClosingDisc_CheckedChanged);
            // 
            // _checkBoxPreparingBurn
            // 
            this._checkBoxPreparingBurn.AutoSize = true;
            this._checkBoxPreparingBurn.Checked = true;
            this._checkBoxPreparingBurn.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxPreparingBurn.Location = new System.Drawing.Point(146, 14);
            this._checkBoxPreparingBurn.Name = "_checkBoxPreparingBurn";
            this._checkBoxPreparingBurn.Size = new System.Drawing.Size(93, 17);
            this._checkBoxPreparingBurn.TabIndex = 5;
            this._checkBoxPreparingBurn.Text = "PreparingBurn";
            this._checkBoxPreparingBurn.UseVisualStyleBackColor = true;
            this._checkBoxPreparingBurn.CheckedChanged += new System.EventHandler(this._checkBoxPreparingBurn_CheckedChanged);
            // 
            // _checkBoxQueryCancel
            // 
            this._checkBoxQueryCancel.AutoSize = true;
            this._checkBoxQueryCancel.Checked = true;
            this._checkBoxQueryCancel.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxQueryCancel.Location = new System.Drawing.Point(9, 98);
            this._checkBoxQueryCancel.Name = "_checkBoxQueryCancel";
            this._checkBoxQueryCancel.Size = new System.Drawing.Size(87, 17);
            this._checkBoxQueryCancel.TabIndex = 4;
            this._checkBoxQueryCancel.Text = "QueryCancel";
            this._checkBoxQueryCancel.UseVisualStyleBackColor = true;
            this._checkBoxQueryCancel.CheckedChanged += new System.EventHandler(this._checkBoxQueryCancel_CheckedChanged);
            // 
            // _checkBoxPNPActivity
            // 
            this._checkBoxPNPActivity.AutoSize = true;
            this._checkBoxPNPActivity.Checked = true;
            this._checkBoxPNPActivity.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxPNPActivity.Location = new System.Drawing.Point(9, 77);
            this._checkBoxPNPActivity.Name = "_checkBoxPNPActivity";
            this._checkBoxPNPActivity.Size = new System.Drawing.Size(82, 17);
            this._checkBoxPNPActivity.TabIndex = 3;
            this._checkBoxPNPActivity.Text = "PNPActivity";
            this._checkBoxPNPActivity.UseVisualStyleBackColor = true;
            this._checkBoxPNPActivity.CheckedChanged += new System.EventHandler(this._checkBoxPNPActivity_CheckedChanged);
            // 
            // _checkBoxTrackProgress
            // 
            this._checkBoxTrackProgress.AutoSize = true;
            this._checkBoxTrackProgress.Checked = true;
            this._checkBoxTrackProgress.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxTrackProgress.Location = new System.Drawing.Point(9, 56);
            this._checkBoxTrackProgress.Name = "_checkBoxTrackProgress";
            this._checkBoxTrackProgress.Size = new System.Drawing.Size(95, 17);
            this._checkBoxTrackProgress.TabIndex = 2;
            this._checkBoxTrackProgress.Text = "TrackProgress";
            this._checkBoxTrackProgress.UseVisualStyleBackColor = true;
            this._checkBoxTrackProgress.CursorChanged += new System.EventHandler(this._checkBoxTrackProgress_CheckedChanged);
            // 
            // _checkBoxBlockProgress
            // 
            this._checkBoxBlockProgress.AutoSize = true;
            this._checkBoxBlockProgress.Checked = true;
            this._checkBoxBlockProgress.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxBlockProgress.Location = new System.Drawing.Point(9, 35);
            this._checkBoxBlockProgress.Name = "_checkBoxBlockProgress";
            this._checkBoxBlockProgress.Size = new System.Drawing.Size(94, 17);
            this._checkBoxBlockProgress.TabIndex = 1;
            this._checkBoxBlockProgress.Text = "BlockProgress";
            this._checkBoxBlockProgress.UseVisualStyleBackColor = true;
            this._checkBoxBlockProgress.CheckedChanged += new System.EventHandler(this._checkBoxBlockProgress_CheckedChanged);
            // 
            // _checkBoxAddProgress
            // 
            this._checkBoxAddProgress.AutoSize = true;
            this._checkBoxAddProgress.Checked = true;
            this._checkBoxAddProgress.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxAddProgress.Location = new System.Drawing.Point(9, 14);
            this._checkBoxAddProgress.Name = "_checkBoxAddProgress";
            this._checkBoxAddProgress.Size = new System.Drawing.Size(86, 17);
            this._checkBoxAddProgress.TabIndex = 0;
            this._checkBoxAddProgress.Text = "AddProgress";
            this._checkBoxAddProgress.UseVisualStyleBackColor = true;
            this._checkBoxAddProgress.CheckedChanged += new System.EventHandler(this._checkBoxAddProgress_CheckedChanged);
            // 
            // _groupBoxIDiscMaster
            // 
            this._groupBoxIDiscMaster.Controls.Add(this._buttonNextRecorder);
            this._groupBoxIDiscMaster.Controls.Add(this._buttonSwitchActiveDiscMasterFormat);
            this._groupBoxIDiscMaster.Controls.Add(this._textBoxActiveDiscMasterFormat);
            this._groupBoxIDiscMaster.Controls.Add(this._labelActiveDiscMasterFormat);
            this._groupBoxIDiscMaster.Location = new System.Drawing.Point(313, 6);
            this._groupBoxIDiscMaster.Name = "_groupBoxIDiscMaster";
            this._groupBoxIDiscMaster.Size = new System.Drawing.Size(496, 47);
            this._groupBoxIDiscMaster.TabIndex = 15;
            this._groupBoxIDiscMaster.TabStop = false;
            this._groupBoxIDiscMaster.Text = "IDiscMaster";
            // 
            // _buttonNextRecorder
            // 
            this._buttonNextRecorder.Location = new System.Drawing.Point(274, 11);
            this._buttonNextRecorder.Name = "_buttonNextRecorder";
            this._buttonNextRecorder.Size = new System.Drawing.Size(105, 20);
            this._buttonNextRecorder.TabIndex = 3;
            this._buttonNextRecorder.Text = "Next Recorder";
            this._buttonNextRecorder.UseVisualStyleBackColor = true;
            this._buttonNextRecorder.Click += new System.EventHandler(this._buttonNextRecorder_Click);
            // 
            // _buttonSwitchActiveDiscMasterFormat
            // 
            this._buttonSwitchActiveDiscMasterFormat.Location = new System.Drawing.Point(385, 11);
            this._buttonSwitchActiveDiscMasterFormat.Name = "_buttonSwitchActiveDiscMasterFormat";
            this._buttonSwitchActiveDiscMasterFormat.Size = new System.Drawing.Size(105, 20);
            this._buttonSwitchActiveDiscMasterFormat.TabIndex = 2;
            this._buttonSwitchActiveDiscMasterFormat.Text = "Switch Format";
            this._buttonSwitchActiveDiscMasterFormat.UseVisualStyleBackColor = true;
            this._buttonSwitchActiveDiscMasterFormat.Click += new System.EventHandler(this._buttonSwitchActiveDiscMasterFormat_Click);
            // 
            // _textBoxActiveDiscMasterFormat
            // 
            this._textBoxActiveDiscMasterFormat.Location = new System.Drawing.Point(146, 12);
            this._textBoxActiveDiscMasterFormat.Name = "_textBoxActiveDiscMasterFormat";
            this._textBoxActiveDiscMasterFormat.ReadOnly = true;
            this._textBoxActiveDiscMasterFormat.Size = new System.Drawing.Size(122, 20);
            this._textBoxActiveDiscMasterFormat.TabIndex = 1;
            // 
            // _labelActiveDiscMasterFormat
            // 
            this._labelActiveDiscMasterFormat.AutoSize = true;
            this._labelActiveDiscMasterFormat.Location = new System.Drawing.Point(6, 16);
            this._labelActiveDiscMasterFormat.Name = "_labelActiveDiscMasterFormat";
            this._labelActiveDiscMasterFormat.Size = new System.Drawing.Size(134, 13);
            this._labelActiveDiscMasterFormat.TabIndex = 0;
            this._labelActiveDiscMasterFormat.Text = "Active Disc Master Format:";
            // 
            // _groupBoxRedbook
            // 
            this._groupBoxRedbook.Controls.Add(this._textBoxTotalAudioTracks);
            this._groupBoxRedbook.Controls.Add(this._textBoxUsedAudioBlocks);
            this._groupBoxRedbook.Controls.Add(this._textBoxTotalAudioBlocks);
            this._groupBoxRedbook.Controls.Add(this._textBoxAudioBlockSize);
            this._groupBoxRedbook.Controls.Add(this._textBoxAvailableTrackBlocks);
            this._groupBoxRedbook.Controls.Add(this._labelTotalAudioTracks);
            this._groupBoxRedbook.Controls.Add(this._labelUsedAudioBlocks);
            this._groupBoxRedbook.Controls.Add(this._labelTotalAudioBlocks);
            this._groupBoxRedbook.Controls.Add(this._labelAudioBlockSize);
            this._groupBoxRedbook.Controls.Add(this._labelAvailableTrackBlocks);
            this._groupBoxRedbook.Enabled = false;
            this._groupBoxRedbook.Location = new System.Drawing.Point(6, 365);
            this._groupBoxRedbook.Name = "_groupBoxRedbook";
            this._groupBoxRedbook.Size = new System.Drawing.Size(304, 121);
            this._groupBoxRedbook.TabIndex = 14;
            this._groupBoxRedbook.TabStop = false;
            this._groupBoxRedbook.Text = "Redbook";
            // 
            // _textBoxTotalAudioTracks
            // 
            this._textBoxTotalAudioTracks.Location = new System.Drawing.Point(131, 97);
            this._textBoxTotalAudioTracks.Name = "_textBoxTotalAudioTracks";
            this._textBoxTotalAudioTracks.ReadOnly = true;
            this._textBoxTotalAudioTracks.Size = new System.Drawing.Size(167, 20);
            this._textBoxTotalAudioTracks.TabIndex = 26;
            // 
            // _textBoxUsedAudioBlocks
            // 
            this._textBoxUsedAudioBlocks.Location = new System.Drawing.Point(131, 76);
            this._textBoxUsedAudioBlocks.Name = "_textBoxUsedAudioBlocks";
            this._textBoxUsedAudioBlocks.ReadOnly = true;
            this._textBoxUsedAudioBlocks.Size = new System.Drawing.Size(167, 20);
            this._textBoxUsedAudioBlocks.TabIndex = 25;
            // 
            // _textBoxTotalAudioBlocks
            // 
            this._textBoxTotalAudioBlocks.Location = new System.Drawing.Point(131, 55);
            this._textBoxTotalAudioBlocks.Name = "_textBoxTotalAudioBlocks";
            this._textBoxTotalAudioBlocks.ReadOnly = true;
            this._textBoxTotalAudioBlocks.Size = new System.Drawing.Size(167, 20);
            this._textBoxTotalAudioBlocks.TabIndex = 24;
            // 
            // _textBoxAudioBlockSize
            // 
            this._textBoxAudioBlockSize.Location = new System.Drawing.Point(131, 34);
            this._textBoxAudioBlockSize.Name = "_textBoxAudioBlockSize";
            this._textBoxAudioBlockSize.ReadOnly = true;
            this._textBoxAudioBlockSize.Size = new System.Drawing.Size(167, 20);
            this._textBoxAudioBlockSize.TabIndex = 23;
            // 
            // _textBoxAvailableTrackBlocks
            // 
            this._textBoxAvailableTrackBlocks.Location = new System.Drawing.Point(131, 13);
            this._textBoxAvailableTrackBlocks.Name = "_textBoxAvailableTrackBlocks";
            this._textBoxAvailableTrackBlocks.ReadOnly = true;
            this._textBoxAvailableTrackBlocks.Size = new System.Drawing.Size(167, 20);
            this._textBoxAvailableTrackBlocks.TabIndex = 22;
            // 
            // _labelTotalAudioTracks
            // 
            this._labelTotalAudioTracks.AutoSize = true;
            this._labelTotalAudioTracks.Location = new System.Drawing.Point(6, 100);
            this._labelTotalAudioTracks.Name = "_labelTotalAudioTracks";
            this._labelTotalAudioTracks.Size = new System.Drawing.Size(100, 13);
            this._labelTotalAudioTracks.TabIndex = 4;
            this._labelTotalAudioTracks.Text = "Total Audio Tracks:";
            // 
            // _labelUsedAudioBlocks
            // 
            this._labelUsedAudioBlocks.AutoSize = true;
            this._labelUsedAudioBlocks.Location = new System.Drawing.Point(6, 79);
            this._labelUsedAudioBlocks.Name = "_labelUsedAudioBlocks";
            this._labelUsedAudioBlocks.Size = new System.Drawing.Size(100, 13);
            this._labelUsedAudioBlocks.TabIndex = 3;
            this._labelUsedAudioBlocks.Text = "Used Audio Blocks:";
            // 
            // _labelTotalAudioBlocks
            // 
            this._labelTotalAudioBlocks.AutoSize = true;
            this._labelTotalAudioBlocks.Location = new System.Drawing.Point(6, 58);
            this._labelTotalAudioBlocks.Name = "_labelTotalAudioBlocks";
            this._labelTotalAudioBlocks.Size = new System.Drawing.Size(99, 13);
            this._labelTotalAudioBlocks.TabIndex = 2;
            this._labelTotalAudioBlocks.Text = "Total Audio Blocks:";
            // 
            // _labelAudioBlockSize
            // 
            this._labelAudioBlockSize.AutoSize = true;
            this._labelAudioBlockSize.Location = new System.Drawing.Point(6, 37);
            this._labelAudioBlockSize.Name = "_labelAudioBlockSize";
            this._labelAudioBlockSize.Size = new System.Drawing.Size(90, 13);
            this._labelAudioBlockSize.TabIndex = 1;
            this._labelAudioBlockSize.Text = "Audio Block Size:";
            // 
            // _labelAvailableTrackBlocks
            // 
            this._labelAvailableTrackBlocks.AutoSize = true;
            this._labelAvailableTrackBlocks.Location = new System.Drawing.Point(6, 16);
            this._labelAvailableTrackBlocks.Name = "_labelAvailableTrackBlocks";
            this._labelAvailableTrackBlocks.Size = new System.Drawing.Size(119, 13);
            this._labelAvailableTrackBlocks.TabIndex = 0;
            this._labelAvailableTrackBlocks.Text = "Available Track Blocks:";
            // 
            // _groupBoxJoliet
            // 
            this._groupBoxJoliet.Controls.Add(this._comboBoxlBootImageEmulationType);
            this._groupBoxJoliet.Controls.Add(this._comboBoxBootImagePlatform);
            this._groupBoxJoliet.Controls.Add(this._buttonSetVolumeName);
            this._groupBoxJoliet.Controls.Add(this._textBoxBootImageManufacturerIdString);
            this._groupBoxJoliet.Controls.Add(this._textBoxVolumeName);
            this._groupBoxJoliet.Controls.Add(this._radioButtonPlaceBootImageOnDiscNo);
            this._groupBoxJoliet.Controls.Add(this._radioButtonPlaceBootImageOnDiscYes);
            this._groupBoxJoliet.Controls.Add(this._textBoxlUsedDataBlocks);
            this._groupBoxJoliet.Controls.Add(this._textBoxlTotalDataBlocks);
            this._groupBoxJoliet.Controls.Add(this._textBoxDataBlockSize);
            this._groupBoxJoliet.Controls.Add(this._labelBootImageEmulationType);
            this._groupBoxJoliet.Controls.Add(this._labelBootImagePlatform);
            this._groupBoxJoliet.Controls.Add(this._labelBootImageManufacturerIdString);
            this._groupBoxJoliet.Controls.Add(this._labelPlaceBootImageOnDisc);
            this._groupBoxJoliet.Controls.Add(this._labelVolumeName);
            this._groupBoxJoliet.Controls.Add(this._labelUsedDataBlocks);
            this._groupBoxJoliet.Controls.Add(this._labelTotalDataBlocks);
            this._groupBoxJoliet.Controls.Add(this._labelDataBlockSize);
            this._groupBoxJoliet.Location = new System.Drawing.Point(3, 516);
            this._groupBoxJoliet.Name = "_groupBoxJoliet";
            this._groupBoxJoliet.Size = new System.Drawing.Size(304, 184);
            this._groupBoxJoliet.TabIndex = 13;
            this._groupBoxJoliet.TabStop = false;
            this._groupBoxJoliet.Text = "Joliet";
            // 
            // _comboBoxlBootImageEmulationType
            // 
            this._comboBoxlBootImageEmulationType.FormattingEnabled = true;
            this._comboBoxlBootImageEmulationType.Items.AddRange(new object[] {
            "None",
            "1.2 MB",
            "1.44 Inch",
            "2.88 MB",
            "Hard Disk"});
            this._comboBoxlBootImageEmulationType.Location = new System.Drawing.Point(185, 160);
            this._comboBoxlBootImageEmulationType.Name = "_comboBoxlBootImageEmulationType";
            this._comboBoxlBootImageEmulationType.Size = new System.Drawing.Size(113, 21);
            this._comboBoxlBootImageEmulationType.TabIndex = 27;
            this._comboBoxlBootImageEmulationType.Text = "None";
            this._comboBoxlBootImageEmulationType.SelectedIndexChanged += new System.EventHandler(this._comboBoxlBootImageEmulationType_SelectedIndexChanged);
            // 
            // _comboBoxBootImagePlatform
            // 
            this._comboBoxBootImagePlatform.FormattingEnabled = true;
            this._comboBoxBootImagePlatform.Items.AddRange(new object[] {
            "x86",
            "PowerPC",
            "Mac",
            "Undefined"});
            this._comboBoxBootImagePlatform.Location = new System.Drawing.Point(185, 139);
            this._comboBoxBootImagePlatform.Name = "_comboBoxBootImagePlatform";
            this._comboBoxBootImagePlatform.Size = new System.Drawing.Size(113, 21);
            this._comboBoxBootImagePlatform.TabIndex = 26;
            this._comboBoxBootImagePlatform.Text = "Undefined";
            this._comboBoxBootImagePlatform.SelectedIndexChanged += new System.EventHandler(this._comboBoxBootImagePlatform_SelectedIndexChanged);
            // 
            // _buttonSetVolumeName
            // 
            this._buttonSetVolumeName.Location = new System.Drawing.Point(259, 79);
            this._buttonSetVolumeName.Name = "_buttonSetVolumeName";
            this._buttonSetVolumeName.Size = new System.Drawing.Size(39, 20);
            this._buttonSetVolumeName.TabIndex = 25;
            this._buttonSetVolumeName.Text = "Set";
            this._buttonSetVolumeName.UseVisualStyleBackColor = true;
            this._buttonSetVolumeName.Click += new System.EventHandler(this._buttonSetVolumeName_Click);
            // 
            // _textBoxBootImageManufacturerIdString
            // 
            this._textBoxBootImageManufacturerIdString.Location = new System.Drawing.Point(185, 118);
            this._textBoxBootImageManufacturerIdString.Name = "_textBoxBootImageManufacturerIdString";
            this._textBoxBootImageManufacturerIdString.ReadOnly = true;
            this._textBoxBootImageManufacturerIdString.Size = new System.Drawing.Size(113, 20);
            this._textBoxBootImageManufacturerIdString.TabIndex = 22;
            // 
            // _textBoxVolumeName
            // 
            this._textBoxVolumeName.Location = new System.Drawing.Point(104, 79);
            this._textBoxVolumeName.Name = "_textBoxVolumeName";
            this._textBoxVolumeName.Size = new System.Drawing.Size(149, 20);
            this._textBoxVolumeName.TabIndex = 21;
            // 
            // _radioButtonPlaceBootImageOnDiscNo
            // 
            this._radioButtonPlaceBootImageOnDiscNo.AutoSize = true;
            this._radioButtonPlaceBootImageOnDiscNo.Checked = true;
            this._radioButtonPlaceBootImageOnDiscNo.Location = new System.Drawing.Point(240, 100);
            this._radioButtonPlaceBootImageOnDiscNo.Name = "_radioButtonPlaceBootImageOnDiscNo";
            this._radioButtonPlaceBootImageOnDiscNo.Size = new System.Drawing.Size(39, 17);
            this._radioButtonPlaceBootImageOnDiscNo.TabIndex = 20;
            this._radioButtonPlaceBootImageOnDiscNo.TabStop = true;
            this._radioButtonPlaceBootImageOnDiscNo.Text = "No";
            this._radioButtonPlaceBootImageOnDiscNo.UseVisualStyleBackColor = true;
            this._radioButtonPlaceBootImageOnDiscNo.CheckedChanged += new System.EventHandler(this._radioButtonPlaceBootImageOnDiscNo_CheckedChanged);
            // 
            // _radioButtonPlaceBootImageOnDiscYes
            // 
            this._radioButtonPlaceBootImageOnDiscYes.AutoSize = true;
            this._radioButtonPlaceBootImageOnDiscYes.Location = new System.Drawing.Point(185, 100);
            this._radioButtonPlaceBootImageOnDiscYes.Name = "_radioButtonPlaceBootImageOnDiscYes";
            this._radioButtonPlaceBootImageOnDiscYes.Size = new System.Drawing.Size(43, 17);
            this._radioButtonPlaceBootImageOnDiscYes.TabIndex = 19;
            this._radioButtonPlaceBootImageOnDiscYes.Text = "Yes";
            this._radioButtonPlaceBootImageOnDiscYes.UseVisualStyleBackColor = true;
            this._radioButtonPlaceBootImageOnDiscYes.CheckedChanged += new System.EventHandler(this._radioButtonPlaceBootImageOnDiscYes_CheckedChanged);
            // 
            // _textBoxlUsedDataBlocks
            // 
            this._textBoxlUsedDataBlocks.Location = new System.Drawing.Point(104, 55);
            this._textBoxlUsedDataBlocks.Name = "_textBoxlUsedDataBlocks";
            this._textBoxlUsedDataBlocks.ReadOnly = true;
            this._textBoxlUsedDataBlocks.Size = new System.Drawing.Size(194, 20);
            this._textBoxlUsedDataBlocks.TabIndex = 18;
            // 
            // _textBoxlTotalDataBlocks
            // 
            this._textBoxlTotalDataBlocks.Location = new System.Drawing.Point(104, 34);
            this._textBoxlTotalDataBlocks.Name = "_textBoxlTotalDataBlocks";
            this._textBoxlTotalDataBlocks.ReadOnly = true;
            this._textBoxlTotalDataBlocks.Size = new System.Drawing.Size(194, 20);
            this._textBoxlTotalDataBlocks.TabIndex = 17;
            // 
            // _textBoxDataBlockSize
            // 
            this._textBoxDataBlockSize.Location = new System.Drawing.Point(104, 13);
            this._textBoxDataBlockSize.Name = "_textBoxDataBlockSize";
            this._textBoxDataBlockSize.ReadOnly = true;
            this._textBoxDataBlockSize.Size = new System.Drawing.Size(194, 20);
            this._textBoxDataBlockSize.TabIndex = 16;
            // 
            // _labelBootImageEmulationType
            // 
            this._labelBootImageEmulationType.AutoSize = true;
            this._labelBootImageEmulationType.Location = new System.Drawing.Point(6, 163);
            this._labelBootImageEmulationType.Name = "_labelBootImageEmulationType";
            this._labelBootImageEmulationType.Size = new System.Drawing.Size(140, 13);
            this._labelBootImageEmulationType.TabIndex = 7;
            this._labelBootImageEmulationType.Text = "Boot Image Emulation Type:";
            // 
            // _labelBootImagePlatform
            // 
            this._labelBootImagePlatform.AutoSize = true;
            this._labelBootImagePlatform.Location = new System.Drawing.Point(6, 142);
            this._labelBootImagePlatform.Name = "_labelBootImagePlatform";
            this._labelBootImagePlatform.Size = new System.Drawing.Size(105, 13);
            this._labelBootImagePlatform.TabIndex = 6;
            this._labelBootImagePlatform.Text = "Boot Image Platform:";
            // 
            // _labelBootImageManufacturerIdString
            // 
            this._labelBootImageManufacturerIdString.AutoSize = true;
            this._labelBootImageManufacturerIdString.Location = new System.Drawing.Point(5, 121);
            this._labelBootImageManufacturerIdString.Name = "_labelBootImageManufacturerIdString";
            this._labelBootImageManufacturerIdString.Size = new System.Drawing.Size(174, 13);
            this._labelBootImageManufacturerIdString.TabIndex = 5;
            this._labelBootImageManufacturerIdString.Text = "Boot Image Manufacturer ID String:";
            // 
            // _labelPlaceBootImageOnDisc
            // 
            this._labelPlaceBootImageOnDisc.AutoSize = true;
            this._labelPlaceBootImageOnDisc.Location = new System.Drawing.Point(6, 100);
            this._labelPlaceBootImageOnDisc.Name = "_labelPlaceBootImageOnDisc";
            this._labelPlaceBootImageOnDisc.Size = new System.Drawing.Size(135, 13);
            this._labelPlaceBootImageOnDisc.TabIndex = 4;
            this._labelPlaceBootImageOnDisc.Text = "Place Boot Image On Disc:";
            // 
            // _labelVolumeName
            // 
            this._labelVolumeName.AutoSize = true;
            this._labelVolumeName.Location = new System.Drawing.Point(6, 79);
            this._labelVolumeName.Name = "_labelVolumeName";
            this._labelVolumeName.Size = new System.Drawing.Size(76, 13);
            this._labelVolumeName.TabIndex = 3;
            this._labelVolumeName.Text = "Volume Name:";
            // 
            // _labelUsedDataBlocks
            // 
            this._labelUsedDataBlocks.AutoSize = true;
            this._labelUsedDataBlocks.Location = new System.Drawing.Point(5, 58);
            this._labelUsedDataBlocks.Name = "_labelUsedDataBlocks";
            this._labelUsedDataBlocks.Size = new System.Drawing.Size(96, 13);
            this._labelUsedDataBlocks.TabIndex = 2;
            this._labelUsedDataBlocks.Text = "Used Data Blocks:";
            // 
            // _labelTotalDataBlocks
            // 
            this._labelTotalDataBlocks.AutoSize = true;
            this._labelTotalDataBlocks.Location = new System.Drawing.Point(4, 37);
            this._labelTotalDataBlocks.Name = "_labelTotalDataBlocks";
            this._labelTotalDataBlocks.Size = new System.Drawing.Size(95, 13);
            this._labelTotalDataBlocks.TabIndex = 1;
            this._labelTotalDataBlocks.Text = "Total Data Blocks:";
            // 
            // _labelDataBlockSize
            // 
            this._labelDataBlockSize.AutoSize = true;
            this._labelDataBlockSize.Location = new System.Drawing.Point(6, 15);
            this._labelDataBlockSize.Name = "_labelDataBlockSize";
            this._labelDataBlockSize.Size = new System.Drawing.Size(86, 13);
            this._labelDataBlockSize.TabIndex = 0;
            this._labelDataBlockSize.Text = "Data Block Size:";
            // 
            // _groupBoxActiveRecorder
            // 
            this._groupBoxActiveRecorder.Controls.Add(this._buttonWriteSpeedDecrease);
            this._groupBoxActiveRecorder.Controls.Add(this._buttonWriteSpeedIncrease);
            this._groupBoxActiveRecorder.Controls.Add(this._textBoxWriteSpeed);
            this._groupBoxActiveRecorder.Controls.Add(this._textBoxMaxWriteSpeed);
            this._groupBoxActiveRecorder.Controls.Add(this._textBoxRecorderState);
            this._groupBoxActiveRecorder.Controls.Add(this._textBoxRecorderType);
            this._groupBoxActiveRecorder.Controls.Add(this._textBoxDriveLetter);
            this._groupBoxActiveRecorder.Controls.Add(this._textBoxOSPath);
            this._groupBoxActiveRecorder.Controls.Add(this._textBoxRevision);
            this._groupBoxActiveRecorder.Controls.Add(this._textBoxVendor);
            this._groupBoxActiveRecorder.Controls.Add(this._textBoxProduct);
            this._groupBoxActiveRecorder.Controls.Add(this._textBoxPnPID);
            this._groupBoxActiveRecorder.Controls.Add(this._labelWriteSpeed);
            this._groupBoxActiveRecorder.Controls.Add(this._labelMaxWriteSpeed);
            this._groupBoxActiveRecorder.Controls.Add(this._labelRecorderState);
            this._groupBoxActiveRecorder.Controls.Add(this._labelRecorderType);
            this._groupBoxActiveRecorder.Controls.Add(this._labelDriveLetter);
            this._groupBoxActiveRecorder.Controls.Add(this._labelOSPath);
            this._groupBoxActiveRecorder.Controls.Add(this._labelRevision);
            this._groupBoxActiveRecorder.Controls.Add(this._labelVendor);
            this._groupBoxActiveRecorder.Controls.Add(this._labelProduct);
            this._groupBoxActiveRecorder.Controls.Add(this._labelPnpID);
            this._groupBoxActiveRecorder.Location = new System.Drawing.Point(3, 6);
            this._groupBoxActiveRecorder.Name = "_groupBoxActiveRecorder";
            this._groupBoxActiveRecorder.Size = new System.Drawing.Size(304, 226);
            this._groupBoxActiveRecorder.TabIndex = 12;
            this._groupBoxActiveRecorder.TabStop = false;
            this._groupBoxActiveRecorder.Text = "Active Recoder";
            // 
            // _buttonWriteSpeedDecrease
            // 
            this._buttonWriteSpeedDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buttonWriteSpeedDecrease.Location = new System.Drawing.Point(272, 202);
            this._buttonWriteSpeedDecrease.Name = "_buttonWriteSpeedDecrease";
            this._buttonWriteSpeedDecrease.Size = new System.Drawing.Size(26, 20);
            this._buttonWriteSpeedDecrease.TabIndex = 21;
            this._buttonWriteSpeedDecrease.Text = "  ";
            this._buttonWriteSpeedDecrease.UseVisualStyleBackColor = true;
            this._buttonWriteSpeedDecrease.Click += new System.EventHandler(this._buttonWriteSpeedDecrease_Click);
            // 
            // _buttonWriteSpeedIncrease
            // 
            this._buttonWriteSpeedIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._buttonWriteSpeedIncrease.Location = new System.Drawing.Point(240, 202);
            this._buttonWriteSpeedIncrease.Name = "_buttonWriteSpeedIncrease";
            this._buttonWriteSpeedIncrease.Size = new System.Drawing.Size(26, 20);
            this._buttonWriteSpeedIncrease.TabIndex = 20;
            this._buttonWriteSpeedIncrease.Text = "+";
            this._buttonWriteSpeedIncrease.UseVisualStyleBackColor = true;
            this._buttonWriteSpeedIncrease.Click += new System.EventHandler(this._buttonWriteSpeedIncrease_Click);
            // 
            // _textBoxWriteSpeed
            // 
            this._textBoxWriteSpeed.Location = new System.Drawing.Point(104, 202);
            this._textBoxWriteSpeed.Name = "_textBoxWriteSpeed";
            this._textBoxWriteSpeed.Size = new System.Drawing.Size(130, 20);
            this._textBoxWriteSpeed.TabIndex = 19;
            // 
            // _textBoxMaxWriteSpeed
            // 
            this._textBoxMaxWriteSpeed.Location = new System.Drawing.Point(104, 181);
            this._textBoxMaxWriteSpeed.Name = "_textBoxMaxWriteSpeed";
            this._textBoxMaxWriteSpeed.ReadOnly = true;
            this._textBoxMaxWriteSpeed.Size = new System.Drawing.Size(194, 20);
            this._textBoxMaxWriteSpeed.TabIndex = 18;
            // 
            // _textBoxRecorderState
            // 
            this._textBoxRecorderState.Location = new System.Drawing.Point(104, 160);
            this._textBoxRecorderState.Name = "_textBoxRecorderState";
            this._textBoxRecorderState.ReadOnly = true;
            this._textBoxRecorderState.Size = new System.Drawing.Size(194, 20);
            this._textBoxRecorderState.TabIndex = 17;
            // 
            // _textBoxRecorderType
            // 
            this._textBoxRecorderType.Location = new System.Drawing.Point(104, 139);
            this._textBoxRecorderType.Name = "_textBoxRecorderType";
            this._textBoxRecorderType.ReadOnly = true;
            this._textBoxRecorderType.Size = new System.Drawing.Size(194, 20);
            this._textBoxRecorderType.TabIndex = 16;
            // 
            // _textBoxDriveLetter
            // 
            this._textBoxDriveLetter.Location = new System.Drawing.Point(104, 118);
            this._textBoxDriveLetter.Name = "_textBoxDriveLetter";
            this._textBoxDriveLetter.ReadOnly = true;
            this._textBoxDriveLetter.Size = new System.Drawing.Size(194, 20);
            this._textBoxDriveLetter.TabIndex = 15;
            // 
            // _textBoxOSPath
            // 
            this._textBoxOSPath.Location = new System.Drawing.Point(104, 97);
            this._textBoxOSPath.Name = "_textBoxOSPath";
            this._textBoxOSPath.ReadOnly = true;
            this._textBoxOSPath.Size = new System.Drawing.Size(194, 20);
            this._textBoxOSPath.TabIndex = 14;
            // 
            // _textBoxRevision
            // 
            this._textBoxRevision.Location = new System.Drawing.Point(104, 76);
            this._textBoxRevision.Name = "_textBoxRevision";
            this._textBoxRevision.ReadOnly = true;
            this._textBoxRevision.Size = new System.Drawing.Size(194, 20);
            this._textBoxRevision.TabIndex = 13;
            // 
            // _textBoxVendor
            // 
            this._textBoxVendor.Location = new System.Drawing.Point(104, 55);
            this._textBoxVendor.Name = "_textBoxVendor";
            this._textBoxVendor.ReadOnly = true;
            this._textBoxVendor.Size = new System.Drawing.Size(194, 20);
            this._textBoxVendor.TabIndex = 12;
            // 
            // _textBoxProduct
            // 
            this._textBoxProduct.Location = new System.Drawing.Point(104, 34);
            this._textBoxProduct.Name = "_textBoxProduct";
            this._textBoxProduct.ReadOnly = true;
            this._textBoxProduct.Size = new System.Drawing.Size(194, 20);
            this._textBoxProduct.TabIndex = 11;
            // 
            // _textBoxPnPID
            // 
            this._textBoxPnPID.Location = new System.Drawing.Point(104, 13);
            this._textBoxPnPID.Name = "_textBoxPnPID";
            this._textBoxPnPID.ReadOnly = true;
            this._textBoxPnPID.Size = new System.Drawing.Size(194, 20);
            this._textBoxPnPID.TabIndex = 10;
            // 
            // _labelWriteSpeed
            // 
            this._labelWriteSpeed.AutoSize = true;
            this._labelWriteSpeed.Location = new System.Drawing.Point(6, 205);
            this._labelWriteSpeed.Name = "_labelWriteSpeed";
            this._labelWriteSpeed.Size = new System.Drawing.Size(69, 13);
            this._labelWriteSpeed.TabIndex = 9;
            this._labelWriteSpeed.Text = "Write Speed:";
            // 
            // _labelMaxWriteSpeed
            // 
            this._labelMaxWriteSpeed.AutoSize = true;
            this._labelMaxWriteSpeed.Location = new System.Drawing.Point(6, 184);
            this._labelMaxWriteSpeed.Name = "_labelMaxWriteSpeed";
            this._labelMaxWriteSpeed.Size = new System.Drawing.Size(92, 13);
            this._labelMaxWriteSpeed.TabIndex = 8;
            this._labelMaxWriteSpeed.Text = "Max Write Speed:";
            // 
            // _labelRecorderState
            // 
            this._labelRecorderState.AutoSize = true;
            this._labelRecorderState.Location = new System.Drawing.Point(6, 163);
            this._labelRecorderState.Name = "_labelRecorderState";
            this._labelRecorderState.Size = new System.Drawing.Size(82, 13);
            this._labelRecorderState.TabIndex = 7;
            this._labelRecorderState.Text = "Recorder State:";
            // 
            // _labelRecorderType
            // 
            this._labelRecorderType.AutoSize = true;
            this._labelRecorderType.Location = new System.Drawing.Point(6, 142);
            this._labelRecorderType.Name = "_labelRecorderType";
            this._labelRecorderType.Size = new System.Drawing.Size(81, 13);
            this._labelRecorderType.TabIndex = 6;
            this._labelRecorderType.Text = "Recorder Type:";
            // 
            // _labelDriveLetter
            // 
            this._labelDriveLetter.AutoSize = true;
            this._labelDriveLetter.Location = new System.Drawing.Point(6, 121);
            this._labelDriveLetter.Name = "_labelDriveLetter";
            this._labelDriveLetter.Size = new System.Drawing.Size(65, 13);
            this._labelDriveLetter.TabIndex = 5;
            this._labelDriveLetter.Text = "Drive Letter:";
            // 
            // _labelOSPath
            // 
            this._labelOSPath.AutoSize = true;
            this._labelOSPath.Location = new System.Drawing.Point(6, 100);
            this._labelOSPath.Name = "_labelOSPath";
            this._labelOSPath.Size = new System.Drawing.Size(50, 13);
            this._labelOSPath.TabIndex = 4;
            this._labelOSPath.Text = "OS Path:";
            // 
            // _labelRevision
            // 
            this._labelRevision.AutoSize = true;
            this._labelRevision.Location = new System.Drawing.Point(6, 79);
            this._labelRevision.Name = "_labelRevision";
            this._labelRevision.Size = new System.Drawing.Size(51, 13);
            this._labelRevision.TabIndex = 3;
            this._labelRevision.Text = "Revision:";
            // 
            // _labelVendor
            // 
            this._labelVendor.AutoSize = true;
            this._labelVendor.Location = new System.Drawing.Point(6, 58);
            this._labelVendor.Name = "_labelVendor";
            this._labelVendor.Size = new System.Drawing.Size(44, 13);
            this._labelVendor.TabIndex = 2;
            this._labelVendor.Text = "Vendor:";
            // 
            // _labelProduct
            // 
            this._labelProduct.AutoSize = true;
            this._labelProduct.Location = new System.Drawing.Point(6, 37);
            this._labelProduct.Name = "_labelProduct";
            this._labelProduct.Size = new System.Drawing.Size(47, 13);
            this._labelProduct.TabIndex = 1;
            this._labelProduct.Text = "Product:";
            // 
            // _labelPnpID
            // 
            this._labelPnpID.AutoSize = true;
            this._labelPnpID.Location = new System.Drawing.Point(6, 16);
            this._labelPnpID.Name = "_labelPnpID";
            this._labelPnpID.Size = new System.Drawing.Size(46, 13);
            this._labelPnpID.TabIndex = 0;
            this._labelPnpID.Text = "PNP ID:";
            // 
            // _groupBoxMediaDetails
            // 
            this._groupBoxMediaDetails.Controls.Add(this._textBoxMediaFlags);
            this._groupBoxMediaDetails.Controls.Add(this._textBoxMediaType);
            this._groupBoxMediaDetails.Controls.Add(this._textBoxFreeBlocks);
            this._groupBoxMediaDetails.Controls.Add(this._textBoxNextWritable);
            this._groupBoxMediaDetails.Controls.Add(this._textBoxStartAddress);
            this._groupBoxMediaDetails.Controls.Add(this._textBoxLastTrack);
            this._groupBoxMediaDetails.Controls.Add(this._textBoxSessions);
            this._groupBoxMediaDetails.Controls.Add(this._textBoxMediaPresent);
            this._groupBoxMediaDetails.Controls.Add(this._labelMediaFlags);
            this._groupBoxMediaDetails.Controls.Add(this._labelMediaType);
            this._groupBoxMediaDetails.Controls.Add(this._labelFreeBlocks);
            this._groupBoxMediaDetails.Controls.Add(this._labelNextWritable);
            this._groupBoxMediaDetails.Controls.Add(this._labelStartAddress);
            this._groupBoxMediaDetails.Controls.Add(this._labelLastTrack);
            this._groupBoxMediaDetails.Controls.Add(this._labelSessions);
            this._groupBoxMediaDetails.Controls.Add(this._labelMediaPresent);
            this._groupBoxMediaDetails.Location = new System.Drawing.Point(313, 141);
            this._groupBoxMediaDetails.Name = "_groupBoxMediaDetails";
            this._groupBoxMediaDetails.Size = new System.Drawing.Size(201, 184);
            this._groupBoxMediaDetails.TabIndex = 11;
            this._groupBoxMediaDetails.TabStop = false;
            this._groupBoxMediaDetails.Text = "Media Details";
            // 
            // _textBoxMediaFlags
            // 
            this._textBoxMediaFlags.Location = new System.Drawing.Point(90, 161);
            this._textBoxMediaFlags.Name = "_textBoxMediaFlags";
            this._textBoxMediaFlags.ReadOnly = true;
            this._textBoxMediaFlags.Size = new System.Drawing.Size(105, 20);
            this._textBoxMediaFlags.TabIndex = 15;
            // 
            // _textBoxMediaType
            // 
            this._textBoxMediaType.Location = new System.Drawing.Point(90, 139);
            this._textBoxMediaType.Name = "_textBoxMediaType";
            this._textBoxMediaType.ReadOnly = true;
            this._textBoxMediaType.Size = new System.Drawing.Size(105, 20);
            this._textBoxMediaType.TabIndex = 14;
            // 
            // _textBoxFreeBlocks
            // 
            this._textBoxFreeBlocks.Location = new System.Drawing.Point(90, 118);
            this._textBoxFreeBlocks.Name = "_textBoxFreeBlocks";
            this._textBoxFreeBlocks.ReadOnly = true;
            this._textBoxFreeBlocks.Size = new System.Drawing.Size(105, 20);
            this._textBoxFreeBlocks.TabIndex = 13;
            // 
            // _textBoxNextWritable
            // 
            this._textBoxNextWritable.Location = new System.Drawing.Point(90, 97);
            this._textBoxNextWritable.Name = "_textBoxNextWritable";
            this._textBoxNextWritable.ReadOnly = true;
            this._textBoxNextWritable.Size = new System.Drawing.Size(105, 20);
            this._textBoxNextWritable.TabIndex = 12;
            // 
            // _textBoxStartAddress
            // 
            this._textBoxStartAddress.Location = new System.Drawing.Point(90, 76);
            this._textBoxStartAddress.Name = "_textBoxStartAddress";
            this._textBoxStartAddress.ReadOnly = true;
            this._textBoxStartAddress.Size = new System.Drawing.Size(105, 20);
            this._textBoxStartAddress.TabIndex = 11;
            // 
            // _textBoxLastTrack
            // 
            this._textBoxLastTrack.Location = new System.Drawing.Point(90, 55);
            this._textBoxLastTrack.Name = "_textBoxLastTrack";
            this._textBoxLastTrack.ReadOnly = true;
            this._textBoxLastTrack.Size = new System.Drawing.Size(105, 20);
            this._textBoxLastTrack.TabIndex = 10;
            // 
            // _textBoxSessions
            // 
            this._textBoxSessions.Location = new System.Drawing.Point(90, 34);
            this._textBoxSessions.Name = "_textBoxSessions";
            this._textBoxSessions.ReadOnly = true;
            this._textBoxSessions.Size = new System.Drawing.Size(105, 20);
            this._textBoxSessions.TabIndex = 9;
            // 
            // _textBoxMediaPresent
            // 
            this._textBoxMediaPresent.Location = new System.Drawing.Point(90, 13);
            this._textBoxMediaPresent.Name = "_textBoxMediaPresent";
            this._textBoxMediaPresent.ReadOnly = true;
            this._textBoxMediaPresent.Size = new System.Drawing.Size(105, 20);
            this._textBoxMediaPresent.TabIndex = 8;
            // 
            // _labelMediaFlags
            // 
            this._labelMediaFlags.AutoSize = true;
            this._labelMediaFlags.Location = new System.Drawing.Point(6, 163);
            this._labelMediaFlags.Name = "_labelMediaFlags";
            this._labelMediaFlags.Size = new System.Drawing.Size(67, 13);
            this._labelMediaFlags.TabIndex = 7;
            this._labelMediaFlags.Text = "Media Flags:";
            // 
            // _labelMediaType
            // 
            this._labelMediaType.AutoSize = true;
            this._labelMediaType.Location = new System.Drawing.Point(6, 142);
            this._labelMediaType.Name = "_labelMediaType";
            this._labelMediaType.Size = new System.Drawing.Size(66, 13);
            this._labelMediaType.TabIndex = 6;
            this._labelMediaType.Text = "Media Type:";
            // 
            // _labelFreeBlocks
            // 
            this._labelFreeBlocks.AutoSize = true;
            this._labelFreeBlocks.Location = new System.Drawing.Point(6, 121);
            this._labelFreeBlocks.Name = "_labelFreeBlocks";
            this._labelFreeBlocks.Size = new System.Drawing.Size(66, 13);
            this._labelFreeBlocks.TabIndex = 5;
            this._labelFreeBlocks.Text = "Free Blocks:";
            // 
            // _labelNextWritable
            // 
            this._labelNextWritable.AutoSize = true;
            this._labelNextWritable.Location = new System.Drawing.Point(5, 100);
            this._labelNextWritable.Name = "_labelNextWritable";
            this._labelNextWritable.Size = new System.Drawing.Size(74, 13);
            this._labelNextWritable.TabIndex = 4;
            this._labelNextWritable.Text = "Next Writable:";
            // 
            // _labelStartAddress
            // 
            this._labelStartAddress.AutoSize = true;
            this._labelStartAddress.Location = new System.Drawing.Point(6, 79);
            this._labelStartAddress.Name = "_labelStartAddress";
            this._labelStartAddress.Size = new System.Drawing.Size(73, 13);
            this._labelStartAddress.TabIndex = 3;
            this._labelStartAddress.Text = "Start Address:";
            // 
            // _labelLastTrack
            // 
            this._labelLastTrack.AutoSize = true;
            this._labelLastTrack.Location = new System.Drawing.Point(6, 58);
            this._labelLastTrack.Name = "_labelLastTrack";
            this._labelLastTrack.Size = new System.Drawing.Size(61, 13);
            this._labelLastTrack.TabIndex = 2;
            this._labelLastTrack.Text = "Last Track:";
            // 
            // _labelSessions
            // 
            this._labelSessions.AutoSize = true;
            this._labelSessions.Location = new System.Drawing.Point(6, 37);
            this._labelSessions.Name = "_labelSessions";
            this._labelSessions.Size = new System.Drawing.Size(52, 13);
            this._labelSessions.TabIndex = 1;
            this._labelSessions.Text = "Sessions:";
            // 
            // _labelMediaPresent
            // 
            this._labelMediaPresent.AutoSize = true;
            this._labelMediaPresent.Location = new System.Drawing.Point(6, 16);
            this._labelMediaPresent.Name = "_labelMediaPresent";
            this._labelMediaPresent.Size = new System.Drawing.Size(78, 13);
            this._labelMediaPresent.TabIndex = 0;
            this._labelMediaPresent.Text = "Media Present:";
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._tabPageBurn);
            this._tabControl.Controls.Add(this._tabPageLog);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(823, 734);
            this._tabControl.TabIndex = 22;
            // 
            // _tabPageBurn
            // 
            this._tabPageBurn.Controls.Add(this._groupBoxStatus);
            this._tabPageBurn.Controls.Add(this._groupBoxRedbookActions);
            this._tabPageBurn.Controls.Add(this._groupBoxEventSubscriptions);
            this._tabPageBurn.Controls.Add(this._groupBoxRedbook);
            this._tabPageBurn.Controls.Add(this._groupBoxJoliet);
            this._tabPageBurn.Controls.Add(this._groupBoxIDiscMaster);
            this._tabPageBurn.Controls.Add(this._groupBoxJolietActions);
            this._tabPageBurn.Controls.Add(this._groupBoxUniversalActions);
            this._tabPageBurn.Controls.Add(this._groupBoxActiveRecorder);
            this._tabPageBurn.Controls.Add(this._groupBoxMediaDetails);
            this._tabPageBurn.Location = new System.Drawing.Point(4, 22);
            this._tabPageBurn.Name = "_tabPageBurn";
            this._tabPageBurn.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageBurn.Size = new System.Drawing.Size(815, 708);
            this._tabPageBurn.TabIndex = 0;
            this._tabPageBurn.Text = "Burn";
            this._tabPageBurn.UseVisualStyleBackColor = true;
            // 
            // _tabPageLog
            // 
            this._tabPageLog.Controls.Add(this._buttonSaveLog);
            this._tabPageLog.Controls.Add(this._buttonClearLog);
            this._tabPageLog.Controls.Add(this._groupBoxLog);
            this._tabPageLog.Location = new System.Drawing.Point(4, 22);
            this._tabPageLog.Name = "_tabPageLog";
            this._tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageLog.Size = new System.Drawing.Size(815, 708);
            this._tabPageLog.TabIndex = 1;
            this._tabPageLog.Text = "Log";
            this._tabPageLog.UseVisualStyleBackColor = true;
            // 
            // _buttonSaveLog
            // 
            this._buttonSaveLog.Location = new System.Drawing.Point(282, 6);
            this._buttonSaveLog.Name = "_buttonSaveLog";
            this._buttonSaveLog.Size = new System.Drawing.Size(80, 22);
            this._buttonSaveLog.TabIndex = 22;
            this._buttonSaveLog.Text = "Save Log";
            this._buttonSaveLog.UseVisualStyleBackColor = true;
            this._buttonSaveLog.Click += new System.EventHandler(this._buttonSaveLog_Click_1);
            // 
            // _buttonClearLog
            // 
            this._buttonClearLog.Location = new System.Drawing.Point(368, 6);
            this._buttonClearLog.Name = "_buttonClearLog";
            this._buttonClearLog.Size = new System.Drawing.Size(72, 22);
            this._buttonClearLog.TabIndex = 23;
            this._buttonClearLog.Text = "Clear Log";
            this._buttonClearLog.UseVisualStyleBackColor = true;
            this._buttonClearLog.Click += new System.EventHandler(this._buttonClearLog_Click_1);
            // 
            // _groupBoxLog
            // 
            this._groupBoxLog.Controls.Add(this._richTextBoxLog);
            this._groupBoxLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._groupBoxLog.Location = new System.Drawing.Point(3, 34);
            this._groupBoxLog.Name = "_groupBoxLog";
            this._groupBoxLog.Size = new System.Drawing.Size(809, 671);
            this._groupBoxLog.TabIndex = 21;
            this._groupBoxLog.TabStop = false;
            this._groupBoxLog.Text = "Log";
            // 
            // _richTextBoxLog
            // 
            this._richTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this._richTextBoxLog.Location = new System.Drawing.Point(3, 16);
            this._richTextBoxLog.Name = "_richTextBoxLog";
            this._richTextBoxLog.ReadOnly = true;
            this._richTextBoxLog.Size = new System.Drawing.Size(803, 652);
            this._richTextBoxLog.TabIndex = 0;
            this._richTextBoxLog.Text = "";
            // 
            // _backgroundWorkerBurnAudio
            // 
            this._backgroundWorkerBurnAudio.DoWork += new System.ComponentModel.DoWorkEventHandler(this._backgroundWorkerBurnAudio_DoWork);
            this._backgroundWorkerBurnAudio.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorkerBurnAudio_RunWorkerCompleted);
            this._backgroundWorkerBurnAudio.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._backgroundWorkerBurnAudio_ProgressChanged);
            // 
            // _backgroundWorkerBurn
            // 
            this._backgroundWorkerBurn.DoWork += new System.ComponentModel.DoWorkEventHandler(this._backgroundWorkerBurn_DoWork);
            this._backgroundWorkerBurn.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorkerBurn_RunWorkerCompleted);
            this._backgroundWorkerBurn.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._backgroundWorkerBurn_ProgressChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 734);
            this.Controls.Add(this._tabControl);
            this.Name = "MainForm";
            this.Text = "Imapi.Net Test Application";
            this._groupBoxStatus.ResumeLayout(false);
            this._groupBoxStatus.PerformLayout();
            this._groupBoxRedbookActions.ResumeLayout(false);
            this._groupBoxJolietActions.ResumeLayout(false);
            this._groupBoxJolietActions.PerformLayout();
            this._groupBoxUniversalActions.ResumeLayout(false);
            this._groupBoxUniversalActions.PerformLayout();
            this._groupBoxEventSubscriptions.ResumeLayout(false);
            this._groupBoxEventSubscriptions.PerformLayout();
            this._groupBoxIDiscMaster.ResumeLayout(false);
            this._groupBoxIDiscMaster.PerformLayout();
            this._groupBoxRedbook.ResumeLayout(false);
            this._groupBoxRedbook.PerformLayout();
            this._groupBoxJoliet.ResumeLayout(false);
            this._groupBoxJoliet.PerformLayout();
            this._groupBoxActiveRecorder.ResumeLayout(false);
            this._groupBoxActiveRecorder.PerformLayout();
            this._groupBoxMediaDetails.ResumeLayout(false);
            this._groupBoxMediaDetails.PerformLayout();
            this._tabControl.ResumeLayout(false);
            this._tabPageBurn.ResumeLayout(false);
            this._tabPageLog.ResumeLayout(false);
            this._groupBoxLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBoxStatus;
        private System.Windows.Forms.Button _buttonCancelBurn;
        private System.Windows.Forms.Label _labelTrackProgress;
        private System.Windows.Forms.Label _labelBlockProgress;
        private System.Windows.Forms.Label _labelAddProgress;
        private System.Windows.Forms.ProgressBar _progressBarTrackProgress;
        private System.Windows.Forms.Label _labelQueryCancelFired;
        private System.Windows.Forms.ProgressBar _progressBarBlockProgress;
        private System.Windows.Forms.ProgressBar _progressBarQueryCancel;
        private System.Windows.Forms.ProgressBar _progressBarAddProgress;
        private System.Windows.Forms.GroupBox _groupBoxRedbookActions;
        private System.Windows.Forms.Button _buttonBurnRedbookCD;
        private System.Windows.Forms.Button _buttonMoveTrackDown;
        private System.Windows.Forms.Button _buttonMoveTrackUp;
        private System.Windows.Forms.Button _buttonAddTrack;
        private System.Windows.Forms.ListView _listViewTracks;
        private System.Windows.Forms.ColumnHeader _columnHeaderTrack;
        private System.Windows.Forms.ColumnHeader _columnHeaderFileName;
        private System.Windows.Forms.GroupBox _groupBoxJolietActions;
        private System.Windows.Forms.CheckBox _checkBoxMultiSession;
        private System.Windows.Forms.Button _buttonBurnJolietCD;
        private System.Windows.Forms.Button _buttonAddFolder;
        private System.Windows.Forms.Button _buttonAddFile;
        private System.Windows.Forms.TreeView _treeViewFiles;
        private System.Windows.Forms.Button _buttonNewSubfolder;
        private System.Windows.Forms.Button _buttonClear;
        private System.Windows.Forms.GroupBox _groupBoxUniversalActions;
        private System.Windows.Forms.CheckBox _checkBoxFullErase;
        private System.Windows.Forms.Button _buttonRefresh;
        private System.Windows.Forms.CheckBox _checkBoxEjectWhenComplete;
        private System.Windows.Forms.CheckBox _checkBoxSimulate;
        private System.Windows.Forms.Button _buttonEjectCD;
        private System.Windows.Forms.Button _buttonEraseCDRW;
        private System.Windows.Forms.GroupBox _groupBoxEventSubscriptions;
        private System.Windows.Forms.CheckBox _checkBoxActiveRecorderChanged;
        private System.Windows.Forms.CheckBox _checkBoxEraseComplete;
        private System.Windows.Forms.CheckBox _checkBoxBurnComplete;
        private System.Windows.Forms.CheckBox _checkBoxClosingDisc;
        private System.Windows.Forms.CheckBox _checkBoxPreparingBurn;
        private System.Windows.Forms.CheckBox _checkBoxQueryCancel;
        private System.Windows.Forms.CheckBox _checkBoxPNPActivity;
        private System.Windows.Forms.CheckBox _checkBoxTrackProgress;
        private System.Windows.Forms.CheckBox _checkBoxBlockProgress;
        private System.Windows.Forms.CheckBox _checkBoxAddProgress;
        private System.Windows.Forms.GroupBox _groupBoxIDiscMaster;
        private System.Windows.Forms.Button _buttonNextRecorder;
        private System.Windows.Forms.Button _buttonSwitchActiveDiscMasterFormat;
        private System.Windows.Forms.TextBox _textBoxActiveDiscMasterFormat;
        private System.Windows.Forms.Label _labelActiveDiscMasterFormat;
        private System.Windows.Forms.GroupBox _groupBoxRedbook;
        private System.Windows.Forms.TextBox _textBoxTotalAudioTracks;
        private System.Windows.Forms.TextBox _textBoxUsedAudioBlocks;
        private System.Windows.Forms.TextBox _textBoxTotalAudioBlocks;
        private System.Windows.Forms.TextBox _textBoxAudioBlockSize;
        private System.Windows.Forms.TextBox _textBoxAvailableTrackBlocks;
        private System.Windows.Forms.Label _labelTotalAudioTracks;
        private System.Windows.Forms.Label _labelUsedAudioBlocks;
        private System.Windows.Forms.Label _labelTotalAudioBlocks;
        private System.Windows.Forms.Label _labelAudioBlockSize;
        private System.Windows.Forms.Label _labelAvailableTrackBlocks;
        private System.Windows.Forms.GroupBox _groupBoxJoliet;
        private System.Windows.Forms.ComboBox _comboBoxlBootImageEmulationType;
        private System.Windows.Forms.ComboBox _comboBoxBootImagePlatform;
        private System.Windows.Forms.Button _buttonSetVolumeName;
        private System.Windows.Forms.TextBox _textBoxBootImageManufacturerIdString;
        private System.Windows.Forms.TextBox _textBoxVolumeName;
        private System.Windows.Forms.RadioButton _radioButtonPlaceBootImageOnDiscNo;
        private System.Windows.Forms.RadioButton _radioButtonPlaceBootImageOnDiscYes;
        private System.Windows.Forms.TextBox _textBoxlUsedDataBlocks;
        private System.Windows.Forms.TextBox _textBoxlTotalDataBlocks;
        private System.Windows.Forms.TextBox _textBoxDataBlockSize;
        private System.Windows.Forms.Label _labelBootImageEmulationType;
        private System.Windows.Forms.Label _labelBootImagePlatform;
        private System.Windows.Forms.Label _labelBootImageManufacturerIdString;
        private System.Windows.Forms.Label _labelPlaceBootImageOnDisc;
        private System.Windows.Forms.Label _labelVolumeName;
        private System.Windows.Forms.Label _labelUsedDataBlocks;
        private System.Windows.Forms.Label _labelTotalDataBlocks;
        private System.Windows.Forms.Label _labelDataBlockSize;
        private System.Windows.Forms.GroupBox _groupBoxActiveRecorder;
        private System.Windows.Forms.Button _buttonWriteSpeedDecrease;
        private System.Windows.Forms.Button _buttonWriteSpeedIncrease;
        private System.Windows.Forms.TextBox _textBoxWriteSpeed;
        private System.Windows.Forms.TextBox _textBoxMaxWriteSpeed;
        private System.Windows.Forms.TextBox _textBoxRecorderState;
        private System.Windows.Forms.TextBox _textBoxRecorderType;
        private System.Windows.Forms.TextBox _textBoxDriveLetter;
        private System.Windows.Forms.TextBox _textBoxOSPath;
        private System.Windows.Forms.TextBox _textBoxRevision;
        private System.Windows.Forms.TextBox _textBoxVendor;
        private System.Windows.Forms.TextBox _textBoxProduct;
        private System.Windows.Forms.TextBox _textBoxPnPID;
        private System.Windows.Forms.Label _labelWriteSpeed;
        private System.Windows.Forms.Label _labelMaxWriteSpeed;
        private System.Windows.Forms.Label _labelRecorderState;
        private System.Windows.Forms.Label _labelRecorderType;
        private System.Windows.Forms.Label _labelDriveLetter;
        private System.Windows.Forms.Label _labelOSPath;
        private System.Windows.Forms.Label _labelRevision;
        private System.Windows.Forms.Label _labelVendor;
        private System.Windows.Forms.Label _labelProduct;
        private System.Windows.Forms.Label _labelPnpID;
        private System.Windows.Forms.GroupBox _groupBoxMediaDetails;
        private System.Windows.Forms.TextBox _textBoxMediaFlags;
        private System.Windows.Forms.TextBox _textBoxMediaType;
        private System.Windows.Forms.TextBox _textBoxFreeBlocks;
        private System.Windows.Forms.TextBox _textBoxNextWritable;
        private System.Windows.Forms.TextBox _textBoxStartAddress;
        private System.Windows.Forms.TextBox _textBoxLastTrack;
        private System.Windows.Forms.TextBox _textBoxSessions;
        private System.Windows.Forms.TextBox _textBoxMediaPresent;
        private System.Windows.Forms.Label _labelMediaFlags;
        private System.Windows.Forms.Label _labelMediaType;
        private System.Windows.Forms.Label _labelFreeBlocks;
        private System.Windows.Forms.Label _labelNextWritable;
        private System.Windows.Forms.Label _labelStartAddress;
        private System.Windows.Forms.Label _labelLastTrack;
        private System.Windows.Forms.Label _labelSessions;
        private System.Windows.Forms.Label _labelMediaPresent;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _tabPageBurn;
        private System.Windows.Forms.TabPage _tabPageLog;
        private System.Windows.Forms.GroupBox _groupBoxLog;
        private System.Windows.Forms.RichTextBox _richTextBoxLog;
        private System.Windows.Forms.Button _buttonSaveLog;
        private System.Windows.Forms.Button _buttonClearLog;
        private System.ComponentModel.BackgroundWorker _backgroundWorkerBurnAudio;
        private System.ComponentModel.BackgroundWorker _backgroundWorkerBurn;
    }
}

