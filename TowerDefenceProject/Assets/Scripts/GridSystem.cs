using UnityEngine;
using System.Collections;

public class GridSystem : MonoBehaviour {
	public GameObject tile;
	public Vector3 [,] position= new Vector3 [6,8];
	public GameObject [,]field= new GameObject[6,8];
	public GameObject warriorTower;
	public GameObject buildMenu;
	//string[,] names = new string[5,4];
	// Use this for initialization
	void Start () {
		warriorTower=Resources.Load("Towers/WarriorTower") as GameObject;
		buildMenu=Resources.Load("BuildMenu") as GameObject;
		tile=Resources.Load ("tile") as GameObject;
		for (int i=0;i<6;i++)
		{
		for(int j=0;j<8;j++)
			{
				position[i,j]=new Vector3(3.0f*j,0.0f,3.0f*i);
			}
		}
		for (int i=0;i<6;i++)
		{
		for(int j=0;j<8;j++)
			{
				field[i,j]=Instantiate(tile) as GameObject;
				field[i,j].transform.position=position[i,j];
				//Instantiate(field[i,j]);
			}
		}
		
	
	}
	
	// Update is called once per frame
	void Update () {
		Raycasting ();
	
	}
	void Raycasting()
	{
		
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))
			{
				if (hit.transform.gameObject.name.Contains("tile"))
				{
					for (int i=0;i<6;i++)
					{
						for(int j=0;j<8;j++)
						{
							if(hit.transform.gameObject.transform.position==position[i,j])
							{
								for(int a=0;a<6;a++)
								{
									for (int s=0;s<8;s++)
									{
										TileManager plot1= field[a,s].gameObject.GetComponent("TileManager") as TileManager;
										plot1.isActive=false;
										
									}
								}
								TileManager plot= field[i,j].gameObject.GetComponent("TileManager") as TileManager;
								plot.isActive=true;
								if (plot.isTaken==false)
								{
									Instantiate (buildMenu,camera.WorldToViewportPoint(plot.gameObject.transform.position+new Vector3(-10.5f,1.5f,-7.5f)),buildMenu.gameObject.transform.rotation);
									Instantiate(warriorTower,plot.gameObject.transform.position+new Vector3(0.0f,2.5f,0.0f),warriorTower.gameObject.transform.rotation);
									plot.isTaken=true;
								}
								else 
								{
								}
							}
						}
					}
				}
			}
		}
	}
	
}
