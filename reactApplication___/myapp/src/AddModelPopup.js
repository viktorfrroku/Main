import React, {Component} from 'react';
import {Modal, Button, Row, Col, Form } from 'react-bootstrap';

export class AddModelPopup extends Component{
    constructor(props)
    {
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event)
    {
        event.preventDefault();
        fetch('https://localhost:5001/Employees/Insert',{
           // mode:'no-cors',
            method:'POST',
            headers:{
               // 'Access-Control-Allow-Origin': 'https://localhost:3001',
                'Content-Type':'application/json',
                'Accept':'application/json'              
               },
            body:JSON.stringify({
                firstName:event.target.FirstName.value,
                lastName:event.target.LastName.value
            })
        })
        .then(res => res.json())
        .then((result) => {
            alert(result);
        },
        (error)=>{
            alert("failed", error.message);
        })
        
    }

    render(){
        return (
            <div className = "Container">
                <Modal {...this.props} size="lg" aria-labelledby="contained-modal-title-vcenter" centered>
                    <Modal.Header>
                        <Modal.Title id="contained-modal-title-vcenter">
                            add departament
                         </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}> 
                                    <Form.Group>
                                        <Form.Label> Employee Firstname </Form.Label>
                                        <Form.Control type="text" name="FirstName" placeholder="FirstName"/>
                                    </Form.Group>
                                    <Form.Group>
                                        <Form.Label> Employee Lastname </Form.Label>
                                        <Form.Control type="text" name="LastName" placeholder="LastName"/>
                                    </Form.Group>
                                    <Form.Group>
                                        <Button type="submit">
                                            add
                                        </Button>
                                    </Form.Group>
                                 </Form>

                            </Col>
                        </Row>
                    </Modal.Body>
                    <Modal.Footer>
                       <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                    </Modal.Footer>
                    
                </Modal>

            </div>
        )
    }
}