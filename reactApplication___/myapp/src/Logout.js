import React, { Component } from 'react';
import { Redirect } from 'react-router';
import { Container } from 'react-bootstrap';

export default class Logout extends Component{
    constructor(props){
        super(props);
        this.logout = this.logout.bind(this);
    }

    logout = () => {  
   
      localStorage.removeItem("user");
      localStorage.removeItem("token");
        //localStorage.clear();
        //window.location.reload();
       
    } 
    render(){
        return (
             <Redirect to='/'/>
        )
    } 
}
 
