#if TOOLS
using System;
using System.Collections.Generic;
using Godot;

namespace PracticeCreateResourceAtGodot;

public partial class CustomResourceInspectorPlugin : EditorInspectorPlugin
{
    private CustomResourceArray target;

    public override bool _CanHandle(GodotObject @object)
    {
        // NOTE: BadCustomResource クラスの場合、Tool 属性がついてないので GetType した時に Resource 型になってる
        var type = @object.GetType();
        GD.Print($"type is: {type}");

        return @object is CustomResourceArray;
    }

    public override void _ParseBegin(GodotObject @object)
    {
        // NOTE: _CanHandle で CustomResourceArray 型のみ有効にしてるので直接キャスト
        target = (CustomResourceArray)@object;

        CreateCustomInspector();
    }

    private void CreateCustomInspector()
    {
        var randomGenerateButton = new Button();
        randomGenerateButton.Text = "Random Generate";
        randomGenerateButton.Pressed += RandomGenerate;

        AddCustomControl(randomGenerateButton);
    }

    private void RandomGenerate()
    {
        var list = new List<CustomResource>();

        for (var i = 0; i < 5; i++)
        {
            var resource = new CustomResource
            {
                IntProp = (int)GD.Randi(),
                FloatProp = GD.Randf(),
                BoolProp = GD.Randi() % 2 == 0,
                StringProp = Guid.NewGuid().ToString(),
                Vector2Prop = new Vector2((float)GD.RandRange(500.0f, 1000.0f), (float)GD.RandRange(250.0f, 500.0f)),
                ColorProp = new Color(GD.Randf(), GD.Randf(), GD.Randf()),
                CurveProp = new Curve()
            };
            
            list.Add(resource);
        }

        target.Data = list.ToArray();
        
        // NOTE: リソースの値が変わった変更通知を投げる必要がある
        target.EmitChanged();
    }
}
#endif