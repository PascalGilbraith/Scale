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

	[Export]
	public PackedScene NextLevel { get; set; }

	public int buttonIndex = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Hide the game menu
		var gameMenu = GetNode<game_menu>("Viewport/GameMenu");
		gameMenu.Hide();
		
		Reset();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Viewport.Position = Player.Position;

		// If escape or pause pressed open the main menu
		if (Input.IsActionJustPressed("ui_cancel") || Input.IsActionJustPressed("pause"))
		{
			// Pause game
			GetTree().Paused = true;

			// Enable the game menu
			var gameMenu = GetNode<game_menu>("Viewport/GameMenu");
			gameMenu.Show();
		}
	}

	private void _on_button_c_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Level/Button1/AudioPlayer1");
		audioPlayer.Play();

		if (buttonIndex == 0)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Level/Button1");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Level/Button2");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_d_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Level/Button2/AudioPlayer2");
		audioPlayer.Play();

		if (buttonIndex == 1)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Level/Button2");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Level/Button3");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_e_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Level/Button3/AudioPlayer3");
		audioPlayer.Play();

		if (buttonIndex == 2)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Level/Button3");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Level/Button4");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_f_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Level/Button4/AudioPlayer4");
		audioPlayer.Play();

		if (buttonIndex == 3)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Level/Button4");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Level/Button5");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_g_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Level/Button5/AudioPlayer5");
		audioPlayer.Play();

		if (buttonIndex == 4)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Level/Button5");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Level/Button6");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_a_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Level/Button6/AudioPlayer6");
		audioPlayer.Play();

		if (buttonIndex == 5)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Level/Button6");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Level/Button7");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_b_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Level/Button7/AudioPlayer7");
		audioPlayer.Play();

		if (buttonIndex == 6)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Level/Button7");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Level/Button8");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_c_2_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Level/Button8/AudioPlayer8");
		audioPlayer.Play();

		if (buttonIndex == 7)
		{
			Win();
		}
		else
		{
			Fail();
		}
	}

	private void _on_player_player_died()
	{
		Fail();
	}

	private void Reset()
	{
		buttonIndex = 0;
		Player.Position = StartPosition.Position;
		GetTree().CallGroup("buttons", button.MethodName.Reset);
		var button1 = GetNode<button>("Level/Button1");
		button1.IsHighlighted = true;
	}
	
	private void Win()
	{
		// Zoom view into player
		
		// Play win sound (descending part of scale)

		// Move to next level
		GetTree().ChangeSceneToPacked(NextLevel);
	}

	private void Fail()
	{
		var failAudioPlayer = GetNode<AudioStreamPlayer>("FailAudioPlayer");
		failAudioPlayer.Play();

		Reset();
	}
}
