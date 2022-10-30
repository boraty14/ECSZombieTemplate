using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace AuthoringAndMono
{
    public class ZombieMono : MonoBehaviour
    {
        public float riseRate;
        public float walkSpeed;
        public float walkAmplitude;
        public float walkFrequency;
    }

    public class ZombieBaker : Baker<ZombieMono>
    {
        public override void Bake(ZombieMono authoring)
        {
            AddComponent(new ZombieRiseRate
            {
                Value = authoring.riseRate
            });
            
            AddComponent(new ZombieWalkProperties
            {
                WalkSpeed = authoring.walkSpeed,
                WalkAmplitude = authoring.walkAmplitude,
                WalkFrequency = authoring.walkFrequency
            });
            
            AddComponent<ZombieTimer>();
            AddComponent<ZombieHeading>();
            AddComponent<NewZombieTag>();
            
        }
    }
}
