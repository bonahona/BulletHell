using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectSelfDestruct : MonoBehaviour
{
    public float SelfDestrucyTimer = 2;

	void Start ()
    {
        GameObject.Destroy(gameObject, SelfDestrucyTimer);	
	}
}
