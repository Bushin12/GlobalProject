using System;
using UnityEngine;

public class InputButton : MonoBehaviour
{
    public float Horizontal { private set; get; }
    public bool MouseRightStay { private set; get; }
    public bool MouseLeft { private set; get; }
    public bool Space { private set; get; }
    public bool Escape { private set; get; }
    public bool KeyR { private set; get; }

    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    private string[] _knowKeyDown = new string[5];
    private bool _isPause = true;
    private void Update()
    {
        if (_isPause)
        {
        Horizontal = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(1))
            MouseRightStay = true;
        else if (Input.GetMouseButtonUp(1))
            MouseRightStay = false;

        MouseLeft = Input.GetMouseButtonDown(0);
        Space = Input.GetKeyDown(KeyCode.Space);
        }
        else
        {
            Horizontal = 0;
        }
        Escape = Input.GetKeyDown(KeyCode.Escape);
        KeyR = Input.GetKeyDown(KeyCode.R);
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    ArrayOffset();
                    _knowKeyDown[0] = keyCode.ToString();
                }
            }
        }
    }
    private void ArrayOffset()
    {
        string valueCell = _knowKeyDown[0];
        for (int i = 0; i < _knowKeyDown.Length-1; i++)
        {
            string timevalue = _knowKeyDown[i + 1];
            _knowKeyDown[i + 1] = valueCell;
            valueCell = timevalue;
        }
    }
    public void Pause(bool pause)
    {
        _isPause = pause;
    }
}
