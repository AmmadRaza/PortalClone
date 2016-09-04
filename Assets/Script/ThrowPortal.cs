using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThrowPortal : MonoBehaviour 
{
	public GameObject m_leftPortal, m_rightPortal, mainCamera, info;

	public AudioSource m_audio;

	public float m_speed;

	private int m_activator = 2;

	void Start()
	{
		Invoke ("InfoPanalDeactivate", 8);
	}

	void InfoPanalDeactivate()
	{
		info.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{	
		Portals ();
		
		Portal (0, m_leftPortal);

		if (m_activator == 0) 
		{
			PortalBehavior(m_leftPortal);
		}

		if (m_activator == 1) 
		{
			PortalBehavior(m_rightPortal);
		}

		Portal (1, m_rightPortal);
	}
		
	void Portal(int a_mousebutton, GameObject a_portal)
	{
		if (Input.GetMouseButtonDown (a_mousebutton)) 
		{
//			a_portal.transform.GetChild (0).transform.GetComponent<Image> ().fillAmount = 0;
//
//			a_portal.transform.GetChild (1).transform.GetComponent<Image> ().fillAmount = 0;

			if(!m_audio.isPlaying)
			{
				m_activator = a_mousebutton;

				throwThosePortals (a_portal);

				m_audio.Play ();
			}
		}
	}

	void PortalBehavior(GameObject a_portal) 
	{
//		a_portal.transform.GetChild(0).transform.GetComponent<Image> ().fillAmount +=  m_speed;
//
//		a_portal.transform.GetChild(1).transform.GetComponent<Image> ().fillAmount +=  m_speed;
//
//		if(a_portal.transform.GetChild(0).transform.GetComponent<Image> ().fillAmount >= 360)
//		{
			m_activator = 2;
//		}
	}

	void throwThosePortals(GameObject portal)
	{
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3 (x, y));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) 
		{
			Quaternion hitObjectRotation = Quaternion.LookRotation (hit.normal);
			
			portal.transform.position = hit.point;

			portal.transform.rotation = hitObjectRotation;
		}
	}

	void Portals()
	{
//		foreach (GameObject a_portal in GameObject.FindGameObjectsWithTag("Portal")) 
//		{
//			Vector3 dis = transform.position - a_portal.transform.position;
//
//			if (dis.magnitude <= 15) 
//			{
////				a_portal.transform.GetChild (1).GetComponent<Camera> ().fieldOfView = transform.GetComponent<PlayerControl> ().m_speed;
//				
//				a_portal.transform.GetChild (1).transform.eulerAngles = new Vector3 (0, transform.GetComponent<PlayerControl> ().m_rotationX, 0);
//			} 
//			else 
//			{
//				a_portal.transform.GetChild (1).transform.eulerAngles = new Vector3 (0, /*Mathf.Lerp(a_portal.transform.GetChild (1).transform.eulerAngles.y, a_portal.transform.eulerAngles.y, Time.deltaTime)*/ a_portal.transform.eulerAngles.y, 0);
//			}
//		}
	}
}
