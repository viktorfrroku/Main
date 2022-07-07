import React,{ Component } from "react";
import { Button, ButtonToolBar } from "react-bootstrap";
import { AddModelPopup } from "./AddModelPopup";
import { Row, Col, Form, Card } from 'react-bootstrap';
import Cookies from 'universal-cookie';
import { Redirect, useHistory } from "react-router-dom";




const regularExpression = RegExp(/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[A-Za-z]+$/);
const user = localStorage.getItem('token'); 


//const coockies = new Cookies();
//coockies.set(user.username, user.authToken, {path: 'https://localhost:3001/'});

const validation = ({ error, ...rest}) => {

    let checkValidation = false;

    Object.values(error).forEach(val => {
        if(val.length > 0)
        {
            checkValidation = false;
        }
        else {
            checkValidation = true;
        }

    });

    Object.values(rest).forEach(val => {
        if(val.length > 0)
        {
            checkValidation = false;
        }
        else {
            checkValidation = true;
        }
    })

    return checkValidation;
}






export class Login extends Component {

    constructor(props)
    {
       super(props);
      // const token = setState(""),
      // const user = setState(""),
        this.state = {
        username :'',
        email:'',
        password :'',
        error: {
            username :'',
            email:'',
            password :''
        }
       }
       
    }

    formObject = event => {
        event.preventDefault();
        const {name, value} = event.target;
        let error = {...this.state.error};

        switch (name) {
            case 'username':
                error.username = value.length < 5 ? 'Name should be more than 5 caracters long' :  '';
                
                break;
           case 'password':
                error.password = value.length < 5 ? 'Name should be more than 5 caracters long' :  '';                
                break;
        
            default:
                break;
        }
        this.setState({
            error,
            [name]: value
        })
    };
    

   
    onFormSubmit_LoginUser = event =>
    {
        event.preventDefault();
                           
        if(validation(this.state))
        {
            console.log(this.state);
            
        }
        else {
            console.log('error ocured..');
        }
        fetch('https://localhost:5001/Login/Login',{
           // mode:'no-cors',
            method:'POST',
            credentials:'include',
            headers:{
               // 'Access-Control-Allow-Origin': 'https://localhost:5001',
                'Content-Type':'application/json',
                'Accept':'application/json',
                          
               },
            
            body:JSON.stringify({
                UserName:event.target.username.value,
                Email:event.target.email.value,
                Password:event.target.password.value
            })
        })
        .then(res => res.json())
        .then(result => {
            localStorage.setItem("token", result.token);
            localStorage.setItem("user",event.target.username.value);

            window.location.pathname= "/";
           }        
           
            
         //console.log(result)
         );
        
      
        
       return <Redirect  to='/'/>;
        

    }

  



    render()
    {
      const {error} = this.state;
        return (
          
                        
            <Row className="d-flex justify-content-center">
            <Col sm={4}>
            <Card >
                <Card.Header style={{backgroundColor:'#ddd'}}>
                <h1>Login</h1>
                </Card.Header>
                <Card.Body>
                    
                        <form className='form-group' onSubmit={this.onFormSubmit_LoginUser}>
                            <small className="text-danger ml-auto">*</small>

                            <input
                               //  required
                                 type="text" 
                                 name="username" 
                                 placeholder="username"
                                 onChange={this.formObject}
                                 className = {error.username.length > 0 ? "is-invalid form-control":"form-control"}
                                 /> 
                             <span className="invalid-feedback">{error.username}</span>                           

                            <small className="text-danger">*</small>

                            
                            <input
                               //  required
                                 type="text" 
                                 name="email" 
                                 placeholder="email"
                                 onChange={this.formObject}
                                 className = {error.email.length > 0 ? "is-invalid form-control":"form-control"}
                                 /> 
                             <span className="invalid-feedback">{error.email}</span>                           

                            <small className="text-danger">*</small>

                                                
                            <input
                                // required
                                 type="password" 
                                 name="password" 
                                 placeholder="password"
                                 onChange={this.formObject}
                                 className = {error.password.length > 0 ? "is-invalid form-control":"form-control"}
                                 
                                 />
                               <span className="invalid-feedback">{error.password}</span>  
                            <br/>  
                          <button type="submit" className="btn btn-outline-dark btn-sm btn-block" >login</button>                    
                        </form>
                      
                    
                </Card.Body>
                </Card>
             </Col>
          
            
        </Row>
            
        //  </section>
        )
    }
} 
