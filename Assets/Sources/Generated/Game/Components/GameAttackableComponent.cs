//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Assets.Sources.Features.Combat.Components.AttackableComponent attackableComponent = new Assets.Sources.Features.Combat.Components.AttackableComponent();

    public bool isAttackable {
        get { return HasComponent(GameComponentsLookup.Attackable); }
        set {
            if (value != isAttackable) {
                if (value) {
                    AddComponent(GameComponentsLookup.Attackable, attackableComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.Attackable);
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

    static Entitas.IMatcher<GameEntity> _matcherAttackable;

    public static Entitas.IMatcher<GameEntity> Attackable {
        get {
            if (_matcherAttackable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Attackable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackable = matcher;
            }

            return _matcherAttackable;
        }
    }
}
