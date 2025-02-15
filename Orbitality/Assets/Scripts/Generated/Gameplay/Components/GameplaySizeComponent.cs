//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public SizeComponent size { get { return (SizeComponent)GetComponent(GameplayComponentsLookup.Size); } }
    public bool hasSize { get { return HasComponent(GameplayComponentsLookup.Size); } }

    public void AddSize(float newX, float newY, float newZ) {
        var index = GameplayComponentsLookup.Size;
        var component = (SizeComponent)CreateComponent(index, typeof(SizeComponent));
        component.X = newX;
        component.Y = newY;
        component.Z = newZ;
        AddComponent(index, component);
    }

    public void ReplaceSize(float newX, float newY, float newZ) {
        var index = GameplayComponentsLookup.Size;
        var component = (SizeComponent)CreateComponent(index, typeof(SizeComponent));
        component.X = newX;
        component.Y = newY;
        component.Z = newZ;
        ReplaceComponent(index, component);
    }

    public void RemoveSize() {
        RemoveComponent(GameplayComponentsLookup.Size);
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

    static Entitas.IMatcher<GameplayEntity> _matcherSize;

    public static Entitas.IMatcher<GameplayEntity> Size {
        get {
            if (_matcherSize == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.Size);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherSize = matcher;
            }

            return _matcherSize;
        }
    }
}
