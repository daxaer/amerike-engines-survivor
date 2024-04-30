using Cysharp.Threading.Tasks;
using Map.controllers;
using Map.views;
using Player.controllers;
using Player.views;
using Utils.AdresableLoader;

namespace DefaultNamespace
{
    public class Game
    {
        public Game()
        {

        }
        public async UniTaskVoid Createlevel()
        {

            var MapView = await AdresableLoader.InstantiateAsync<IMapView>("Map_Default");
            IMapController  mapController = new MapController(MapView);

            var playerView = await AdresableLoader.InstantiateAsync<IPlayerView>("Player_Default");
            IPlayerController playerController = new PlayerController(playerView);
        }
    }
}


