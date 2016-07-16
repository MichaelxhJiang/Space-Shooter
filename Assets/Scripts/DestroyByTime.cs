using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour 
{
	public float lifetime;

	public void Start ()
	{
		Destroy (gameObject, lifetime);	
	}
}
