//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Assets.Sources.Features.Stats.Components.DeadComponent deadComponent = new Assets.Sources.Features.Stats.Components.DeadComponent();

    public bool isDead {
        get { return HasComponent(GameComponentsLookup.Dead); }
        set {
            if (value != isDead) {
                if (value) {
                    AddComponent(GameComponentsLookup.Dead, deadComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.Dead);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherDead;

    public static Entitas.IMatcher<GameEntity> Dead {
        get {
            if (_matcherDead == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Dead);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDead = matcher;
            }

            return _matcherDead;
        }
    }
}
