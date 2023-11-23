﻿using Oper4sToolsAgain.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oper4sToolsAgain
{
	internal class miscTools
	{		
		public static void closeProgram()
		{
			Oper4sToolsFunctions.playFarewell();
			if (Program.appSettings.isDebugMode()) MessageBox.Show("The next launch of the application will run in Debug Mode", "Oper4sTools Debug Mode");
			Oper4sTools.timer.Dispose();
			Oper4sTools.notifyIcon.Dispose();
			System.Windows.Forms.Application.Exit();
		}
	}

	public class Oper4sToolsFunctions()
	{
		static SoundPlayer player;
		public static void setTimer()
		{
			int time = Int32.Parse((TimeSpan.FromMinutes(Program.appSettings.getTimeInterval()).TotalMilliseconds).ToString());
			Console.WriteLine("Timer starts");
			Oper4sTools.timer = new System.Threading.Timer(playReminder, null, time, time);
		}
		public static void playGreeting() { player = new SoundPlayer(SoundController.getSound("0")); player.PlaySync(); }

		public static void playFarewell () { player = new SoundPlayer(SoundController.getSound("1")); player.PlaySync(); }
		public static void playReminder(object state)
		{
			try
			{
				Console.WriteLine("Playing at {0}", DateTime.Now);
				player = new SoundPlayer(SoundController.getSound("2"));
				player.PlaySync();
			}
			catch (Exception e)
			{
				Console.WriteLine("Problem found in playReminder {0}",e.Message);
			}
		}
	}

	public class UserControlMethods
	{
		public static void maskChange(UserControl uc, UserControl _current)
		{
			Oper4sTools.thisForm.Controls.Remove(_current);
			_current = uc;
			Oper4sTools.thisForm.Controls.Add(_current);
			_current.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			_current.Location = new System.Drawing.Point(0, 0);
			_current.Name = "_current";
			_current.Size = new System.Drawing.Size(800, 450);
			_current.TabIndex = 0;
		}	
	}

	public class TrayIcon
	{
		public static void startTrayIcon()
		{
			Oper4sTools.contextMenuStrip = getContextMenuStrip();
			Oper4sTools.notifyIcon = getTrayIcon();
		}
		public static ContextMenuStrip getContextMenuStrip()
		{
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			contextMenuStrip.Items.Add("Welcome to Oper4's Tools", Oper4sImageTools.getImage("logo1"));
			contextMenuStrip.Items.Add("-------------------------");
			contextMenuStrip.Items.Add("Home", null, Oper4sToolsEventHandlers.homeContextMenu);
			contextMenuStrip.Items.Add("Posture Check", Oper4sImageTools.getImage("skill2"), Oper4sToolsEventHandlers.postureCheckMenu);
			contextMenuStrip.Items.Add("Try Posture Check Sound", Oper4sImageTools.getImage("skill3"), Oper4sToolsEventHandlers.tryPostureCheckMenu);
			contextMenuStrip.Items.Add("Open Debug Console at next Launch", null, Oper4sToolsEventHandlers.openDebugConsole);
			contextMenuStrip.Items.Add("Exit", null, Oper4sToolsEventHandlers.exitToolStripMenuItem);

			return contextMenuStrip;
		}

		private static NotifyIcon getTrayIcon()
		{
			NotifyIcon notifyIcon = new NotifyIcon();
			notifyIcon.Icon = Oper4sImageTools.getIcon("haxxor_icon");
			notifyIcon.Text = "Oper4's Tools";
			notifyIcon.Visible = true;
			notifyIcon.ContextMenuStrip = Oper4sTools.contextMenuStrip;
			notifyIcon.MouseClick += Oper4sToolsEventHandlers.NotifyIcon_Click;
			return notifyIcon;
		}
	}

	public class Oper4sImageTools
	{
		public static Bitmap getImage(string imageName)
		{
			Bitmap image = (Bitmap)Resources.ResourceManager.GetObject(imageName);
			return image;
		}
		public static Icon getIcon(string iconName)
		{
			Bitmap pngIcon = (Bitmap)Resources.ResourceManager.GetObject(iconName);
			IntPtr hBitmap = pngIcon.GetHicon();
			Icon icon = Icon.FromHandle(hBitmap);
			return icon;
		}
	}
}