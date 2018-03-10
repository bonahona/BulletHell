using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public InputDevice Device;
    public GameObject PlayerShip;
    public Transform StartPosition;

    public int ExtraLives = 3;

    private PlayerShip CurrentShip;

    private void Start()
    {
        //SpawnShip();
    }

    private void Update()
    {
        var inputState = Device.Read();

        if(CurrentShip == null) {
            if (inputState.StartButton) {
                //LevelObject.Instance.StartLevel();
                SpawnShip();
            }
        } else {
            CurrentShip.TakeInput(inputState);
        }
    }

    private void SpawnShip()
    {
        CurrentShip = GameObject.Instantiate(PlayerShip, StartPosition.position, Quaternion.Euler(0, -90, 0)).GetComponent<PlayerShip>();
    }
}
