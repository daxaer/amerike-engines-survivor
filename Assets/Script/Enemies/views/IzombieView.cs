using UnityEngine;

namespace Enemies.views
{
    public interface IzombieView
    {
        float MoveSpeed { get; }
        Transform Transform { get;}
        bool FlipSprite { get; set; }
        GameObject GameObject { get;}
    }
}
