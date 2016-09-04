using UnityEngine;
using System.Collections;

public class StepIn : MonoBehaviour 
{
	public GameObject m_portal;
	public AudioSource m_audio;
	private GameObject p_portal;
	private bool booliean = false;

	void Update()
	{
//		CamEffect ();
	}

	void CamEffect()
	{
		if(booliean == true)
		{
			p_portal.transform.GetChild (0).transform.GetComponent<Camera> ().fieldOfView -= 200* Time.deltaTime;

			if(p_portal.transform.GetChild (0).transform.GetComponent<Camera> ().fieldOfView <= 61)
			{
				booliean = false;
			}
		}
	}

	void OnCollisionEnter(Collision a_collision)
	{
		if (a_collision.gameObject.tag != "Player")
		{
			m_audio.Play ();
		}
	}

	void OnCollisionStay(Collision a_collision)
	{
		if (a_collision.gameObject.tag == "Player")
		{
			a_collision.transform.position = m_portal.transform.position;

			//a_collision.transform.GetChild (0).transform.GetComponent<Camera> ().fieldOfView = 158;

			p_portal = a_collision.gameObject;

			GetComponent<BoxCollider> ().enabled = false;

			m_portal.GetComponent<BoxCollider> ().enabled = false;

			booliean = true;

			Invoke ("Col", 2);
		} 
	}

	void Col()
	{
		GetComponent<BoxCollider> ().enabled = true;

		m_portal.GetComponent<BoxCollider> ().enabled = true;
	}
}
