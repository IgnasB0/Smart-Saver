import './App.css';
import MainForm from './MainForm';
import ExpenseForm from './ExpenseForm';
import ExpenseInputForm from './ExpenseInputForm';
import React, {Component} from 'react';

import {BrowserRouter,Route,Switch} from 'react-router-dom';
import {Income} from './components/Income';
import IncomeModal from './components/IncomeModal'

import NavBar from './NavBar';
import Expense from './components/Expense';
import { AddExpense } from './components/AddExpense';
import { AddCategory } from './components/AddCategory';



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

export default App;

/* /income, /expense, /addexpense, /addcategory */