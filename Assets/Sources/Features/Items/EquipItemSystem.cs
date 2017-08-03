﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class EquipItemSystem : ReactiveSystem<ActionsEntity>
{
	public EquipItemSystem(Contexts contexts) : base(contexts.actions)
	{
	}

	protected override ICollector<ActionsEntity> GetTrigger(IContext<ActionsEntity> context)
	{
		return context.CreateCollector(ActionsMatcher.Action.Added());
	}

	protected override bool Filter(ActionsEntity entity)
	{
		return entity.action.Action is EquipAction || entity.action.Action is PickAndEquipAction;
	}

	protected override void Execute(List<ActionsEntity> entities)
	{
		foreach (var entity in entities)
		{
			IItem item;
			GameEntity target;

			if (entity.action.Action is EquipAction)
			{
				var action = (EquipAction)entity.action.Action;
				item = action.Item;
				target = action.Target;
			}
			else
			{
				var action = (PickAndEquipAction)entity.action.Action;
				var itemEntity = Map.Instance.GetItem(action.Position);

				if (itemEntity == null)
				{
					continue; // This should be somewhere else
				}

				itemEntity.isDestroyed = true;
				item = itemEntity.item.Item;
				target = action.Target;
			}

			// TODO: should old game object be destroyed while replacing?
			var asset = Resources.Load<GameObject>(item.Prefab);
			var go = Object.Instantiate(asset);
			var parentGo = target.view.gameObject;
			go.transform.SetParent(parentGo.transform, false);
			go.transform.SetSiblingIndex((int)item.Slot);

			var sprite = go.GetComponent<SpriteRenderer>();
			sprite.sortingLayerName = "Characters"; // TODO: should not be hardcoded

			target.SetInventoryItem(item.Slot, item); // TODO: should slot be handled this way?
		}
	}
}