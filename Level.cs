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

	[Signal]
	public delegate void Button1PushedEventHandler();

	[Signal]
	public delegate void Button2PushedEventHandler();

	[Signal]
	public delegate void Button3PushedEventHandler();

	[Signal]
	public delegate void Button4PushedEventHandler();

	[Signal]
	public delegate void Button5PushedEventHandler();

	[Signal]
	public delegate void Button6PushedEventHandler();

	[Signal]
	public delegate void Button7PushedEventHandler();

	[Signal]
	public delegate void Button8PushedEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_button_1_button_pushed()
	{
		EmitSignal(SignalName.Button1Pushed);
	}

	private void _on_button_2_button_pushed()
	{
		EmitSignal(SignalName.Button2Pushed);
	}

	private void _on_button_3_button_pushed()
	{
		EmitSignal(SignalName.Button3Pushed);
	}

	private void _on_button_4_button_pushed()
	{
		EmitSignal(SignalName.Button4Pushed);
	}

	private void _on_button_5_button_pushed()
	{
		EmitSignal(SignalName.Button5Pushed);
	}

	private void _on_button_6_button_pushed()
	{
		EmitSignal(SignalName.Button6Pushed);
	}

	private void _on_button_7_button_pushed()
	{
		EmitSignal(SignalName.Button7Pushed);
	}

	private void _on_button_8_button_pushed()
	{
		EmitSignal(SignalName.Button8Pushed);
	}
}
