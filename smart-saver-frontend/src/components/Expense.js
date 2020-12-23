import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import { AddExpense } from './AddExpense';
import {Link, Router} from 'react-router-dom';
import {BrowserRouter,Route,Switch} from 'react-router-dom';
import { AddCategory } from './AddCategory';
import { Income } from './Income';
import MainForm from '../MainForm';
import NavBar from '../NavBar';



export class Expense extends React.Component{

    constructor(props) {
        super(props);
          this.state = {
            expensecategories: []
          }; 
          this.handleCategory = this.handleCategory.bind(this);
          this.handleBack = this.handleBack.bind(this);
      }



handleBack() {
  alert(this);
}

handleCategory() {
alert(this);
}



createUI(){
  
  return this.state.expensecategories.map((el, i) => 
  <div key={i}>

    <label> {el||''}:  
        <Link to={{pathname: "/addexpense", data: el||''}} >Add</Link>  
    </label>

     {/* <input type="text" value={el||''} /> */}
     {/* <button onClick={() => this.handleSubmit(el||'')}> Add</button>    */}
   
     

  </div>
        
)
}


    render(){
      
        fetch("https://localhost:44317/categories/parse-categories")
        .then(res => res.json()).then(
            result => {
                this.setState({expensecategories:result});
            }
        )

            return(
              <form>
                {this.createUI()}
            
                 <button onClick={this.handleCategory}> Add Category</button>    

                  <button onClick={this.handleBack}> Back</button>  
                
                  
              </form>
            );
        
     }

}
export default Expense;
const element = <Expense></Expense>
ReactDOM.render(element, document.getElementById('root'));
