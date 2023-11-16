using Godot;
using System;

public partial class game_menu : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_button_play_pressed()
	{
		// Load first level scene
		//GetTree().ChangeSceneToPacked(FirstLevel);
	}

	private void _on_button_quit_pressed()
	{
		// Quit the game
		GetTree().Quit();
	}

	private void _on_button_resume_pressed()
	{
		// Resume current game
		Hide();
		GetTree().Paused = false;
	}
}
