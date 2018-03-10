using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName ="BulletHell/Level")]
public class Level : ScriptableObject
{
    public float StartDelay = 5;
    public List<LevelWave> Waves;
}
