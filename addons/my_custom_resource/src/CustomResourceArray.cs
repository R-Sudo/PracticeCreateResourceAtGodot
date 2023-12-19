using Godot;

namespace PracticeCreateResourceAtGodot;

[GlobalClass]
[Tool]
public partial class CustomResourceArray : Resource
{
    [Export]
    public CustomResource[] Data { get; set; }
}