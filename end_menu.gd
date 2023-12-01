extends CanvasLayer

@export var label_time: Label

func _ready():
	var timer = get_node("/root/Global")
	label_time.text = "Time: %10.3f s" % timer.time_elapsed

func _on_button_menu_pressed():
	get_tree().change_scene_to_file("res://main_menu.tscn")
