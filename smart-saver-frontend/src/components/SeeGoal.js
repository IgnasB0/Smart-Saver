import React, {Component} from 'react';
import { GoalProgressCircle } from './GoalProgressCircle'

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
        fetch("https://localhost:44317/frontend/get-goal-amount")
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
