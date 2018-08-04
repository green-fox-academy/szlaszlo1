package com.greenfoxacademy.tokenbasedapp.controllers;

import com.greenfoxacademy.tokenbasedapp.models.ErrorMessage;
import com.greenfoxacademy.tokenbasedapp.models.Post;
import com.greenfoxacademy.tokenbasedapp.services.PostService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class PostRestController {
    @Autowired
    PostService postService;

    @GetMapping("/getposts")
    public ResponseEntity<?> listPosts(){
        return ResponseEntity.status(200).body(postService.getPosts());
    }

    @GetMapping("/addnewpost")
    public ResponseEntity<?> addPost(@RequestParam(value = "description",required = false) String description,
                                     @RequestParam(value = "url",required = false) String url){
        if (description == null || url==null) {
            return ResponseEntity.status(HttpStatus.NO_CONTENT).body(new ErrorMessage("description or url not set"));
        }
        else{
            return ResponseEntity.status(200).body(postService.createPost(new Post(description,url)));
        }
    }
}
