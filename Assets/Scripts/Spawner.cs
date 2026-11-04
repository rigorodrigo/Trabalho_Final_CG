using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemy;
    public WaypointPath path1;

    public float timeToSpawn = 3.0f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
        if (timer > timeToSpawn)
        {
            // Cria um novo objeto "Obstáculo" instanciando GameObject
            Enemy newEnemy = Instantiate(enemy);
            newEnemy.transform.position = transform.position + path1.waypoints[0].position;
            newEnemy.path = path1;
            timer = 0;
        }
        timer += Time.deltaTime;

    }
}
