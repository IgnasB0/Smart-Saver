import React, {useState} from 'react';
import {NavLink} from 'react-router-dom';
import {Navbar, Nav} from 'react-bootstrap';

function NavBar(){
    const [open, setOpen] = useState(false);
    return (
        <div>
        <nav>
            <div className="logo"> 
            MainForm
            </div>
            <ul className="nav-links" style={{transform: open ? "translateX(0px)" : "" }}>
            <Nav>
                <NavLink className="d-inline p-2 bg-dark text-white"
                to="/">
                    <li><a>Mainform</a></li>
                    </NavLink>

                    <NavLink className="d-inline p-2 bg-dark text-white"
                        to="/income">
                 <li><a>Income</a></li>
                    </NavLink>
                
                    <NavLink className="d-inline p-2 bg-dark text-white"
                        to="/expense">
                 <li><a>Expense</a></li>
                    </NavLink>

                    <NavLink className="d-inline p-2 bg-dark text-white"
                        to="/addexpense">
                 <li><a>AddExpense</a></li>
                    </NavLink>
                     <NavLink className="d-inline p-2 bg-dark text-white"
                        to="/addcategory">
                 <li><a>AddCategory</a></li>
                    </NavLink> 
            </Nav>
            </ul>
            <i onClick={() => setOpen(!open)} className="fas fa-bars burger"></i>
        </nav>    
        </div>
    )
}

export default NavBar;