﻿namespace Assets.Sources.Extensions
{
	using System.Collections.Generic;
	using Features.Config;
	using Features.Items;
	using Helpers;
	using Helpers.Items;
	using Helpers.Monsters;
	using Helpers.Networking;

	public static class GameContextExtensions
	{
		public static GameEntity CreateWall(this GameContext context, IntVector2 pos, string prefab)
		{
			var entity = context.CreateEntity();

			entity.isMapTile = true;
			entity.isSolid = true;
			entity.isWall = true;

			entity.AddPosition(pos, false);
			entity.AddAsset(prefab);

			return entity;
		}

		public static GameEntity CreateFloor(this GameContext context, IntVector2 pos, string prefab)
		{
			var entity = context.CreateEntity();

			entity.isMapTile = true;
			entity.isFloor = true;

			entity.AddPosition(pos, false);
			entity.AddAsset(prefab);

			return entity;
		}

		public static GameEntity CreateTorch(this GameContext context, IntVector2 pos)
		{
			var entity = context.CreateEntity();

			entity.isSolid = true;

			entity.AddPosition(pos, false);
			entity.AddAsset(Prefabs.Torch);
			entity.AddLight(6);

			return entity;
		}

		public static GameEntity CreatePlayer(this GameContext context, IntVector2 pos, Player player)
		{
			var entity = context.CreateEntity();
		
			entity.AddPlayer(player.Id);
			entity.AddPosition(pos, false);
			entity.isTurnBased = true;
			entity.isInit = true;
			entity.isSolid = true;
			entity.AddAsset(Prefabs.BodyWhite);
			entity.AddStats(100, 30, 100, 10, 100, 5);
			entity.AddHealth(100);
			entity.isWolfAI = true;
			// entity.isAI = true;
			entity.AddName(player.Name);
			entity.AddRevealAround(5);
			// entity.AddLight(5);
			entity.isShouldAct = true;
			entity.AddInventory(new Dictionary<InventorySlot, InventoryItem>());
			entity.AddNetworkTracked(null);

			return entity;
		}

		public static GameEntity CreateMonster(this GameContext context, IntVector2 pos, MonsterType type, EntityReference reference, int lootSeed)
		{
			var monsters = context.GetService<MonsterDatabase>();
			var config = monsters.GetItem(type);

			var entity = context.CreateEntity();

			entity.AddPosition(pos, false);
			entity.isTurnBased = true;
			entity.isInit = true;
			entity.isSolid = true;
			entity.isAI = true;
			entity.isShouldAct = true;
			entity.AddNetworkTracked(reference);

			entity.AddAsset(config.Prefab);
			entity.AddStats(config.Health, config.Attack, config.AttackSpeed, config.Defense, config.MovementSpeed, config.CriticalChance);
			entity.AddHealth(config.Health);
			entity.isSheepAI = config.Sheep;
			entity.isChest = config.Chest;
			entity.isAttackable = config.IsAttackable;
			entity.isTwoFace = config.IsTwoFace;

			if (config.LootGroup.HasValue)
			{
				entity.AddLoot(lootSeed, config.LootGroup.Value);
			}

			EntityDatabase.Instance.AddEntity(reference.Id, entity);

			return entity;
		}

		public static GameEntity CreateItem(this GameContext context, IItem item, IntVector2 pos)
		{
			var entity = context.CreateEntity();

			entity.AddPosition(pos, false);
			entity.AddItem(item);
			entity.isInit = true;
			entity.AddAsset(item.Prefab);

			return entity;
		}

		public static T GetService<T>(this GameContext context)
		{
			return context.servicesHandler.Services.GetItem<T>();
		}

		public static void AddService<T>(this GameContext context, T service)
		{
			context.servicesHandler.Services.AddItem(service);
		}

		public static GameEntity CreateItem(this GameContext context, ItemName name, IntVector2 pos)
		{
			var items = context.GetService<ItemDatabase>();
			var item = items.GetItem(name);
			return context.CreateItem(item, pos);
		}

		public static GameEntity GetCurrentPlayer(this GameContext context)
		{
			return context.currentPlayer.Entity.GetEntity();
		}

		public static Config GetConfig(this GameContext context)
		{
			return context.GetService<Config>();
		}
	}
}