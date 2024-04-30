using Cysharp.Threading.Tasks;
using DefaultNamespace;
using UnityEngine;
using Utils.AdresableLoader;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Game _game;
    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;

            _game = new Game();
            _game.Createlevel().Forget();
            DontDestroyOnLoad(gameObject);
        }
    }
}
