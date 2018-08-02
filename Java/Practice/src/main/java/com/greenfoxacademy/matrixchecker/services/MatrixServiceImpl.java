package com.greenfoxacademy.matrixchecker.services;

import org.springframework.stereotype.Service;

@Service
public class MatrixServiceImpl implements MatrixService {
    @Override
    public String validateMatrix(String matrixNumbers) {
        Boolean isSquare=true;
        Boolean isIncreasing=true;
        Boolean isAllNumeric=true;

        if (matrixNumbers != null) {
            String[] matrix = matrixNumbers.split("\r\n");
            Integer[][] numMatrix = new Integer[matrix.length][];
            for (int i = 0; i < matrix.length; i++) {
                String[] currentString=matrix[i].split(" ");
                if (currentString.length != matrix.length) {
                    isSquare=false;
                    break;
                }
                numMatrix[i]=new Integer[currentString.length];
                for (int j = 0; j < numMatrix[i].length ; j++) {
                    numMatrix[i][j]=Integer.parseInt(currentString[j]);

                }
            }
        }
        return "a";
    }
}
