using UnityEngine;
using UnityEngine.UI;
public class GridColorChanger : MonoBehaviour {

	public Color color;
	void Start () {
		ChangeColor();
	}
	
	void ChangeColor(){
		foreach(Transform row in transform){
			foreach(Transform image in row){
				image.GetComponent<Image>().color = color;
			}
		}
	}
}
