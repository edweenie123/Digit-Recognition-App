using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

public class InitializeTheta : MonoBehaviour {

	public static InitializeTheta inst;

	public Matrix<double> theta1 = Matrix<double>.Build.Dense(25, 401);
	public Matrix<double> theta2 = Matrix<double>.Build.Dense(10, 26);  
	
	public TextAsset theta1Text;
	public TextAsset theta2Text;

	void Start(){
		inst = this;
		ImportTheta1and2();
	}
	void ImportTheta1and2(){
		// importing theta1
		if (theta1Text != null){
			// splitting each line of theta1
			string[] theta1Lines = (theta1Text.text.Split('\n'));
			
			for (int i = 0; i < theta1Lines.Length; i++){
				// convert each element of theta1Lines to a double
				double[] doubleArray = Array.ConvertAll(theta1Lines[i].Split(' '), double.Parse);
				Vector<double> doubleVector = Vector<double>.Build.Dense(401);
				// converting double[] into vector
				int count = 0;
				foreach(double elem in doubleArray){
					doubleVector.At(count, elem);
					count++;
				}
				theta1.SetRow(i, doubleVector);
			}
			//print(theta1);
		}
		// importing theta2
		if (theta1Text != null){
			// splitting each line of theta2
			string[] theta2Lines = (theta2Text.text.Split('\n'));
			
			for (int i = 0; i < theta2Lines.Length; i++){
				// convert each element of theta2Lines to a double
				double[] doubleArray = Array.ConvertAll(theta2Lines[i].Split(' '), double.Parse);
				Vector<double> doubleVector = Vector<double>.Build.Dense(26);
				// converting double[] into vector
				int count = 0;
				foreach(double elem in doubleArray){
					doubleVector.At(count, elem);
					count++;
				}
				theta2.SetRow(i, doubleVector);
			}
			//print(theta2);
		}

	}

}
