using UnityEngine;
using System.Collections;

public class plasterpuffscript : MonoBehaviour {
	public float opac= 0.0f;

	void  UpdateColor (){
		var renderers= transform.GetComponentsInChildren<MeshRenderer>();
		var color= new Vector4(0,0,0,opac*0.2f);
		foreach(var renderer in renderers){
			renderer.material.SetColor("_TintColor", color);
		}
	}

	void  Start (){
		opac = Random.Range(0.0f,1.0f);
		UpdateColor();
		var localEuler = transform.localEulerAngles;
		localEuler.z = Random.Range (0.0f, 360.0f);
		transform.localEulerAngles = localEuler;
		transform.localScale = new Vector3(Random.Range(0.8f,2.0f), Random.Range(0.8f,2.0f), Random.Range(0.8f,2.0f));
	}

	void  Update (){
		UpdateColor();
		opac -= Time.deltaTime * 10.0f;
		transform.localScale += new Vector3(1,1,1)*Time.deltaTime*30.0f;
		if(opac <= 0.0f){
			Destroy(gameObject);
		}
	}
}