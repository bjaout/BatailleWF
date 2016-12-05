namespace BatailleWF
{
    partial class BatailleWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblJ1Name = new System.Windows.Forms.Label();
            this.lblJ2Name = new System.Windows.Forms.Label();
            this.lblJ2NbCard = new System.Windows.Forms.Label();
            this.lblJ1NbCard = new System.Windows.Forms.Label();
            this.txtbJ1Name = new System.Windows.Forms.TextBox();
            this.txtbJ2Name = new System.Windows.Forms.TextBox();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pbJ2 = new System.Windows.Forms.PictureBox();
            this.pbJ1 = new System.Windows.Forms.PictureBox();
            this.gridLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLayout
            // 
            this.gridLayout.ColumnCount = 3;
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.gridLayout.Controls.Add(this.lblJ1Name, 0, 0);
            this.gridLayout.Controls.Add(this.lblJ2Name, 2, 4);
            this.gridLayout.Controls.Add(this.lblJ2NbCard, 2, 6);
            this.gridLayout.Controls.Add(this.lblJ1NbCard, 0, 2);
            this.gridLayout.Controls.Add(this.txtbJ1Name, 0, 1);
            this.gridLayout.Controls.Add(this.txtbJ2Name, 2, 5);
            this.gridLayout.Controls.Add(this.rtbDisplay, 1, 1);
            this.gridLayout.Controls.Add(this.btnPlay, 2, 0);
            this.gridLayout.Controls.Add(this.pbJ2, 2, 3);
            this.gridLayout.Controls.Add(this.pbJ1, 0, 3);
            this.gridLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLayout.Location = new System.Drawing.Point(0, 0);
            this.gridLayout.Name = "gridLayout";
            this.gridLayout.RowCount = 7;
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.gridLayout.Size = new System.Drawing.Size(1063, 460);
            this.gridLayout.TabIndex = 0;
            // 
            // lblJ1Name
            // 
            this.lblJ1Name.AutoSize = true;
            this.lblJ1Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJ1Name.Location = new System.Drawing.Point(3, 0);
            this.lblJ1Name.Name = "lblJ1Name";
            this.lblJ1Name.Size = new System.Drawing.Size(194, 25);
            this.lblJ1Name.TabIndex = 0;
            this.lblJ1Name.Text = "Name";
            this.lblJ1Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblJ2Name
            // 
            this.lblJ2Name.AutoSize = true;
            this.lblJ2Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJ2Name.Location = new System.Drawing.Point(866, 379);
            this.lblJ2Name.Name = "lblJ2Name";
            this.lblJ2Name.Size = new System.Drawing.Size(194, 25);
            this.lblJ2Name.TabIndex = 1;
            this.lblJ2Name.Text = "Name";
            this.lblJ2Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblJ2NbCard
            // 
            this.lblJ2NbCard.AutoSize = true;
            this.lblJ2NbCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJ2NbCard.Location = new System.Drawing.Point(866, 435);
            this.lblJ2NbCard.Name = "lblJ2NbCard";
            this.lblJ2NbCard.Size = new System.Drawing.Size(194, 25);
            this.lblJ2NbCard.TabIndex = 2;
            this.lblJ2NbCard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblJ1NbCard
            // 
            this.lblJ1NbCard.AutoSize = true;
            this.lblJ1NbCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJ1NbCard.Location = new System.Drawing.Point(3, 56);
            this.lblJ1NbCard.Name = "lblJ1NbCard";
            this.lblJ1NbCard.Size = new System.Drawing.Size(194, 25);
            this.lblJ1NbCard.TabIndex = 3;
            this.lblJ1NbCard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtbJ1Name
            // 
            this.txtbJ1Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbJ1Name.Location = new System.Drawing.Point(3, 28);
            this.txtbJ1Name.Name = "txtbJ1Name";
            this.txtbJ1Name.Size = new System.Drawing.Size(194, 26);
            this.txtbJ1Name.TabIndex = 4;
            this.txtbJ1Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtbJ2Name
            // 
            this.txtbJ2Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbJ2Name.Location = new System.Drawing.Point(866, 407);
            this.txtbJ2Name.Name = "txtbJ2Name";
            this.txtbJ2Name.Size = new System.Drawing.Size(194, 26);
            this.txtbJ2Name.TabIndex = 5;
            this.txtbJ2Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDisplay.Location = new System.Drawing.Point(203, 28);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.gridLayout.SetRowSpan(this.rtbDisplay, 5);
            this.rtbDisplay.Size = new System.Drawing.Size(657, 404);
            this.rtbDisplay.TabIndex = 6;
            this.rtbDisplay.TabStop = false;
            this.rtbDisplay.Text = "";
            // 
            // btnPlay
            // 
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlay.Location = new System.Drawing.Point(866, 3);
            this.btnPlay.Name = "btnPlay";
            this.gridLayout.SetRowSpan(this.btnPlay, 3);
            this.btnPlay.Size = new System.Drawing.Size(194, 75);
            this.btnPlay.TabIndex = 7;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pbJ2
            // 
            this.pbJ2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbJ2.Location = new System.Drawing.Point(866, 84);
            this.pbJ2.Name = "pbJ2";
            this.pbJ2.Size = new System.Drawing.Size(194, 292);
            this.pbJ2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbJ2.TabIndex = 8;
            this.pbJ2.TabStop = false;
            // 
            // pbJ1
            // 
            this.pbJ1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbJ1.Location = new System.Drawing.Point(3, 84);
            this.pbJ1.Name = "pbJ1";
            this.pbJ1.Size = new System.Drawing.Size(194, 292);
            this.pbJ1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbJ1.TabIndex = 9;
            this.pbJ1.TabStop = false;
            // 
            // BatailleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 460);
            this.Controls.Add(this.gridLayout);
            this.Name = "BatailleWindow";
            this.Text = "Bataille";
            this.gridLayout.ResumeLayout(false);
            this.gridLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel gridLayout;
        private System.Windows.Forms.Label lblJ1Name;
        private System.Windows.Forms.Label lblJ2Name;
        private System.Windows.Forms.Label lblJ2NbCard;
        private System.Windows.Forms.Label lblJ1NbCard;
        private System.Windows.Forms.TextBox txtbJ1Name;
        private System.Windows.Forms.TextBox txtbJ2Name;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.PictureBox pbJ2;
        private System.Windows.Forms.PictureBox pbJ1;
    }
}

