extends Node2D
class_name button

signal button_pushed

@export var Sound: AudioStream

@export var AudioPlayer: AudioStreamPlayer2D

@export var Sprite: AnimatedSprite2D

@export var Highlight: PointLight2D

var is_pushed: bool = false

var is_single_use: bool = false

var is_highlighted: bool = false

var is_black: bool = false

func set_is_highlighted(value: bool):
	is_highlighted = value
	Highlight.enabled = is_highlighted

# Called when the node enters the scene tree for the first time.
func _ready():
	AudioPlayer.stream = Sound
	if Sound.resource_path.contains("#"):
		is_black = true
		Sprite.play("idle_black")

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta):
	if Sprite.animation == "release" and Sprite.frame_progress == 1:
		Sprite.play("idle")
	elif Sprite.animation == "release_black" and Sprite.frame_progress == 1:
		Sprite.play("idle_black")

func _on_press_collider_body_entered(body):
	if body is player:
		AudioPlayer.play()
		if is_black:
			Sprite.play("press_black")
		else:
			Sprite.play("press")
		if not is_single_use || not is_pushed:
			emit_signal("button_pushed")

func reset():
	is_pushed = false
	set_is_highlighted(false)

func play_sound():
	AudioPlayer.play()

func _on_release_collider_body_exited(body):
	if body is player:
		if is_black:
			Sprite.play("release_black")
		else:
			Sprite.play("release")
