package com.greenfoxacademy.tokenbasedapp.repositories;

import com.greenfoxacademy.tokenbasedapp.models.ApplicationUser;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ApplicationUserRepository extends CrudRepository<ApplicationUser,Integer> {
    ApplicationUser findApplicationUserByUsername(String username);
}
