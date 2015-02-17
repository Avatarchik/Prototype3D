using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FreeMoveCamera : MonoBehaviour
{
	private RaycastHit hit;
	public float minLookAngle = -20f;
	public float maxLookAngle = 75f;
	public float minHeight = 2f;
	public float maxHeight = 5f;
	public float movementSpeed = 5f;
	public string TargetTag;
	private Vector3 cameraRotation;
	private Vector3 targetPosition;
	public Text _warriorName;
	public Text _warriorId;
	private string _id;
	private string _name;
	public SceneManager sceneContainer;
	private Vector2 scrollViewVector = Vector2.zero;
	private string warriorName;

	void Awake ()
	{
		targetPosition = transform.position;
		_id = _warriorId.text;
		_name = _warriorName.text;
	}

	void OnGUI ()
	{
		scrollViewVector = GUI.BeginScrollView (new Rect (5, 5, 200, Screen.height - 200), scrollViewVector, new Rect (0, 0, 200, Screen.height - 200));
		var warriorNameList = sceneContainer.WarriorsList;

		warriorName = "";

		foreach (WarriorObject w in warriorNameList) {
			warriorName += w.warriorName + "\n";
		}

		warriorName = GUI.TextArea (new Rect (0, 0, 200, Screen.height - 200), warriorName);
		
		GUI.EndScrollView ();
	}

	void Update ()
	{
		Vector3 moveOffset = Vector3.zero;
		float deltaTime = Time.deltaTime * 25f;

		cameraRotation.y = (cameraRotation.y + Input.GetAxis ("Mouse X")) % 360;
		cameraRotation.x = Mathf.Clamp (cameraRotation.x - Input.GetAxis ("Mouse Y"), minLookAngle, maxLookAngle);

		// движение камеры вперед/назад
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S)) {
			Vector3 newForward = transform.forward;
			newForward.y = 0;
			moveOffset += Input.GetKey (KeyCode.S) ? -1 * newForward : newForward;
		}

		// движение камеры влево/вправо
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			moveOffset += Input.GetKey (KeyCode.A) ? -transform.right : transform.right;
		}

		moveOffset = moveOffset.normalized * movementSpeed * Mathf.Sqrt (transform.position.y);

		targetPosition += moveOffset * Time.deltaTime;
		targetPosition.y = Mathf.Clamp (targetPosition.y, minHeight, maxHeight);
			
		transform.position = Vector3.Lerp (transform.position, targetPosition, deltaTime);
		transform.rotation = Quaternion.Lerp (Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, 0), Quaternion.Euler (cameraRotation), deltaTime);

		// получаем информацию о юните
		Ray ray = camera.ViewportPointToRay (new Vector3 (0.5F, 0.5F, 0));
		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetMouseButton (1)) {
				sceneContainer.removeUnit (hit.transform.GetComponent<Warrior> ()._warriorId);
				Destroy (hit.transform.gameObject);
			}
			// отображаем в гуи
			_warriorId.text = _id + hit.transform.GetComponent<Warrior> ()._warriorId;
			_warriorName.text = _name + hit.transform.GetComponent<Warrior> ()._warriorName;

		} else {
			_warriorId.text = _id;
			_warriorName.text = _name;
		}

		if (Input.GetMouseButton (0)) {
			Collider[] hitColliders = Physics.OverlapSphere (transform.position, 10);

			if (hitColliders.Length == 0)
				sceneContainer.createUnit (transform.position + ray.direction * 5);
		}
	}
}
