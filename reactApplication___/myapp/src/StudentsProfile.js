import React,{ Component } from "react";
import { Button, ButtonToolBar } from "react-bootstrap";
import { AddModelPopup } from "./AddModelPopup";


export class StudentsProfile extends Component {
    constructor(props)
    {
           super(props);
           //this.state = {emps:[], addModalShow:false}
           
    }

 
    render()
    {
      
        return (
          
                        
         // <section className="h-100 gradient-custom-2">
            <div className="py-5 h-100">
              <div className="row d-flex justify-content-center align-items-center h-100">
                <div className="col col-lg-9 col-xl-7">
                  <div className="card">
                    <div className="rounded-top text-white d-flex flex-row" style={{backgroundColor: '#000', height: '200px'}}>
                      <div className="ms-4 mt-5 d-flex flex-column" style={{width: '300px;', paddingLeft: '25px'}}>
                        <img src="https://mdbootstrap.com/img/Photos/new-templates/bootstrap-profiles/avatar-1.jpg" alt="Generic placeholder image" className="img-fluid img-thumbnail mt-4 mb-2" style={{width: '140px', zIndex: '1'}} />
                        <button type="button" className="btn btn-outline-dark" data-mdb-ripple-color="dark" style={{zIndex: '1'}} >
                          Edit profile
                        </button>
                      </div>
                      <div className="ms-3" style={{marginTop: '200px', textColor: "#ffff"}}>
                        <h5>Andy Horwitz</h5>
                        <p>New York</p> 
                      </div>
                    </div>
                    <div class="p-4 text-black" >
                      <div class="d-flex justify-content-end text-center py-1">
                        <div>
                            <ul class="mb-0 list-unstyled d-flex flex-row" style={{color: "#1B7B2C;", zIndex: 1}}>
                              <li>
                                <i class="fas fa-star fa-xs"></i>
                              </li>
                              <li>
                                <i class="fas fa-star fa-xs"></i>
                              </li>
                              <li>
                                <i class="fas fa-star fa-xs"></i>
                              </li>
                              <li>
                                <i class="fas fa-star fa-xs"></i>
                              </li>
                              <li>
                                <i class="fas fa-star fa-xs"></i>
                              </li>
                            </ul>
                          <p class="mb-1 h5">253</p>
                          <p className="small text-muted mb-0">Photos</p>
                        </div>
                        <div className="px-3">
                          <p className="mb-1 h5">1026</p>
                          <p className="small text-muted mb-0">Followers</p>
                        </div>
                        <div>
                          <p className="mb-1 h5">478</p>
                          <p className="small text-muted mb-0">Following</p>
                        </div>
                      </div>
                    </div>
                    <div className="card-body p-4 text-black">
                      <div className="mb-5">
                        <p className="lead fw-normal mb-1">About</p>
                        <div className="p-4" style={{backgroundColor: '#f8f9fa'}}>
                          <p className="font-italic mb-1">Web Developer</p>
                          <p className="font-italic mb-1">Lives in New York</p>
                          <p className="font-italic mb-0">Photographer</p>
                        </div>
                      </div>
                      <div className="d-flex justify-content-between align-items-center mb-4">
                        <p className="lead fw-normal mb-0">Recent photos</p>
                        <p className="mb-0"><a href="#!" className="text-muted">Show all</a></p>
                      </div>
                      <div className="row g-2">
                        <div className="col mb-2">
                          <img src="https://mdbootstrap.com/img/Photos/Lightbox/Original/img%20(112).jpg" alt="image 1" className="w-100 rounded-3"/>
                        </div>
                        <div className="col mb-2">
                          <img src="https://mdbootstrap.com/img/Photos/Lightbox/Original/img%20(107).jpg" alt="image 1" className="w-100 rounded-3"/>
                        </div>
                      </div>
                      <div className="row g-2">
                        <div className="col">
                          <img src="https://mdbootstrap.com/img/Photos/Lightbox/Original/img%20(108).jpg" alt="image 1" className="w-100 rounded-3"/>
                        </div>
                        <div className="col">
                          <img src="https://mdbootstrap.com/img/Photos/Lightbox/Original/img%20(114).jpg" alt="image 1" className="w-100 rounded-3"/>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
        //  </section>
        )
    }
} 