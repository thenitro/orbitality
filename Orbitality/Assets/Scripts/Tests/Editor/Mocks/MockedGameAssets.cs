using System.Collections.Generic;
using Controllers;
using Gameplay;
using UnityEngine;

namespace Tests.Editor.Mocks
{
    public class MockedGameAssets : IGameAssets
    {
        private readonly Dictionary<GameObjectType, GameObject> _assets;
        
        public MockedGameAssets()
        {
            _assets = new Dictionary<GameObjectType, GameObject>();
            _assets.Add(GameObjectType.Sun, new GameObject());
            _assets.Add(GameObjectType.Planet, new GameObject());
            _assets.Add(GameObjectType.Rocket, new GameObject());
        }
        
        public GameObject GetPrefabByGameObjectType(GameObjectType type)
        {
            return _assets[type];
        }
    }
}