using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	private int jumpCount = 0;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
		}
		else
		{
			jumpCount = 0;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && (IsOnFloor() || IsOnWall())) // Add || jumpCount < 2 to allow double jump.
		{
			velocity.Y = JumpVelocity;
			jumpCount++;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			animatedSprite2D.FlipH = direction.X < 0;
			if (IsOnFloor())
			{
				velocity.X = direction.X * Speed;
				animatedSprite2D.Play("run");
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
					animatedSprite2D.Play("fall");
				}
				else
				{
					if (jumpCount == 1)
					{
						animatedSprite2D.Play("jump");
					}
					else
					{
						if (IsOnWall())
						{
							animatedSprite2D.Play("wall_jump");
						}
						else
						{
							animatedSprite2D.Play("double_jump");
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
				animatedSprite2D.Play("idle");
			}
			else
			{
				if (velocity.Y > 0)
				{
					animatedSprite2D.Play("fall");
				}
				else
				{
					if (jumpCount == 1)
					{
						animatedSprite2D.Play("jump");
					}
					else
					{
						if (IsOnWall())
						{
							animatedSprite2D.Play("wall_jump");
						}
						else
						{
							animatedSprite2D.Play("double_jump");
						}
					}
				}
			}
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
