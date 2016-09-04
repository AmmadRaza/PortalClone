using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour 
{
	public float m_speed, minX = -180.0f, maxX = 180.0f, minY = -45.0f, maxY = 45.0f, sensX = 50.0f, sensY = 50.0f, rotationY = 0.0f, rotationX = 0.0f;
	private bool IsNearPortal = false;
	private GameObject a_portal;
	internal float m_rotationX;

	void Start () 
	{
		Cursor.visible = false;
	}

	void Update () 
	{
		PlayerBehavior ();
	}

	void PlayerBehavior()
	{
		Move ("w", Vector3.forward);
		Move ("s", Vector3.back);
		Move ("d", Vector3.right);
		Move ("a", Vector3.left);

		CamRotator ();
	}

	void Move(string a_key, Vector3 a_move)
	{
		if (Input.GetKey (a_key)) 
		{
			transform.Translate(a_move * m_speed * Time.deltaTime);
		}
	}

	void CamRotator()
	{
		rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;

		rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;

		rotationY = Mathf.Clamp (rotationY, minY, maxY);

		if(IsNearPortal == false)
		{
			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		}
		else if (IsNearPortal == true)
		{
			Vector3 ss = transform.position - a_portal.transform.position;

			transform.rotation = Quaternion.LookRotation (ss);

			IsNearPortal = false;
		}

		m_rotationX = rotationX;
	}

	void OnCollisionEnter(Collision a_collision)
	{
		if(a_collision.gameObject.tag == "Portal")
		{
			a_portal = a_collision.gameObject;

			IsNearPortal = true;
		}
	}
}
