using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

public class SigmoidFunction : MonoBehaviour {

	public static SigmoidFunction inst;

	double e = 2.71828182845;
	void Start(){
		inst = this;
	}

	public Matrix<double> Sigmoid (Matrix<double> input){
		Matrix<double> sigmoidInput = Matrix<double>.Build.Dense(input.RowCount, input.ColumnCount);
		int rowNum = -1;
		int colNum = -1;
		foreach(Vector<double> row in input.EnumerateRows()){
			rowNum++;
			foreach(double elem in row){
				colNum++;
				double sigmoidElem = 1 / (1 + Math.Pow(e, -elem));
				sigmoidInput.At(rowNum, colNum, sigmoidElem);
			}
			colNum = -1;
		}
		
		return (sigmoidInput);
	}
}
