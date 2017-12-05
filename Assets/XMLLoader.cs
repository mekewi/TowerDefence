using UnityEngine;

using System.Collections;

using System.Collections.Generic; //Needed for Lists

using System.Xml; //Needed for XML functionality

using System.Xml.Serialization; //Needed for XML Functionality

using System.IO;

using System.Xml.Linq; //Needed for XDocument
[System.Serializable]
public class turretData
{
	public int Range;
	public int BulletSpeed;
	public CellDetails Position;
}
public class XMLLoader : MonoBehaviour {

	XDocument xmlDoc; //create Xdocument. Will be used later to read XML file IEnumerable<XElement> items; //Create an Ienumerable list. Will be used to store XML Items. List <XMLData> data = new List <XMLData>(); //Initialize List of XMLData objects.
	public List<turretData> turrets;
	public int PlayerHealth;
	public CellDetails PlayerPosition;

	void Start ()

	{
		LoadXML ();

	}

	void Update ()

	{
	}

	void LoadXML()

	{
		xmlDoc = XDocument.Load( "Assets/Resources/GameData.xml");
		AssignData ();
	}

	void AssignData()
	{
		string rows = xmlDoc.Element ("Game").Element ("Grid").Element ("Rows").Value;
		string columns = xmlDoc.Element ("Game").Element ("Grid").Element ("Columns").Value;
		GamePlayBusses.instance.playingGrid.numberOfRows = int.Parse (rows);
		GamePlayBusses.instance.playingGrid.numberOfColumns = int.Parse (columns);

		string PlayerPositionCellColumn = xmlDoc.Element ("Game").Element ("Player").Element ("Position").Element ("Column").Value;
		string PlayerPositionCellRow = xmlDoc.Element ("Game").Element ("Player").Element ("Position").Element ("Row").Value;
		string _PlayerHealth = xmlDoc.Element ("Game").Element ("Player").Element ("Health").Value;

		PlayerPosition = new CellDetails ();
		PlayerPosition.ColumnIndex = int.Parse (PlayerPositionCellColumn);
		PlayerPosition.RowIndex = int.Parse (PlayerPositionCellRow);
		PlayerHealth = int.Parse (_PlayerHealth);

		XElement turretsXML = xmlDoc.Element ("Game").Element ("turrets");
		turrets = new List<turretData> ();
		foreach (XElement item in turretsXML.Elements()) {
			turretData turretDataXml = new turretData ();
			turretDataXml.Range = int.Parse (item.Element ("Information").Element ("turretRange").Value);
			turretDataXml.BulletSpeed = int.Parse (item.Element ("Information").Element ("BulletSpeed").Value);
			turretDataXml.Position = new CellDetails ();
			turretDataXml.Position.RowIndex = int.Parse (item.Element ("Position").Element ("Row").Value);
			turretDataXml.Position.ColumnIndex = int.Parse (item.Element ("Position").Element ("Column").Value);
			turrets.Add (turretDataXml);
		}
		GamePlayBusses.instance.GenerateGrid ();

	}
}

