import React, {Component} from 'react';
import moment from 'moment'; 
import Expense from './Expense';
export class AddExpense extends React.Component{

    constructor(props) {
        super(props);
        this.state ={
            expenseCategory: '',
            expenseName: '',
            expenseAmount: '',
            expenseDate: ''
        }
        this.InsertedExpense = this.InsertedExpense.bind(this);
      }

      changeHandler = e =>{
        this.setState({[e.target.name]: e.target.value})
    }

    InsertedExpense() {
        alert('Expense was added successfully!');
      }


    submitHandler = e =>{
        e.preventDefault()
        const url="https://localhost:44317/expenses"
        const {data} = this.props.location;
        const data1 ={
            expenseName:this.state.expenseName,
            expenseAmount:this.state.expenseAmount,
            expenseDate:this.state.expenseDate,
            expenseCategory: data
            
            
        };
        var now = moment().format();
        const expensespost = "\"" + this.state.expenseName + "," + this.state.expenseAmount + "," + now +"," + data +   "\"" ;

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
        const {data} = this.props.location;
        return (
            
        <div>
            <form onSubmit={this.submitHandler}>
                <label>Expense name:
                <div>
                <input type="text" name="expenseName" value={expenseName} onChange={this.changeHandler} step="any"/>
                </div>
                Expense amount: 
                <div>
                <input type="number" name="expenseAmount" value={expenseAmount} onChange={this.changeHandler} step="any"/>
                </div>
                Expense category:
                <div> 
                <input type="text" name="expenseCategory" value={data} onChange={this.changeHandler} step="any"/>
                </div>

                <button type="submit">Submit</button>
                </label>

                
            </form>
        </div>
        )
    }


}