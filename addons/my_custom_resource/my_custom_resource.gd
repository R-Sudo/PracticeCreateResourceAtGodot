@tool
extends EditorPlugin

var inspector_plugin

func _enter_tree():
	inspector_plugin = preload("res://addons/my_custom_resource/src/CustomResourceInspectorPlugin.cs").new()
	add_inspector_plugin(inspector_plugin)

func _exit_tree():
	remove_inspector_plugin(inspector_plugin)
