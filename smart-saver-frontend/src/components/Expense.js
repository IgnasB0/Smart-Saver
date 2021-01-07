import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import { AddExpense } from './AddExpense';
import {Link, Router} from 'react-router-dom';
import {BrowserRouter,Route,Switch} from 'react-router-dom';
import { AddCategory } from './AddCategory';
import { Income } from './Income';
import MainForm from '../MainForm';
import ExpenseModal from './ExpenseModal';
import AddExpenseModal from './AddExpenseModal';
import AddCategoryModal from './AddCategoryModal';
import  history  from './history';



class Expense extends React.Component{

    constructor(props) {
        super(props);
          this.state = {
            expensecategories: [],
            expensecategoryName: []
          }; 
          this.expense = this.expense.bind(this);
         
      }

      expense(){
        window.open('/');
      }
      
    
        

createUI(){
  return this.state.expensecategories.map((el, i) => 
  <div key={i} class="expense-container">   
        <p class="expense-label"> {el||''} </p> 
        <p class="expense-category-amount">{'N/A'}</p>
        <AddExpenseModal name = {el}/>
  </div>
      
)

}
    render(){
      
        fetch("https://localhost:44317/categories/parse-categories")
        .then(res => res.json()).then(
            result => {
                this.setState({expensecategories:result});
            }
        );

            return(
              
            <div class="category-load-container">
              <div class="only-categories-container">
                {this.createUI()}
              </div>
              <div class="category-load-button-row">
                <AddCategoryModal/>
                <button class="main-form-button-right" onClick={()=> history.push('/')}> Back </button> 
              </div>
            </div>
 
            );
        
     }

}
export default Expense;

const element = <Expense></Expense>

ReactDOM.render(element,document.getElementById("root"));


