using Godot;
using System;
using System.Diagnostics;

public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -300.0f;

	private int jumpCount = 0;
	private bool isWallJumping = false;
	
	[Export]
	public Timer TimerWallJump { get; set; }

	[Export]
	public Timer SpawnTimer { get; set; }

	[Export]
	public Timer DeSpawnTimer { get; set; }

	[Export]
	public AnimatedSprite2D Sprite { get; set; }

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	[Signal]
	public delegate void PlayerDiedEventHandler();

	[Signal]
	public delegate void PlayerSpawnedEventHandler();

	[Signal]
	public delegate void PlayerDeSpawnedEventHandler();

	public override void _PhysicsProcess(double delta)
	{
		if (!SpawnTimer.IsStopped() || !DeSpawnTimer.IsStopped())
		{
			return;
		}

		// Check for collisions with spikes.
		var collisionCount = GetSlideCollisionCount();
		for (int i = 0; i < collisionCount; i++)
		{
			var collision = GetSlideCollision(i);
			var collider = collision.GetCollider();
			if (collider is spike)
			{
				EmitSignal(SignalName.PlayerDied);
			}
		}

		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
		}
		else
		{
			jumpCount = 0;
			isWallJumping = false;
		}

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && (IsOnFloor() || IsOnWall())) // Add || jumpCount < 2 to allow double jump.
		{
			velocity.Y = JumpVelocity;
			jumpCount++;

			if (IsOnWall() && !IsOnFloor())
			{
				isWallJumping = IsOnWall();
				TimerWallJump.Start();
				velocity.X = -direction.X * (Speed / 2);
			}
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		
		if (isWallJumping)
		{
			Sprite.FlipH = direction.X < 0;
			Sprite.Play("wall_jump");
		}
		else if (direction != Vector2.Zero)
		{
			Sprite.FlipH = direction.X < 0;
			if (IsOnFloor())
			{
				velocity.X = direction.X * Speed;
				Sprite.Play("run");
			}
			else
			{
				if (IsOnWallOnly() && Input.IsActionJustPressed("ui_accept"))
				{
					velocity.X = -direction.X * (Speed / 2);
				}
				else
				{
					velocity.X = Mathf.MoveToward(Velocity.X, direction.X * Speed, Speed * 2);
				}

				if (velocity.Y > 0)
				{
					Sprite.Play("fall");
				}
				else
				{
					if (jumpCount == 1)
					{
						Sprite.Play("jump");
					}
					else
					{
						if (IsOnWall())
						{
							Sprite.Play("wall_jump");
						}
						else
						{
							Sprite.Play("double_jump");
						}
					}
				}
			}
			
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			if (IsOnFloor())
			{
				Sprite.Play("idle");
			}
			else
			{
				if (velocity.Y > 0)
				{
					Sprite.Play("fall");
				}
				else
				{
					if (jumpCount == 1)
					{
						Sprite.Play("jump");
					}
					else
					{
						if (IsOnWall())
						{
							Sprite.Play("wall_jump");
						}
						else
						{
							Sprite.Play("double_jump");
						}
					}
				}
			}
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void Spawn(Vector2 position)
	{
		Position = position;
		Sprite.Play("appear");
		SpawnTimer.Start();
	}

	public void DeSpawn()
	{
		Sprite.Play("disappear");
		DeSpawnTimer.Start();
	}

	private void _on_visible_on_screen_notifier_2d_screen_exited()
	{
		// We shouldn't be able to exit the screen, but just in case...
		EmitSignal(SignalName.PlayerDied);
	}

	private void _on_timer_wall_jump_timeout()
	{
		isWallJumping = false;
	}

	private void _on_timer_spawn_timeout()
	{
		EmitSignal(SignalName.PlayerSpawned);
	}

	private void _on_timer_de_spawn_timeout()
	{
		EmitSignal(SignalName.PlayerDeSpawned);
	}
}
