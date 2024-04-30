using Cysharp.Threading.Tasks;
using Enemies.view;
using Enemies.views;
using Player.views;
using UnityEngine;
using UnityEngine.Pool;
using Utils.AdresableLoader;

namespace Enemies.controller
{
    public class SpawnController : MonoBehaviour, ISpawnController
    {
        private IEnemiesSpawnerView _enemiesSpawnerView;
        private IzombieView _zombieView1;
        private IzombieView _zombieView2;
        private IObjectPool<GameObject> _zombiePool;
        private const int PoolSize = 1000;
        private IPlayerView _playerView;

        public SpawnController(IEnemiesSpawnerView enemiesSpawnerView, IPlayerView playerView) 
        {
            _enemiesSpawnerView = enemiesSpawnerView;
            _playerView = playerView;

            GenerateZombie().Forget();
        }


        private async UniTaskVoid GenerateZombie()
        {
            _zombieView1 = await AdresableLoader.InstantiateAsync<IzombieView>("Zombie_Default");
            _zombieView2 = await AdresableLoader.InstantiateAsync<IzombieView>("Zombie_Base");


            _zombiePool = new ObjectPool<GameObject>(
                CreatePooledItem,
                OnTakedFromPool,
                OnReturnedPool,
                OnDestroyPool,
                true,
                10,
                PoolSize
            );
      
            for (int i = 0; i < 10; i++)
            {
                _zombiePool.Get();
            }
        }

        private GameObject CreatePooledItem()
        {
            var position = _enemiesSpawnerView.Position;
            var enemyPosition = position + Random.insideUnitCircle * _enemiesSpawnerView.Radius;
            int enemyType = Random.Range(0, 2);
            GameObject enemy;

            if (enemyType == 0)
            {
                enemy = Object.Instantiate(_zombieView1.GameObject, enemyPosition, Quaternion.identity);
            }
            else
            {
                enemy = Object.Instantiate(_zombieView2.GameObject, enemyPosition, Quaternion.identity);
            }
            var zombieView = enemy.GetComponent<IzombieView>();

            var zombieController = new ZombieController(zombieView, _playerView);
            return enemy;
        }
 
        private void OnTakedFromPool(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        private void OnReturnedPool(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        private void OnDestroyPool(GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }
    }
}

