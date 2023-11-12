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
		Reset();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Viewport.Position = Player.Position;
	}

	private void _on_button_c_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Button1/AudioPlayer1");
		audioPlayer.Play();

		if (buttonIndex == 0)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Button1");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Button2");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_d_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Button2/AudioPlayer2");
		audioPlayer.Play();

		if (buttonIndex == 1)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Button2");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Button3");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_e_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Button3/AudioPlayer3");
		audioPlayer.Play();

		if (buttonIndex == 2)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Button3");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Button4");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_f_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Button4/AudioPlayer4");
		audioPlayer.Play();

		if (buttonIndex == 3)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Button4");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Button5");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_g_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Button5/AudioPlayer5");
		audioPlayer.Play();

		if (buttonIndex == 4)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Button5");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Button6");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_a_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Button6/AudioPlayer6");
		audioPlayer.Play();

		if (buttonIndex == 5)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Button6");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Button7");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_b_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Button7/AudioPlayer7");
		audioPlayer.Play();

		if (buttonIndex == 6)
		{
			buttonIndex++;
			var thisButton = GetNode<button>("Button7");
			thisButton.IsHighlighted = false;
			var nextButton = GetNode<button>("Button8");
			nextButton.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_c_2_button_pushed()
	{
		var audioPlayer = GetNode<AudioStreamPlayer>("Button8/AudioPlayer8");
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
		var button1 = GetNode<button>("Button1");
		button1.IsHighlighted = true;
	}
	
	private void Win()
	{
		// Zoom view into player
		
		// Play win sound (descending part of scale)

		// Move to next level
	}

	private void Fail()
	{
		var failAudioPlayer = GetNode<AudioStreamPlayer>("FailAudioPlayer");
		failAudioPlayer.Play();

		Reset();
	}
}
