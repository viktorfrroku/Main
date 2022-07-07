import React, { Component } from "react";


export class categories extends Component {
    constructor(props){
        super(props)
        this.state = {data:[]}
    }


    getCategories(){
        fetch('https://localhost:5001/api/Category',{
        
            headers:{
               // 'Access-Control-Allow-Origin': 'https://localhost:3001',
                'Content-Type':'application/json',
                'Accept':'application/json',
               // 'Authorization' : `Bearer ${localStorage.getItem("token")}`           
    
            }})
            .then(response => response.json())
            .then(res => {
                this.setState({data:res});
            })
    }

    componentDidMount(){
         this.getCategories();
    }
    componentDidUpdate(){
          this.getCategories();
    }


    
    render(){

        const {data} = this.state;
        return(
            <div><h2>welcome to categories page</h2>
              <div>
              <div className="row">
                  {data.map(d => 
                    <div className="col-sm-4" key={d.id}>
                        <div className="card">
                            <div className="card-body" style={{textAlign:'left'}}>
                            <img src={process.env.PUBLIC_URL + '/img/markus-spiske-fpTVkXjxL_Y-unsplash.jpg'} witdth='250px'/>
                            <h4>{d.name}</h4>
                            <p>{d.description}</p>
                            <sm>{d.created_at}</sm>
                            <a href={`/items/${d.id}`} > <button  className="btn btn-sm btn-outline-dark">go to item</button></a>
                            </div>
                        </div>
                    </div>
                  )}
                   
                  </div>
              </div>
             </div>
        )
    }

}