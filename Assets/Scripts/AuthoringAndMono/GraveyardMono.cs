using ComponentsAndTags;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace AuthoringAndMono
{
    public class GraveyardMono : MonoBehaviour
    {
        public float2 fieldDimensions;
        public int numberTombstonesToSpawn;
        public GameObject tombstonePrefab;
    }

    public class GraveyardBaker : Baker<GraveyardMono>
    {
        public override void Bake(GraveyardMono authoring)
        {
            AddComponent(new GraveyardProperties
            {
                FieldDimensions = authoring.fieldDimensions,
                NumberTombstonesToSpawn = authoring.numberTombstonesToSpawn,
                TombstonePrefab = GetEntity(authoring.tombstonePrefab)
            });
        }
    }
}
