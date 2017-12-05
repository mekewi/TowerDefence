using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this class generate Enviroment Grid at run time
 */
public class bounds
{
	public float MinX;
	public float MaxX;
	public float MinY;
	public float MaxY;
}
[System.Serializable]
public class GridGenerator : MonoBehaviour {

	public int cellSize;
	public int numberOfRows;
	public int numberOfColumns;
	public float spaceBetween;
	[SerializeField]
	private Transform cellPrefab;
	[SerializeField]
	private Transform gridParent;
	[SerializeField]
	private Transform ground;
	public bounds PlayGroundBounds;


	// This Method to Draw The Grid Or Update it if there variables changed over life Time
	public void DrawUpdateGrid(){
		PlayGroundBounds = new bounds ();
		for (int columnIndex = 0; columnIndex < numberOfColumns; columnIndex++) {
			for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++) {
				Transform CellObject;
//				int cellIndex = getCellIndex (columnIndex, rowIndex);
//				if (cellIndex < gridParent.childCount) {
//					CellObject = gridParent.GetChild (cellIndex);
//				} else {
					CellObject = Instantiate (cellPrefab, gridParent) as Transform;
//				}
				float correctPositionX = ((columnIndex * spaceBetween) + columnIndex) * cellSize;
				float correctPositionY = (((rowIndex * spaceBetween) + rowIndex)) * cellSize;
 						
				CellObject.localPosition = new Vector3 (correctPositionX,correctPositionY);
				CellObject.localScale = new Vector3 (cellSize, 0.1f, cellSize);
				CellObject.name = (columnIndex +","+ rowIndex+" : Index : "+getCellIndex(columnIndex,rowIndex));
			}
		}
		PlayGroundBounds.MinX = 0;
		PlayGroundBounds.MaxX = (float)cellSize * (float)numberOfColumns-(float)cellSize;
		PlayGroundBounds.MinY = 0;
		PlayGroundBounds.MaxY = (float)cellSize * (float)numberOfRows-(float)cellSize;

		ground.localScale = new Vector3 (((float)cellSize * (float)numberOfColumns) / 10.0f, 1, ((float)cellSize * (float)numberOfRows) / 10.0f);
		ground.localPosition = new Vector3 (((float)cellSize * (float)numberOfColumns)/2-((float)cellSize/2), (((float)cellSize * (float)numberOfRows)/2-((float)cellSize/2)), 0);
		getbounds ();
		GamePlayBusses.instance.GridGeneratedSuccess ();
	}
	public GameObject GetCellByCoordinate(CellDetails cellCoordinate){
		int CellIndexInParent =  getCellIndex (cellCoordinate.ColumnIndex, cellCoordinate.RowIndex);
		return gridParent.GetChild (CellIndexInParent).gameObject;
	} 
	// Use this for initialization
	void Start () {
	}
	void Awake(){
	}
	public int getCellIndex(int column,int row){
		int cellIndex = (column * (numberOfRows)) + row;
		return cellIndex;
	}
	public void getbounds(){
		Debug.Log ("MaxX : " + PlayGroundBounds.MaxX + "  MaxY : " + PlayGroundBounds.MaxY);
	}
}
