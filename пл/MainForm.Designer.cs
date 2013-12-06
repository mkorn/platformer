/*
 * Created by SharpDevelop.
 * User: 1
 * Date: 08.10.2013
 * Time: 16:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace пл
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			//this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			/*this.button1.Location = new System.Drawing.Point(1, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(36, 27);
			this.button1.TabIndex = 1;
			this.button1.Text = "<";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1KeyDown);
			*/
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1000, 700);
			this.panel2.TabIndex = 3;
			this.panel2.Visible = true;

			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1000, 700);
			this.panel3.TabIndex = 3;
			this.panel3.Visible = false;

			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Location = new System.Drawing.Point(40, 600);
			this.panel1.Name = "panel1";
			//this.panel1.BringToFront();
			this.panel1.Size = new System.Drawing.Size(40, 50);
			this.panel1.TabIndex = 3;

			this.label1 = new System.Windows.Forms.Label();
			this.label1.Text="0";
			this.label1.Location = new System.Drawing.Point(90, 60);

			this.label2 = new System.Windows.Forms.Label();
			this.label2.Text="Game over :(\nNew game - 1\nQuit - 2";
			this.label2.Location = new System.Drawing.Point(90, 60);
			this.label2.Size = new System.Drawing.Size(150, 100);

			// MainForm
			//this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(1000, 700);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			//this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "пл";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyUp);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		//private System.Windows.Forms.Button button1;
	}
}
