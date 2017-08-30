﻿namespace Assets.Sources.Helpers.Items
{
	using System.Text;
	using Features.Items;
	using Features.Stats.Components;

	public class Weapon : Equipment
	{
		public override InventorySlot Slot
		{
			get
			{
				return InventorySlot.Weapon;
			}
		}

		public int Attack { get; private set; }

		public Weapon(ItemName name, string prefab, int attack)
		{
			Name = name;
			Prefab = prefab;
			Attack = attack;
		}

		public override string ToInventoryString()
		{
			var sb = new StringBuilder();

			sb.AppendFormat(NiceName());
			sb.AppendLine();
			sb.AppendFormat("Damage: {0}", Attack);

			return sb.ToString();
		}

		public override void ModifyStats(StatsComponent stats)
		{
			stats.Attack += Attack;
		}
	}
}