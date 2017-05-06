namespace Chess24Cheat
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
            this.components = new System.ComponentModel.Container();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.EngineFilename = new System.Windows.Forms.TextBox();
            this.QSmBox = new System.Windows.Forms.CheckBox();
            this.KSmBox = new System.Windows.Forms.CheckBox();
            this.QBox = new System.Windows.Forms.CheckBox();
            this.KBox = new System.Windows.Forms.CheckBox();
            this.score = new System.Windows.Forms.Label();
            this.PlayForMe = new System.Windows.Forms.CheckBox();
            this.AnalysisTimeUnits = new System.Windows.Forms.Label();
            this.AnalysisTime = new System.Windows.Forms.TextBox();
            this.AnalysisResult = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.black = new System.Windows.Forms.RadioButton();
            this.white = new System.Windows.Forms.RadioButton();
            this.RunAnalysis = new System.Windows.Forms.Button();
            this.InitTheEngine = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.browserPanel = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.controlsPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.EngineFilename);
            this.controlsPanel.Controls.Add(this.QSmBox);
            this.controlsPanel.Controls.Add(this.KSmBox);
            this.controlsPanel.Controls.Add(this.QBox);
            this.controlsPanel.Controls.Add(this.KBox);
            this.controlsPanel.Controls.Add(this.score);
            this.controlsPanel.Controls.Add(this.PlayForMe);
            this.controlsPanel.Controls.Add(this.AnalysisTimeUnits);
            this.controlsPanel.Controls.Add(this.AnalysisTime);
            this.controlsPanel.Controls.Add(this.AnalysisResult);
            this.controlsPanel.Controls.Add(this.richTextBox);
            this.controlsPanel.Controls.Add(this.groupBox1);
            this.controlsPanel.Controls.Add(this.RunAnalysis);
            this.controlsPanel.Controls.Add(this.InitTheEngine);
            this.controlsPanel.Controls.Add(this.start);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlsPanel.Location = new System.Drawing.Point(0, 0);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(1098, 133);
            this.controlsPanel.TabIndex = 0;
            // 
            // EngineFilename
            // 
            this.EngineFilename.Location = new System.Drawing.Point(12, 99);
            this.EngineFilename.Name = "EngineFilename";
            this.EngineFilename.Size = new System.Drawing.Size(422, 20);
            this.EngineFilename.TabIndex = 15;
            this.EngineFilename.Text = "D:\\Chess\\stockfish-8-win\\Windows\\stockfish_8_x64.exe";
            // 
            // QSmBox
            // 
            this.QSmBox.AutoSize = true;
            this.QSmBox.Checked = true;
            this.QSmBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.QSmBox.Location = new System.Drawing.Point(580, 99);
            this.QSmBox.Name = "QSmBox";
            this.QSmBox.Size = new System.Drawing.Size(32, 17);
            this.QSmBox.TabIndex = 14;
            this.QSmBox.Text = "q";
            this.QSmBox.UseVisualStyleBackColor = true;
            // 
            // KSmBox
            // 
            this.KSmBox.AutoSize = true;
            this.KSmBox.Checked = true;
            this.KSmBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KSmBox.Location = new System.Drawing.Point(541, 99);
            this.KSmBox.Name = "KSmBox";
            this.KSmBox.Size = new System.Drawing.Size(32, 17);
            this.KSmBox.TabIndex = 13;
            this.KSmBox.Text = "k";
            this.KSmBox.UseVisualStyleBackColor = true;
            // 
            // QBox
            // 
            this.QBox.AutoSize = true;
            this.QBox.Checked = true;
            this.QBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.QBox.Location = new System.Drawing.Point(502, 100);
            this.QBox.Name = "QBox";
            this.QBox.Size = new System.Drawing.Size(34, 17);
            this.QBox.TabIndex = 12;
            this.QBox.Text = "Q";
            this.QBox.UseVisualStyleBackColor = true;
            // 
            // KBox
            // 
            this.KBox.AutoSize = true;
            this.KBox.Checked = true;
            this.KBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KBox.Location = new System.Drawing.Point(463, 100);
            this.KBox.Name = "KBox";
            this.KBox.Size = new System.Drawing.Size(33, 17);
            this.KBox.TabIndex = 11;
            this.KBox.Text = "K";
            this.KBox.UseVisualStyleBackColor = true;
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.Location = new System.Drawing.Point(907, 10);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(194, 73);
            this.score.TabIndex = 10;
            this.score.Text = "00,00";
            // 
            // PlayForMe
            // 
            this.PlayForMe.AutoSize = true;
            this.PlayForMe.Location = new System.Drawing.Point(157, 59);
            this.PlayForMe.Name = "PlayForMe";
            this.PlayForMe.Size = new System.Drawing.Size(82, 17);
            this.PlayForMe.TabIndex = 9;
            this.PlayForMe.Text = "Play For Me";
            this.PlayForMe.UseVisualStyleBackColor = true;
            this.PlayForMe.CheckedChanged += new System.EventHandler(this.PlayForMe_CheckedChanged);
            // 
            // AnalysisTimeUnits
            // 
            this.AnalysisTimeUnits.AutoSize = true;
            this.AnalysisTimeUnits.Location = new System.Drawing.Point(265, 76);
            this.AnalysisTimeUnits.Name = "AnalysisTimeUnits";
            this.AnalysisTimeUnits.Size = new System.Drawing.Size(63, 13);
            this.AnalysisTimeUnits.TabIndex = 7;
            this.AnalysisTimeUnits.Text = "milliseconds";
            // 
            // AnalysisTime
            // 
            this.AnalysisTime.Location = new System.Drawing.Point(250, 53);
            this.AnalysisTime.Name = "AnalysisTime";
            this.AnalysisTime.Size = new System.Drawing.Size(91, 20);
            this.AnalysisTime.TabIndex = 6;
            this.AnalysisTime.Text = "5000";
            this.AnalysisTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AnalysisResult
            // 
            this.AnalysisResult.AutoSize = true;
            this.AnalysisResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnalysisResult.Location = new System.Drawing.Point(465, 12);
            this.AnalysisResult.Name = "AnalysisResult";
            this.AnalysisResult.Size = new System.Drawing.Size(132, 73);
            this.AnalysisResult.TabIndex = 5;
            this.AnalysisResult.Text = "****";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(622, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(279, 71);
            this.richTextBox.TabIndex = 4;
            this.richTextBox.Text = "";
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.black);
            this.groupBox1.Controls.Add(this.white);
            this.groupBox1.Location = new System.Drawing.Point(347, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 71);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analysis color";
            // 
            // black
            // 
            this.black.AutoSize = true;
            this.black.Location = new System.Drawing.Point(6, 42);
            this.black.Name = "black";
            this.black.Size = new System.Drawing.Size(52, 17);
            this.black.TabIndex = 1;
            this.black.Text = "Black";
            this.black.UseVisualStyleBackColor = true;
            // 
            // white
            // 
            this.white.AutoSize = true;
            this.white.Checked = true;
            this.white.Location = new System.Drawing.Point(6, 19);
            this.white.Name = "white";
            this.white.Size = new System.Drawing.Size(53, 17);
            this.white.TabIndex = 0;
            this.white.TabStop = true;
            this.white.Text = "White";
            this.white.UseVisualStyleBackColor = true;
            // 
            // RunAnalysis
            // 
            this.RunAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunAnalysis.Location = new System.Drawing.Point(250, 12);
            this.RunAnalysis.Name = "RunAnalysis";
            this.RunAnalysis.Size = new System.Drawing.Size(91, 35);
            this.RunAnalysis.TabIndex = 2;
            this.RunAnalysis.Text = "Analyse";
            this.RunAnalysis.UseVisualStyleBackColor = true;
            this.RunAnalysis.Click += new System.EventHandler(this.RunAnalysis_Click);
            // 
            // InitTheEngine
            // 
            this.InitTheEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InitTheEngine.Location = new System.Drawing.Point(153, 12);
            this.InitTheEngine.Name = "InitTheEngine";
            this.InitTheEngine.Size = new System.Drawing.Size(91, 35);
            this.InitTheEngine.TabIndex = 1;
            this.InitTheEngine.Text = "Init Engine";
            this.InitTheEngine.UseVisualStyleBackColor = true;
            this.InitTheEngine.Click += new System.EventHandler(this.InitEngine_Click);
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(12, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(135, 77);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // browserPanel
            // 
            this.browserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserPanel.Location = new System.Drawing.Point(0, 133);
            this.browserPanel.Name = "browserPanel";
            this.browserPanel.Size = new System.Drawing.Size(1098, 283);
            this.browserPanel.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 416);
            this.Controls.Add(this.browserPanel);
            this.Controls.Add(this.controlsPanel);
            this.Name = "MainForm";
            this.Text = "Chess24 Cheat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Panel browserPanel;
        private System.Windows.Forms.Label AnalysisResult;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton black;
        private System.Windows.Forms.RadioButton white;
        private System.Windows.Forms.Button RunAnalysis;
        private System.Windows.Forms.Button InitTheEngine;
        private System.Windows.Forms.Label AnalysisTimeUnits;
        private System.Windows.Forms.TextBox AnalysisTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox PlayForMe;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.CheckBox QSmBox;
        private System.Windows.Forms.CheckBox KSmBox;
        private System.Windows.Forms.CheckBox QBox;
        private System.Windows.Forms.CheckBox KBox;
        private System.Windows.Forms.TextBox EngineFilename;
    }
}

