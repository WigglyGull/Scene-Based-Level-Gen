//LevelGenerator.cs: The Main Level Gen Script
using Godot;
using System.Collections.Generic;

public class LevelGenerator : Node2D{
    Vector2 worldSize = new Vector2(3, 10);
    Room[,] rooms;
    List<Vector2> takenPositions = new List<Vector2>();
    int gridSizeX, gridSizeY;
    int numberOfRooms;
    static PackedScene roomWhiteObj = ResourceLoader.Load("res://MapSprite.tscn") as PackedScene;
    RandomNumberGenerator rng = new RandomNumberGenerator();

    bool setSprite;
    bool endGen;

    Node2D currentLevel;
    Level levelScript;

    string upString;
    string downString;
    string leftString;
    string rightString;

    public override void _Ready(){
        rng.Randomize();
        numberOfRooms = rng.RandiRange(14, 18);
        if(numberOfRooms >= (worldSize.x * 2) * (worldSize.y * 2)) numberOfRooms = Mathf.RoundToInt((worldSize.x * 2) * (worldSize.y * 2));
        gridSizeX = Mathf.RoundToInt(worldSize.x);
        gridSizeY = Mathf.RoundToInt(worldSize.y);

        CreateRooms(); //lays out the actual map
        SetDoor(); //assigns the doors where rooms would connect
    }

    public override void _Process(float delta){
        if(!setSprite){
            SpawnRoom(); //gets position and sets room to match
            setSprite = true;
            endGen = false;
        }

        if(Input.IsActionJustPressed("ui_up") && levelScript.up){
            _ChangeScene(upString);
        }else if(Input.IsActionJustPressed("ui_down") && levelScript.down){
            _ChangeScene(downString);
        }else if(Input.IsActionJustPressed("ui_right") && levelScript.right){
            _ChangeScene(rightString);
        }else if(Input.IsActionJustPressed("ui_left") && levelScript.left){
            _ChangeScene(leftString);
        }
    }

    void _ChangeScene(string dirString){
        GetTree().ChangeScene(dirString);
        setSprite = false;
    }

    void CreateRooms(){
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];
        rooms[gridSizeX, gridSizeY] = new Room(Vector2.Zero, 1, 0);
        takenPositions.Insert(0, Vector2.Zero);
        Vector2 checkPos = Vector2.Zero;

        float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.01f;

        for(int i = 0; i < numberOfRooms - 1; i++){ //add rooms
            rng.Randomize();
            float randomPercent = ((float) i) / (((float) numberOfRooms - 1));
            randomCompare = Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPercent);
            checkPos = NewPosition(); //grab new position

            if(CheckNeighbours(checkPos, takenPositions) > 1 && rng.Randf() > randomCompare){ //test new position
                int itterations = 0;
                do{
                    checkPos = SelectiveNewPosition();
                    itterations++;
                }while(CheckNeighbours(checkPos, takenPositions) > 1 && itterations < 100);
            }

