import React, {Component} from 'react';

export class Goal extends React.Component{


    constructor(props) {
        super(props);
        this.state ={
            goalName: '',
            goalAmount: '',
            goalDate: ''
        }
        this.InsertedGoal = this.InsertedGoal.bind(this);
      }

      InsertedGoal() {
        alert('Goal was added successfully!');
      }

      changeHandler = e =>{
        this.setState({[e.target.name]: e.target.value})
    }
    submitHandler = e =>{
        e.preventDefault()
        const url="https://localhost:44317/goal"
        const goalpost = "\"" + this.state.goalName + "," + this.state.goalAmount + "," + this.state.goalDate + "\"" ;

        fetch(url,
            {
                method:'POST',
                body: goalpost,
                headers:{'Content-Type':'application/json'}
            })
            .then(res => res)
            .catch(error => console.error('Error:',error))
            .then(response => this.InsertedGoal());
            
    }


    render(){
        const {goalName, goalAmount, goalDate} = this.state;
        return  (
            
    <div class="income-component">
            <form onSubmit={this.submitHandler}>
                <p>Goal Name:</p>
                <input type="text" name="goalName" value={goalName} onChange={this.changeHandler} step="any"/>
                <p>Goal Amount:</p>
                <input type="number" name="goalAmount" value={goalAmount} onChange={this.changeHandler} step="any"/>
                <p>Goal Date:</p>
                <input type="date" name="goalDate"value={goalDate} onChange={this.changeHandler}/>
                <div class="modal-buton-container">
                    <button class="modal-button" type="submit">Submit</button>
                </div>
            </form>
        </div>
        );
    }
}