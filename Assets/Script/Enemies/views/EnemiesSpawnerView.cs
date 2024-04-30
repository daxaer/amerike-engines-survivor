using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.view
{
    public class EnemiesSpawnerView : MonoBehaviour, IEnemiesSpawnerView
    {
        [SerializeField] private float _radius;
        public float Radius => _radius;
        public Vector2 Position => transform.position;
          
    }
        
}
