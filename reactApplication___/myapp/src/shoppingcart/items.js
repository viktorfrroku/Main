 import { eventListeners } from "@popperjs/core";
import React, { Component } from "react";

 export class items extends Component {
    constructor(props){
        super(props)
        this.state = {
             output:[],
             item:[],
            name:'',
            description:'',
            sku:0,
            category_id:0,
             inventory_id:0,
            price:0,
             discount_id:0,
             dtnt:[]
            }
        
     }

    refreshList() {
         fetch('https://localhost:5001/api/product',
            {headers:{
               'Content-Type':'application/json',
                'Accept':'application/json'
             }}
        )
       .then(response => response.json())
         .then(data => {
            this.setState({output:data})
        })
     

     }
     

    addItem(item) {
         // eventListeners.preventDefault();
     // `https://localhost:5001/api/product/${id}`
          fetch(`https://localhost:5001/api/product/27`,
             {headers:{
                 'Content-Type':'application/json',
                'Accept':'application/json'
            }}
         )
         .then(response => response.json())
         .then(d => {
             this.setState({item:d});
             localStorage.setItem("item",d);
            })
        //var itemsAdded = parseInt(localStorage.getItem("data"));
        //localStorage.setItem("item",++itemsAdded);
       

    }

    
    componentDidMount()
    {
         this.refreshList();
         this.addItem();
   }
     componentDidUpdate(){
        this.refreshList();
        this.addItem();
   }

    render(){
        const {output} = this.state;
        return(
            <div><h2>welcome to items page</h2>
                <div className="row">
                    {output.map( out => 
                         <div className="col-sm-4" key={out.id}>
                         <div className="card-body" style={{textAlign:"left"}}>
                             <img src={process.env.PUBLIC_URL + '/img/alex-trail-cMCVM48SYAE-unsplash.jpg'} alt="thi is an image" sizes="(max-width:800px) 500px, 800px"/>
                               <div>   
                                      <i class="fa fa-star" aria-hidden="true"></i>
                                      <i class="fa fa-star" aria-hidden="true"></i>
                                      <i class="fa fa-star" aria-hidden="true"></i>
                                      <i class="fa fa-star" aria-hidden="true"></i>
                                      <i class="fa fa-star" aria-hidden="true"></i>
                                     
                              </div>
                              <h2>{out.name}</h2>
                               <p>{out.description}</p>
                               <p> quantity <a href='#'>-</a><a href='' className="border">1</a><a href='#'>+</a></p>
                              <h6>{out.price} $</h6>
                         {/* <button className="btn btn-sm btn-outline-dark" onClick={this.addItem().bind(this)}>add to card</button> */}
                         <button className="btn btn-sm btn-outline-dark" onClick={() => this.addItem(out)}>add to card</button>
  
                              
                          </div>
                      </div>
                        
                        ) }
                   
                       
                     </div>

               
             </div>
        )
     }

 } 