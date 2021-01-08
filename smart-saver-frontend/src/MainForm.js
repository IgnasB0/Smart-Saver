import { render } from '@testing-library/react';
import React from 'react';
import './MainForm.css';
import ReactDOM from 'react-dom';
import Button from 'react-bootstrap/Button';
import IncomeModal from './components/IncomeModal';
import LoginModal from './LoginModal';
import LoginForm from './LoginForm';
import GoalModal from './components/GoalModal';
import RecurringIncomeModal from './components/RecurringIncomeModal'
import ExpenseModal from './components/ExpenseModal';
import AddExpenseModal from './components/AddExpenseModal';
import SeeGoalModal from './components/SeeGoalModal';
import { SeeGoal } from './components/SeeGoal';
import  Chart  from './components/Chart';
import Expense from './components/Expense';
import { BrowserRouter } from 'react-router-dom';
import  history  from './components/history';
class MainForm extends React.Component{
   

    constructor(props) {
        super(props);
        this.state = {
            Username: "",
            password: "",
            loginStatus: false
          };
        this.state = {
          incomes: []
        };
        this.state = { 
            loginInfo: [] 
        };
        this.state = {
            expenses: []
          };
          this.state = {
            balance: []
          };
          this.state = {
            loggedIn: "no"
          };
          

          this.expense = this.expense.bind(this);
          this.refreshPage = this.refreshPage.bind(this);
          this.user = ["",""];

      }
      
      expense(){
        window.open('/expensecategories');
      }

      componentDidMount(){
        
        
    }
    refreshPage() {
        window.location.reload();
      }
      
      callbackFunction = (childData) => {
            this.setState({message: childData})
      }

      loginChangeHandler = (e) => {
        this.setState({ [e.target.name]: e.target.value });
      };
    
      loginHandler = (e) => {
        
        e.preventDefault()
            const url="https://localhost:44317/Login/AttemptLogin?userName=" + this.state.Username + "&password=" + this.state.Password
    
            fetch(url,
                {
                    method:'GET',
                    headers:{'Content-Type':'application/json'}
                })
                .then(res => res.json()).then(
                  result => {
                      this.setState({loginStatus:result});
                      if(this.state.loginStatus)
                        alert("Login successful");
                      else
                        alert("Wrong password");
                  }
              )
              fetch(`https://localhost:44317/expenses/OneUserMonthlyExpenses?username=${encodeURIComponent(this.state.Username)}&password=${encodeURIComponent(this.state.Password)}`)
        .then(res => res.json()).then(
            result => {
                this.setState({expenses:result});
            }
        )
        fetch(`https://localhost:44317/incomes/OneUserMonthlyIncome?username=${encodeURIComponent(this.state.Username)}&password=${encodeURIComponent(this.state.Password)}`)
        .then(res => res.json()).then(
            result => {
                this.setState({incomes:result});
            }
        )
        fetch(`https://localhost:44317/frontend/get-One-User-monthly-balance?username=${encodeURIComponent(this.state.Username)}&password=${encodeURIComponent(this.state.Password)}`)
        .then(res => res.json()).then(
            result => {
                this.setState({balance:result});
            }
        )
        
                
      };


    render() {
        const { Username, Password } = this.state;
    return (
<div class="main-form-container">

    <div class="row">   
        <div class="welcoming-container">
        <div>
        <form onSubmit={this.loginHandler}>
          <div>
            Username:
            <input
              type="text"
              name="Username"
              value={Username}
              onChange={this.loginChangeHandler}
            />
          </div>
          <div>
            Password:
            <input
              type="password"
              name="Password"
              value={Password}
              onChange={this.loginChangeHandler}
            />
          </div>
          
          <button type="submit">Log In</button>
        </form>
      </div>
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
         {/* <button class="main-form-button-left" onClick={this.expense}> Add Expense </button>  */}
         <button class="main-form-button-left" onClick={()=> history.push('/expensecategories')}>Add Expense</button>
    </div>
    <div class="option-column">
        <GoalModal/>
    </div>
</div>

    <div class="spacer2"/>
    <div class="chart-area">
        <Chart dataFromParent = {this.user}/>
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
            <SeeGoal dataFromParent = {this.state}/>
        </div>
    </div>
</div>
    );
}
}
export default MainForm;

const element = <MainForm></MainForm>

ReactDOM.render(element,document.getElementById("root"));

function Greeting(props) {
    const isLoggedIn = props.state.loggedIn;
    if (isLoggedIn == "yes") {
      return <div><p class="welcome-message">Welcome, {this.username}, to World's Best Smart Saver!</p></div>;
    }
    return <div></div>;
  }

  