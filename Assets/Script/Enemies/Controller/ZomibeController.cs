using Enemies.views;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Animations;
using Player.views;

namespace Enemies.controller
{
    public class ZomibeController : IZombieController
    {
        private IPlayerView playerView;
        private IzombieView zombieView;
        public ZomibeController(IzombieView _zombieView, IPlayerView _playerView)
        {
            zombieView = _zombieView;
            playerView = _playerView;
            StartMovement().Forget();
        }

        private async UniTask StartMovement()
        {
            while (true)
            {
                await MoveToPlayer();
                await UniTask.Yield();
            }
        }
        private async UniTask MoveToPlayer()
        {
            Vector3 playerPosition = playerView.Transform.position;
            Vector3 direccion = playerPosition - zombieView.Transform.position;
            direccion.Normalize();
            float playerDirection = Mathf.Sign(direccion.x);

            zombieView.FlipSprite = (playerDirection < 0);

            zombieView.Transform.position = Vector2.MoveTowards(zombieView.Transform.position,playerPosition,zombieView.MoveSpeed * Time.deltaTime);
            await UniTask.DelayFrame(1);
        }
    }
}

