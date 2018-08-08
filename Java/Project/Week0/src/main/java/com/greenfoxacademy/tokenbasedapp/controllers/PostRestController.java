package com.greenfoxacademy.tokenbasedapp.controllers;

import com.greenfoxacademy.tokenbasedapp.models.ErrorMessage;
import com.greenfoxacademy.tokenbasedapp.models.Post;
import com.greenfoxacademy.tokenbasedapp.services.PostService;
import netscape.security.ForbiddenTargetException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

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
        return  ResponseEntity.status(200).body(postService.createPost(new Post(description,url)));
    }


}
