import './App.css';
import MainForm from './MainForm';
import React, {Component} from 'react';

import {BrowserRouter,Route,Switch} from 'react-router-dom';
import {Income} from './components/Income';
import IncomeModal from './components/IncomeModal'

import NavBar from './NavBar';
import Expense from './components/Expense';
import { AddExpense } from './components/AddExpense';
import { AddCategory } from './components/AddCategory';
import  Chart  from './components/Chart';







function App() {
  return (
  <BrowserRouter>

  <div class="mainDiv">
      <Switch>
          <Route path='/' component={MainForm} exact />
          <Route path='/expensecategories' component={Expense} exact />
          <Route path='/addexpense' component={AddExpense} exact />
          <Route path='/category' component={AddCategory} exact />
          <Route path='/chart' component={Chart} exact />
      </Switch>
  </div>
</BrowserRouter> 
  
  
  );


}

export default App;

/* /income, /expense, /addexpense, /addcategory */