﻿namespace Assets.Sources.Features.Lights.Systems
{
	using System.Collections.Generic;
	using Entitas;
	using Extensions;
	using Helpers;
	using Helpers.Map;
	using Helpers.SystemDependencies.Attributes;
	using Helpers.SystemDependencies.Phases;
	using UnityEngine;

	[ExecutePhase(ExecutePhase.ReactToComponents)]
	public class SetLightsSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly GameContext gameContext;
		private readonly IGroup<GameEntity> inLightGroup;
		private readonly IGroup<GameEntity> isLightGroup;
		private EntityMap map;

		public SetLightsSystem(Contexts contexts) : base(contexts.game)
		{
			gameContext = contexts.game;
			inLightGroup = gameContext.GetGroup(GameMatcher.InLight);
			isLightGroup = gameContext.GetGroup(GameMatcher.Light);
		}

		public void Initialize()
		{
			map = gameContext.GetService<EntityMap>();
		}

		protected override void Execute(List<GameEntity> entities)
		{
			// TODO: Should be optimized later
			foreach (var le in inLightGroup.GetEntities())
			{
				le.RemoveInLight();
			}

			foreach (var entity in isLightGroup.GetEntities())
			{
				if (entity.hasLight)
				{
					EditNearbyLights(entity);
				}
				else
				{
					var floor = map.TileHasAny(entity.position.value, e => e.isFloor);

					if (entity.hasInLight)
					{
						entity.ReplaceInLight(floor.inLight.Value);
					}
					else
					{
						entity.AddInLight(floor.inLight.Value);
					}
				}
			}
		}

		protected override bool Filter(GameEntity entity)
		{
			return true;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Position.Added(), GameMatcher.Light.Added(), GameMatcher.View.Added());
		}

		private void EditNearbyLights(GameEntity entity)
		{
			var pos = entity.position.value;
			var entitiesToChange = map.GetRhombWithoutCorners(pos, entity.light.Radius);

			foreach (var le in entitiesToChange)
			{
				var distance = IntVector2.MaxDistance(pos, le.position.value);
				if (distance == 0) distance = 1;
				var newVal = 100 - distance * 10;
            
				if (le.hasInLight)
				{
					if (le.inLight.Value < newVal)
					{
						le.inLight.Value = newVal;
					}
				} else
				{
					le.AddInLight(newVal);
				}
			}
		}
	}
}