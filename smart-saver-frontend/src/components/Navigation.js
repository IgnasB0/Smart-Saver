import React, {Component} from 'react';
import {NavLink} from 'react-router-dom';
import {Navbar, Nav} from 'react-bootstrap';

export class Navigation extends React.Component{
    render(){
        return(
            <Navbar bg="dark" expand ="lg">
            <Navbar.Toggle aria-controls="basic-navbar-nav"/>
            <Navbar.Collapse id="basic-navbar-nav">
            <Nav>
                <NavLink className="d-inline p-2 bg-dark text-white"
                to="/">Mainform</NavLink>
                
                <NavLink className="d-inline p-2 bg-dark text-white"
                to="/income">Income</NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white"
                to="/expense">Expense</NavLink>
                
                 <NavLink className="d-inline p-2 bg-dark text-white"
                to="/addexpense">AddExpense</NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white"
                to="/addcategory">AddCategory</NavLink> 

            </Nav>
            </Navbar.Collapse>
            </Navbar>
        )
    }
}
