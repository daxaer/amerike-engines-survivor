using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemies.view
{
    public interface IEnemiesSpawnerView
    {
        float Radius { get; }

        Vector2 Position { get; }
    }
}

