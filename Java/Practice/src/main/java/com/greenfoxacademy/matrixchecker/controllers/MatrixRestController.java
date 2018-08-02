package com.greenfoxacademy.matrixchecker.controllers;


import com.greenfoxacademy.matrixchecker.models.Matrix;
import com.greenfoxacademy.matrixchecker.services.MatrixRestService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class MatrixRestController {
    @Autowired
    MatrixRestService matrixRestService;
    @GetMapping("/matrices")
    public ResponseEntity<?> getMatrices(){
        List<Matrix> matrixList = matrixRestService.getMatrices();
        return ResponseEntity.status(200).body(matrixList);
    }
}
