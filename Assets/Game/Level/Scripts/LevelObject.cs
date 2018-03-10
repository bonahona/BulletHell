using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class LevelObject : Manager<LevelObject>
{
    public Level Level;

    private bool IsStarted = false;

    private LinkedList<LevelWave> Waves;

    private float CurrentTimer;

    public void StartLevel()
    {
        IsStarted = true;
    }

    private void Start()
    {
        Waves = new LinkedList<LevelWave>();
        Level.Waves.ForEach(w => Waves.AddLast(w));
    }

    void Update ()
    {
        if (!IsStarted) {
            return;
        }

        CurrentTimer += Time.deltaTime;

        foreach(var wave in Waves.ToList()) {
            if(wave.SpawnTimer <= CurrentTimer) {
                SpawnWave(wave);
                Waves.Remove(wave);
            }
        }
	}


    private void SpawnWave(LevelWave wave)
    {
        foreach (var spawn in wave.Spawns) {
            var wrapperObject = new GameObject("Wrapper");
            wrapperObject.transform.position = spawn.StartPosition;

            var enemy = GameObject.Instantiate(spawn.Enemy, spawn.StartPosition, spawn.Enemy.transform.rotation, wrapperObject.transform).GetComponent<Enemy>();

            if (spawn.Animation != null) {
                enemy.SetAnimationClip(spawn.Animation);
            }
        }
    }
}
