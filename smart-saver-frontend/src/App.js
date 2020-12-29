import './App.css';
import MainForm from './MainForm';
import ExpenseForm from './ExpenseForm';
import ExpenseInputForm from './ExpenseInputForm';
import React, {Component} from 'react';

import {BrowserRouter,Route,Switch} from 'react-router-dom';
import {Income} from './components/Income';
import IncomeModal from './components/IncomeModal'

import NavBar from './NavBar';




function App() {
  return (
  <BrowserRouter>
  <div class="mainDiv">
      <Switch>
          <Route path='/' component={MainForm} exact />
      </Switch>
  </div>
</BrowserRouter> 
  
  
  );




}
 // return (
  //  <div className="App">
   //   <MainForm/>
   //   <ExpenseForm/> (/*Temporary location. Component spawn should be automized and in different window. This is just for representation.*/)
  //    <ExpenseInputForm/>
  //  </div>
 // );


/*  return (
   <BrowserRouter>
      <div className="container">

        <h3 className="m-3 d-flex justify-content-center">
          Mainform yra cia
        </h3>

        <Navigation/>
          <Switch>
              <Route path='/' component={MainForm} exact />
              <Route path='/income' component={Income} exact />
          </Switch>
      </div>
  </BrowserRouter> 
); */

export default App;
