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
            element : ''
          }; 

          
          this.handleCategory = this.handleCategory.bind(this);
      }
      
 
      handleCategory(){
        window.open('/category');
      }
        

createUI(){
  return this.state.expensecategories.map((el, i) => 
  <div key={i} >

    <label> {el||''} :   <Link to={{pathname: "/addexpense", data: el||''}} >Add</Link>  

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
        var disabled = this.props.disabled || false;
        var style = { backgroundColor: 'red' };

        if(disabled == false) {
          style = { backgroundColor: 'rgb(201, 141, 21)' }
        }
        

            return(
              
              <form >
 
                {this.createUI()}
              
                 <button style ={style} onClick={this.handleCategory}> Add Category</button>   
                 
                
               

              </form>
             
            
            );
        
     }

}
export default Expense;
const element = <Expense></Expense>
ReactDOM.render(element, document.getElementById('root'));
