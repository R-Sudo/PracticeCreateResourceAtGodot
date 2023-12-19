using System.Linq;
using Godot;
using PracticeCreateResourceAtGodot;

public partial class Test : Node
{
    [Export] private Button loadButton;
    [Export] private Sprite2D target;

    public override void _Ready()
    {
        loadButton.Pressed += OnPressed;
    }

    private void OnPressed()
    {
        var res = GD.Load<CustomResourceArray>("res://addons/my_custom_resource/res/array.tres");
        var first = res?.Data.FirstOrDefault();

        if (first is null)
        {
            return;
        }

        target.Position = first.Vector2Prop;
        target.Modulate = first.ColorProp;
    }
}
