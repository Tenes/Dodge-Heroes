using Godot;
using System;

public class Blink
{
    private int _numberOfBlink = 0;
    private int _maxNumberOfBlink = 2;
    private bool _blinkBool = true;
    private ShaderMaterial _shader;
    private Timer _blinkTimer;
    public void Start() => _blinkTimer.Start();
    public Blink(ShaderMaterial shader, Timer blinkTimer)
    {
        _shader = shader;
        _blinkTimer = blinkTimer;
    }
    public void TriggerBlink()
    {
        if(_numberOfBlink < _maxNumberOfBlink)
        {
            _shader.SetShaderParam("blinking", _blinkBool);
            _blinkBool = !_blinkBool;
            _numberOfBlink += 1;
        }
        else
        {
            _blinkTimer.Stop();
            _numberOfBlink = 0;
        }
    }
}
