using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputDevice", menuName = "BulletHell/Input Device")]
public class InputDevice : ScriptableObject
{
    [InputAxis]
    public string LeftHorizontalAxis;
    [InputAxis]
    public string LeftVerticalAxis;
    [InputAxis]
    public string RightHorizontalAxis;
    [InputAxis]
    public string RightVerticalAxis;

    [InputAxis]
    public string LeftTriggerAxis;
    [InputAxis]
    public string RightTriggerAxis;

    public KeyCode StartButton;
    public KeyCode XButton;
    public KeyCode YButton;
    public KeyCode BButton;
    public KeyCode AButton;

    public InputState Read()
    {
        var result = new InputState();

        result.LeftStick = ReadStick(LeftHorizontalAxis, LeftVerticalAxis);
        result.RightStick = ReadStick(RightHorizontalAxis, RightVerticalAxis);
        result.StartButton = Input.GetKeyDown(StartButton);
        result.XButton = Input.GetKeyDown(StartButton);
        result.YButton = Input.GetKeyDown(StartButton);
        result.BButton = Input.GetKeyDown(StartButton);
        result.AButton = Input.GetKeyDown(StartButton);

        return result;
    }

    private Vector2 ReadStick(string horizontalAxis, string verticalAxis)
    {
        return new Vector2(Input.GetAxis(horizontalAxis), Input.GetAxis(verticalAxis));
    }
}
