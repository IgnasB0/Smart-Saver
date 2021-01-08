import React, {Component} from 'react';
import { GoalProgressCircle } from './GoalProgressCircle'
import {BrowserRouter,Route,Switch} from 'react-router-dom';
import { Link } from "react-router-dom"; 
export class SeeGoal extends React.Component{

    constructor(props) {
        super(props);
        this.state ={
            incomeTotal: '',
            expenseTotal: '',
            balanceTotal: '',
            amountToGoal: '',
            timetoGoal: '',
            goalAmount: ''
        }

        this.username = "Ignas";
        this.password = "slaptazodis123";
      }

      componentDidMount(){
        fetch(`https://localhost:44317/expenses/OneUserMonthlyExpenses?username=${encodeURIComponent(this.username)}&password=${encodeURIComponent(this.password)}`)
        .then(res => res.json()).then(
            result => {
                this.setState({expenseTotal:result});
            }
        )
        fetch(`https://localhost:44317/incomes/OneUserMonthlyIncome?username=${encodeURIComponent(this.username)}&password=${encodeURIComponent(this.password)}`)
        .then(res => res.json()).then(
            result => {
                this.setState({incomeTotal:result});
            }
        )
        fetch(`https://localhost:44317/frontend/get-One-User-monthly-balance?username=${encodeURIComponent(this.username)}&password=${encodeURIComponent(this.password)}`)
        .then(res => res.json()).then(
            result => {
                this.setState({balanceTotal:result});
            }
        )
        fetch(`https://localhost:44317/frontend/get-one-user-amount-to-reach-goal?username=${encodeURIComponent(this.username)}&password=${encodeURIComponent(this.password)}`)
        .then(res => res.json()).then(
            result => {
                this.setState({amountToGoal:result});
            }
        )
        fetch(`https://localhost:44317/frontend/time-left-until-goal-one-user?username=${encodeURIComponent(this.username)}&password=${encodeURIComponent(this.password)}`)
        .then(res => res.json()).then(
            result => {
                this.setState({timetoGoal:result});
            }
        )
        fetch(`https://localhost:44317/frontend/get-one-user-goal-amount?username=${encodeURIComponent(this.username)}&password=${encodeURIComponent(this.password)}`)
        .then(res => res.json()).then(
            result => {
                this.setState({goalAmount:result});
            }
        )
        
        
    }
    render(){
        
        return  (
            

    <div class="goal-info-component">
            <form>
                <div class="option-column">
                    <p class="goal-amount-label">
                        Amount needed to reach goal:
                    </p>
                    <p class="goal-amount-number">
                        {this.state.amountToGoal}
                    </p>
                </div>
                <div class="option-column">
                    <p class="goal-time-label">
                        Time left to reach the goal:
                    </p>
                    <p class="goal-amount-number">
                        {this.state.timetoGoal}
                    </p>
                    <p class="goal-time-units">
                        months
                    </p>
                    <div class="goal-progress-circle-container">
                        <GoalProgressCircle
                            radius={ 70 }
                            stroke={ 12 }
                            progress={ 100 * ((this.state.goalAmount - this.state.amountToGoal) / this.state.goalAmount) }/>
                    </div>
                </div>
            </form>
        </div>
        );
    }

    
}
