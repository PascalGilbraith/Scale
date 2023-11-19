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
	public game_menu GameMenu { get; set; }

	[Export]
	public PackedScene NextLevel { get; set; }

	[Export]
	public button button1 { get; set; }

	[Export]
	public button button2 { get; set; }

	[Export]
	public button button3 { get; set; }

	[Export]
	public button button4 { get; set; }

	[Export]
	public button button5 { get; set; }

	[Export]
	public button button6 { get; set; }

	[Export]
	public button button7 { get; set; }

	[Export]
	public button button8 { get; set; }

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
		button1.PlaySound();

		if (buttonIndex == 0)
		{
			buttonIndex++;
			button1.IsHighlighted = false;
			button2.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_d_button_pushed()
	{
		button2.PlaySound();

		if (buttonIndex == 1)
		{
			buttonIndex++;
			button2.IsHighlighted = false;
			button3.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_e_button_pushed()
	{
		button3.PlaySound();

		if (buttonIndex == 2)
		{
			buttonIndex++;
			button3.IsHighlighted = false;
			button4.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_f_button_pushed()
	{
		button4.PlaySound();

		if (buttonIndex == 3)
		{
			buttonIndex++;
			button4.IsHighlighted = false;
			button5.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_g_button_pushed()
	{
		button5.PlaySound();

		if (buttonIndex == 4)
		{
			buttonIndex++;
			button5.IsHighlighted = false;
			button6.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_a_button_pushed()
	{
		button6.PlaySound();

		if (buttonIndex == 5)
		{
			buttonIndex++;
			button6.IsHighlighted = false;
			button7.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_b_button_pushed()
	{
		button7.PlaySound();

		if (buttonIndex == 6)
		{
			buttonIndex++;
			button7.IsHighlighted = false;
			button8.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_c_2_button_pushed()
	{
		button8.PlaySound();

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
