package com.greenfoxacademy.tokenbasedapp.services;

import com.greenfoxacademy.tokenbasedapp.models.Post;
import org.springframework.stereotype.Service;

@Service
public interface PostService {
    void createPost(Post post);
    
}
