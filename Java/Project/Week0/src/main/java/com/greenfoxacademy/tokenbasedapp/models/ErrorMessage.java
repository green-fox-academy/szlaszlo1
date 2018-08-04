package com.greenfoxacademy.tokenbasedapp.models;

public class ErrorMessage{

    public String errorMsg;

    public ErrorMessage() {
    }

    public ErrorMessage(String errorMsg) {
        this.errorMsg = errorMsg;
    }

    public String getErrorMsg() {
        return errorMsg;
    }

    public void setErrorMsg(String errorMsg) {
        this.errorMsg = errorMsg;
    }
}
