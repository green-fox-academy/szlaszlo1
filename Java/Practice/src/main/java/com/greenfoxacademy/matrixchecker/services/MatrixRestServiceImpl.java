package com.greenfoxacademy.matrixchecker.services;

import com.greenfoxacademy.matrixchecker.models.Matrix;
import com.greenfoxacademy.matrixchecker.repositories.MatrixRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;

@Service
public class MatrixRestServiceImpl implements MatrixRestService {
    @Autowired
    MatrixRepository matrixRepository;
    @Override
    public ArrayList<Matrix> getMatrices() {
        ArrayList<Matrix> matrices=new ArrayList<>();
        matrixRepository.findAll().forEach(matrices::add);
        return matrices;
    }
}
