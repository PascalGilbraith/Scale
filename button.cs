using Godot;
using System;

public partial class button : Area2D
{
	[Signal]
	public delegate void ButtonPushedEventHandler();

	[Export]
	public AudioStream Sound { get; set; }

	[Export]
	public AudioStreamPlayer2D AudioPlayer { get; set; }

	[Export]
	public AnimatedSprite2D Sprite { get; set; }

	[Export]
	public PointLight2D Highlight { get; set; }

	public bool IsPushed { get; private set; } = false;
	public bool IsSingleUse { get; set; } = false;

	private bool isHighlighted;
	public bool IsHighlighted {
		get => isHighlighted;
		set
		{
			isHighlighted = value;
			Highlight.Enabled = isHighlighted;
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Set audio from audio stream
		AudioPlayer.Stream = Sound;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Since we don't loop the animation we need to return to idle once it's done
		if (Sprite.Animation == "press" && Sprite.FrameProgress == 1)
		{
			Sprite.Play("idle");
		}
	}

	private void _on_body_entered(Node2D body)
	{
		// I'm only interested in collisions with the character (and maybe boxes in the future)
		if (body is player)
		{
			Sprite.Play("press");

			if (!IsSingleUse || !IsPushed)
			{
				EmitSignal(SignalName.ButtonPushed);
			}
			IsPushed = true;
		}
	}

	public void Reset()
	{
		IsPushed = false;
		IsHighlighted = false;
	}

	public void PlaySound()
	{
		AudioPlayer.Play();
	}
}
