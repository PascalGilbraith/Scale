using Godot;
using System;

public partial class main : Node
{
	[Export]
	public player Player { get; set; }

	[Export]
	public Camera2D Viewport { get; set; }

	[Export]
	public game_menu GameMenu { get; set; }

	[Export]
	public AudioStreamPlayer FailAudioPlayer { get; set; }

	[Export]
	public PackedScene NextLevel { get; set; }

	[Export]
	public Level CurrentLevel { get; set; }

	public int buttonIndex = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Hide the game menu
		GameMenu.Hide();
		
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
			GameMenu.Show();
		}
	}

	private void _on_button_c_button_pushed()
	{
		CurrentLevel.Button1.PlaySound();

		if (buttonIndex == 0)
		{
			buttonIndex++;
			CurrentLevel.Button1.IsHighlighted = false;
			CurrentLevel.Button2.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_d_button_pushed()
	{
		CurrentLevel.Button2.PlaySound();

		if (buttonIndex == 1)
		{
			buttonIndex++;
			CurrentLevel.Button2.IsHighlighted = false;
			CurrentLevel.Button3.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_e_button_pushed()
	{
		CurrentLevel.Button3.PlaySound();

		if (buttonIndex == 2)
		{
			buttonIndex++;
			CurrentLevel.Button3.IsHighlighted = false;
			CurrentLevel.Button4.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_f_button_pushed()
	{
		CurrentLevel.Button4.PlaySound();

		if (buttonIndex == 3)
		{
			buttonIndex++;
			CurrentLevel.Button4.IsHighlighted = false;
			CurrentLevel.Button5.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_g_button_pushed()
	{
		CurrentLevel.Button5.PlaySound();

		if (buttonIndex == 4)
		{
			buttonIndex++;
			CurrentLevel.Button5.IsHighlighted = false;
			CurrentLevel.Button6.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_a_button_pushed()
	{
		CurrentLevel.Button6.PlaySound();

		if (buttonIndex == 5)
		{
			buttonIndex++;
			CurrentLevel.Button6.IsHighlighted = false;
			CurrentLevel.Button7.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_b_button_pushed()
	{
		CurrentLevel.Button7.PlaySound();

		if (buttonIndex == 6)
		{
			buttonIndex++;
			CurrentLevel.Button7.IsHighlighted = false;
			CurrentLevel.Button8.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_c_2_button_pushed()
	{
		CurrentLevel.Button8.PlaySound();

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
		Player.Position = CurrentLevel.StartPosition.Position;
		GetTree().CallGroup("buttons", button.MethodName.Reset);
		CurrentLevel.Button1.IsHighlighted = true;
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
		FailAudioPlayer.Play();

		Reset();
	}
}
