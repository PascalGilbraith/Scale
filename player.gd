extends CharacterBody2D
class_name player

const SPEED = 200.0
const ACCELERATION = 20.0
const DECELERATION = 100.0
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
	
	if is_on_wall():
		is_wall_jumping = false
	
	# Handle Jump.
	if Input.is_action_just_pressed("jump") and (is_on_floor() or is_on_wall()): # Add || jumpCount < 2 to allow double jump.
		if is_on_wall() and not is_on_floor():
			is_wall_jumping = true
			timer_wall_jump.start()
			var wall_direction = get_wall_normal()
			velocity = wall_direction * (SPEED / 2)
			sprite.play("wall_jump")
		
		velocity.y = JUMP_VELOCITY
		jump_count += 1
	
	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction = Input.get_axis("ui_left", "ui_right")

	if is_wall_jumping:
		if velocity.y > 0:
			sprite.flip_h = direction < 0;
			sprite.play("fall")
	elif direction:
		sprite.flip_h = direction < 0;
		if is_on_floor():
			velocity.x = move_toward(velocity.x, direction * SPEED, ACCELERATION)
			sprite.play("run")
		else:
			velocity.x = move_toward(velocity.x, direction * SPEED, ACCELERATION)

			if velocity.y > 0:
				if is_on_wall():
					var wall_direction = get_wall_normal()
					sprite.flip_h = wall_direction.x > 0;
					sprite.play("wall_jump")
				else:
					sprite.play("fall")
			else:
				sprite.play("jump")
	else:
		velocity.x = move_toward(velocity.x, 0, DECELERATION)
		if is_on_floor():
			sprite.play("idle")
		else:
			if velocity.y > 0:
				if is_on_wall():
					var wall_direction = get_wall_normal()
					sprite.flip_h = wall_direction.x > 0;
					sprite.play("wall_jump")
				else:
					sprite.play("fall")
			else:
				sprite.play("jump")

	move_and_slide()

func spawn(spawn_position: Vector2):
	position = spawn_position
	velocity = Vector2(0,0)
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
