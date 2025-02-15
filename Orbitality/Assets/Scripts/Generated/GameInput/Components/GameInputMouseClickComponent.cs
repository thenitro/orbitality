//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameInputEntity {

    static readonly MouseClickComponent mouseClickComponent = new MouseClickComponent();

    public bool isMouseClick {
        get { return HasComponent(GameInputComponentsLookup.MouseClick); }
        set {
            if (value != isMouseClick) {
                var index = GameInputComponentsLookup.MouseClick;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : mouseClickComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameInputMatcher {

    static Entitas.IMatcher<GameInputEntity> _matcherMouseClick;

    public static Entitas.IMatcher<GameInputEntity> MouseClick {
        get {
            if (_matcherMouseClick == null) {
                var matcher = (Entitas.Matcher<GameInputEntity>)Entitas.Matcher<GameInputEntity>.AllOf(GameInputComponentsLookup.MouseClick);
                matcher.componentNames = GameInputComponentsLookup.componentNames;
                _matcherMouseClick = matcher;
            }

            return _matcherMouseClick;
        }
    }
}
