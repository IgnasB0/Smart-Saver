import React, {useState} from 'react';
import {NavLink} from 'react-router-dom';
import {Navbar, Nav} from 'react-bootstrap';
import Button from 'react-bootstrap/Button';
import IncomeModal from './components/IncomeModal';

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
            </Nav>
            </ul>
            <i onClick={() => setOpen(!open)} className="fas fa-bars burger"></i>
        </nav>    
        </div>
    )
}

export default NavBar;