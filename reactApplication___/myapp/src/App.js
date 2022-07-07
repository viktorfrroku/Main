import React, {Component} from 'react';
import bootstrap from 'react-bootstrap';
import { Home } from './Home';
import { Navigation } from './Navigation';
import { Upload } from './Upload';
import { AddModelPopup } from './AddModelPopup';
import { Students } from './Students';
import { UnAuthorized } from './UnAuthorized';
import {Login} from './Login';
import {Register} from './Register';
import Logout from './Logout';
import { StudentsDetail } from './StudentsDetail';
import { Cart } from './shoppingcart/cart';
import { Payment } from './shoppingcart/paymant';
import { categories } from './shoppingcart/categories';
import { items } from './shoppingcart/items';
import './App.css';

import { Employees } from './Employees';
import {BrowserRouter, Route, Switch} from "react-router-dom";
import { About } from './About';
import { Footer } from './Footer';




function App()  {
       
      return (
        <div className="App">
            <BrowserRouter>
            <br></br>
            <Navigation/>
            <div className="container">
              <h5 className="m-3 d-flex justify-content-center">
                react
              </h5>
           
              <Switch>
                <Route path="/" component={Home} exact/>
                <Route path="/Employees" component={Employees} exact/>
                <Route path="/Students" component={Students} exact/>
                <Route path="/Login" component={Login} exact/>
                <Route path="/UnAuthorized" component={UnAuthorized} exact/>
                <Route path="/Register" component={Register} exact/>
                <Route path="/Logout" component={Logout} exact/>
                <Route path="/Students/:id?" component={StudentsDetail} exact/>
                <Route path="/About" component={About} exact/>
                <Route path="/Cart" component={Cart} exact/>
                <Route path="/categories" component={categories} exact/>
                <Route path="/items" component={items} exact/>
                <Route path="/Payment" component={Payment} exact/>
             </Switch>

            </div>
            </BrowserRouter>
            <Footer/>          
            </div>

      );
}

export default App;
