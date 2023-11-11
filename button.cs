using Godot;
using System;

public partial class button : Area2D
{
	[Signal]
	public delegate void ButtonPushedEventHandler();

	public bool IsPushed { get; private set; } = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_body_entered(Node2D body)
	{
		// TODO: Animate the button.
		if (!IsPushed)
		{
			// I'm only interested in collisions with the character (and maybe boxes in the future)
			if (body is player)
			{
				IsPushed = true;
				EmitSignal(SignalName.ButtonPushed);
			}
		}
	}
}
