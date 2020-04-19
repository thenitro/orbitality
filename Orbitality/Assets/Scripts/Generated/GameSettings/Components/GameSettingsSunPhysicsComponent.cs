//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameSettingsContext {

    public GameSettingsEntity sunPhysicsEntity { get { return GetGroup(GameSettingsMatcher.SunPhysics).GetSingleEntity(); } }
    public SunPhysicsComponent sunPhysics { get { return sunPhysicsEntity.sunPhysics; } }
    public bool hasSunPhysics { get { return sunPhysicsEntity != null; } }

    public GameSettingsEntity SetSunPhysics(float newMass) {
        if (hasSunPhysics) {
            throw new Entitas.EntitasException("Could not set SunPhysics!\n" + this + " already has an entity with SunPhysicsComponent!",
                "You should check if the context already has a sunPhysicsEntity before setting it or use context.ReplaceSunPhysics().");
        }
        var entity = CreateEntity();
        entity.AddSunPhysics(newMass);
        return entity;
    }

    public void ReplaceSunPhysics(float newMass) {
        var entity = sunPhysicsEntity;
        if (entity == null) {
            entity = SetSunPhysics(newMass);
        } else {
            entity.ReplaceSunPhysics(newMass);
        }
    }

    public void RemoveSunPhysics() {
        sunPhysicsEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameSettingsEntity {

    public SunPhysicsComponent sunPhysics { get { return (SunPhysicsComponent)GetComponent(GameSettingsComponentsLookup.SunPhysics); } }
    public bool hasSunPhysics { get { return HasComponent(GameSettingsComponentsLookup.SunPhysics); } }

    public void AddSunPhysics(float newMass) {
        var index = GameSettingsComponentsLookup.SunPhysics;
        var component = (SunPhysicsComponent)CreateComponent(index, typeof(SunPhysicsComponent));
        component.Mass = newMass;
        AddComponent(index, component);
    }

    public void ReplaceSunPhysics(float newMass) {
        var index = GameSettingsComponentsLookup.SunPhysics;
        var component = (SunPhysicsComponent)CreateComponent(index, typeof(SunPhysicsComponent));
        component.Mass = newMass;
        ReplaceComponent(index, component);
    }

    public void RemoveSunPhysics() {
        RemoveComponent(GameSettingsComponentsLookup.SunPhysics);
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
public sealed partial class GameSettingsMatcher {

    static Entitas.IMatcher<GameSettingsEntity> _matcherSunPhysics;

    public static Entitas.IMatcher<GameSettingsEntity> SunPhysics {
        get {
            if (_matcherSunPhysics == null) {
                var matcher = (Entitas.Matcher<GameSettingsEntity>)Entitas.Matcher<GameSettingsEntity>.AllOf(GameSettingsComponentsLookup.SunPhysics);
                matcher.componentNames = GameSettingsComponentsLookup.componentNames;
                _matcherSunPhysics = matcher;
            }

            return _matcherSunPhysics;
        }
    }
}
