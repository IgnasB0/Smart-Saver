import React, {Component} from 'react';
import moment from 'moment'; 
import Expense from './Expense';
import MainForm from '../MainForm';
import {Link,useHistory} from 'react-router-dom';
import { browserHistory, Router, Route,Switch } from 'react-router';

export class AddExpense extends React.Component{

    constructor(props) {
        super(props);
        this.state ={
            expenseCategory: '',
            expenseName: '',
            expenseAmount: '',
            expenseDate: '',
            name: props.name
        }
        this.InsertedExpense = this.InsertedExpense.bind(this);
    }

      changeHandler = e =>{
        this.setState({[e.target.name]: e.target.value})
    }

    InsertedExpense() {
        alert('Expense was added successfully!');
      }


    submitHandler = (e) =>{
        e.preventDefault();
        const url="https://localhost:44317/expenses";

        var now = moment().format();
        const expensespost = "\"" + this.state.expenseName + "," + this.state.expenseAmount + "," + now +"," + this.state.name +   "\"" ;

        fetch(url,
            {
                method:'POST',
                body: expensespost,
                headers:{'Content-Type':'application/json'}
            })
            .then(res => res)
            .catch(error => console.error('Error:',error))
            .then(response => this.InsertedExpense());
            
    }

      render(){
        const {expenseCategory, expenseName,expenseAmount} = this.state;
        return (
            
        <div class="expense-component">
            <form onSubmit={this.submitHandler}>
                <div class="row">
                    <p>Expense name: </p>
                    <input type="text" name="expenseName" value={expenseName} onChange={this.changeHandler} step="any"/>
                </div>
                <div class="row">
                    <p>Expense amount: </p>
                    <input type="number" name="expenseAmount" value={expenseAmount} onChange={this.changeHandler} step="any"/>
                    </div>
                <div class="row">
                    <p>Expense category:</p>
                    <input type="text" name="expenseCategory" value={this.state.name} onChange={this.changeHandler} step="any"/>
                </div>
                <div class="spacer"/>
                <div class="modal-button-container">
                    <button class="modal-button" type="submit">Submit</button>
                </div>
            </form>
        </div>
        )
    }


}