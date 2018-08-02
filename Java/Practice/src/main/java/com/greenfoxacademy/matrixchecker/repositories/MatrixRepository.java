package com.greenfoxacademy.matrixchecker.repositories;

import com.greenfoxacademy.matrixchecker.models.Matrix;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface MatrixRepository extends CrudRepository<Matrix,Integer> {
}
