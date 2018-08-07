package com.greenfoxacademy.tokenbasedapp.services;

import com.greenfoxacademy.tokenbasedapp.models.ApplicationUser;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Component;

@Component
public class PostUserDetailsService implements UserDetailsService {
    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        ApplicationUser applicationUser=loadApplicationUserByName(username);
        return new User(applicationUser.getUserName(),applicationUser.getPassword(),
                AuthorityUtils.createAuthorityList("ROLE_USER"));
    }

    public ApplicationUser loadApplicationUserByName(String userName){
        return new ApplicationUser("userName","pass");
    }
}
