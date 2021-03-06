﻿using Assets.Sources.Features.Items;
using Assets.Sources.Features.Stats.Components;
using Assets.Sources.Helpers.Items;

public interface IItem
{
	ItemName Name { get; }
	string Prefab { get; }
	InventorySlot Slot { get; }
	string ToInventoryString();
	void ModifyStats(StatsComponent stats);
}