using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private int _minSpeed;
    [SerializeField] private int _maxSpeed;
    [SerializeField] private GameObject[] _asteroidPrefab;
    [SerializeField] private GameObject[] _asteroidSpawnPoint;

    [SerializeField] private GameObject Borders;

    private GameObject asteroid;
    
    private int lastSpawnPoint = -1;

    [SerializeField] private int _maxAsteroids;
    
    public int _asteroidCount = 0;
    
    private float Timer;
    void Update()
    {
        _asteroidCount = GameObject.FindGameObjectsWithTag("Asteroid").Length;
        Timer += Time.deltaTime;
        if (Timer >= 0.1f) 
        {
            if (_asteroidCount < _maxAsteroids)
            {
                _asteroidCount += 1;
                SpawnAsteroid();
            }
            Timer = 0;
        }
    }

    void SpawnAsteroid()
    {
        int SpawnPoint = Random.Range(0, _asteroidSpawnPoint.Length);

        if (SpawnPoint == lastSpawnPoint || _asteroidSpawnPoint[SpawnPoint] == null)
        {
            while (SpawnPoint == lastSpawnPoint || _asteroidSpawnPoint[SpawnPoint] == null)
            {
                SpawnPoint = Random.Range(0, _asteroidSpawnPoint.Length);
            }
        }

        int AsteroidType = Random.Range(0, _asteroidPrefab.Length);

        asteroid = Instantiate(_asteroidPrefab[AsteroidType], _asteroidSpawnPoint[SpawnPoint].transform.position, Quaternion.identity);
        lastSpawnPoint = SpawnPoint;
        Force(SpawnPoint, asteroid); 
    }
    
    public void Force(int SpawnPoint, GameObject asteroid)
    {
        Physics2D.IgnoreCollision(asteroid.GetComponent<Collider2D>(), Borders.GetComponent<Collider2D>(),enabled);
        
        int speed = UnityEngine.Random.Range(_minSpeed, _maxSpeed);
        
        if (SpawnPoint > 0 && SpawnPoint < 6)
        {
            asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.7f,0.7f),-1) * speed * Time.deltaTime);
        }
        else if (SpawnPoint > 13 && SpawnPoint < 19)
        {
            asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.7f,0.7f),1) * speed * Time.deltaTime);
        }
        else if (SpawnPoint > 7 && SpawnPoint < 12)
        {
            asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,Random.Range(-0.7f,0.7f)) * speed * Time.deltaTime);
        }
        else if (SpawnPoint > 19 && SpawnPoint < 24)
        {
            asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,Random.Range(-0.7f,0.7f)) * speed * Time.deltaTime);
        }
        else if (SpawnPoint == 0 || SpawnPoint == 6)
        {
            asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-1) * speed * Time.deltaTime);
        }
        else if (SpawnPoint == 7)
        {
            asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,-1) * speed * Time.deltaTime);
        }
        else if (SpawnPoint == 12)
        {
            asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,1) * speed * Time.deltaTime);
        }
        else if (SpawnPoint == 13 || SpawnPoint == 24)
        {
            asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,1) * speed * Time.deltaTime);
        }
        else if (SpawnPoint == 19)
        {
            asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1) * speed * Time.deltaTime);
        }
    }
}
