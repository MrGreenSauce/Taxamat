namespace Taxamat
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chbx_createFilteredList = new System.Windows.Forms.CheckBox();
            this.fillEmptyFields = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_Merge = new System.Windows.Forms.Button();
            this.lbx_Files = new System.Windows.Forms.ListBox();
            this.btn_addFilesForMerge = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pbox_inputOk = new System.Windows.Forms.PictureBox();
            this.pbox_inputNotOk = new System.Windows.Forms.PictureBox();
            this.progressLbl = new System.Windows.Forms.Label();
            this.pBar_hierarchy = new System.Windows.Forms.ProgressBar();
            this.chbx_createSeparateFileStatistics = new System.Windows.Forms.CheckBox();
            this.chbx_removeArchea = new System.Windows.Forms.CheckBox();
            this.chbx_removeViruses = new System.Windows.Forms.CheckBox();
            this.chbx_removeBacteria = new System.Windows.Forms.CheckBox();
            this.chbx_removeFungi = new System.Windows.Forms.CheckBox();
            this.chbx_removeViridiplantae = new System.Windows.Forms.CheckBox();
            this.chbx_removeMetazoa = new System.Windows.Forms.CheckBox();
            this.inputLbl = new System.Windows.Forms.Label();
            this.createTaxListBtn = new System.Windows.Forms.Button();
            this.readInputListBtn = new System.Windows.Forms.Button();
            this.loadNodeLbl = new System.Windows.Forms.Label();
            this.loadNodes = new System.Windows.Forms.Button();
            this.loadLbl = new System.Windows.Forms.Label();
            this.loadNamesLbl = new System.Windows.Forms.Label();
            this.loadNames = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbox_nodesOk = new System.Windows.Forms.PictureBox();
            this.pbox_namesOk = new System.Windows.Forms.PictureBox();
            this.pbox_nodesNotOk = new System.Windows.Forms.PictureBox();
            this.pbox_namesNotOk = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbx_removeUnidentified = new System.Windows.Forms.CheckBox();
            this.tab3_createDiversityStatistics = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pbox_statisticsOk = new System.Windows.Forms.PictureBox();
            this.pbar_statistics = new System.Windows.Forms.ProgressBar();
            this.gbox_downsamplingMethod = new System.Windows.Forms.GroupBox();
            this.nUD_downsampleTarget = new System.Windows.Forms.NumericUpDown();
            this.rbtn_userDefined = new System.Windows.Forms.RadioButton();
            this.rbtn_lowestSampleTotal = new System.Windows.Forms.RadioButton();
            this.chbx_downsample = new System.Windows.Forms.CheckBox();
            this.chbx_CreateStatistics = new System.Windows.Forms.CheckBox();
            this.lbl_statisticsCreatedFromMerged = new System.Windows.Forms.Label();
            this.btn_LoadMergedFile = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_inputOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_inputNotOk)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_nodesOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_namesOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_nodesNotOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_namesNotOk)).BeginInit();
            this.panel2.SuspendLayout();
            this.tab3_createDiversityStatistics.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_statisticsOk)).BeginInit();
            this.gbox_downsamplingMethod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_downsampleTarget)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chbx_createFilteredList
            // 
            this.chbx_createFilteredList.AutoSize = true;
            this.chbx_createFilteredList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbx_createFilteredList.Location = new System.Drawing.Point(15, 14);
            this.chbx_createFilteredList.Name = "chbx_createFilteredList";
            this.chbx_createFilteredList.Size = new System.Drawing.Size(92, 17);
            this.chbx_createFilteredList.TabIndex = 17;
            this.chbx_createFilteredList.Text = "Apply filters";
            this.toolTip1.SetToolTip(this.chbx_createFilteredList, "Creates an extra result file in which the checked groups are removed.");
            this.chbx_createFilteredList.UseVisualStyleBackColor = true;
            this.chbx_createFilteredList.CheckedChanged += new System.EventHandler(this.chbx_createFilteredList_CheckedChanged_1);
            // 
            // fillEmptyFields
            // 
            this.fillEmptyFields.AutoSize = true;
            this.fillEmptyFields.Checked = true;
            this.fillEmptyFields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fillEmptyFields.Location = new System.Drawing.Point(12, 188);
            this.fillEmptyFields.Name = "fillEmptyFields";
            this.fillEmptyFields.Size = new System.Drawing.Size(96, 17);
            this.fillEmptyFields.TabIndex = 30;
            this.fillEmptyFields.Text = "Fill empty fields";
            this.toolTip1.SetToolTip(this.fillEmptyFields, "Any empty field in the result files will be replaced by \"n.a.\"");
            this.fillEmptyFields.UseVisualStyleBackColor = true;
            this.fillEmptyFields.CheckedChanged += new System.EventHandler(this.fillEmptyFields_CheckedChanged_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_Merge);
            this.tabPage2.Controls.Add(this.lbx_Files);
            this.tabPage2.Controls.Add(this.btn_addFilesForMerge);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(633, 496);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Merge Files";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_Merge
            // 
            this.btn_Merge.Location = new System.Drawing.Point(21, 176);
            this.btn_Merge.Name = "btn_Merge";
            this.btn_Merge.Size = new System.Drawing.Size(168, 43);
            this.btn_Merge.TabIndex = 2;
            this.btn_Merge.Text = "Specify Output File And Merge Selected Files";
            this.btn_Merge.UseVisualStyleBackColor = true;
            this.btn_Merge.Click += new System.EventHandler(this.btn_Merge_Click);
            // 
            // lbx_Files
            // 
            this.lbx_Files.FormattingEnabled = true;
            this.lbx_Files.Location = new System.Drawing.Point(214, 46);
            this.lbx_Files.Name = "lbx_Files";
            this.lbx_Files.Size = new System.Drawing.Size(413, 173);
            this.lbx_Files.TabIndex = 1;
            // 
            // btn_addFilesForMerge
            // 
            this.btn_addFilesForMerge.Location = new System.Drawing.Point(21, 46);
            this.btn_addFilesForMerge.Name = "btn_addFilesForMerge";
            this.btn_addFilesForMerge.Size = new System.Drawing.Size(135, 40);
            this.btn_addFilesForMerge.TabIndex = 0;
            this.btn_addFilesForMerge.Text = "Select Files for Merging";
            this.btn_addFilesForMerge.UseVisualStyleBackColor = true;
            this.btn_addFilesForMerge.Click += new System.EventHandler(this.btn_addFilesForMerge_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pbox_inputOk);
            this.tabPage1.Controls.Add(this.pbox_inputNotOk);
            this.tabPage1.Controls.Add(this.progressLbl);
            this.tabPage1.Controls.Add(this.pBar_hierarchy);
            this.tabPage1.Controls.Add(this.chbx_createSeparateFileStatistics);
            this.tabPage1.Controls.Add(this.chbx_removeArchea);
            this.tabPage1.Controls.Add(this.chbx_removeViruses);
            this.tabPage1.Controls.Add(this.chbx_removeBacteria);
            this.tabPage1.Controls.Add(this.chbx_removeFungi);
            this.tabPage1.Controls.Add(this.chbx_removeViridiplantae);
            this.tabPage1.Controls.Add(this.chbx_removeMetazoa);
            this.tabPage1.Controls.Add(this.fillEmptyFields);
            this.tabPage1.Controls.Add(this.inputLbl);
            this.tabPage1.Controls.Add(this.createTaxListBtn);
            this.tabPage1.Controls.Add(this.readInputListBtn);
            this.tabPage1.Controls.Add(this.loadNodeLbl);
            this.tabPage1.Controls.Add(this.loadNodes);
            this.tabPage1.Controls.Add(this.loadLbl);
            this.tabPage1.Controls.Add(this.loadNamesLbl);
            this.tabPage1.Controls.Add(this.loadNames);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(633, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create Hierarchy";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pbox_inputOk
            // 
            this.pbox_inputOk.Image = ((System.Drawing.Image)(resources.GetObject("pbox_inputOk.Image")));
            this.pbox_inputOk.Location = new System.Drawing.Point(189, 146);
            this.pbox_inputOk.Name = "pbox_inputOk";
            this.pbox_inputOk.Size = new System.Drawing.Size(24, 23);
            this.pbox_inputOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_inputOk.TabIndex = 40;
            this.pbox_inputOk.TabStop = false;
            this.pbox_inputOk.Visible = false;
            // 
            // pbox_inputNotOk
            // 
            this.pbox_inputNotOk.Image = ((System.Drawing.Image)(resources.GetObject("pbox_inputNotOk.Image")));
            this.pbox_inputNotOk.Location = new System.Drawing.Point(189, 146);
            this.pbox_inputNotOk.Name = "pbox_inputNotOk";
            this.pbox_inputNotOk.Size = new System.Drawing.Size(24, 23);
            this.pbox_inputNotOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_inputNotOk.TabIndex = 41;
            this.pbox_inputNotOk.TabStop = false;
            // 
            // progressLbl
            // 
            this.progressLbl.AutoSize = true;
            this.progressLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.progressLbl.Location = new System.Drawing.Point(213, 388);
            this.progressLbl.Name = "progressLbl";
            this.progressLbl.Size = new System.Drawing.Size(0, 20);
            this.progressLbl.TabIndex = 29;
            // 
            // pBar_hierarchy
            // 
            this.pBar_hierarchy.Location = new System.Drawing.Point(211, 434);
            this.pBar_hierarchy.Name = "pBar_hierarchy";
            this.pBar_hierarchy.Size = new System.Drawing.Size(355, 23);
            this.pBar_hierarchy.Step = 1;
            this.pBar_hierarchy.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar_hierarchy.TabIndex = 39;
            // 
            // chbx_createSeparateFileStatistics
            // 
            this.chbx_createSeparateFileStatistics.AutoSize = true;
            this.chbx_createSeparateFileStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbx_createSeparateFileStatistics.Location = new System.Drawing.Point(12, 211);
            this.chbx_createSeparateFileStatistics.Name = "chbx_createSeparateFileStatistics";
            this.chbx_createSeparateFileStatistics.Size = new System.Drawing.Size(237, 17);
            this.chbx_createSeparateFileStatistics.TabIndex = 38;
            this.chbx_createSeparateFileStatistics.Text = "Create separate files for each taxonomy level";
            this.chbx_createSeparateFileStatistics.UseVisualStyleBackColor = true;
            this.chbx_createSeparateFileStatistics.CheckedChanged += new System.EventHandler(this.chbx_createSeparateFileStatistics_CheckedChanged);
            // 
            // chbx_removeArchea
            // 
            this.chbx_removeArchea.AutoSize = true;
            this.chbx_removeArchea.Enabled = false;
            this.chbx_removeArchea.Location = new System.Drawing.Point(28, 434);
            this.chbx_removeArchea.Name = "chbx_removeArchea";
            this.chbx_removeArchea.Size = new System.Drawing.Size(109, 17);
            this.chbx_removeArchea.TabIndex = 36;
            this.chbx_removeArchea.Text = "Remove Archaea";
            this.chbx_removeArchea.UseVisualStyleBackColor = true;
            // 
            // chbx_removeViruses
            // 
            this.chbx_removeViruses.AutoSize = true;
            this.chbx_removeViruses.Enabled = false;
            this.chbx_removeViruses.Location = new System.Drawing.Point(28, 411);
            this.chbx_removeViruses.Name = "chbx_removeViruses";
            this.chbx_removeViruses.Size = new System.Drawing.Size(103, 17);
            this.chbx_removeViruses.TabIndex = 35;
            this.chbx_removeViruses.Text = "Remove Viruses";
            this.chbx_removeViruses.UseVisualStyleBackColor = true;
            // 
            // chbx_removeBacteria
            // 
            this.chbx_removeBacteria.AutoSize = true;
            this.chbx_removeBacteria.Enabled = false;
            this.chbx_removeBacteria.Location = new System.Drawing.Point(28, 388);
            this.chbx_removeBacteria.Name = "chbx_removeBacteria";
            this.chbx_removeBacteria.Size = new System.Drawing.Size(108, 17);
            this.chbx_removeBacteria.TabIndex = 34;
            this.chbx_removeBacteria.Text = "Remove Bacteria";
            this.chbx_removeBacteria.UseVisualStyleBackColor = true;
            // 
            // chbx_removeFungi
            // 
            this.chbx_removeFungi.AutoSize = true;
            this.chbx_removeFungi.Enabled = false;
            this.chbx_removeFungi.Location = new System.Drawing.Point(28, 365);
            this.chbx_removeFungi.Name = "chbx_removeFungi";
            this.chbx_removeFungi.Size = new System.Drawing.Size(95, 17);
            this.chbx_removeFungi.TabIndex = 33;
            this.chbx_removeFungi.Text = "Remove Fungi";
            this.chbx_removeFungi.UseVisualStyleBackColor = true;
            // 
            // chbx_removeViridiplantae
            // 
            this.chbx_removeViridiplantae.AutoSize = true;
            this.chbx_removeViridiplantae.Enabled = false;
            this.chbx_removeViridiplantae.Location = new System.Drawing.Point(28, 342);
            this.chbx_removeViridiplantae.Name = "chbx_removeViridiplantae";
            this.chbx_removeViridiplantae.Size = new System.Drawing.Size(126, 17);
            this.chbx_removeViridiplantae.TabIndex = 32;
            this.chbx_removeViridiplantae.Text = "Remove Viridiplantae";
            this.chbx_removeViridiplantae.UseVisualStyleBackColor = true;
            // 
            // chbx_removeMetazoa
            // 
            this.chbx_removeMetazoa.AutoSize = true;
            this.chbx_removeMetazoa.Enabled = false;
            this.chbx_removeMetazoa.Location = new System.Drawing.Point(28, 319);
            this.chbx_removeMetazoa.Name = "chbx_removeMetazoa";
            this.chbx_removeMetazoa.Size = new System.Drawing.Size(110, 17);
            this.chbx_removeMetazoa.TabIndex = 31;
            this.chbx_removeMetazoa.Text = "Remove Metazoa";
            this.chbx_removeMetazoa.UseVisualStyleBackColor = true;
            // 
            // inputLbl
            // 
            this.inputLbl.AutoSize = true;
            this.inputLbl.Location = new System.Drawing.Point(243, 153);
            this.inputLbl.Name = "inputLbl";
            this.inputLbl.Size = new System.Drawing.Size(57, 13);
            this.inputLbl.TabIndex = 28;
            this.inputLbl.Text = "not loaded";
            // 
            // createTaxListBtn
            // 
            this.createTaxListBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.createTaxListBtn.Location = new System.Drawing.Point(217, 283);
            this.createTaxListBtn.Name = "createTaxListBtn";
            this.createTaxListBtn.Size = new System.Drawing.Size(349, 63);
            this.createTaxListBtn.TabIndex = 27;
            this.createTaxListBtn.Text = "Create Hierarchy";
            this.createTaxListBtn.UseVisualStyleBackColor = true;
            this.createTaxListBtn.Click += new System.EventHandler(this.createTaxListBtn_Click_1);
            // 
            // readInputListBtn
            // 
            this.readInputListBtn.Location = new System.Drawing.Point(12, 146);
            this.readInputListBtn.Name = "readInputListBtn";
            this.readInputListBtn.Size = new System.Drawing.Size(154, 26);
            this.readInputListBtn.TabIndex = 26;
            this.readInputListBtn.Text = "Load Input File(s)";
            this.readInputListBtn.UseVisualStyleBackColor = true;
            this.readInputListBtn.Click += new System.EventHandler(this.readInputListBtn_Click_1);
            // 
            // loadNodeLbl
            // 
            this.loadNodeLbl.AutoSize = true;
            this.loadNodeLbl.Location = new System.Drawing.Point(243, 78);
            this.loadNodeLbl.Name = "loadNodeLbl";
            this.loadNodeLbl.Size = new System.Drawing.Size(57, 13);
            this.loadNodeLbl.TabIndex = 24;
            this.loadNodeLbl.Text = "not loaded";
            // 
            // loadNodes
            // 
            this.loadNodes.Location = new System.Drawing.Point(12, 73);
            this.loadNodes.Name = "loadNodes";
            this.loadNodes.Size = new System.Drawing.Size(154, 23);
            this.loadNodes.TabIndex = 23;
            this.loadNodes.Text = "Load \"nodes.dmp\"";
            this.loadNodes.UseVisualStyleBackColor = true;
            this.loadNodes.Click += new System.EventHandler(this.loadNodes_Click_1);
            // 
            // loadLbl
            // 
            this.loadLbl.AutoSize = true;
            this.loadLbl.Location = new System.Drawing.Point(243, 38);
            this.loadLbl.Name = "loadLbl";
            this.loadLbl.Size = new System.Drawing.Size(57, 13);
            this.loadLbl.TabIndex = 22;
            this.loadLbl.Text = "not loaded";
            this.loadLbl.Click += new System.EventHandler(this.loadLbl_Click);
            // 
            // loadNamesLbl
            // 
            this.loadNamesLbl.AutoSize = true;
            this.loadNamesLbl.Location = new System.Drawing.Point(208, 38);
            this.loadNamesLbl.Name = "loadNamesLbl";
            this.loadNamesLbl.Size = new System.Drawing.Size(0, 13);
            this.loadNamesLbl.TabIndex = 21;
            // 
            // loadNames
            // 
            this.loadNames.Location = new System.Drawing.Point(12, 33);
            this.loadNames.Name = "loadNames";
            this.loadNames.Size = new System.Drawing.Size(154, 23);
            this.loadNames.TabIndex = 20;
            this.loadNames.Text = "Load \"names.dmp\"";
            this.loadNames.UseVisualStyleBackColor = true;
            this.loadNames.Click += new System.EventHandler(this.loadNames_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbox_nodesOk);
            this.panel1.Controls.Add(this.pbox_namesOk);
            this.panel1.Controls.Add(this.pbox_nodesNotOk);
            this.panel1.Controls.Add(this.pbox_namesNotOk);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(6, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 114);
            this.panel1.TabIndex = 25;
            // 
            // pbox_nodesOk
            // 
            this.pbox_nodesOk.Image = ((System.Drawing.Image)(resources.GetObject("pbox_nodesOk.Image")));
            this.pbox_nodesOk.Location = new System.Drawing.Point(182, 56);
            this.pbox_nodesOk.Name = "pbox_nodesOk";
            this.pbox_nodesOk.Size = new System.Drawing.Size(24, 23);
            this.pbox_nodesOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_nodesOk.TabIndex = 3;
            this.pbox_nodesOk.TabStop = false;
            this.pbox_nodesOk.Visible = false;
            // 
            // pbox_namesOk
            // 
            this.pbox_namesOk.Image = ((System.Drawing.Image)(resources.GetObject("pbox_namesOk.Image")));
            this.pbox_namesOk.Location = new System.Drawing.Point(182, 16);
            this.pbox_namesOk.Name = "pbox_namesOk";
            this.pbox_namesOk.Size = new System.Drawing.Size(24, 23);
            this.pbox_namesOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_namesOk.TabIndex = 2;
            this.pbox_namesOk.TabStop = false;
            this.pbox_namesOk.Visible = false;
            // 
            // pbox_nodesNotOk
            // 
            this.pbox_nodesNotOk.Image = ((System.Drawing.Image)(resources.GetObject("pbox_nodesNotOk.Image")));
            this.pbox_nodesNotOk.Location = new System.Drawing.Point(182, 56);
            this.pbox_nodesNotOk.Name = "pbox_nodesNotOk";
            this.pbox_nodesNotOk.Size = new System.Drawing.Size(24, 23);
            this.pbox_nodesNotOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_nodesNotOk.TabIndex = 1;
            this.pbox_nodesNotOk.TabStop = false;
            // 
            // pbox_namesNotOk
            // 
            this.pbox_namesNotOk.Image = ((System.Drawing.Image)(resources.GetObject("pbox_namesNotOk.Image")));
            this.pbox_namesNotOk.Location = new System.Drawing.Point(182, 16);
            this.pbox_namesNotOk.Name = "pbox_namesNotOk";
            this.pbox_namesNotOk.Size = new System.Drawing.Size(24, 23);
            this.pbox_namesNotOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_namesNotOk.TabIndex = 0;
            this.pbox_namesNotOk.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chbx_removeUnidentified);
            this.panel2.Controls.Add(this.chbx_createFilteredList);
            this.panel2.Location = new System.Drawing.Point(12, 267);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(159, 223);
            this.panel2.TabIndex = 37;
            // 
            // chbx_removeUnidentified
            // 
            this.chbx_removeUnidentified.AutoSize = true;
            this.chbx_removeUnidentified.Enabled = false;
            this.chbx_removeUnidentified.Location = new System.Drawing.Point(14, 189);
            this.chbx_removeUnidentified.Name = "chbx_removeUnidentified";
            this.chbx_removeUnidentified.Size = new System.Drawing.Size(125, 17);
            this.chbx_removeUnidentified.TabIndex = 37;
            this.chbx_removeUnidentified.Text = "Remove Unidentified";
            this.chbx_removeUnidentified.UseVisualStyleBackColor = true;
            // 
            // tab3_createDiversityStatistics
            // 
            this.tab3_createDiversityStatistics.Controls.Add(this.tabPage1);
            this.tab3_createDiversityStatistics.Controls.Add(this.tabPage2);
            this.tab3_createDiversityStatistics.Controls.Add(this.tabPage3);
            this.tab3_createDiversityStatistics.Controls.Add(this.tabPage4);
            this.tab3_createDiversityStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tab3_createDiversityStatistics.Location = new System.Drawing.Point(12, 12);
            this.tab3_createDiversityStatistics.Name = "tab3_createDiversityStatistics";
            this.tab3_createDiversityStatistics.SelectedIndex = 0;
            this.tab3_createDiversityStatistics.Size = new System.Drawing.Size(641, 522);
            this.tab3_createDiversityStatistics.TabIndex = 20;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pbox_statisticsOk);
            this.tabPage3.Controls.Add(this.pbar_statistics);
            this.tabPage3.Controls.Add(this.gbox_downsamplingMethod);
            this.tabPage3.Controls.Add(this.chbx_downsample);
            this.tabPage3.Controls.Add(this.chbx_CreateStatistics);
            this.tabPage3.Controls.Add(this.lbl_statisticsCreatedFromMerged);
            this.tabPage3.Controls.Add(this.btn_LoadMergedFile);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(633, 496);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Statistics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pbox_statisticsOk
            // 
            this.pbox_statisticsOk.Image = ((System.Drawing.Image)(resources.GetObject("pbox_statisticsOk.Image")));
            this.pbox_statisticsOk.Location = new System.Drawing.Point(240, 42);
            this.pbox_statisticsOk.Name = "pbox_statisticsOk";
            this.pbox_statisticsOk.Size = new System.Drawing.Size(24, 23);
            this.pbox_statisticsOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_statisticsOk.TabIndex = 41;
            this.pbox_statisticsOk.TabStop = false;
            this.pbox_statisticsOk.Visible = false;
            // 
            // pbar_statistics
            // 
            this.pbar_statistics.Location = new System.Drawing.Point(134, 399);
            this.pbar_statistics.Name = "pbar_statistics";
            this.pbar_statistics.Size = new System.Drawing.Size(355, 23);
            this.pbar_statistics.Step = 1;
            this.pbar_statistics.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbar_statistics.TabIndex = 40;
            // 
            // gbox_downsamplingMethod
            // 
            this.gbox_downsamplingMethod.Controls.Add(this.nUD_downsampleTarget);
            this.gbox_downsamplingMethod.Controls.Add(this.rbtn_userDefined);
            this.gbox_downsamplingMethod.Controls.Add(this.rbtn_lowestSampleTotal);
            this.gbox_downsamplingMethod.Enabled = false;
            this.gbox_downsamplingMethod.Location = new System.Drawing.Point(44, 136);
            this.gbox_downsamplingMethod.Name = "gbox_downsamplingMethod";
            this.gbox_downsamplingMethod.Size = new System.Drawing.Size(276, 142);
            this.gbox_downsamplingMethod.TabIndex = 5;
            this.gbox_downsamplingMethod.TabStop = false;
            this.gbox_downsamplingMethod.Text = "Target Value";
            // 
            // nUD_downsampleTarget
            // 
            this.nUD_downsampleTarget.Enabled = false;
            this.nUD_downsampleTarget.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUD_downsampleTarget.Location = new System.Drawing.Point(53, 91);
            this.nUD_downsampleTarget.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nUD_downsampleTarget.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_downsampleTarget.Name = "nUD_downsampleTarget";
            this.nUD_downsampleTarget.Size = new System.Drawing.Size(120, 20);
            this.nUD_downsampleTarget.TabIndex = 7;
            this.nUD_downsampleTarget.ThousandsSeparator = true;
            this.nUD_downsampleTarget.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbtn_userDefined
            // 
            this.rbtn_userDefined.AutoSize = true;
            this.rbtn_userDefined.Location = new System.Drawing.Point(31, 68);
            this.rbtn_userDefined.Name = "rbtn_userDefined";
            this.rbtn_userDefined.Size = new System.Drawing.Size(115, 17);
            this.rbtn_userDefined.TabIndex = 1;
            this.rbtn_userDefined.Text = "Define target value";
            this.rbtn_userDefined.UseVisualStyleBackColor = true;
            this.rbtn_userDefined.CheckedChanged += new System.EventHandler(this.rbtn_userDefined_CheckedChanged);
            // 
            // rbtn_lowestSampleTotal
            // 
            this.rbtn_lowestSampleTotal.AutoSize = true;
            this.rbtn_lowestSampleTotal.Checked = true;
            this.rbtn_lowestSampleTotal.Location = new System.Drawing.Point(31, 32);
            this.rbtn_lowestSampleTotal.Name = "rbtn_lowestSampleTotal";
            this.rbtn_lowestSampleTotal.Size = new System.Drawing.Size(147, 17);
            this.rbtn_lowestSampleTotal.TabIndex = 0;
            this.rbtn_lowestSampleTotal.TabStop = true;
            this.rbtn_lowestSampleTotal.Text = "Match lowest sample total";
            this.rbtn_lowestSampleTotal.UseVisualStyleBackColor = true;
            // 
            // chbx_downsample
            // 
            this.chbx_downsample.AutoSize = true;
            this.chbx_downsample.Location = new System.Drawing.Point(27, 113);
            this.chbx_downsample.Name = "chbx_downsample";
            this.chbx_downsample.Size = new System.Drawing.Size(87, 17);
            this.chbx_downsample.TabIndex = 4;
            this.chbx_downsample.Text = "Downsample";
            this.chbx_downsample.UseVisualStyleBackColor = true;
            this.chbx_downsample.CheckedChanged += new System.EventHandler(this.chbx_downsample_CheckedChanged);
            // 
            // chbx_CreateStatistics
            // 
            this.chbx_CreateStatistics.AutoSize = true;
            this.chbx_CreateStatistics.Location = new System.Drawing.Point(27, 90);
            this.chbx_CreateStatistics.Name = "chbx_CreateStatistics";
            this.chbx_CreateStatistics.Size = new System.Drawing.Size(102, 17);
            this.chbx_CreateStatistics.TabIndex = 2;
            this.chbx_CreateStatistics.Text = "Create Statistics";
            this.chbx_CreateStatistics.UseVisualStyleBackColor = true;
            this.chbx_CreateStatistics.CheckedChanged += new System.EventHandler(this.chbx_CreateStatistics_CheckedChanged);
            // 
            // lbl_statisticsCreatedFromMerged
            // 
            this.lbl_statisticsCreatedFromMerged.AutoSize = true;
            this.lbl_statisticsCreatedFromMerged.Location = new System.Drawing.Point(275, 46);
            this.lbl_statisticsCreatedFromMerged.Name = "lbl_statisticsCreatedFromMerged";
            this.lbl_statisticsCreatedFromMerged.Size = new System.Drawing.Size(0, 13);
            this.lbl_statisticsCreatedFromMerged.TabIndex = 1;
            // 
            // btn_LoadMergedFile
            // 
            this.btn_LoadMergedFile.Location = new System.Drawing.Point(27, 36);
            this.btn_LoadMergedFile.Name = "btn_LoadMergedFile";
            this.btn_LoadMergedFile.Size = new System.Drawing.Size(190, 33);
            this.btn_LoadMergedFile.TabIndex = 0;
            this.btn_LoadMergedFile.Text = "Create Statistics For Merged File";
            this.btn_LoadMergedFile.UseVisualStyleBackColor = true;
            this.btn_LoadMergedFile.Click += new System.EventHandler(this.btn_LoadMergedFile_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.AboutLabel);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(633, 496);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // AboutLabel
            // 
            this.AboutLabel.AutoSize = true;
            this.AboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AboutLabel.Location = new System.Drawing.Point(20, 25);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(391, 128);
            this.AboutLabel.TabIndex = 0;
            this.AboutLabel.Text = "Version: 1.04\r\n\r\nFor the downloadable manual and step-by-step guide along with \r\n" +
    "example test data please visit www.taxamat.com!\r\n\r\nSupport:\r\ninfo@taxamat.com\r\n\r" +
    "\n";
            this.AboutLabel.Click += new System.EventHandler(this.AboutLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 547);
            this.Controls.Add(this.tab3_createDiversityStatistics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Taxamat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_inputOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_inputNotOk)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_nodesOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_namesOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_nodesNotOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_namesNotOk)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tab3_createDiversityStatistics.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_statisticsOk)).EndInit();
            this.gbox_downsamplingMethod.ResumeLayout(false);
            this.gbox_downsamplingMethod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_downsampleTarget)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_Merge;
        private System.Windows.Forms.ListBox lbx_Files;
        private System.Windows.Forms.Button btn_addFilesForMerge;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chbx_createSeparateFileStatistics;
        private System.Windows.Forms.CheckBox chbx_removeArchea;
        private System.Windows.Forms.CheckBox chbx_removeViruses;
        private System.Windows.Forms.CheckBox chbx_removeBacteria;
        private System.Windows.Forms.CheckBox chbx_removeFungi;
        private System.Windows.Forms.CheckBox chbx_removeViridiplantae;
        private System.Windows.Forms.CheckBox chbx_removeMetazoa;
        private System.Windows.Forms.CheckBox fillEmptyFields;
        private System.Windows.Forms.Label progressLbl;
        private System.Windows.Forms.Label inputLbl;
        private System.Windows.Forms.Button createTaxListBtn;
        private System.Windows.Forms.Button readInputListBtn;
        private System.Windows.Forms.Label loadNodeLbl;
        private System.Windows.Forms.Button loadNodes;
        private System.Windows.Forms.Label loadLbl;
        private System.Windows.Forms.Label loadNamesLbl;
        private System.Windows.Forms.Button loadNames;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chbx_removeUnidentified;
        private System.Windows.Forms.CheckBox chbx_createFilteredList;
        private System.Windows.Forms.TabControl tab3_createDiversityStatistics;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lbl_statisticsCreatedFromMerged;
        private System.Windows.Forms.Button btn_LoadMergedFile;
        private System.Windows.Forms.CheckBox chbx_downsample;
        private System.Windows.Forms.CheckBox chbx_CreateStatistics;
        private System.Windows.Forms.ProgressBar pBar_hierarchy;
        private System.Windows.Forms.GroupBox gbox_downsamplingMethod;
        private System.Windows.Forms.RadioButton rbtn_userDefined;
        private System.Windows.Forms.RadioButton rbtn_lowestSampleTotal;
        private System.Windows.Forms.NumericUpDown nUD_downsampleTarget;
        private System.Windows.Forms.ProgressBar pbar_statistics;
        private System.Windows.Forms.PictureBox pbox_namesOk;
        private System.Windows.Forms.PictureBox pbox_nodesNotOk;
        private System.Windows.Forms.PictureBox pbox_namesNotOk;
        private System.Windows.Forms.PictureBox pbox_nodesOk;
        private System.Windows.Forms.PictureBox pbox_inputOk;
        private System.Windows.Forms.PictureBox pbox_inputNotOk;
        private System.Windows.Forms.PictureBox pbox_statisticsOk;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label AboutLabel;
    }
}

