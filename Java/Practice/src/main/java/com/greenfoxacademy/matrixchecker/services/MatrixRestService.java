package com.greenfoxacademy.matrixchecker.services;

import com.greenfoxacademy.matrixchecker.models.Matrix;
import org.springframework.stereotype.Service;

import java.util.ArrayList;

@Service
public interface MatrixRestService {
    ArrayList<Matrix> getMatrices();
}
