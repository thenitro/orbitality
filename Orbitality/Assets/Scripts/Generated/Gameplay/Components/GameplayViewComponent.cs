//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public ViewComponent view { get { return (ViewComponent)GetComponent(GameplayComponentsLookup.View); } }
    public bool hasView { get { return HasComponent(GameplayComponentsLookup.View); } }

    public void AddView(UnityEngine.GameObject newView) {
        var index = GameplayComponentsLookup.View;
        var component = (ViewComponent)CreateComponent(index, typeof(ViewComponent));
        component.View = newView;
        AddComponent(index, component);
    }

    public void ReplaceView(UnityEngine.GameObject newView) {
        var index = GameplayComponentsLookup.View;
        var component = (ViewComponent)CreateComponent(index, typeof(ViewComponent));
        component.View = newView;
        ReplaceComponent(index, component);
    }

    public void RemoveView() {
        RemoveComponent(GameplayComponentsLookup.View);
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
public sealed partial class GameplayMatcher {

    static Entitas.IMatcher<GameplayEntity> _matcherView;

    public static Entitas.IMatcher<GameplayEntity> View {
        get {
            if (_matcherView == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.View);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherView = matcher;
            }

            return _matcherView;
        }
    }
}
