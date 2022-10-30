using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ComponentsAndTags
{
    public readonly partial struct ZombieWalkAspect : IAspect
    {
        public readonly Entity Entity;

        private readonly TransformAspect _transformAspect;
        private readonly RefRW<ZombieTimer> _zombieTimer;
        private readonly RefRO<ZombieWalkProperties> _zombieWalkProperties;
        private readonly RefRO<ZombieHeading> _zombieHeading;

        private float WalkSpeed => _zombieWalkProperties.ValueRO.WalkSpeed;
        private float WalkAmplitude => _zombieWalkProperties.ValueRO.WalkAmplitude;
        private float WalkFrequency => _zombieWalkProperties.ValueRO.WalkFrequency;
        private float Heading => _zombieHeading.ValueRO.Value;

        private float WalkTimer
        {
            get => _zombieTimer.ValueRO.Value;
            set => _zombieTimer.ValueRW.Value = value;
        }

        public void Walk(float deltaTime)
        {
            WalkTimer += deltaTime;
            _transformAspect.Position += _transformAspect.Forward * WalkSpeed * deltaTime;

            var swayAngle = WalkAmplitude * math.sin(WalkFrequency * WalkTimer);
            _transformAspect.Rotation = quaternion.Euler(0,Heading,swayAngle);
        }

        public bool IsInStoppingRange(float3 brainPosition, float brainRadiusSq)
        {
            return math.distancesq(brainPosition, _transformAspect.Position) < brainRadiusSq;
        }
    }
}
