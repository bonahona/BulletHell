using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T s_instance;
    public static T Instance
    {
        get
        {
            if (s_instance == null) {
                s_instance = GameObject.FindObjectOfType<T>();
            }

            return s_instance;
        }

        set
        {

            s_instance = value;


        }
    }
}