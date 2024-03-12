using Cysharp.Threading.Tasks;
using Enemies.controller;
using Enemies.view;
using Enemies.views;
using Map.views;
using Player.controllers;
using Player.views;
using UnityEngine;
using Utils.AdresableLoader;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private PlayerView playerViewSource; 
    private void Awake()
    {
        if(Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CreateGame().Forget();
        }
    }

    private async UniTaskVoid CreateGame()
    {

        var MapView = await AdresableLoader.InstantiateAsync<IMapView>("Map_Default");
        var playerView = await AdresableLoader.InstantiateAsync<IPlayerView>("Player_Default");
        IPlayerController playerController = new PlayerController(playerView);

        var ZombieView = await AdresableLoader.InstantiateAsync<IzombieView>("Zombie_Default");
        ZombieView.Transform.position = SpawnManager.Instance.RandomPosition(playerView, ZombieView);
        IZombieController zombieController = new ZomibeController(ZombieView, playerView);
    }
}
