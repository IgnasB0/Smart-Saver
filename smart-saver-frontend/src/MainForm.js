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
import  Chart  from './components/Chart';
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
          this.handleBack = this.handleBack.bind(this);
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
    handleBack() {
        window.open("/chart");
      }



    render() {
      //  const {incomes} = this.state;
       // const {expenses} = this.state;
    return (
<div class="main-form-container">

    <div class="row">   
        <div class="user-container">
            <div class="user-label">
                <p class="user-label">User: {'user'}</p>
            </div>
        </div>
    </div>
<div class="spacer"/>
<div class="row">
    <div class="status-column">
        <i class="glyphicon glyphicon-upload" id="status-icon"/>
        <p class="status-label">Monthly Income: {this.state.incomes}</p>
    </div>
</div>
<div class="spacer"/>
<div class="row">
    <div class="status-column">
        <i class="glyphicon glyphicon-download" id="status-icon"/>
        <p class="status-label">Monthly Expenses Amount: {this.state.expenses}</p>
    </div>
    
</div>
<div class="spacer"/>
<div class="row">
    <div class="status-column">
        <i class="glyphicon glyphicon-circle-arrow-right" id="status-icon"/>
        <p class="status-label">Monthly Balance: {this.state.balance}</p>
    </div>
</div>
<div class="option-column">
        <Chart/>
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
<div class="spacer"/>
<div class="row">
    <div class="option-column">
        <ExpenseModal/>
    </div>
    <div class="option-column">
        <GoalModal/>
    </div>
    <div class="option-column">
        <SeeGoalModal/>
    </div>
    
</div>


<div class="row">
    <p>*Here we can place graph*</p>
    <p>(Don't know how, though)</p>
</div>
<div class="row">
    <p>Time left until goal is reached: {'N/A'} months</p>
</div>
</div>
    );
}
}
export default MainForm;

const element = <MainForm></MainForm>

ReactDOM.render(element,document.getElementById("root"));

