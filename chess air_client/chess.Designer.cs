using System.Drawing;

namespace chessair_client
{
    partial class Chess
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
            //base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chess));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.oponent_nickname = new System.Windows.Forms.Label();
            this.my_nickname = new System.Windows.Forms.Label();
            this.play_friend = new System.Windows.Forms.Button();
            this.outcome_tx = new System.Windows.Forms.Label();
            this.playai = new System.Windows.Forms.Button();
            this.historical_games = new System.Windows.Forms.FlowLayoutPanel();
            this.more_bt = new System.Windows.Forms.Button();
            this.less_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bpawn.png");
            this.imageList1.Images.SetKeyName(1, "bknight.png");
            this.imageList1.Images.SetKeyName(2, "bbishop.png");
            this.imageList1.Images.SetKeyName(3, "brook.png");
            this.imageList1.Images.SetKeyName(4, "bqueen.png");
            this.imageList1.Images.SetKeyName(5, "bking.png");
            this.imageList1.Images.SetKeyName(6, "wpawn.png");
            this.imageList1.Images.SetKeyName(7, "wknight.png");
            this.imageList1.Images.SetKeyName(8, "wbishop.png");
            this.imageList1.Images.SetKeyName(9, "wrook.png");
            this.imageList1.Images.SetKeyName(10, "wqueen.png");
            this.imageList1.Images.SetKeyName(11, "wking.png");
            this.imageList1.Images.SetKeyName(12, "reddot.png");
            // 
            // oponent_nickname
            // 
            this.oponent_nickname.AutoSize = true;
            this.oponent_nickname.BackColor = System.Drawing.Color.Transparent;
            this.oponent_nickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.oponent_nickname.ForeColor = System.Drawing.Color.DodgerBlue;
            this.oponent_nickname.Location = new System.Drawing.Point(3, 3);
            this.oponent_nickname.Name = "oponent_nickname";
            this.oponent_nickname.Size = new System.Drawing.Size(83, 25);
            this.oponent_nickname.TabIndex = 0;
            this.oponent_nickname.Text = "oponent";
            this.oponent_nickname.Visible = false;
            // 
            // my_nickname
            // 
            this.my_nickname.AutoSize = true;
            this.my_nickname.BackColor = System.Drawing.Color.Transparent;
            this.my_nickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.my_nickname.ForeColor = System.Drawing.Color.DodgerBlue;
            this.my_nickname.Location = new System.Drawing.Point(3, 675);
            this.my_nickname.Name = "my_nickname";
            this.my_nickname.Size = new System.Drawing.Size(39, 25);
            this.my_nickname.TabIndex = 1;
            this.my_nickname.Text = "me";
            this.my_nickname.Visible = false;
            // 
            // play_friend
            // 
            this.play_friend.AutoEllipsis = true;
            this.play_friend.BackColor = System.Drawing.Color.ForestGreen;
            this.play_friend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.play_friend.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.play_friend.Location = new System.Drawing.Point(8, 94);
            this.play_friend.Name = "play_friend";
            this.play_friend.Size = new System.Drawing.Size(262, 120);
            this.play_friend.TabIndex = 2;
            this.play_friend.Text = "play vs friend";
            this.play_friend.UseVisualStyleBackColor = false;
            this.play_friend.Click += new System.EventHandler(this.Play_Click);
            // 
            // outcome_tx
            // 
            this.outcome_tx.AutoSize = true;
            this.outcome_tx.BackColor = System.Drawing.Color.Transparent;
            this.outcome_tx.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Underline);
            this.outcome_tx.ForeColor = System.Drawing.Color.Green;
            this.outcome_tx.Location = new System.Drawing.Point(28, 55);
            this.outcome_tx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.outcome_tx.Name = "outcome_tx";
            this.outcome_tx.Size = new System.Drawing.Size(0, 31);
            this.outcome_tx.TabIndex = 3;
            // 
            // playai
            // 
            this.playai.AutoEllipsis = true;
            this.playai.BackColor = System.Drawing.Color.ForestGreen;
            this.playai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playai.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.playai.Location = new System.Drawing.Point(8, 223);
            this.playai.Name = "playai";
            this.playai.Size = new System.Drawing.Size(262, 120);
            this.playai.TabIndex = 4;
            this.playai.Text = "play vs AI";
            this.playai.UseVisualStyleBackColor = false;
            this.playai.Click += new System.EventHandler(this.Playai_Click);
            // 
            // historical_games
            // 
            this.historical_games.AutoScroll = true;
            this.historical_games.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.historical_games.Location = new System.Drawing.Point(12, 358);
            this.historical_games.Name = "historical_games";
            this.historical_games.Size = new System.Drawing.Size(315, 290);
            this.historical_games.TabIndex = 5;
            // 
            // more_bt
            // 
            this.more_bt.BackColor = System.Drawing.Color.ForestGreen;
            this.more_bt.Location = new System.Drawing.Point(182, 654);
            this.more_bt.Name = "more_bt";
            this.more_bt.Size = new System.Drawing.Size(145, 29);
            this.more_bt.TabIndex = 7;
            this.more_bt.Text = "more";
            this.more_bt.UseVisualStyleBackColor = false;
            this.more_bt.Click += new System.EventHandler(this.more_bt_Click);
            // 
            // less_bt
            // 
            this.less_bt.BackColor = System.Drawing.Color.ForestGreen;
            this.less_bt.Location = new System.Drawing.Point(12, 654);
            this.less_bt.Name = "less_bt";
            this.less_bt.Size = new System.Drawing.Size(164, 29);
            this.less_bt.TabIndex = 8;
            this.less_bt.Text = "less";
            this.less_bt.UseVisualStyleBackColor = false;
            this.less_bt.Click += new System.EventHandler(this.less_bt_Click);
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1236, 709);
            this.Controls.Add(this.less_bt);
            this.Controls.Add(this.more_bt);
            this.Controls.Add(this.historical_games);
            this.Controls.Add(this.playai);
            this.Controls.Add(this.outcome_tx);
            this.Controls.Add(this.play_friend);
            this.Controls.Add(this.my_nickname);
            this.Controls.Add(this.oponent_nickname);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Chess";
            this.Text = "chessair";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label oponent_nickname;
        private System.Windows.Forms.Label my_nickname;
        private System.Windows.Forms.Button play_friend;
        private System.Windows.Forms.Label outcome_tx;
        private System.Windows.Forms.Button playai;
        private System.Windows.Forms.FlowLayoutPanel historical_games;
        private System.Windows.Forms.Button more_bt;
        private System.Windows.Forms.Button less_bt;
    }
}