            //finalize position
            if(i == numberOfRooms -2)rooms[(int) checkPos.x + gridSizeX,(int) checkPos.y + gridSizeY] = new Room(checkPos, 2, takenPositions.Count); //Spawns Last Room
            else rooms[(int) checkPos.x + gridSizeX,(int) checkPos.y + gridSizeY] = new Room(checkPos, 0, takenPositions.Count); //Spawns Normal Room
            
            
            takenPositions.Insert(0, checkPos);
        }
    }

    Vector2 NewPosition(){
        int x = 0, y = 0;
		Vector2 checkingPos = Vector2.Zero;
		do{
            rng.Randomize();
			int index = Mathf.RoundToInt(rng.Randf() * (takenPositions.Count - 1)); // pick a random room
			x = (int) takenPositions[index].x;
			y = (int) takenPositions[index].y;
			bool UpDown = (rng.Randf() < 0.5f);
			bool positive = (rng.Randf() < 0.5f);
			if (UpDown){
				y -= 1;
			}else{
				if (positive) x += 1;
				else x -= 1;
			}
			checkingPos = new Vector2(x,y);
		}while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y < -gridSizeY); //make sure the position is valid
		return checkingPos;
    }

    int CheckNeighbours(Vector2 checkingPos, List<Vector2> usedPositions){
        //starts at zero, and adds 1 for each side there is already a room
        int ret = 0;
        if(usedPositions.Contains(checkingPos + Vector2.Right)) ret++;
        if(usedPositions.Contains(checkingPos + Vector2.Left)) ret++;
        if(usedPositions.Contains(checkingPos + Vector2.Up)) ret++;
        if(usedPositions.Contains(checkingPos + Vector2.Down)) ret++;
        return ret;
    }

    void RoomsBeside(Room currentPos){
        foreach (Room nieghbourRoom in rooms){
            if(nieghbourRoom == null) continue; //skip where there is no room
            if(nieghbourRoom.gridPos == currentPos.gridPos + Vector2.Up) upString = SetString(nieghbourRoom.index);
            if(nieghbourRoom.gridPos == currentPos.gridPos + Vector2.Down) downString = SetString(nieghbourRoom.index);
            if(nieghbourRoom.gridPos == currentPos.gridPos + Vector2.Left) leftString = SetString(nieghbourRoom.index);
            if(nieghbourRoom.gridPos == currentPos.gridPos + Vector2.Right) rightString = SetString(nieghbourRoom.index);   
        }
    }

    string SetString(int index){
        //Sets level depending on the index
        string dirString = "";
        switch(index){
            case 0: dirString = "res://Levels/Level.tscn";
                return dirString;
            case 1: dirString = "res://Levels/Level2.tscn";
                return dirString;
            case 2: dirString = "res://Levels/Level3.tscn";
                return dirString;
            case 3: dirString = "res://Levels/Level4.tscn";
                return dirString;
            case 4: dirString = "res://Levels/Level5.tscn";
                return dirString;
            case 5: dirString = "res://Levels/Level6.tscn";
                return dirString;
            case 6: dirString = "res://Levels/Level7.tscn";
                return dirString;
            case 7: dirString = "res://Levels/Level8.tscn";
                return dirString;
            case 8: dirString = "res://Levels/Level9.tscn";
                return dirString;
            case 9: dirString = "res://Levels/Level10.tscn";
                return dirString;
            case 10: dirString = "res://Levels/Level11.tscn";
                return dirString;
            case 11: dirString = "res://Levels/Level12.tscn";
                return dirString;
            case 12: dirString = "res://Levels/Level13.tscn";
                return dirString;
            case 13: dirString = "res://Levels/Level14.tscn";
                return dirString;
            case 14: dirString = "res://Levels/Level15.tscn";
                return dirString;
            case 15: dirString = "res://Levels/Level16.tscn";
                return dirString;
            case 16: dirString = "res://Levels/Level17.tscn";
                return dirString;
            case 17: dirString = "res://Levels/Level18.tscn";
                return dirString;
        }
        return dirString;
    }

    Vector2 SelectiveNewPosition(){
        int index = 0, inc = 0;
		int x =0, y =0;
		Vector2 checkingPos = Vector2.Zero;
		do{
            rng.Randomize();
			inc = 0;
			do{
				index = Mathf.RoundToInt(rng.Randf()  * (takenPositions.Count - 1));
				inc ++;
			}while (CheckNeighbours(takenPositions[index], takenPositions) > 1 && inc < 100);
			x = (int) takenPositions[index].x;
			y = (int) takenPositions[index].y;
			bool UpDown = (rng.Randf() < 0.5f);
			bool positive = (rng.Randf() < 0.5f);
			if (UpDown){
				y -= 1;
			}else{
				if (positive){
					x += 1;
				}else{
					x -= 1;
				}
			}
			checkingPos = new Vector2(x,y);
		}while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y < -gridSizeY);
		return checkingPos;
    }

    void SetDoor(){
        for (int x = 0; x < ((gridSizeX * 2)); x++){
			for (int y = 0; y < ((gridSizeY * 2)); y++){
				if (rooms[x,y] == null) continue;
				
				Vector2 gridPosition = new Vector2(x,y);
				if (y - 1 < 0) rooms[x,y].doorTop = false;
				else rooms[x,y].doorTop = (rooms[x,y-1] != null);
				
				if (y + 1 >= gridSizeY * 2) rooms[x,y].doorBot = false;
				else rooms[x,y].doorBot = (rooms[x,y+1] != null);
				
				if (x - 1 < 0) rooms[x,y].doorLeft = false;
				else rooms[x,y].doorLeft = (rooms[x - 1,y] != null);
				
				if (x + 1 >= gridSizeX * 2) rooms[x,y].doorRight = false;
				else rooms[x,y].doorRight = (rooms[x+1,y] != null);
			}
		}
    }

    void SpawnRoom(){
        foreach (Room room in rooms){
            if(room == null) continue; //skip where there is no room
            currentLevel = GetTree().GetRoot().GetNode<Node2D>("Level");
            levelScript = currentLevel as Level;

            if(room.index == levelScript.roomIndex){
                RoomsBeside(room);
                levelScript.up = room.doorTop;
                levelScript.down = room.doorBot;
                levelScript.right = room.doorRight;
                levelScript.left = room.doorLeft;
            }
        }
    }
}