using Godot;

namespace PracticeCreateResourceAtGodot;

[GlobalClass]
[Tool]
public partial class CustomResource : Resource
{
    [Export]
    public int IntProp { get; set; }

    [Export]
    public float FloatProp { get; set; }

    [Export]
    public bool BoolProp { get; set; }

    [Export]
    public string StringProp { get; set; }

    [Export]
    public Vector2 Vector2Prop { get; set; }

    [Export]
    public Color ColorProp { get; set; }

    [Export]
    public Curve CurveProp { get; set; }
}
