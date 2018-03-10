using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName ="BulletHell/Level")]
public class Level : ScriptableObject
{
    public List<LevelWave> Waves;
}
