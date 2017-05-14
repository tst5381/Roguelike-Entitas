//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public RectangularMapComponent rectangularMap { get { return (RectangularMapComponent)GetComponent(GameComponentsLookup.RectangularMap); } }
    public bool hasRectangularMap { get { return HasComponent(GameComponentsLookup.RectangularMap); } }

    public void AddRectangularMap(int newWidth, int newHeight) {
        var index = GameComponentsLookup.RectangularMap;
        var component = CreateComponent<RectangularMapComponent>(index);
        component.width = newWidth;
        component.height = newHeight;
        AddComponent(index, component);
    }

    public void ReplaceRectangularMap(int newWidth, int newHeight) {
        var index = GameComponentsLookup.RectangularMap;
        var component = CreateComponent<RectangularMapComponent>(index);
        component.width = newWidth;
        component.height = newHeight;
        ReplaceComponent(index, component);
    }

    public void RemoveRectangularMap() {
        RemoveComponent(GameComponentsLookup.RectangularMap);
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

    static Entitas.IMatcher<GameEntity> _matcherRectangularMap;

    public static Entitas.IMatcher<GameEntity> RectangularMap {
        get {
            if (_matcherRectangularMap == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RectangularMap);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRectangularMap = matcher;
            }

            return _matcherRectangularMap;
        }
    }
}
