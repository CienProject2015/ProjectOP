using UnityEngine;
using System.Collections;

public class HologramAnim : MonoBehaviour {

	public Vector2 animRate;
	private Vector2 offset = Vector2.zero;

	void Update () {
		offset += animRate * Time.deltaTime;
		GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", offset);
	}
}
