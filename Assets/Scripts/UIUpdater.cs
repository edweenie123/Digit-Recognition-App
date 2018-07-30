using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIUpdater : MonoBehaviour {
	public static UIUpdater inst;
	public Text predictionText;
	public Text DrawDigitHereText;
	public GameObject aboutPanel;
	public GameObject scrollRect;
	public GameObject horizontalToggle;

	public GameObject grid;
	public Toggle gridToggle;

	void Start(){
		inst = this;
	}

	public void UpdatePredictionText (double[] fir, double[] sec, double[] trd, double psum){
		double firConfidence = fir[0]/psum * 100;
		double secConfidence = sec[0]/psum * 100;
		double trdConfidence = trd[0]/psum * 100;
		predictionText.text = ">> 1st Prediction: " + fir[1] + " - " + Mathf.Round((float)firConfidence) + "%" + " Confidence \n" +
								">> 2nd Prediction: " + sec[1] + " - " + Mathf.Round((float)secConfidence) + "%" + " Confidence \n" +
								">> 3rd Prediction: " + trd[1] + " - " + Mathf.Round((float)trdConfidence) + "%" + " Confidence \n";
	}

	public void UpdateDrawDigitHereTextState(bool on){
		if (!on){
			DrawDigitHereText.gameObject.SetActive(false);
		}else{
			DrawDigitHereText.gameObject.SetActive(true);
		}
	}

	public void UpdateAboutPanelState(bool state){
		if (state){
			aboutPanel.SetActive(true);
			InitializeInput.inst.ableDraw = false;
		}else{
			aboutPanel.SetActive(false);
			InitializeInput.inst.ableDraw = true;
		}
	}

	public void UpdateScrolling(){
		if (horizontalToggle.GetComponent<Toggle>().isOn){
			scrollRect.GetComponent<ScrollRect>().horizontal = true;
		}else{
			scrollRect.GetComponent<ScrollRect>().horizontal = false;			
		}
	}

	public void UpdateGridToggle(){
		if (gridToggle.isOn){
			grid.SetActive(true);
		}else{
			grid.SetActive(false);
		}
	}
}
