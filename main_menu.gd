extends CanvasLayer
class_name main_menu_gd

@export var first_scene: PackedScene

func _on_button_play_pressed():
	get_tree().change_scene_to_packed(first_scene)

func _on_button_quit_pressed():
	get_tree().quit()
