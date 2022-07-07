import { Component } from "react";
import { Row, Col, Form, Card } from 'react-bootstrap';

export class UnAuthorized extends Component {

   constructor(props)
   {
       super(props);

   }

   render(){
    
        return (<div className="text-left">
                 <Row lg={12}>
                     <Col sm={12}>
                         <h1 className="alert alert-danger">401 not authrized!</h1>
                         <hr/>
                         <h6>you are not authorized to access this page</h6>
                     </Col>
                 </Row>

        </div>)
   }   
}