import React,{ Component } from "react";
import { Button, ButtonToolBar } from "react-bootstrap";
import { AddModelPopup } from "./AddModelPopup";
import { UnAuthorized } from "./UnAuthorized";


export class Employees extends Component {
    constructor(props)
    {
           super(props);
           this.state = {emps:[], addModalShow:false};
           //this.state = {Logintoken};
          // const Logintoken = !null ? localStorage.getItem("token") : '';
           
    }

    loginToken = () => {
        return localStorage.getItem("token") !== null ? localStorage.getItem("token") : '';
    }

    refreshList()
    {
         fetch("https://localhost:5001/Employees",{
        
         headers:{
            // 'Access-Control-Allow-Origin': 'https://localhost:3001',
             'Content-Type':'application/json',
             'Accept':'application/json',
             'Authorization' : `Bearer ${localStorage.getItem("token")}`           

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

    render()
    {
        
        const {emps} = this.state;
        let addModalClose=()=>this.setState({addModalShow:false});

        if(localStorage.getItem("token") !== null)
        {
            return (
                <div>
                   <table className="table table-striped">
                    <thead>
                        <tr>
                         <th scope="col">FirstName</th>
                        <th scope="col">LastName</th>
                        <th scope="col">options</th>
                        </tr>
                    </thead>
                    <tbody>
                       {emps.map(emp => 
                            <tr key={emp.emplyeeId}>
                            <td>{emp.firstName}</td>
                            <td>{emp.lastName}</td>
                            <td><a href="#" >edit</a> / <a href="#"> delete</a></td>
                            </tr>
                        )}
                        
                        </tbody>
                      </table>
                   
                    <div className="btn-toolbar">
                          <Button  className="btn btn-outline-dark" onClick={()=>this.setState({addModalShow:true})}>
                                add emplyee
                          </Button>
                          <AddModelPopup show={this.state.addModalShow} onHide={addModalClose} />
                          
                      </div>
                      </div> ); 
                      }
                      else
                      {
                          return <UnAuthorized/>    ;
                      }
         }
      
    }
 