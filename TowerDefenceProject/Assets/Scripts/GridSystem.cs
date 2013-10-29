using UnityEngine;
using System.Collections;

public class GridSystem : MonoBehaviour {
	public GameObject tile;
	public Vector3 [,] position= new Vector3 [3,7];
	public GameObject [,]field= new GameObject[3,7];
	//string[,] names = new string[5,4];
	// Use this for initialization
	void Start () {
		for (int i=0;i<3;i++)
		{
		for(int j=0;j<7;j++)
			{
				position[i,j]=new Vector3(2.0f*j,0.0f,2.0f*i);
			}
		}
		for (int i=0;i<3;i++)
		{
		for(int j=0;j<7;j++)
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
					for (int i=0;i<3;i++)
					{
						for(int j=0;j<7;j++)
						{
							if(hit.transform.gameObject.transform.position==position[i,j])
							{
								for(int a=0;a<3;a++)
								{
									for (int s=0;s<7;s++)
									{
										TileManager plot1= field[a,s].gameObject.GetComponent("TileManager") as TileManager;
										plot1.isActive=false;
										
									}
								}
								TileManager plot= field[i,j].gameObject.GetComponent("TileManager") as TileManager;
								plot.isActive=true;
							}
						}
					}
				}
			}
		}
	}
	
}
