import React, {Component} from 'react';

export class RecurringIncome extends React.Component{

    constructor(props) {
        super(props);
        this.state ={
            reccuringIncomeAmount: '',
            reccuringIncomeDateFrom: '',
            reccuringIncomeDateUntil: ''
        }
        this.InsertedReccuringIncome = this.InsertedReccuringIncome.bind(this);
      }

      InsertedReccuringIncome() {
        alert('Reccuring Income was added successfully!');
      }

      changeHandler = e =>{
        this.setState({[e.target.name]: e.target.value})
    }
    submitHandler = e =>{
        e.preventDefault()
        const url="https://localhost:44317/recurringincomes"
        const reccuringincomepost = "\"" + this.state.reccuringIncomeAmount + "," + this.state.reccuringIncomeDateFrom + "," + this.state.reccuringIncomeDateUntil + "\"" ;

        fetch(url,
            {
                method:'POST',
                body: reccuringincomepost,
                headers:{'Content-Type':'application/json'}
            })
            .then(res => res)
            .catch(error => console.error('Error:',error))
            .then(response => this.InsertedReccuringIncome());
            
    }


    render(){
        const {reccuringIncomeAmount, reccuringIncomeDateFrom, reccuringIncomeDateUntil} = this.state;
        return  (
            <div class="recurring-income-component">
                <form onSubmit={this.submitHandler}>
                <p>Reccuring Income Amount:</p>
                <input type="number" name="reccuringIncomeAmount" value={reccuringIncomeAmount} onChange={this.changeHandler} step="any"/>
                <p>Reccuring Income Date From:</p>
                <input type="date" name="reccuringIncomeDateFrom" value={reccuringIncomeDateFrom} onChange={this.changeHandler} step="any"/>
                <p>Goal Date:</p>
                <input type="date" name="reccuringIncomeDateUntil"value={reccuringIncomeDateUntil} onChange={this.changeHandler}/>
                <div class="spacer"/>
                <div class="modal-button-container">
                    <button class="modal-button" type="submit">Submit</button>
                </div>
            </form>
            </div>
        );
    }
}