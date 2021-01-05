import React, {Component} from 'react';
import Button from 'react-bootstrap/Button';

export class SeeGoal extends React.Component{

    constructor(props) {
        super(props);
        this.state ={
            incomeTotal: '',
            expenseTotal: '',
            balanceTotal: '',
            amountToGoal: '',
            timetoGoal: ''
        }
     
      }

      componentDidMount(){
        fetch("https://localhost:44317/frontend/get-monthly-expenses")
        .then(res => res.json()).then(
            result => {
                this.setState({expenseTotal:result});
            }
        )
        fetch("https://localhost:44317/frontend/get-monthly-income")
        .then(res => res.json()).then(
            result => {
                this.setState({incomeTotal:result});
            }
        )
        fetch("https://localhost:44317/frontend/get-monthly-balance")
        .then(res => res.json()).then(
            result => {
                this.setState({balanceTotal:result});
            }
        )
        fetch("https://localhost:44317/frontend/get-amount-to-reach-goal")
        .then(res => res.json()).then(
            result => {
                this.setState({amountToGoal:result});
            }
        )
        fetch("https://localhost:44317/frontend/time-left-until-goal")
        .then(res => res.json()).then(
            result => {
                this.setState({timetoGoal:result});
            }
        )
        
        
    }
    render(){
        
        return  (
            

    <div class="income-component">
            <form>
                <div>
                <label>
                    Expense Total:  {this.state.expenseTotal}
                </label>
                </div>
               <div>
               <label>
                    Income Total:  {this.state.incomeTotal}
                </label>
               </div>
               <div>
               <label>
                    Balance:  {this.state.balanceTotal}
                </label>
               </div>
               <div>
               <label>
                    Amount needed to reach goal:  {this.state.amountToGoal}
                </label>
               </div>
               <div>
               <label>
                   Time left to reach a goal (in months):  {this.state.timetoGoal}
                </label>
               </div>
            </form>
        </div>
        );
    }

    
}
