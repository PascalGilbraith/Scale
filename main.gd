extends Node
class_name main

@export var player: player
@export var viewport: Camera2D
@export var game_menu: game_menu
@export var fail_audio_player: AudioStreamPlayer
@export var next_level: PackedScene
@export var start_position: Marker2D
@export var button1: button
@export var button2: button
@export var button3: button
@export var button4: button
@export var button5: button
@export var button6: button
@export var button7: button
@export var button8: button

var button_index: int = 1

# Called when the node enters the scene tree for the first time.
func _ready():
	game_menu.hide()
	reset()
	button1.play_sound()
	button3.play_sound()
	button5.play_sound()
	button8.play_sound()

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta):
	viewport.position = player.position
	if Input.is_action_just_pressed("ui_cancel") or Input.is_action_just_pressed("pause"):
		get_tree().paused = true
		game_menu.show()

func _on_button_1_button_pushed():
	if button_index == 1:
		button_index += 1
		button1.set_is_highlighted(false)
		button2.set_is_highlighted(true)
	else:
		fail()

func _on_button_2_button_pushed():
	if button_index == 2:
		button_index += 1
		button2.set_is_highlighted(false)
		button3.set_is_highlighted(true)
	else:
		fail()

func _on_button_3_button_pushed():
	if button_index == 3:
		button_index += 1
		button3.set_is_highlighted(false)
		button4.set_is_highlighted(true)
	else:
		fail()

func _on_button_4_button_pushed():
	if button_index == 4:
		button_index += 1
		button4.set_is_highlighted(false)
		button5.set_is_highlighted(true)
	else:
		fail()

func _on_button_5_button_pushed():
	if button_index == 5:
		button_index += 1
		button5.set_is_highlighted(false)
		button6.set_is_highlighted(true)
	else:
		fail()

func _on_button_6_button_pushed():
	if button_index == 6:
		button_index += 1
		button6.set_is_highlighted(false)
		button7.set_is_highlighted(true)
	else:
		fail()

func _on_button_7_button_pushed():
	if button_index == 7:
		button_index += 1
		button7.set_is_highlighted(false)
		button8.set_is_highlighted(true)
	else:
		fail()

func _on_button_8_button_pushed():
	if button_index == 8:
		win()
	else:
		fail()

func _on_player_player_died():
	fail()

func _on_player_player_spawned():
	get_tree().paused = false

func _on_player_player_despawned():
	if next_level == null:
		pass
	else:
		get_tree().change_scene_to_packed(next_level)

func reset():
	button_index = 1
	get_tree().call_group("buttons", "reset")
	button1.set_is_highlighted(true)
	player.spawn(start_position.position)

func win():
	player.despawn()

func fail():
	fail_audio_player.play()
	reset()
