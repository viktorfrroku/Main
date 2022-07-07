import React from "react";
import { Container, Table } from "react-bootstrap";
import {Row, Col} from "react-bootstrap";
import { useParams } from "react-router";
import { useState } from "react";

import { Component } from "react";




export class StudentsDetail extends Component
{
   constructor(props){
     super(props);
    // const data = useState([]);
   
     this.state = {students:[], addresses:[], courses:[], enrollment:[]};
    
     
     //this.state = {url:''}
   // const params = useParams();
   }



   refreshList(){
   const qurey = new URLSearchParams(window.location.search);
   const id = qurey.get("id");
    fetch(`https://localhost:5001/Students/1002`,{
        
        headers:{
           // 'Access-Control-Allow-Origin': 'https://localhost:3001',
            'Content-Type':'application/json',
            'Accept':'application/json',
           // 'Authorization' : `Bearer ${localStorage.getItem("token")}`           

        }})
        .then(response => response.json())
        .then(d => {
         this.setState({students:d});
         this.setState({addresses:d.addresses});
         this.setState({courses:d.courses});
         this.setState({enrollment:d.enrollment});
         console.log(d);
         
        });


   }

   componentDidMount()
   {
       this.refreshList();

   }

   render(){

// this.setState({addresses});
 const {students} = this.state;
 const {addresses} = this.state;
 const {courses} = this.state;
 const {enrollment} = this.state;
      // const ads = [];
           return(
            <div>
                   <Row>
                       <Col sm={4}>
                       <i class="far fa-id-card fa-5x"></i>
                       </Col>
                       <Col sm={8}>
                       <h1><strong>Students page</strong></h1>
                       </Col>
                      
                   </Row>
                   <hr/>
           
                    <Row>          
                        
                        <Col sm={4}  style={{textAlign:'right'}}>
                        
                        <ul className="list-group">
                                    <li className="list-group-item">firstname</li>
                                    <li className="list-group-item">lastname</li> 
                                    <li className="list-group-item">email</li> 
                                    <li className="list-group-item">reating</li> 
                                </ul>
                        </Col>

                        <Col sm={8}>
                                <ul className="list-group" style={{textAlign:'left'}}>
                                    <li className="list-group-item">{students.firstName}</li>
                                    <li className="list-group-item">{students.lastName}</li> 
                                    <li className="list-group-item">{students.email}</li>
                                                                  

                                    <li className="list-group-item">
                                            <span class="fa fa-star checked"></span>
                                            <span class="fa fa-star checked"></span>
                                            <span class="fa fa-star checked"></span>
                                            <span class="fa fa-star"></span>
                                            <span class="fa fa-star"></span>
                                    </li>                   
                                 </ul>
                                 
                        </Col>  
                    </Row>

                   <br/>
                   <br/>
                    <Row>                       
                    <Col>
                    <h2>Addresses</h2>
                            <Table Style='text-align:left;' className='table table-striped table-sm'>
                                    <thead>
                                        <tr>
                                            <th>land</th>
                                            <th>city</th>
                                            <th>street</th>
                                            <th>zipCode</th>
                                            <th>naeighberhood</th>
                                            <th>options</th>
                                            
                                            
                                        </tr>

                                    </thead>
                                    <tbody>
                                        {addresses.map( adr => 
                                            
                                        <tr key={adr.addressId}>
                                            <td><a Style='text-decoration:none; color:black' href={`/Students/${adr.addressId}`}>{adr.land}</a></td>
                                            <td>{adr.land}</td>
                                            <td>{adr.city}</td>
                                            <td>{adr.street}</td>
                                            <td>{adr.zipCode}</td>
                                            <td>{adr.naeighberhood}</td>
                                            <td><a Style='text-decoration:none; color:black' href="#">edit</a> | <a Style='text-decoration:none; color:black' href="#">delete</a></td>
                                        </tr>
                                        )}
                                    </tbody>
                            </Table>
                   
                      </Col>
                      </Row>
                      <Row>
                         <Col sm={8}>
                            <h2>Courses</h2>
                                <Table Style='text-align:left;' className='table table-striped table-sm'>
                                        <thead>
                                            <tr>
                                                <th>course</th>
                                                
                                                <th>options</th>
                                                
                                                
                                            </tr>

                                        </thead>
                                        <tbody>
                                            {courses.map( cours => 
                                                
                                            <tr key={cours.coursesId}>
                                                <td><a Style='text-decoration:none; color:black' href={`/Students/${cours.coursesId}`}>{cours.coursesName}</a></td>
                                                <td>{cours.coursesName}</td>
                                            
                                            <td><a Style='text-decoration:none; color:black' href="#">edit</a> | <a Style='text-decoration:none; color:black' href="#">delete</a></td>
                                            </tr>

                                            )}

                                        </tbody>
                                </Table>
                         </Col>
                         <Col sm={4}>
                           
                              
                              
                           
                         </Col>
                        
                    </Row>

                    <br/>
                   <br/>
                   
         </div>

           
       )
   }

}