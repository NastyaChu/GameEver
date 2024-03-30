using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public PlayerController player;

    public int enemiesMaxCount = 3;
    public float delay = 3;

    public List<Transform> _spawnerPoints;
    public List<EnemyAI> _enemies;
    public List<Transform> patrolPoints;
    public float increaseEnemiesCountDelay = 30;
    private float _timeLastSpawner;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAI>();

        Invoke("IncreaseEnemiesMaxCount", increaseEnemiesCountDelay);
    }

    private void Update()
    {
        CheakDead();
  
        if (_enemies.Count >= enemiesMaxCount) return;
        
        if (Time.time - _timeLastSpawner < delay) return;
        


        CreatEnemy();

        void CheakDead()
        {
            for (var i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].IsAlive()) continue;
                _enemies.RemoveAt(i);
                i--;
            }
        }
    }

    private void IncreaseEnemiesMaxCount()
    {
        enemiesMaxCount++;
        Invoke("IncreaseEnemiesMaxCount", increaseEnemiesCountDelay);
    }

    private void CreatEnemy()
    {
        
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
        _enemies.Add(enemy);
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _timeLastSpawner = Time.time;
    }
}
