package com.greenfoxacademy.tokenbasedapp.repositories;

import com.greenfoxacademy.tokenbasedapp.models.Post;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface PostRepository extends CrudRepository<Post,Integer> {
}
