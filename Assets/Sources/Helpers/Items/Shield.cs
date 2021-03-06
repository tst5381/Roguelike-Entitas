﻿namespace Assets.Sources.Helpers.Items
{
	using System.Text;
	using Features.Items;
	using Features.Stats.Components;

	public class Shield : Equipment
	{
		public override InventorySlot Slot
		{
			get
			{
				return InventorySlot.Shield;
			}
		}

		public int Defense { get; private set; }

		public Shield(ItemName name, string prefab, int defense)
		{
			Name = name;
			Prefab = prefab;
			Defense = defense;
		}

		public override string ToInventoryString()
		{
			var sb = new StringBuilder();

			sb.AppendFormat(NiceName());
			sb.AppendLine();
			sb.AppendFormat("Defense: {0}", Defense);

			return sb.ToString();
		}

		public override void ModifyStats(StatsComponent stats)
		{
			stats.Defense += Defense;
		}
	}
}