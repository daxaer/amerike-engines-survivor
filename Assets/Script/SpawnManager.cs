using Enemies.controller;
using Enemies.view;
using Enemies.views;
using Player.views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    public GameObject Zombies;
    public int poolSize = 10;

    private ObjectPool<IzombieView> pool;
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
            pool = new ObjectPool<IzombieView>(() => Instantiate(Zombies).GetComponent<IzombieView>(), null);
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

    public IzombieView SpawnZombie(Vector3 position, Quaternion rotation)
    {
        // Obtener un objeto del pool y activarlo en la posición y rotación especificadas
        IzombieView zombie = pool.Get();
        zombie.Transform.position = position;
        zombie.Transform.rotation = rotation;
        zombie.GameObject.SetActive(true);
        return zombie;
    }

    public void DespawnZombie(IzombieView zombie)
    {
        // Desactivar el objeto y devolverlo al pool
        zombie.GameObject.SetActive(false);
        pool.Release(zombie);
    }
}