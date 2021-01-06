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
  <div key={i} >
    <div class="row">   
        <div class="expense-container">
            <div class="expense-label">
            <label> {el||''} :  <AddExpenseModal name = {el}/>
          </label> 
            </div>
        </div>
    </div>
    
    
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
              
            <div>
              {this.createUI()}
             <AddCategoryModal/>
             <button class="main-form-button-left" onClick={this.expense}> Back </button> 

            </div>
 
            );
        
     }

}
export default Expense;

const element = <Expense></Expense>

ReactDOM.render(element,document.getElementById("root"));


