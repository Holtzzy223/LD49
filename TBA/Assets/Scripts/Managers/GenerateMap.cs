using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
	public int mapHeight = 0;
	public int mapWidth =0;
	public Vector2 genPos = new Vector2(0,0);
	public bool gen = true;
	public int  ranNode;
	public enum RoomType
	{ 
		
	};
	private int roomsGenerated;
	public int RoomMax;
    
	public void GenRooms(int mapHeight, int mapWidth, Vector2 genPos)
	{
		//set RoomMax in macros or alternatively ghaneg to global variable

		if (gen == true)
		{
			do
			{
				ranNode = Random.Range(0, 3);
				roomType = Random.Range(0, 3);// Type of room to spawn
				roomsGenerated++;

				if (roomsGenerated >= RoomMax)
				{
					gen = false;
				}
				if (ranNode == 0 && doorTop == false)
				{
					//Set random room placement
					doorTop = false;
					doorBottom = true;
					doorLeft = false;
					doorRight = false;
					//Door
					instance_create_layer(genX + (mapWidth / 2), genY + 46, "Doors", oDoorTop);
					genY -= mapHeight;
					//Main Room Obj
					instance_create_depth(genX, genY, depth, oRoom);
					//Room Type

					switch (roomType)
					{
						case 0: //Rest
								//DO SOMETHING
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomMob);
							break;

						case 1: //mob/Trap Room
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomMob);
							break;

						case 2: //Trap/Puzzle
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomTrap);
							break;

					}


					//Door
					instance_create_layer(genX + (mapWidth / 2), genY + (mapHeight - 46), "Doors", oDoorBottom);

				}
				if (ranNode == 1 && doorBottom == false)
				{
					//Set random room placement
					doorTop = true;
					doorBottom = false;
					doorLeft = false;
					doorRight = false;

					instance_create_layer(genX + (mapWidth / 2), genY + (mapHeight - 46), "Doors", oDoorBottom);
					genY += mapHeight;
					instance_create_depth(genX, genY, depth, oRoom);
					switch (roomType)
					{
						case 0: //Rest
								//DO SOMETHING
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomMob);
							break;

						case 1: //mob/Trap Room
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomMob);
							break;

						case 2: //Trap/Puzzle
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomTrap);
							break;

					}

					instance_create_layer(genX + (mapWidth / 2), genY + 46, "Doors", oDoorTop);

				}
				if (ranNode == 2 && doorRight == false)
				{
					//Set random room placement
					doorRight = false;
					doorTop = false;
					doorBottom = false;
					doorLeft = true;


					instance_create_layer(genX + (mapWidth - (46)), genY + (mapHeight / 2), "Doors", oDoorRight);
					genX += mapWidth;
					instance_create_depth(genX, genY, depth, oRoom);
					switch (roomType)
					{
						case 0: //Rest
								//DO SOMETHING
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomMob);
							break;

						case 1: //mob/Trap Room
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomMob);
							break;

						case 2: //Trap/Puzzle
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomTrap);
							break;

					}
					instance_create_layer(genX + 46, genY + (mapHeight / 2), "Doors", oDoorLeft);

				}
				if (ranNode == 3 && doorLeft == false)
				{
					//Set random room placement
					doorLeft = false;
					doorTop = false;
					doorBottom = false;
					doorRight = true;

					instance_create_layer(genX + 46, genY + (mapHeight / 2), "Doors", oDoorLeft);
					genX -= mapWidth;
					instance_create_depth(genX, genY, depth, oRoom);
					switch (roomType)
					{
						case 0: //Rest
								//DO SOMETHING
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomMob);
							break;

						case 1: //mob/Trap Room
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomMob);
							break;

						case 2: //Trap/Puzzle
							instance_create_depth(genX + (mapWidth / 2), genY + (mapHeight / 2), depth, oRoomTrap);
							break;

					}
					instance_create_layer(genX + (mapWidth - 46), genY + (mapHeight / 2), "Doors", oDoorRight);

				}

			}

			while (roomsGenerated >= RoomMax);
		}

	}
}
