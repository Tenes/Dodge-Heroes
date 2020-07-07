using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory : Node
{
    public void _OnExitButtonReleased()
    {
        GetParent().RemoveChild(this);
    }
}
