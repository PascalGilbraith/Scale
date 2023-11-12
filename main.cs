using Godot;
using System;

public partial class main : Node
{
	[Export]
	public Marker2D StartPosition { get; set; }
	
	[Export]
	public player Player { get; set; }

	[Export]
	public Camera2D Viewport { get; set; }

	public int buttonIndex = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Viewport.Position = Player.Position;
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

	private void _on_button_e_button_pushed()
	{
		var EAudioPlayer = GetNode<AudioStreamPlayer>("EAudioPlayer");
		EAudioPlayer.Play();
	}

	private void _on_button_f_button_pushed()
	{
		var FAudioPlayer = GetNode<AudioStreamPlayer>("FAudioPlayer");
		FAudioPlayer.Play();
	}

	private void _on_button_g_button_pushed()
	{
		var GAudioPlayer = GetNode<AudioStreamPlayer>("GAudioPlayer");
		GAudioPlayer.Play();
	}

	private void _on_button_a_button_pushed()
	{
		var AAudioPlayer = GetNode<AudioStreamPlayer>("AAudioPlayer");
		AAudioPlayer.Play();
	}

	private void _on_button_b_button_pushed()
	{
		var BAudioPlayer = GetNode<AudioStreamPlayer>("BAudioPlayer");
		BAudioPlayer.Play();
	}

	private void _on_button_c_2_button_pushed()
	{
		var C2AudioPlayer = GetNode<AudioStreamPlayer>("C2AudioPlayer");
		C2AudioPlayer.Play();
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
	
	private void Win()
	{
		// Zoom view into player
		
		// Play win sound (descending part of scale)

		// Move to next level
	}
}
