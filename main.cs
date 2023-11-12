using Godot;
using System;

public partial class main : Node
{
	[Export]
	public Marker2D StartPosition { get; set; }
	
	[Export]
	public player Player { get; set; }

	public int buttonIndex = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_button_c_button_pushed()
	{
		var CAudioPlayer = GetNode<AudioStreamPlayer>("CAudioPlayer");
		CAudioPlayer.Play();
	}

	private void _on_button_d_button_pushed()
	{
		var DAudioPlayer = GetNode<AudioStreamPlayer>("DAudioPlayer");
		DAudioPlayer.Play();
	}

	private void _on_player_player_died()
	{
		Reset();
	}

	private void Reset()
	{
		var failAudioPlayer = GetNode<AudioStreamPlayer>("FailAudioPlayer");
		failAudioPlayer.Play();
		Player.Position = StartPosition.Position;
		GetTree().CallGroup("buttons", button.MethodName.Reset);
	}
}
