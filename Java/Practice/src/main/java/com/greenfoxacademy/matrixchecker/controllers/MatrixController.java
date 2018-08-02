package com.greenfoxacademy.matrixchecker.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;

@Controller
public class MatrixController {

    @GetMapping("")
    public String main(){
        return "main";
    }

    @PostMapping("/matrix")
    public String checkIncreasingMatrix(String matrixNumbers){
        return "main";
    }
}
