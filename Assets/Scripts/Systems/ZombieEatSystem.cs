using ComponentsAndTags;
using Unity.Burst;
using Unity.Entities;

namespace Systems
{
    [BurstCompile]
    public partial struct ZombieEatSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            new ZombieEatJob
            {
                DeltaTime = deltaTime
            }.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct ZombieEatJob: IJobEntity
    {
        public float DeltaTime;

        [BurstCompile]
        private void Execute(ZombieEatAspect zombie)
        {
            zombie.Eat(DeltaTime);
        }
    }
}