import './App.css';
import MainForm from './MainForm';
import ExpenseForm from './ExpenseForm';
import ExpenseInputForm from './ExpenseInputForm';
import React, {Component} from 'react';

import {BrowserRouter,Route,Switch} from 'react-router-dom';
import {Income} from './components/Income';

import NavBar from './NavBar';
import Expense from './components/Expense';
import { AddExpense } from './components/AddExpense';
import { AddCategory } from './components/AddCategory';



function App() {
  return (
  <BrowserRouter>
  <div className="container">


    <NavBar/>
      <Switch>
        <Route path='/' component={MainForm} exact />
         <Route path='/income' component={Income} exact />
         <Route path='/expense' component={Expense} exact />
         <Route path="/addexpense" component={AddExpense} />
          <Route path="/addcategory" component={AddCategory} /> 
      </Switch>
  </div>
</BrowserRouter> 
  
  
  );


}

export default App;
