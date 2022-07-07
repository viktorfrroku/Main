import React,{ Component } from "react";
import { Button, ButtonToolBar } from "react-bootstrap";
import { AddModelPopup } from "./AddModelPopup";
import { Row, Col, Form, Card } from 'react-bootstrap';
import { useForm } from 'react-hook-form';

const regularExpression = RegExp(/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[A-Za-z]+$/);
const validPassword = RegExp(/^[a-zA-Z0-9~@#$^*()_+=[\]{}|\\,.?: -]*$/);

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



export class Register extends Component {
    constructor(props)
    {
           
       super(props);
       this.state = {
        firstname:'',
        lastname:'',
        email:'',
        username :'',
        password :'',
        error: {
            firstname:'',
            lastname:'',
            email:'',
            username :'',
            password :''
        }
       }
           
    }


    onFormSubmit = event =>
    {
        event.preventDefault();
        if(validation(this.state))
        {
            console.log(this.state)
            fetch('https://localhost:5001/Login/Register',{
                method:'POST',
                headers:{
                   // 'Access-Control-Allow-Origin': 'https://localhost:3001',
                    'Content-Type':'application/json',
                    'Accept':'application/json'              
                   },
                body:JSON.stringify({
                    UserName:event.target.username.value,
                    Email:event.target.email.value,
                    Password:event.targe.password.value
                })
            })
            .then(res => res.json())
            .then(result => console.log(result));
        }
        else {
            console.log('error ocured..');
        }
    }

    formObject = event => {
        event.preventDefault();
        const {name, value} = event.target;
        let error = {...this.state.error};

        switch (name) {
            case 'firstname':
                error.firstname = value.length < 5 ? 'Name should be more than 5 caracters long' :  '';                
                break;

            case 'lastname':
                error.lastname = value.length < 5 ? 'Name should be more than 5 caracters long' :  '';                
                break;

             case 'email':
                error.email = value.length < 5 ? 'Name should be more than 5 caracters long' :  ''; 
                error.email = !regularExpression.test(value)  ? 'please put correct email address' : '';             
                break;

            case 'username':
                error.username = value.length < 5 ? 'Name should be more than 5 caracters long' :  '';                
                break;
            case 'password':
                error.password = value.length < 5 ? 'Name should be more than 5 caracters long' :  '';
                error.password = !validPassword.test(value)  ? 'the password must include all caracters' : '';
                                       
            break;
        
            default:
                break;
        }
        this.setState({
            error,
            [name]: value
        })
    };
    



 
    render()
    {
        const {error} = this.state;
      
        return (
          
                        
            <Row className="d-flex justify-content-center">
                <Col sm={4}>
                <Card >
                    <Card.Header style={{backgroundColor:'#ddd'}}>
                    <h1>Registration</h1>
                    </Card.Header>
                    <Card.Body>
                        
                   
                    <form className='form-group' onSubmit={this.onFormSubmit}>
                          <small className="text-danger ml-auto">*</small>

                            <input
                            //  required
                                type="text" 
                                name="firstname" 
                                placeholder="firstname"
                                onChange={this.formObject}
                                className = {error.firstname.length > 0 ? "is-invalid form-control":"form-control"}
                                /> 
                            <span className="invalid-feedback">{error.firstname}</span>     


                            <small className="text-danger ml-auto">*</small>

                            <input
                               //  required
                                 type="text" 
                                 name="lastname" 
                                 placeholder="lastname"
                                 onChange={this.formObject}
                                 className = {error.lastname.length > 0 ? "is-invalid form-control":"form-control"}
                                 /> 
                             <span className="invalid-feedback">{error.lastname}</span> 

                              <small className="text-danger ml-auto">*</small>

                              <input
                               //  required
                                 type="email" 
                                 name="email" 
                                 placeholder="email"
                                 onChange={this.formObject}
                                 className = {error.email.length > 0 ? "is-invalid form-control":"form-control"}
                                 /> 
                             <span className="invalid-feedback">{error.email}</span> 

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
