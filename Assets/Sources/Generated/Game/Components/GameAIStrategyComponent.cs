//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AIStrategyComponent aIStrategy { get { return (AIStrategyComponent)GetComponent(GameComponentsLookup.AIStrategy); } }
    public bool hasAIStrategy { get { return HasComponent(GameComponentsLookup.AIStrategy); } }

    public void AddAIStrategy(AIStrategyEnum newValue) {
        var index = GameComponentsLookup.AIStrategy;
        var component = CreateComponent<AIStrategyComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAIStrategy(AIStrategyEnum newValue) {
        var index = GameComponentsLookup.AIStrategy;
        var component = CreateComponent<AIStrategyComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAIStrategy() {
        RemoveComponent(GameComponentsLookup.AIStrategy);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAIStrategy;

    public static Entitas.IMatcher<GameEntity> AIStrategy {
        get {
            if (_matcherAIStrategy == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AIStrategy);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAIStrategy = matcher;
            }

            return _matcherAIStrategy;
        }
    }
}