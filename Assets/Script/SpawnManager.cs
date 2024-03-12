using Enemies.views;
using Player.views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public float spawnRadius = 5f;
    public Vector3 RandomPosition(IPlayerView player, IzombieView zombie)
    {
        Vector3 playerPosition = player.Transform.position;
        Vector3 randomDirection = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 randomPosition = playerPosition + randomDirection;

        return randomPosition;
    }
}
