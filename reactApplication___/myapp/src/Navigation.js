import React,{ Component } from "react";
import {NavLink} from 'react-router-dom';
import { Navbar, Nav } from "react-bootstrap";
import ShoppingCartIcon from "@material-ui/icons/ShoppingCart";
import { Upload } from "./Upload";



export class Navigation extends Component {

    loggingOut(e) 
    {
     e.preventDefault();
       localStorage.removeItem("token");
       localStorage.removeItem("user");
       window.location.href ="/";
    
    }

    render()
    {
        return (
            
          <Navbar  expand="lg" style={{backgroundColor:"white"}}> 
              <div className="container">
              <Navbar.Toggle aria-controles="basic-navbar-nav" />
              <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                            <Nav.Link className="active" href="/">Home</Nav.Link>
                                {localStorage.getItem("user") !== null ? <Nav.Link href="/Employees">Employees</Nav.Link>: ''}
                            <Nav.Link href="/Students">Students</Nav.Link>
                            <Nav.Link href="/Courses">Courses</Nav.Link> 
                            <Nav.Link href="/StudentsDetail">detail</Nav.Link>
                            <Nav.Link href="/items">items</Nav.Link>
                            <Nav.Link href="/categories">categories</Nav.Link>
                            <Nav.Link href="/About">About</Nav.Link>    
                    </Nav>
                    <Nav className="ml-auto">
                        {localStorage.getItem("user") == null ? <Nav.Link href="/login">sign in</Nav.Link>   : <Nav.Link > {localStorage.getItem("user")}</Nav.Link>}


                        {localStorage.getItem("user") !== null ?  <Nav.Link  onClick={this.loggingOut.bind(this)}>sign out</Nav.Link> : <Nav.Link href="/register">sign up</Nav.Link> }
                        <Nav.Link href="/Cart">
                          <ShoppingCartIcon/>{`4`}
                        </Nav.Link>
                        
                        
                    </Nav>
              </Navbar.Collapse>
              </div>
             
          </Navbar>
          
        ); 

    }
}