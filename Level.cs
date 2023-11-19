using Godot;
using System;

public partial class Level : Node2D
{
	[Export]
	public Marker2D StartPosition { get; set; }

	[Export]
	public button Button1 { get; set; }

	[Export]
	public button Button2 { get; set; }

	[Export]
	public button Button3 { get; set; }

	[Export]
	public button Button4 { get; set; }

	[Export]
	public button Button5 { get; set; }

	[Export]
	public button Button6 { get; set; }

	[Export]
	public button Button7 { get; set; }

	[Export]
	public button Button8 { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
