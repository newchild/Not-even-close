using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKYPE4COMLib;
using LeagueSharp;
using System.Windows.Forms;
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
		private static LeagueSharp.Common.Menu Menu;
		static void Main(string[] args)
		{
			
			CustomEvents.Game.OnGameLoad+=Game_OnGameLoad;
		}

		private static void Game_OnGameLoad(EventArgs args)
		{
			Menu = new LeagueSharp.Common.Menu("Skype Loader", "Skype Loader", true);
			Menu.AddToMainMenu();
			Skype Client = new Skype();
			Client.Attach();
			Client.MessageStatus +=
			  new _ISkypeEvents_MessageStatusEventHandler(Client_MessageStatus);
		}


		private static void Client_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
		{
			MessageBox.Show("Received");

			Text = pMessage.Sender.DisplayName + " " + pMessage.Body;
			Game.PrintChat(Text);
		}
	}
}
