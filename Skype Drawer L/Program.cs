using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKYPE4COMLib;
using LeagueSharp;
using Color = System.Drawing.Color;
using LeagueSharp.Common;
using SharpDX;
using System.Threading.Tasks;
using System.Timers;

namespace Skype_Drawer_L
{
	class Program
	{
		private static bool SkypeActive;
		public static System.Timers.Timer aTimer = new System.Timers.Timer();
		private static string Text;
		private static Menu Menu;
		static void Main(string[] args)
		{
			Skype Client = new Skype();
			Client.Attach();
			Client.MessageStatus+=Client_MessageStatus;
			CustomEvents.Game.OnGameLoad+=Game_OnGameLoad;
		}

		private static void Game_OnGameLoad(EventArgs args)
		{
			Menu = new Menu("Skype Loader", "Skype Loader", true);
			Menu.AddToMainMenu();
			Drawing.OnDraw += Drawing_OnDraw;
		}

		static void Drawing_OnDraw(EventArgs args)
		{
			if (SkypeActive)
			{
				Drawing.DrawText(0, 0, Color.Green, Text);
			}
		}


		private static void Client_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
		{
			Text = pMessage.Sender.DisplayName + " " + pMessage.Body;
			SkypeActive = true;
			aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			aTimer.Interval = 5000;
			aTimer.Enabled = true;
		}
		private static void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			SkypeActive = false;
			aTimer.Stop();
		}
	}
}
