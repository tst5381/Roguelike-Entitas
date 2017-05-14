//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameBoardEntity { get { return GetGroup(GameMatcher.GameBoard).GetSingleEntity(); } }

    public bool isGameBoard {
        get { return gameBoardEntity != null; }
        set {
            var entity = gameBoardEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isGameBoard = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly GameBoardComponent gameBoardComponent = new GameBoardComponent();

    public bool isGameBoard {
        get { return HasComponent(GameComponentsLookup.GameBoard); }
        set {
            if (value != isGameBoard) {
                if (value) {
                    AddComponent(GameComponentsLookup.GameBoard, gameBoardComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.GameBoard);
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

    static Entitas.IMatcher<GameEntity> _matcherGameBoard;

    public static Entitas.IMatcher<GameEntity> GameBoard {
        get {
            if (_matcherGameBoard == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameBoard);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameBoard = matcher;
            }

            return _matcherGameBoard;
        }
    }
}