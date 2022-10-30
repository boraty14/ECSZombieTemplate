using ComponentsAndTags;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace AuthoringAndMono
{
    public class GraveyardMono : MonoBehaviour
    {
        public float2 fieldDimensions;
        public int numberTombstonesToSpawn;
        public GameObject tombstonePrefab;
        public uint randomSeed;
        public GameObject zombiePrefab;
        public float zombieSpawnRate;
    }

    public class GraveyardBaker : Baker<GraveyardMono>
    {
        public override void Bake(GraveyardMono authoring)
        {
            AddComponent(new GraveyardProperties
            {
                FieldDimensions = authoring.fieldDimensions,
                NumberTombstonesToSpawn = authoring.numberTombstonesToSpawn,
                TombstonePrefab = GetEntity(authoring.tombstonePrefab),
                ZombiePrefab = GetEntity(authoring.zombiePrefab),
                ZombieSpawnRate = authoring.zombieSpawnRate
            });
            AddComponent(new GraveyardRandom
            {
                Value = Random.CreateFromIndex(authoring.randomSeed)
            });
            AddComponent<ZombieSpawnPoints>();
            AddComponent<ZombieSpawnTimer>();
        }
    }
}
