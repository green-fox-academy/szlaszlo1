package com.greenfoxacademy.matrixchecker.controllers;

import com.greenfoxacademy.matrixchecker.services.MatrixService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;

@Controller
public class MatrixController {
    @Autowired
    MatrixService matrixService;

    @GetMapping("")
    public String main(){
        return "main";
    }

    @PostMapping("/matrix")
    public String checkIncreasingMatrix(String matrixNumbers){
        matrixService.validateMatrix(matrixNumbers);
        return "main";
    }
}
