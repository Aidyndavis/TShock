﻿using System.ComponentModel;
using Terraria;

namespace TerrariaServer.Hooks.Classes
{
	public class NpcSpawnEventArgs : HandledEventArgs
	{
		public NPC Npc { get; set; }
	}
}
