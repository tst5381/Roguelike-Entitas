﻿namespace Assets.Sources.Features.Items.Systems
{
	using Entitas;
	using Helpers.SystemDependencies.Attributes;
	using Helpers.SystemDependencies.Phases;
	using Scripts;
	using UnityEngine;

	[ExecutePhase(ExecutePhase.Input)]
	public class InventoryScreenInputSystem : IExecuteSystem, IInitializeSystem
	{
		private readonly GameContext gameContext;
		private InventoryController inventoryController;
		private bool inventoryOpened;

		public InventoryScreenInputSystem(Contexts contexts)
		{
			gameContext = contexts.game;
		}

		public void Initialize()
		{
			inventoryController = gameContext.GetService<InventoryController>();
		}

		public void Execute()
		{
			if (Input.GetKeyDown(KeyCode.I))
			{
				inventoryOpened = !inventoryOpened;

				if (inventoryOpened)
				{
					inventoryController.SetHealth(gameContext.GetCurrentPlayer().health.Value);
					inventoryController.Open();
				}
				else
				{
					inventoryController.Close();
				}
			}
		}
	}
}