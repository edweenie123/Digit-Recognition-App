using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

public class InitializeInput : MonoBehaviour {
	public static InitializeInput inst;
	public float lineWidth = 200f;
	public float feedforwardRefreshRate = 1f;

	public bool ableDraw = true;
	void Start () {
		inst = this;
		ResetBoard();
		

	}

	public void ChangeLineWidth(float newWidth){
		lineWidth = newWidth * 120f + 30;
	}
	
	public void ResetBoard(){
		foreach(Transform row in transform){
			foreach(Transform image in row){
				var tempColor = image.GetComponent<Image>().color;
				tempColor.a = 0;
				image.GetComponent<Image>().color = tempColor;
			}
		}
	}

	public Matrix<double> UpdateInput(){
		Matrix<double> inputArray = Matrix<double>.Build.Dense(20, 20);
		int y = -1;
		foreach(Transform row in transform){
			y += 1;
			int x = -1;
			foreach(Transform image in row){
				x += 1;
				float val = image.GetComponent<Image>().color.a / 255;
				inputArray.At(y, x, val);
			}
		}
		return inputArray;
	}

	public void PrintInput(){
		Matrix<double> inputMatrix = UpdateInput();
		// check if board is empty
		UIUpdater.inst.UpdateDrawDigitHereTextState(CheckBoardEmpty.inst.CheckIFBoardEmpty(inputMatrix));
		// build unwrapped version of input
		Matrix<double> wrappedInput = Matrix<double>.Build.Dense(1, 401);
		// add bias node
		wrappedInput.At(0,0,1);
		// mapping each pixel into the vector wrappedInput
		int counter = 1;
		for (int col = 0; col < 20; col++){
			for (int row = 0; row < 20; row++){
				wrappedInput.At(0,counter, inputMatrix.At(row, col));
				counter++;
			}
		}
		//print(wrappedInput);
		//print(wrappedInput);
		Feedforward(wrappedInput);
		
	}

	public void Feedforward(Matrix<double> input){
		// feed forward to get confidence for all digits
		Matrix<double> theta1 = InitializeTheta.inst.theta1;
		Matrix<double> theta2 = InitializeTheta.inst.theta2;
		Matrix<double> z1 = input.Multiply(theta1.Transpose());
		Matrix<double> a1 = SigmoidFunction.inst.Sigmoid(z1);
		Matrix<double> a1bias = Matrix<double>.Build.Dense(1, 26);
		a1bias.At(0,0,1);
		int colNum = 1;
		foreach(double elem in a1.Enumerate()){
			a1bias.At(0, colNum, elem);
			colNum++;
		}
		Matrix<double> z2 = a1bias.Multiply(theta2.Transpose());
		Matrix<double> a2 = SigmoidFunction.inst.Sigmoid(z2);
		
		// Find the 3 most confident digits

		double[] largestVar = new double[2];
		double[] seclargestVar = new double[2];
		double[] trdlargestVar = new double[2];
		for (int i = 0; i < 10; i++){
			if (i == 0){
				largestVar[0] = a2.At(0,i);
				largestVar[1] = i + 1;
			}else if (a2.At(0,i) > largestVar[0]){
				seclargestVar[0] = largestVar[0];
				seclargestVar[1] = largestVar[1];
				largestVar[0] = a2.At(0, i);
				largestVar[1] = i + 1;
			}else if (a2.At(0,i) > seclargestVar[0]){
				trdlargestVar[0] = seclargestVar[0];
				trdlargestVar[1] = seclargestVar[1];
				seclargestVar[0] = a2.At(0,i);
				seclargestVar[1] = i + 1;
			}
		}
		
		if (largestVar[1] == 10){
			largestVar[1] = 0;
		}
		if (seclargestVar[1] == 10){
			seclargestVar[1] = 0;
		}
		if (trdlargestVar[1] == 10){
			trdlargestVar[1] = 0;
		}
		double predictSum = a2.ColumnSums().Sum();
		UIUpdater.inst.UpdatePredictionText(largestVar, seclargestVar, trdlargestVar, predictSum);
		//print("The number is: " + largestVar[1] + " and the confidence is: " + largestVar[0]/predictSum);
	}

	float timer;
	void Update(){
		if (ableDraw){
			UpdateTouchInput();

			// timer for automatic feedforward
			timer += Time.deltaTime;
			if (timer > feedforwardRefreshRate){
				timer = 0;
				PrintInput();
			}
		}
		
	}
	void UpdateTouchInput(){
		if(Input.GetMouseButton(0)){
     		PointerEventData pointer = new PointerEventData(EventSystem.current);
     		pointer.position = Input.mousePosition;

			List<RaycastResult> raycastResults = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointer, raycastResults);

			if(raycastResults.Count > 0){
				foreach(var go in raycastResults){  
					Collider2D[] colliderHits = Physics2D.OverlapCircleAll(pointer.position, lineWidth);

					foreach(Collider2D col in colliderHits){
						Color tempCol = col.gameObject.GetComponent<Image>().color;
						tempCol.a = 255f;
						col.gameObject.GetComponent<Image>().color = tempCol;
					}
					
				}
			}
		}
	}
}
