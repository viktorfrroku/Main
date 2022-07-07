import React,{ Component } from "react";
import { Button, ButtonToolBar } from "react-bootstrap";
import { AddModelPopup } from "./AddModelPopup";
import {Modal,  Row, Col, Form } from 'react-bootstrap';



export class Upload extends Component {
    constructor(props)
    {
           super(props);
           this.state = {emps:[], addModalShow:false}
           this.uploadFileFromForm=this.uploadFileFromForm.bind(this)
           
    }
   
    uploadFileFromForm(event)
    {
       console.log(event.target.file[1]);
        event.preventDefault();
        const formData = new FormData();
        formData.append('file',event.target.file.value);

        fetch("https://localhost:5001/Download/uplFile",{
            method:"POST",
          //  mode:"no-cors",
            headers:{
               "Accept":"application/json"
            },
            body:JSON.stringify({
               uploadFile:formData
            })
        })
        .then(res => res.json())
        .then((result) => 
        alert(result.message()))

       // onChange();
    }

    

    render()
    {
      // const {emps} = this.state;
      // let addModalClose=()=>this.setState({addModalShow:false});
        return (
          
            <div className="container">
                <h1>welcom to upload page   </h1>
                <Row className="justify-content-center">
                    <Col sm={6} >
                     <Form onSubmit={this.uploadFileFromForm}>
                                              
                      <Form.File type="file" name="file"  placeholder="uploadFile" /><br></br>
                       <Button className="btn btn-success btn-sm btn-block" type="submit"> upload</Button>                 
                      </Form>                     
                   </Col>
                </Row>
            </div>             
          
        ); 
    }
} 