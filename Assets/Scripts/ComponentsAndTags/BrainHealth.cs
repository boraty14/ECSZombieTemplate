using Unity.Entities;
using UnityEngine;

namespace ComponentsAndTags
{
    public struct BrainHealth : IComponentData
    {
        public float Value;
        public float Max;
    }
}
