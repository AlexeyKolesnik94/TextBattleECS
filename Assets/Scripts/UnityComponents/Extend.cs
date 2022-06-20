using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Services
{
    public static class Extend
    {
        public static void SendMessage(this EcsWorld world, string message)
        {
            world.NewEntity().Get<MessageRequest>().Message = message;
        }

        public static bool Roll100(this float num)
        {
            return Random.Range(0f, 100f) < num;
        }
    }
}
