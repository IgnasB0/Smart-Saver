import React, {Component} from 'react';
import Button from 'react-bootstrap/Button';

export class Income extends React.Component{

    constructor(props) {
        super(props);
        this.state ={
            incomeAmount: '',
            incomeDate: ''
        }
        this.InsertedIncome = this.InsertedIncome.bind(this);
      }

      InsertedIncome() {
        alert('Income was added successfully!');
      }


         changeHandler = e =>{
            this.setState({[e.target.name]: e.target.value})
        }
        submitHandler = e =>{
            e.preventDefault()
            const url="https://localhost:44317/incomes"
            const data ={
                incomeAmount:this.state.incomeAmount,
                incomeDate:this.state.incomeDate
            }
            const incomespost = "\"" + this.state.incomeAmount + "," + this.state.incomeDate + "\"" ;

            fetch(url,
                {
                    method:'POST',
                    body: incomespost,
                    headers:{'Content-Type':'application/json'}
                })
                .then(res => res)
                .catch(error => console.error('Error:',error))
                .then(response => this.InsertedIncome());
                
        }

    render(){
        const {incomeAmount, incomeDate} = this.state;
        return  (
            

    <div class="income-component">
            <form onSubmit={this.submitHandler}>
                <p>Amount:</p>
                <input type="number" name="incomeAmount" value={incomeAmount} onChange={this.changeHandler} step="any"/>
                <p>Date:</p>
                <input type="date" name="incomeDate"value={incomeDate} onChange={this.changeHandler}/>
                <div class="spacer"/>
                <div class="modal-buton-container">
                    <button class="modal-button" type="submit">Submit</button>
                </div>
            </form>
        </div>
        );
    }

    
}
