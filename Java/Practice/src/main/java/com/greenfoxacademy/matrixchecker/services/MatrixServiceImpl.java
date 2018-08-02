package com.greenfoxacademy.matrixchecker.services;

import org.springframework.stereotype.Service;

@Service
public class MatrixServiceImpl implements MatrixService {
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
                for (int i = 0; i <numMatrix.length-1 ; i++) {
                    for (int j = 0; j <numMatrix[i].length-1 ; j++) {
                        if (numMatrix[i][j]>numMatrix[i][j+1] ||numMatrix[i][j]>numMatrix[i+1][j]) {
                            isIncreasing=false;
                            returnMessage="Matrix is not increasing";
                        }
                    }
                }
                if (isIncreasing) {

                }
            }
        }
        else {
            returnMessage="Empty input";
        }
        return "a";
    }
}
