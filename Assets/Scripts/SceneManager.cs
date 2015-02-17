using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarriorObject
{
	public int warriorId { get; set; }

	public string warriorName { get; set; }

	public Vector3 warriorPosition;
	public Quaternion warriorRotation;

	public string warriorPrefab { get; set; }
}

public class SceneManager : MonoBehaviour
{

	public List<WarriorObject> WarriorsList;
	public  int currentId;

	void Start ()
	{
		GameObject warriorPrefab;
		WarriorsList = DataXMLSerializer.ReadFromXmlFile<List<WarriorObject>> ("Assets/Resource/warriors.xml");

		foreach (WarriorObject _warrior in WarriorsList) {	
			warriorPrefab = GameObject.Find (_warrior.warriorPrefab);

			if (warriorPrefab != null) {
				GameObject instance = Instantiate (warriorPrefab, _warrior.warriorPosition, _warrior.warriorRotation) as GameObject;
				instance.GetComponent<Warrior> ()._warriorName = _warrior.warriorName;
				instance.GetComponent<Warrior> ()._warriorId = currentId = _warrior.warriorId;
			}
		}
	}

	public void createUnit (Vector3 position)
	{
		var nposition = new Vector3 (position.x, 1, position.z);

		WarriorObject unit = new WarriorObject {
			warriorName = getRandomName(),
			warriorId = WarriorsList.Count + 1,
			warriorPosition = nposition,
			warriorRotation = new Quaternion(0,0,0,0),
			warriorPrefab = "Warrior"
			
		};

		WarriorsList.Add (unit);

		GameObject warriorPrefab = GameObject.Find (unit.warriorPrefab);
		
		if (warriorPrefab != null) {
			GameObject instance = Instantiate (warriorPrefab, nposition, new Quaternion (0, 0, 0, 0)) as GameObject;
			instance.GetComponent<Warrior> ()._warriorName = unit.warriorName;
			instance.GetComponent<Warrior> ()._warriorId = unit.warriorId;
		}
		DataXMLSerializer.WriteToXmlFile<List<WarriorObject>> ("Assets/Resource/warriors.xml", WarriorsList);
	}

	public void removeUnit (int Id)
	{
		WarriorsList.RemoveAll (x => x.warriorId == Id);
		DataXMLSerializer.WriteToXmlFile<List<WarriorObject>> ("Assets/Resource/warriors.xml", WarriorsList);
	}

	public string getRandomName ()
	{	
		string warrior_firstNames_data = "Aaye Aelin Adanedhel Aduial Aglarond Aha Ai Aina Ainu Aiglos Alda Alqua Amandil Amarth Amon Anarya Anca Ando Anga Asca Barad Brethil Bragol Carca";
		string warrior_lastNames_data = "Coranar Coron Daro Dina Drego Edhel Edain Eldarin Elenya Ennor Enyd Eryn Esse Estel Minas Gaur Gurth Silme Ulaer";
		
		string[] warrior_firstNames = warrior_firstNames_data.Split (' ');
		string[] warrior_lastNames = warrior_lastNames_data.Split (' ');

		return warrior_firstNames [Random.Range (0, warrior_firstNames.Length - 1)] + " " + warrior_lastNames [Random.Range (0, warrior_lastNames.Length - 1)];	                                                                                         
	}

}
