using Godot;
using System;

public partial class BoardController : Node2D
{
	[Export] int boardSize = 3;
	[Export] PackedScene boardChunk = null;

	private BoardChunk[] boardChunks;
	private int currentButtonNumber = 1;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		boardChunks = new BoardChunk[boardSize*boardSize];

		int boardChunksIndex = 0;

		for (int x = 0; x < boardSize; x++)
		{
			for (int y = 0; y < boardSize; y++)
			{
				BoardChunk newBoardChunk = boardChunk.Instantiate<BoardChunk>();

				AddChild(newBoardChunk);
				newBoardChunk.Name = "BoarChunk" + boardChunksIndex;

				Texture2D texture2D = newBoardChunk.Texture;

				float halfX = texture2D.GetSize().X * 0.5f;
				float halfY = texture2D.GetSize().Y * 0.5f;

				Vector2 newPosition = new Vector2((float)(texture2D.GetSize().X * x) + halfX, (float)(texture2D.GetSize().Y * y) + halfY);

				newBoardChunk.Position = newPosition;
				
				boardChunks[boardChunksIndex] = newBoardChunk;
				boardChunksIndex++;
			}
		}
	}

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseButton mouseButton)
		{
			if(!mouseButton.Pressed || mouseButton.ButtonIndex != MouseButton.Left) return;

			for (int i = 0; i < boardChunks.Length; i++)
			{
				SudokuCell cell = boardChunks[i].CheckIfCellsHaveMouseIn();

				if(cell == null) continue;

				cell.Clear();
				cell.AppendText($"[center][color=yellow]{currentButtonNumber}[/color][/center]");
			}
		}
    }

	public void SetSelectedCellContentNumber(int buttonNumber)
	{
		currentButtonNumber = buttonNumber;
	}

	
}
