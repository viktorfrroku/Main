import React from "react";
import { Table } from "react-bootstrap";

import { Component } from "react";


export class Students extends Component
{
   constructor(props){
     super(props);
     this.state = {emps:[]}
   }


   refreshList(){
    fetch("https://localhost:5001/Students",{
        
        headers:{
           // 'Access-Control-Allow-Origin': 'https://localhost:3001',
            'Content-Type':'application/json',
            'Accept':'application/json',
           // 'Authorization' : `Bearer ${localStorage.getItem("token")}`           

        }})
        .then(response => response.json())
        .then(data => {
            this.setState({emps:data});
        })

   }

   componentDidMount()
   {
       this.refreshList();

   }
   componentDidUpdate()
   {
       this.refreshList();
   }


   render(){
       const {emps} = this.state;
      
           return(
           <Table Style='text-align:left;' className='table table-striped table-sm'>
               <thead>
                   <tr>
                       <th>firstName</th>
                       <th>lastName</th>
                       <th>profile_image</th>
                       <th>optins</th>
                       
                       
                   </tr>

               </thead>
               <tbody>
                   {emps.map(emp => 
                       
                   <tr key={emp.studentsId}>
                       <td><a Style='text-decoration:none; color:black' href={`/Students/${emp.studentsId}`}>{emp.firstName}</a></td>
                       <td>{emp.lastName}</td>
                       <td>{emp.profile_image}</td>
                       <td><a Style='text-decoration:none; color:black' href="#">edit</a> | <a Style='text-decoration:none; color:black' href="#">delete</a></td>
                   </tr>

                   )}

               </tbody>
           </Table>
           
       )
   }

}