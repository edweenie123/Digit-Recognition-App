using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

public class CheckBoardEmpty : MonoBehaviour {
	public static CheckBoardEmpty inst;

	void Start(){
		inst = this;
	}

	public bool CheckIFBoardEmpty(Matrix<double> inputMatrix){
		bool isEmpty = true;
		if (inputMatrix.ColumnSums().Sum() > 0){
			isEmpty = false;
		}
		return isEmpty;
	}
}
