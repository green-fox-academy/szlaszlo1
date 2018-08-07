package com.greenfoxacademy.tokenbasedapp.security;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.crypto.password.PasswordEncoder;

import static org.springframework.security.crypto.password.NoOpPasswordEncoder.*;

@Configuration
@EnableWebSecurity
public class SecurityConfig extends WebSecurityConfigurerAdapter {


    @Override
    public void configure(HttpSecurity httpSecurity) throws Exception{
        httpSecurity
                .authorizeRequests()
                    .antMatchers("/getposts").hasRole("ADMIN")
                    .antMatchers("/addnewpost*").hasRole("USER")
                .and()
                    .formLogin();
    }

    @Autowired
    public void configureGlobal(AuthenticationManagerBuilder auth) throws Exception{
        auth.inMemoryAuthentication()
                .withUser("phil").password("1234").roles("USER")
                .and()
                .withUser("admin").password("Admin1234").roles("USER","ADMIN");
    }

    @Bean
    public PasswordEncoder passwordEncoder(){
        return getInstance();
    }
}
