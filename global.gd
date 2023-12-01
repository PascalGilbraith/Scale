extends Node

var is_running := true
var time_elapsed := 0.0

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if is_running:
		time_elapsed += delta
		#time.text = format_string % time_elapsed

func reset():
	is_running = false
	time_elapsed = 0
	
func start():
	is_running = true

func stop():
	is_running = false
