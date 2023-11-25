extends CanvasLayer
class_name game_menu

func _ready():
	if OS.has_feature("web"):
		var quit_button = get_node("Button_Quit")
		quit_button.hide()

func _on_button_play_pressed():
	var scene_file = get_tree().current_scene.scene_file_path
	if scene_file.ends_with("main.tscn"):
		get_tree().reload_current_scene()
		hide()
		get_tree().paused = false
	else:
		get_tree().change_scene_to_file("res://Levels/main.tscn")
		hide()
		get_tree().paused = false

func _on_button_quit_pressed():
	get_tree().quit()

func _on_button_resume_pressed():
	# Resume current game
	hide()
	get_tree().paused = false
