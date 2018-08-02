package com.greenfoxacademy.matrixchecker.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import java.util.Date;

@Entity
public class Matrix {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    private Date checkDate;
    private String matrixNumbers;



    public Matrix(String matrixNumbers) {
        this.matrixNumbers = matrixNumbers;
        checkDate=new Date();
    }

    public Matrix() {
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Date getCheckDate() {
        return checkDate;
    }

    public void setCheckDate(Date checkDate) {
        this.checkDate = checkDate;
    }

    public String getMatrixNumbers() {
        return matrixNumbers;
    }

    public void setMatrixNumbers(String matrixNumbers) {
        this.matrixNumbers = matrixNumbers;
    }


}
