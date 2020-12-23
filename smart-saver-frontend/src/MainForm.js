import { render } from '@testing-library/react';
import React from 'react';
import './MainForm.css';
import ReactDOM from 'react-dom';
import Button from 'react-bootstrap/Button';

import {Income} from './components/Income';

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
      //  const {incomes} = this.state;
       // const {expenses} = this.state;
    return (
<div>

    <div class="row">
        <div class="user-column">
            <p class="user-label">User: {'user'}</p>
        </div>
        <div class="user-column">
        </div>
    </div>
<div class="row">
    <div class="status-column">
        <p class="status-label">Monthly Income: {this.state.incomes}</p>
    </div>
    <div class="status-column">
        <p class="status-label">Monthly Expenses Amount: {this.state.expenses}</p>
    </div>
    <div class="status-column">
        <p class="status-label">Monthly Balance: {this.state.balance}</p>
    </div>
</div>
<div class="row">
    <div class="option-column">
        {/* <button>Add Income</button> */}

        {/* <Button variant="primary">Add Income Button</Button> */}

    </div>
    <div class="option-column">
        {/* <button>Manage Recurring Income</button> */}
        <Button variant="primary">Manage Recurring Income Button</Button>
    </div>
    <div class="option-column">
        {/* <button>Add Expense</button> */}
        <Button variant="primary">Add Expense Button</Button>
    </div>
    <div class="option-column">
        {/* <button>Set Goal</button> */}
        <Button variant="primary">Set Goal Button</Button>
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

