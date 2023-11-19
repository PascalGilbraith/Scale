extends CharacterBody2D
class_name player

const SPEED = 300.0
const JUMP_VELOCITY = -400.0

var jump_count: int = 0
var is_wall_jumping: bool = false

@export var timer_wall_jump: Timer
@export var timer_spawn: Timer
@export var timer_despawn: Timer
@export var sprite: AnimatedSprite2D

signal player_died
signal player_spawned
signal player_despawned

# Get the gravity from the project settings to be synced with RigidBody nodes.
var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")

func _physics_process(delta):
	if (not timer_spawn.is_stopped()) or (not timer_despawn.is_stopped()):
		return
	
	var collision_count = get_slide_collision_count()
	for collision_index in collision_count:
		var collision = get_slide_collision(collision_index)
		var collider = collision.get_collider()
		if collider is spike:
			emit_signal("player_died")
	
	# Add the gravity.
	if not is_on_floor():
		velocity.y += gravity * delta
	else:
		jump_count = 0
		is_wall_jumping = false
	
	var direction = Input.get_axis("ui_left", "ui_right")
	
	# Handle Jump.
	if Input.is_action_just_pressed("ui_accept") and (is_on_floor() or is_on_wall()): # Add || jumpCount < 2 to allow double jump.
		velocity.y = JUMP_VELOCITY
		++jump_count
		
		if is_on_wall() and not is_on_floor():
			is_wall_jumping = true
			timer_wall_jump.start()
			velocity.x = -direction * (SPEED / 2)
	
	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.

	if is_wall_jumping:
		sprite.flip_h = direction < 0;
		sprite.play("wall_jump")
	elif direction:
		sprite.flip_h = direction < 0;
		if is_on_floor():
			velocity.x = direction * SPEED
			sprite.play("run")
		else:
			if is_on_wall_only() and Input.is_action_just_pressed("ui_accept"):
				velocity.x = -direction * (SPEED / 2)
			else:
				velocity.x = move_toward(velocity.x, direction * SPEED, SPEED / 2)
			
			if velocity.y > 0:
				sprite.play("fall")
			else:
				if jump_count == 1:
					sprite.play("jump")
				else:
					if is_on_wall():
						sprite.play("wall_jump")
					else:
						sprite.play("double_jump")
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		if is_on_floor():
			sprite.play("idle")
		else:
			if velocity.y > 0:
				sprite.play("fall")
			else:
				if jump_count == 1:
					sprite.play("jump")
				else:
					if is_on_wall():
						sprite.play("wall_jump")
					else:
						sprite.play("double_jump")

	move_and_slide()

func spawn(spawn_position: Vector2):
	position = spawn_position
	sprite.play("appear")
	timer_spawn.start()

func despawn():
	sprite.play("disappear")
	timer_despawn.start()

func _on_visible_on_screen_notifier_2d_screen_exited():
	emit_signal("player_died")

func _on_timer_wall_jump_timeout():
	is_wall_jumping = false

func _on_timer_spawn_timeout():
	emit_signal("player_spawned")

func _on_timer_de_spawn_timeout():
	emit_signal("player_despawned")
