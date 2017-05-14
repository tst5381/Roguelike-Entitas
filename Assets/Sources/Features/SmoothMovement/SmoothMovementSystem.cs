﻿using System;
using System.Collections.Generic;
using System.Collections;
using Entitas;
using UnityEngine;

public sealed class SmoothMovementSystem : ReactiveSystem<GameEntity>
{
    GameContext context;

    public SmoothMovementSystem(Contexts contexts) : base (contexts.game)
    {
        context = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.isSmoothMovementInProgress)
            {
                continue;
            }

            entity.AddCoroutine(SmoothMovement(entity), null);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasPosition && entity.hasSmoothMovement && !entity.isInit;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SmoothMovement);
    }

    static IEnumerator SmoothMovement(GameEntity entity)
    {
        var gameObject = entity.view.gameObject;
        var transform = gameObject.transform;
        var end = entity.smoothMovement.target;
        var endVector3 = (Vector3)((Vector2)end);
        var inverseMoveTime = 1f / entity.smoothMovement.moveTime;
        var sqrRemainingDistance = (transform.position - endVector3).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector2 newPostion = Vector2.MoveTowards(transform.position, end, inverseMoveTime * Time.deltaTime);
            transform.position = newPostion;
            sqrRemainingDistance = (transform.position - endVector3).sqrMagnitude;
            yield return null;
        }

        entity.ReplacePosition(end);
        entity.isSmoothMovementInProgress = false;
        entity.isActionInProgress = false;
    }
}