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
    public string TriggerAxis;

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

        var triggerAxis = Input.GetAxis(TriggerAxis);
        result.LeftTrigger = triggerAxis > 0.8f;
        result.RightTrigger = triggerAxis < -0.8f;

        return result;
    }

    private Vector2 ReadStick(string horizontalAxis, string verticalAxis)
    {
        return new Vector2(Input.GetAxis(horizontalAxis), -Input.GetAxis(verticalAxis));
    }
}
