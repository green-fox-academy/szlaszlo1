package com.greenfoxacademy.tokenbasedapp.services;

import com.greenfoxacademy.tokenbasedapp.models.Post;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface PostService {
    Post createPost(Post post);
    Iterable<Post> getPosts();
    void updatePost(Post post);
    void deletePost(Post post);
}
