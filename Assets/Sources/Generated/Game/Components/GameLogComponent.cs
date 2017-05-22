//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LogComponent log { get { return (LogComponent)GetComponent(GameComponentsLookup.Log); } }
    public bool hasLog { get { return HasComponent(GameComponentsLookup.Log); } }

    public void AddLog(System.Collections.Generic.Queue<string> newQueue, int newMaxSize) {
        var index = GameComponentsLookup.Log;
        var component = CreateComponent<LogComponent>(index);
        component.queue = newQueue;
        component.maxSize = newMaxSize;
        AddComponent(index, component);
    }

    public void ReplaceLog(System.Collections.Generic.Queue<string> newQueue, int newMaxSize) {
        var index = GameComponentsLookup.Log;
        var component = CreateComponent<LogComponent>(index);
        component.queue = newQueue;
        component.maxSize = newMaxSize;
        ReplaceComponent(index, component);
    }

    public void RemoveLog() {
        RemoveComponent(GameComponentsLookup.Log);
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

    static Entitas.IMatcher<GameEntity> _matcherLog;

    public static Entitas.IMatcher<GameEntity> Log {
        get {
            if (_matcherLog == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Log);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLog = matcher;
            }

            return _matcherLog;
        }
    }
}