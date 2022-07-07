import React,{ Component } from "react";
import {Row, Col} from 'react-bootstrap';
import {NavLink} from 'react-router-dom';
import { Navbar, Nav } from "react-bootstrap";

export class Home extends Component {
    render()
    {//className="mt-5 d-flex justify-content-center"
        
         return (
           <div className="front-page-layout">
             <Row>
         
                <h1>welcome to homwpage</h1>
                <button className="btn btn-secondary btn-outline-secondary btn-block">welcome</button>
             
             </Row>
            
             
            
           </div> );
       
    }
}