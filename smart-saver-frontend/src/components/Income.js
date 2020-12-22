import React, {Component} from 'react';
import Button from 'react-bootstrap/Button';
import axios from 'axios';

export class Income extends React.Component{

    constructor(props) {
        super(props);
        this.state ={
            incomeAmount: '',
            incomeDate: ''
        }
        
      }

     

        changeHandler = e =>{
            this.setState({[e.target.name]: e.target.value})
        }

        /* submitHandler = e =>{
            e.preventDefault()
            console.log(this.state)
            axios.post('https://localhost:44317/incomes',this.state)
                .then(response => {
                    console.log(response)
                })
                .catch(error => {
                    console.log(error)
                })
        } */

        componentDidMount() {            //kazkas blogai su portais

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ title: 'React POST Request Example' })
            };
            fetch('https://localhost:44317/incomes', requestOptions)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
        }


       
    render(){
        const {incomeAmount, incomeDate} = this.state;
        return (
            
        <div>
            <form onSubmit={this.componentDidMount}>
                <div>
                <input type="number" name="incomeAmount" value={incomeAmount} onChange={this.changeHandler} step="any"/>
                </div>
                <div>
                <input type="date" name="incomeDate"value={incomeDate} onChange={this.changeHandler}/>
                </div>
                <Button type="submit">Submit</Button>
            </form>
        </div>
        )
    }
}