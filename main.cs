using Godot;
using System;

public partial class main : Node
{
	[Export]
	public Marker2D StartPosition { get; set; }
	
	[Export]
	public player Player { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_player_player_died()
	{
		Reset();
	}

	private void Reset()
	{
		Player.Position = StartPosition.Position;
		GetTree().CallGroup("buttons", button.MethodName.Reset);
	}
}
