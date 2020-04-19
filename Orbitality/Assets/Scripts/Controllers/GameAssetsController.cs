using System.Collections.Generic;
using Gameplay;
using UnityEngine;

namespace Controllers
{
    public class GameAssetsController : MonoBehaviour, IGameAssets
    {
#pragma warning disable 0649
        [SerializeField] private GameObject Sun;
        [SerializeField] private GameObject Planet;
        [SerializeField] private GameObject Rocket;
#pragma warning restore 0649
        
        private Dictionary<GameObjectType, GameObject> _prefabs;
        
        private void Awake()
        {
            _prefabs = new Dictionary<GameObjectType, GameObject>();
            _prefabs.Add(GameObjectType.Sun, Sun);
            _prefabs.Add(GameObjectType.Planet, Planet);
            _prefabs.Add(GameObjectType.Rocket, Rocket);
            
            Contexts.sharedInstance.gameflow.ReplaceGameAssets(this);
        }

        public GameObject GetPrefabByGameObjectType(GameObjectType type)
        {
            if (!_prefabs.ContainsKey(type))
            {
                Debug.LogWarningFormat("GameAssetsController.GetPrefabByGameObjectType: No such asset {0}", type);
                return null;
            }

            return _prefabs[type];
        }
    }
}