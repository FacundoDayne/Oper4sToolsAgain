﻿using System.Runtime.CompilerServices;

namespace Oper4sToolsAgain
{
	partial class Oper4sTools
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Oper4sTools));
			SuspendLayout();
			// 
			// Oper4sTools
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MaximumSize = new Size(816, 489);
			MinimumSize = new Size(816, 489);
			Name = "Oper4sTools";
			Text = "Oper4sTools";
			ResumeLayout(false);
		}

		#endregion

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				Hide(); // Hide the main form
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			e.Cancel = true; // Cancel the default close operation
			WindowState = FormWindowState.Minimized; // Minimize the form
			ShowInTaskbar = false; // Hide the form from the taskbar
			base.OnFormClosing(e);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			ShowInTaskbar = true;
			base.OnAutoSizeChanged(e);
		}

	}
}
