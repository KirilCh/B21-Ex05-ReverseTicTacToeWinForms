
namespace B21_Ex05_Kiril_323439711_Yonatan_204307672
{
    partial class FormGameSettings
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
            this.m_LabelPlayers = new System.Windows.Forms.Label();
            this.m_LabelPlayer1 = new System.Windows.Forms.Label();
            this.m_LabelPlayer2 = new System.Windows.Forms.Label();
            this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_TextBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_LabelRows = new System.Windows.Forms.Label();
            this.m_NumercUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.m_LabelColumns = new System.Windows.Forms.Label();
            this.m_NumercUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.m_ButtonStartGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumercUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumercUpDownColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // m_LabelPlayers
            // 
            this.m_LabelPlayers.AutoSize = true;
            this.m_LabelPlayers.Location = new System.Drawing.Point(21, 24);
            this.m_LabelPlayers.Name = "m_LabelPlayers";
            this.m_LabelPlayers.Size = new System.Drawing.Size(59, 17);
            this.m_LabelPlayers.TabIndex = 0;
            this.m_LabelPlayers.Text = "Players:";
            // 
            // m_LabelPlayer1
            // 
            this.m_LabelPlayer1.AutoSize = true;
            this.m_LabelPlayer1.Location = new System.Drawing.Point(32, 54);
            this.m_LabelPlayer1.Name = "m_LabelPlayer1";
            this.m_LabelPlayer1.Size = new System.Drawing.Size(64, 17);
            this.m_LabelPlayer1.TabIndex = 1;
            this.m_LabelPlayer1.Text = "Player 1:";
            // 
            // m_LabelPlayer2
            // 
            this.m_LabelPlayer2.AutoSize = true;
            this.m_LabelPlayer2.Location = new System.Drawing.Point(59, 88);
            this.m_LabelPlayer2.Name = "m_LabelPlayer2";
            this.m_LabelPlayer2.Size = new System.Drawing.Size(64, 17);
            this.m_LabelPlayer2.TabIndex = 4;
            this.m_LabelPlayer2.Text = "Player 2:";
            // 
            // m_CheckBoxPlayer2
            // 
            this.m_CheckBoxPlayer2.AutoSize = true;
            this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(35, 88);
            this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(18, 17);
            this.m_CheckBoxPlayer2.TabIndex = 3;
            this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.m_CheckBoxPlayer2_CheckedChanged);
            // 
            // m_TextBoxPlayer1Name
            // 
            this.m_TextBoxPlayer1Name.Location = new System.Drawing.Point(143, 54);
            this.m_TextBoxPlayer1Name.Name = "m_TextBoxPlayer1Name";
            this.m_TextBoxPlayer1Name.Size = new System.Drawing.Size(120, 22);
            this.m_TextBoxPlayer1Name.TabIndex = 2;
            // 
            // m_TextBoxPlayer2Name
            // 
            this.m_TextBoxPlayer2Name.Enabled = false;
            this.m_TextBoxPlayer2Name.Location = new System.Drawing.Point(143, 85);
            this.m_TextBoxPlayer2Name.Name = "m_TextBoxPlayer2Name";
            this.m_TextBoxPlayer2Name.Size = new System.Drawing.Size(120, 22);
            this.m_TextBoxPlayer2Name.TabIndex = 5;
            this.m_TextBoxPlayer2Name.Text = "[Computer]";
            // 
            // m_LabelBoardSize
            // 
            this.m_LabelBoardSize.AutoSize = true;
            this.m_LabelBoardSize.Location = new System.Drawing.Point(21, 125);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(77, 17);
            this.m_LabelBoardSize.TabIndex = 6;
            this.m_LabelBoardSize.Text = "Board Size";
            // 
            // m_LabelRows
            // 
            this.m_LabelRows.AutoSize = true;
            this.m_LabelRows.Location = new System.Drawing.Point(32, 158);
            this.m_LabelRows.Name = "m_LabelRows";
            this.m_LabelRows.Size = new System.Drawing.Size(46, 17);
            this.m_LabelRows.TabIndex = 7;
            this.m_LabelRows.Text = "Rows:";
            // 
            // m_NumercUpDownRows
            // 
            this.m_NumercUpDownRows.Location = new System.Drawing.Point(84, 156);
            this.m_NumercUpDownRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.m_NumercUpDownRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_NumercUpDownRows.Name = "m_NumercUpDownRows";
            this.m_NumercUpDownRows.Size = new System.Drawing.Size(43, 22);
            this.m_NumercUpDownRows.TabIndex = 8;
            this.m_NumercUpDownRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // m_LabelColumns
            // 
            this.m_LabelColumns.AutoSize = true;
            this.m_LabelColumns.Location = new System.Drawing.Point(155, 158);
            this.m_LabelColumns.Name = "m_LabelColumns";
            this.m_LabelColumns.Size = new System.Drawing.Size(39, 17);
            this.m_LabelColumns.TabIndex = 9;
            this.m_LabelColumns.Text = "Cols:";
            // 
            // m_NumercUpDownColumns
            // 
            this.m_NumercUpDownColumns.Location = new System.Drawing.Point(200, 156);
            this.m_NumercUpDownColumns.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.m_NumercUpDownColumns.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_NumercUpDownColumns.Name = "m_NumercUpDownColumns";
            this.m_NumercUpDownColumns.Size = new System.Drawing.Size(49, 22);
            this.m_NumercUpDownColumns.TabIndex = 10;
            this.m_NumercUpDownColumns.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // m_ButtonStartGame
            // 
            this.m_ButtonStartGame.Location = new System.Drawing.Point(35, 211);
            this.m_ButtonStartGame.Name = "m_ButtonStartGame";
            this.m_ButtonStartGame.Size = new System.Drawing.Size(214, 27);
            this.m_ButtonStartGame.TabIndex = 11;
            this.m_ButtonStartGame.Text = "Start";
            this.m_ButtonStartGame.UseVisualStyleBackColor = true;
            this.m_ButtonStartGame.Click += new System.EventHandler(this.m_ButtonStartGame_Click);
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 294);
            this.Controls.Add(this.m_ButtonStartGame);
            this.Controls.Add(this.m_NumercUpDownColumns);
            this.Controls.Add(this.m_LabelColumns);
            this.Controls.Add(this.m_NumercUpDownRows);
            this.Controls.Add(this.m_LabelRows);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_TextBoxPlayer2Name);
            this.Controls.Add(this.m_TextBoxPlayer1Name);
            this.Controls.Add(this.m_CheckBoxPlayer2);
            this.Controls.Add(this.m_LabelPlayer2);
            this.Controls.Add(this.m_LabelPlayer1);
            this.Controls.Add(this.m_LabelPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGameSettings";
            ((System.ComponentModel.ISupportInitialize)(this.m_NumercUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumercUpDownColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_LabelPlayers;
        private System.Windows.Forms.Label m_LabelPlayer1;
        private System.Windows.Forms.Label m_LabelPlayer2;
        private System.Windows.Forms.CheckBox m_CheckBoxPlayer2;
        private System.Windows.Forms.TextBox m_TextBoxPlayer1Name;
        private System.Windows.Forms.TextBox m_TextBoxPlayer2Name;
        private System.Windows.Forms.Label m_LabelBoardSize;
        private System.Windows.Forms.Label m_LabelRows;
        private System.Windows.Forms.NumericUpDown m_NumercUpDownRows;
        private System.Windows.Forms.Label m_LabelColumns;
        private System.Windows.Forms.NumericUpDown m_NumercUpDownColumns;
        private System.Windows.Forms.Button m_ButtonStartGame;
    }
}