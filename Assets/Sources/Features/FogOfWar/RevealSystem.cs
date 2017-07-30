﻿using System;
using System.Collections.Generic;
using Entitas;

public sealed class RevealSystem : ReactiveSystem<GameEntity>
{
	private IGroup<GameEntity> isLightGroup;

    public RevealSystem(Contexts contexts) : base(contexts.game)
    {
	    isLightGroup = contexts.game.GetGroup(GameMatcher.RevealAround);
    }

    protected override void Execute(List<GameEntity> entities)
    {
		// This should be smarter
        foreach (var lightEntity in isLightGroup.GetEntities())
        {
            foreach (var revealEntity in Map.Instance.GetRhombWithoutCorners(lightEntity.position.value, lightEntity.revealAround.radius))
            {
                if (!revealEntity.isRevealed)
                {
                    revealEntity.isRevealed = true;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
	    return true; // entity.hasRevealAround;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position.Added());
    }
}