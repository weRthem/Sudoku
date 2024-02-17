using Godot;
using System;

public partial class Sprite2D : Godot.Sprite2D
{
	[Export] float rotationSpeed = 1f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		FlipV = true;

		Modulate = new Color(1f, 0f, 0f);
	}	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//Rotate(rotationSpeed);
	}
}
