package com.greenfoxacademy.tokenbasedapp.security;

import com.greenfoxacademy.tokenbasedapp.models.ApplicationUser;
import com.greenfoxacademy.tokenbasedapp.models.JWTUserDetails;
import com.greenfoxacademy.tokenbasedapp.services.PostUserDetailsService;
import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.core.context.SecurityContext;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.web.authentication.www.BasicAuthenticationFilter;

import javax.servlet.FilterChain;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.List;

import static com.greenfoxacademy.tokenbasedapp.security.SecurityConstants.HEADER_STRING;
import static com.greenfoxacademy.tokenbasedapp.security.SecurityConstants.SECRET;
import static com.greenfoxacademy.tokenbasedapp.security.SecurityConstants.TOKEN_PREFIX;

public class JWTAuthorizationFilter extends BasicAuthenticationFilter {
    private final PostUserDetailsService postUserDetailsService;

    public JWTAuthorizationFilter(AuthenticationManager authenticationManager, PostUserDetailsService postUserDetailsService) {
        super(authenticationManager);
        this.postUserDetailsService = postUserDetailsService;
    }


    //block unauthorized requests
    @Override
    protected void doFilterInternal(HttpServletRequest request,
                                    HttpServletResponse response,
                                    FilterChain chain) throws IOException, ServletException {
        String header=request.getHeader(HEADER_STRING);
        if (header == null || !header.startsWith(TOKEN_PREFIX)) {
            chain.doFilter(request,response);
            return;
        }
        UsernamePasswordAuthenticationToken userPasswordAuth=getAuthenticationToken(request);
        SecurityContextHolder.getContext().setAuthentication(userPasswordAuth);
        chain.doFilter(request,response);
    }

    public UsernamePasswordAuthenticationToken getAuthenticationToken(HttpServletRequest request){
        String token=request.getHeader(HEADER_STRING);
        if (token==null)return null;
        Claims body= Jwts.parser().setSigningKey(SECRET)
                .parseClaimsJws(token.replace(TOKEN_PREFIX,""))
                .getBody();

        ApplicationUser appUser=new ApplicationUser();
        appUser.setUsername(body.getSubject());
        appUser.setRoles((String)body.get("role"));


        List<GrantedAuthority> grantedAuthorities= AuthorityUtils.commaSeparatedStringToAuthorityList(appUser.getRoles());
        JWTUserDetails userDetails=new JWTUserDetails(appUser.getUsername(),appUser.getPassword(),grantedAuthorities);
        //UserDetails userDetails=postUserDetailsService.loadUserByUsername(userName);
        //ApplicationUser applicationUser=postUserDetailsService.loadApplicationUserByName(userName);
        return appUser!=null?new UsernamePasswordAuthenticationToken(appUser,null,userDetails.getAuthorities()):null;
    }
}
