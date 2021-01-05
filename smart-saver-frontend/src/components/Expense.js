import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import { AddExpense } from './AddExpense';
import {Link, Router} from 'react-router-dom';
import {BrowserRouter,Route,Switch} from 'react-router-dom';
import { AddCategory } from './AddCategory';
import { Income } from './Income';
import MainForm from '../MainForm';



export class Expense extends React.Component{

    constructor(props) {
        super(props);
          this.state = {
            expensecategories: [],
            expensecategoryName: [],
          }; 

          
          this.handleBack = this.handleBack.bind(this);
      }
      
    
      

handleBack() {
  alert(this);
}




componentDidMount(){
  fetch("https://localhost:44317/expenses/get-category-expense-amount?neededCategory=Food" )
        .then(res => res.json()).then(
            result => {
                this.setState({expensecategoryName:result});
            }
        ) }


     

createUI(){
  
  return this.state.expensecategories.map((el, i) => 
  <div key={i} >

    <label> {el||''} :  
         <div>
          {/*  <label> Expense by category:  {this.state.expensecategoryName}</label> kazkaip reiktu paduoti category  */}

          <Link to={{pathname: "/addexpense", data: el||''}} >Add</Link>  
         </div>

         
    </label> 
    
  
  </div>
        
)
}




    render(){
      
        fetch("https://localhost:44317/categories/parse-categories")
        .then(res => res.json()).then(
            result => {
                this.setState({expensecategories:result});
            }
        );
        

            return(
              
              <form >
 
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
