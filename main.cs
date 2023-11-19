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

	private void _on_button_1_button_pushed()
	{
		Button1.PlaySound();

		if (buttonIndex == 0)
		{
			buttonIndex++;
			Button1.IsHighlighted = false;
			Button2.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_2_button_pushed()
	{
		Button2.PlaySound();

		if (buttonIndex == 1)
		{
			buttonIndex++;
			Button2.IsHighlighted = false;
			Button3.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_3_button_pushed()
	{
		Button3.PlaySound();

		if (buttonIndex == 2)
		{
			buttonIndex++;
			Button3.IsHighlighted = false;
			Button4.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_4_button_pushed()
	{
		Button4.PlaySound();

		if (buttonIndex == 3)
		{
			buttonIndex++;
			Button4.IsHighlighted = false;
			Button5.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_5_button_pushed()
	{
		Button5.PlaySound();

		if (buttonIndex == 4)
		{
			buttonIndex++;
			Button5.IsHighlighted = false;
			Button6.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_6_button_pushed()
	{
		Button6.PlaySound();

		if (buttonIndex == 5)
		{
			buttonIndex++;
			Button6.IsHighlighted = false;
			Button7.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_7_button_pushed()
	{
		Button7.PlaySound();

		if (buttonIndex == 6)
		{
			buttonIndex++;
			Button7.IsHighlighted = false;
			Button8.IsHighlighted = true;
		}
		else
		{
			Fail();
		}
	}

	private void _on_button_8_button_pushed()
	{
		Button8.PlaySound();

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

	private void _on_player_player_spawned()
	{
		GetTree().Paused = false;
	}

	private void _on_player_player_de_spawned()
	{
		if (NextLevel == null)
		{
			// End game
		}
		else
		{
			//CurrentLevel.Free();

			//var nextLevel = NextLevel.Instantiate<Level>();
			//AddChild(nextLevel);
			
			//CurrentLevel = nextLevel;
			// Load NextLevel
			GetTree().ChangeSceneToPacked(NextLevel);
		}
	}

	private void Reset()
	{
		buttonIndex = 0;
		GetTree().CallGroup("buttons", button.MethodName.Reset);
		Button1.IsHighlighted = true;

		Player.Spawn(StartPosition.Position);
	}
	
	private void Win()
	{
		// Zoom view into player
		
		// Play win sound (descending part of scale)

		// Move to next level
		Player.DeSpawn();
	}

	private void Fail()
	{
		FailAudioPlayer.Play();

		Reset();
	}
}
