using Enemies.views;
using UnityEngine;
using Utils.Bindings;

namespace Enemies.view
{
    public class ZombiesView : MonoBehaviour, IzombieView
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private IntBinding state;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public float MoveSpeed => _moveSpeed;

        public Transform Transform => transform;

        public bool FlipSprite { get => _spriteRenderer.flipX; set => _spriteRenderer.flipX = value; }

        public GameObject GameObject => gameObject;
    }
}
