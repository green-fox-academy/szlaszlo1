package com.greenfoxacademy.tokenbasedapp.services;

import com.greenfoxacademy.tokenbasedapp.models.ApplicationUser;
import com.greenfoxacademy.tokenbasedapp.repositories.ApplicationUserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Component;

@Component
public class PostUserDetailsService implements UserDetailsService {
    @Autowired
    ApplicationUserRepository applicationUserRepository;

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        ApplicationUser applicationUser=loadApplicationUserByName(username);
        applicationUser.setPassword("{noop}"+applicationUser.getPassword());
        return new User(applicationUser.getUsername(),applicationUser.getPassword(),
                AuthorityUtils.createAuthorityList(applicationUser.getRoles()));
    }

    public ApplicationUser loadApplicationUserByName(String username){
        return applicationUserRepository.findApplicationUserByUsername(username);
    }
}
