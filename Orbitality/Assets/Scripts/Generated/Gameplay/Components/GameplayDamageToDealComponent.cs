//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public DamageToDealComponent damageToDeal { get { return (DamageToDealComponent)GetComponent(GameplayComponentsLookup.DamageToDeal); } }
    public bool hasDamageToDeal { get { return HasComponent(GameplayComponentsLookup.DamageToDeal); } }

    public void AddDamageToDeal(float newValue) {
        var index = GameplayComponentsLookup.DamageToDeal;
        var component = (DamageToDealComponent)CreateComponent(index, typeof(DamageToDealComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDamageToDeal(float newValue) {
        var index = GameplayComponentsLookup.DamageToDeal;
        var component = (DamageToDealComponent)CreateComponent(index, typeof(DamageToDealComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDamageToDeal() {
        RemoveComponent(GameplayComponentsLookup.DamageToDeal);
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

    static Entitas.IMatcher<GameplayEntity> _matcherDamageToDeal;

    public static Entitas.IMatcher<GameplayEntity> DamageToDeal {
        get {
            if (_matcherDamageToDeal == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.DamageToDeal);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherDamageToDeal = matcher;
            }

            return _matcherDamageToDeal;
        }
    }
}
