package com.greenfoxacademy.matrixchecker.controllers;

import com.greenfoxacademy.matrixchecker.services.MatrixService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class MatrixController {
    @Autowired
    MatrixService matrixService;

    @GetMapping("")
    public String main(){
        return "main";
    }

    @PostMapping("/matrix")
    public String checkIncreasingMatrix(@RequestParam(name = "matrixNumbers",required = false) String matrixNumbers, Model model){
        model.addAttribute("result",matrixService.validateMatrix(matrixNumbers));
        return "main";
    }
}
