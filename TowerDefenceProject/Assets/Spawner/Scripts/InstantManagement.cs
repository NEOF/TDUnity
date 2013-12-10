namespace TD.Spawner
{
    using UnityEngine;
    public static class InstantManagement
    {
        public static string poolName = "SpawnedEnemy";
        public static Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot)
        {
#if POOLMANAGER_INSTALLED
            // If the pool doesn't exist, it will be created before use
            if (!PoolManager.Pools.ContainsKey(poolName))
                (new GameObject(poolName)).AddComponent<SpawnPool>();

            return PoolManager.Pools[poolName].Spawn(prefab, pos, rot);
#else
            return (Transform)Object.Instantiate(prefab, pos, rot);
#endif
        }
        public static void Despawn(Transform instance)
        {
#if POOLMANAGER_INSTALLED
            PoolManager.Pools[poolName].Despawn(instance);
#else
            Object.Destroy(instance.gameObject);
#endif
        }
        public static void ReadyPreSpawn(Transform prefab, int amount)
        {
#if POOLMANAGER_INSTALLED
            if (!PoolManager.Pools.ContainsKey(poolName))
                (new GameObject(poolName)).AddComponent<SpawnPool>();

            PrefabPool item = new PrefabPool(prefab);
            item.preloadAmount = amount;

            PoolManager.Pools[poolName].CreatePrefabPool(item);

#endif
        }
    }
}