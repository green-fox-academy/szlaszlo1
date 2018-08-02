package com.greenfoxacademy.matrixchecker.services;

import org.springframework.stereotype.Service;

@Service
public interface MatrixService {
    String validateMatrix(String matrixNumbers);
}
