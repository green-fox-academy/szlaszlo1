package com.greenfoxacademy.tokenbasedapp.security;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.env.Environment;

public class SecurityConstants {


    public static final String SECRET=System.getenv("jwtSecret");
    public static final String TOKEN_PREFIX = System.getenv("tokenPrefix");
    public static final String HEADER_STRING = System.getenv("headerString");
    public static final long EXPIRATION_TIME = 900_000L;
}
