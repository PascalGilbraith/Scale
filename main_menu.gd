extends CanvasLayer
class_name main_menu_gd

@export var first_scene: PackedScene

func _ready():
	if OS.has_feature("web"):
		var quit_button = get_node("Button_Quit")
		quit_button.hide()

func _on_button_play_pressed():
	var timer = get_node("/root/Global")
	timer.reset()
	get_tree().change_scene_to_packed(first_scene)

func _on_button_quit_pressed():
	get_tree().quit()
