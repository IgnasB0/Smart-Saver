import { render } from '@testing-library/react';
import React from 'react';
import './MainForm.css';
import ReactDOM from 'react-dom';
import Button from 'react-bootstrap/Button';
import IncomeModal from './components/IncomeModal';
import GoalModal from './components/GoalModal';
import RecurringIncomeModal from './components/RecurringIncomeModal'
import ExpenseModal from './components/ExpenseModal';
import AddExpenseModal from './components/AddExpenseModal';
import SeeGoalModal from './components/SeeGoalModal';
import { SeeGoal } from './components/SeeGoal';
import  Chart  from './components/Chart';
import Expense from './components/Expense';
import { BrowserRouter } from 'react-router-dom';
class MainForm extends React.Component{
   

    constructor(props) {
        super(props);
        this.state = {
          incomes: []
        };
        this.state = {
            expenses: []
          };
          this.state = {
            balance: []
          };
          this.expense = this.expense.bind(this);
      }
      
      expense(){
        window.open('/expensecategories');
      }

      componentDidMount(){
        fetch("https://localhost:44317/frontend/get-monthly-expenses")
        .then(res => res.json()).then(
            result => {
                this.setState({expenses:result});
            }
        )
        fetch("https://localhost:44317/frontend/get-monthly-income")
        .then(res => res.json()).then(
            result => {
                this.setState({incomes:result});
            }
        )
        fetch("https://localhost:44317/frontend/get-monthly-balance")
        .then(res => res.json()).then(
            result => {
                this.setState({balance:result});
            }
        )
        
    }
   


    render() {
    return (
<div class="main-form-container">

    <div class="row">   
        <div class="welcoming-container">
            <p class="welcome-message">Welcome, {'User'}, to World's Best Smart Saver!</p>
        </div>
    </div>
<div class="spacer"/>
<div class="row">
    <div class="status-column">
        <i class="glyphicon glyphicon-upload" id="status-icon"/>
        <p class="status-label">Monthly Income:</p>
        <p class="status-number">{this.state.incomes}</p>
    </div>
</div>
<div class="spacer"/>
<div class="row">
    <div class="status-column">
        <i class="glyphicon glyphicon-download" id="status-icon"/>
        <p class="status-label">Monthly Expenses Amount:</p>
        <p class="status-number">{this.state.expenses}</p>
    </div>
    
</div>
<div class="spacer"/>
<div class="row">
    <div class="status-column">
        <i class="glyphicon glyphicon-circle-arrow-right" id="status-icon"/>
        <p class="status-label">Monthly Balance:</p>
        <p class="status-number">{this.state.balance}</p>
    </div>
</div>

<div class="spacer"/>
<div class="row">
    <div class="option-column">
        <IncomeModal/>
    </div>
    <div class="option-column">
        <RecurringIncomeModal/>
    </div>
</div>
<div class="row">
    <div class="option-column">
         <button class="main-form-button-left" onClick={this.expense}> Add Expense </button> 
    </div>
    <div class="option-column">
        <GoalModal/>
    </div>
</div>

    <div class="spacer2"/>
    <div class="chart-area">
        <Chart/>
    </div>
    <div class="spacer2"/>
    <div class="row">   
        <div class="goal-info-container">
            <p class="goal-info-message">Goal Progress Information</p>
        </div>
    </div>
    <div class="spacer"/>
    <div class="row">
        <div class="status-column">
            <SeeGoal/>
        </div>
    </div>
</div>
    );
}
}
export default MainForm;

const element = <MainForm></MainForm>

ReactDOM.render(element,document.getElementById("root"));

