using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSpawn
{
    public float SpawnTimer;
    public GameObject Enemy;
    public AnimationClip Animation;
    public Vector3 StartPosition;
}
