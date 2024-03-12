using Enemies.views;
using UnityEngine;
using Utils.Bindings;

namespace Enemies.view
{
    public class ZombiesView : MonoBehaviour, IzombieView
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private boolBinding hit;
        [SerializeField] private SpriteRenderer _SpriteRenderer;

        public float MoveSpeed => _moveSpeed;

        public Transform Transform { get => transform; }

        public bool FlipSprite { get => _SpriteRenderer.flipX; set => _SpriteRenderer.flipX = value; }
    }
}
