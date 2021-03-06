//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public NetworkTrackedComponent networkTracked { get { return (NetworkTrackedComponent)GetComponent(GameComponentsLookup.NetworkTracked); } }
    public bool hasNetworkTracked { get { return HasComponent(GameComponentsLookup.NetworkTracked); } }

    public void AddNetworkTracked(EntityReference newReference) {
        var index = GameComponentsLookup.NetworkTracked;
        var component = CreateComponent<NetworkTrackedComponent>(index);
        component.Reference = newReference;
        AddComponent(index, component);
    }

    public void ReplaceNetworkTracked(EntityReference newReference) {
        var index = GameComponentsLookup.NetworkTracked;
        var component = CreateComponent<NetworkTrackedComponent>(index);
        component.Reference = newReference;
        ReplaceComponent(index, component);
    }

    public void RemoveNetworkTracked() {
        RemoveComponent(GameComponentsLookup.NetworkTracked);
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

    static Entitas.IMatcher<GameEntity> _matcherNetworkTracked;

    public static Entitas.IMatcher<GameEntity> NetworkTracked {
        get {
            if (_matcherNetworkTracked == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NetworkTracked);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNetworkTracked = matcher;
            }

            return _matcherNetworkTracked;
        }
    }
}
