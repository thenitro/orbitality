//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameflowMatcher {

    public static Entitas.IAllOfMatcher<GameflowEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<GameflowEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<GameflowEntity> AllOf(params Entitas.IMatcher<GameflowEntity>[] matchers) {
          return Entitas.Matcher<GameflowEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<GameflowEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<GameflowEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<GameflowEntity> AnyOf(params Entitas.IMatcher<GameflowEntity>[] matchers) {
          return Entitas.Matcher<GameflowEntity>.AnyOf(matchers);
    }
}
