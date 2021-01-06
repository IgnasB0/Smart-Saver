import React, {Component} from 'react';
import Button from 'react-bootstrap/Button';
import {Link,useHistory} from 'react-router-dom';
import { browserHistory, Router, Route,Switch } from 'react-router';

export class AddCategory extends React.Component{
    constructor(props) {
        super(props);
        this.state ={
            categoryName: ''
        }
        this.InsertedCategory = this.InsertedCategory.bind(this);
      }

      InsertedCategory() {
        alert('Category was added successfully!');
      }

      changeHandler = e =>{
        this.setState({[e.target.name]: e.target.value})
    }
    submitHandler = e =>{
        e.preventDefault()
        const url="https://localhost:44317/categories"
        const categoriespost = "\"" + this.state.categoryName + "\"" ;

        fetch(url,
            {
                method:'POST',
                body: categoriespost,
                headers:{'Content-Type':'application/json'}
            })
            .then(res => res)
            .catch(error => console.error('Error:',error))
            .then(response => this.InsertedCategory());
            
    }

      render(){
        const {categoryName} = this.state;
        return (
            
        <div>
            <form onSubmit={this.submitHandler}>
                <label>
                    Category name:
                
                <div>
                <input type="text" name="categoryName" value={categoryName} onChange={this.changeHandler} step="any"/>
                </div>
                </label>
                <button class="main-form-button-left" type="submit">Add</button>
                
            </form>
        </div>
        )
    }
} 