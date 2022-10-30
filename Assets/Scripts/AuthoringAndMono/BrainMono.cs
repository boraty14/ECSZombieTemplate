using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace AuthoringAndMono
{
    public class BrainMono : MonoBehaviour
    {
        
    }

    public class BrainBaker : Baker<BrainMono>
    {
        public override void Bake(BrainMono authoring)
        {
            AddComponent<BrainTag>();
        }
    }
}
