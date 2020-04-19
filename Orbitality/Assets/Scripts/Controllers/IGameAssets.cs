using Gameplay;
using UnityEngine;

namespace Controllers
{
    public interface IGameAssets
    {
        GameObject GetPrefabByGameObjectType(GameObjectType type);
    }
}