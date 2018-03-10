using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class LevelObject : Manager<LevelObject>
{
    public Level Level;

    private bool IsStarted = false;

    private LinkedList<LevelSpawn> Spawns;

    private float CurrentTimer;

    public void StartLevel()
    {
        IsStarted = true;
    }

    private void Start()
    {
        Spawns = new LinkedList<LevelSpawn>();
        Level.Spawn.ForEach(s => Spawns.AddLast(s));
    }

    void Update ()
    {
        if (!IsStarted) {
            return;
        }

        CurrentTimer += Time.deltaTime;

        foreach(var spawn in Spawns.ToList()) {
            if(spawn.SpawnTimer <= CurrentTimer) {
                SpawnEnemy(spawn);
                Spawns.Remove(spawn);
            }
        }
	}


    private void SpawnEnemy(LevelSpawn spawn)
    {
        var wrapperObject = new GameObject("Wrapper");
        wrapperObject.transform.position = spawn.StartPosition;

        GameObject.Instantiate(spawn.Enemy, spawn.StartPosition, spawn.Enemy.transform.rotation, wrapperObject.transform);
    }
}
