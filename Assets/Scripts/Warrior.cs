using UnityEngine;
using System.Collections;

public class Warrior : MonoBehaviour
{
	public int _warriorId;
	public string _warriorName;

	void Start ()
	{
		transform.GetComponentInChildren<TextMesh> ().text = _warriorName;
	}
}
