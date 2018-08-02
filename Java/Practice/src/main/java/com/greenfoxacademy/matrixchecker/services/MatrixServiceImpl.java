package com.greenfoxacademy.matrixchecker.services;

import com.greenfoxacademy.matrixchecker.models.Matrix;
import com.greenfoxacademy.matrixchecker.repositories.MatrixRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class MatrixServiceImpl implements MatrixService {

    @Autowired
    MatrixRepository matrixRepository;

    @Override
    public String validateMatrix(String matrixNumbers) {
        Boolean isSquare=true;
        Boolean isIncreasing=true;
        Boolean isAllNumeric=true;
        String returnMessage="The matrix is increasing!";
        if (matrixNumbers != null) {
            String[] matrix = matrixNumbers.split("\r\n");
            Integer[][] numMatrix = new Integer[matrix.length][];
            for (int i = 0; i < matrix.length; i++) {
                String[] currentString=matrix[i].split(" ");
                if (currentString.length != matrix.length) {
                    isSquare=false;
                    returnMessage="This is not a square matrix";
                    break;
                }
                numMatrix[i]=new Integer[currentString.length];
                for (int j = 0; j < numMatrix[i].length ; j++) {
                    try {
                        numMatrix[i][j]=Integer.parseInt(currentString[j]);
                    }
                    catch (NumberFormatException e){
                        isAllNumeric=false;
                        returnMessage="Not all member is numeric";
                    }
                }
            }
            if (isAllNumeric && isSquare) {
                for (int i = 0; i <numMatrix.length; i++) {
                    for (int j = 0; j <numMatrix[i].length ; j++) {
                        if (i<numMatrix.length-1&& numMatrix[i][j]>numMatrix[i+1][j] || j<numMatrix[i].length-1 && numMatrix[i][j]>numMatrix[i][j+1]) {
                            isIncreasing=false;
                            returnMessage="Matrix is not increasing";
                        }
                    }
                }
                if (isIncreasing) {
                    matrixRepository.save(new Matrix(matrixNumbers));
                }
            }
        }
        else {
            returnMessage="Empty input";
        }
        return returnMessage;
    }
}
