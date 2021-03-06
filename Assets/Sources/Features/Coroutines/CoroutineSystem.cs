﻿namespace Assets.Sources.Features.Coroutines
{
	using Entitas;
	using Helpers.SystemDependencies.Attributes;
	using Helpers.SystemDependencies.Phases;

	/// <summary>
	/// Handle coroutines. Coroutines must not create or alter actions!!!
	/// </summary>
	[ExecutePhase(ExecutePhase.Input)]
	public sealed class CoroutineSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> coroutines;

		public CoroutineSystem(Contexts contexts)
		{
			coroutines = contexts.game.GetGroup(GameMatcher.Coroutine);
		}

		public void Execute()
		{
			foreach (var entity in coroutines.GetEntities())
			{
				var coroutine = entity.coroutine.Value;

				if (!coroutine.MoveNext())
				{
					if (entity.coroutine.Callback != null)
					{
						entity.coroutine.Callback(entity);
					}

					entity.RemoveCoroutine();
					// TODO: should be better
					if (entity.GetComponentIndices().Length == 0)
					{
						entity.Destroy();
					}
				}
			}
		}
	}
}