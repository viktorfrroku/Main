import React, { Component } from "react";
export class Cart extends Component {

    constructor(props){
        super(props);
      
    }

    render(){

       
     //var item = JSON.parse(fullItem);
        return (
        
      
        <div >
        <div className="row">
            <div className="col-md-8 cart">
                 <div className="text-left">
                 <ul className="list-group " >
                   
                      </ul>
                     {Object.keys(localStorage).forEach((key) => {
                        <li>
                            <a>{localStorage.getItem(key)}</a>
                        </li>
                       })}
                                        
                         
                     
                </div>
               
               
           
            </div>

            
            <div className="col-md-3 cart">
                 <div className="text-left">
                     <div><h2>summary</h2></div>
                      <div className="row">
                          <p>price $</p>
                          <div><p>quantity</p> 
                          </div>

                      </div>\
                      </div>
                     
              
               
               
           
            </div>
            </div>
    </div>)
    }

}