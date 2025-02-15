//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public HealthComponent health { get { return (HealthComponent)GetComponent(GameplayComponentsLookup.Health); } }
    public bool hasHealth { get { return HasComponent(GameplayComponentsLookup.Health); } }

    public void AddHealth(float newValue) {
        var index = GameplayComponentsLookup.Health;
        var component = (HealthComponent)CreateComponent(index, typeof(HealthComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHealth(float newValue) {
        var index = GameplayComponentsLookup.Health;
        var component = (HealthComponent)CreateComponent(index, typeof(HealthComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHealth() {
        RemoveComponent(GameplayComponentsLookup.Health);
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

    static Entitas.IMatcher<GameplayEntity> _matcherHealth;

    public static Entitas.IMatcher<GameplayEntity> Health {
        get {
            if (_matcherHealth == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.Health);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherHealth = matcher;
            }

            return _matcherHealth;
        }
    }
}
