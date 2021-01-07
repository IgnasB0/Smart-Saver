import React, { useState } from 'react';
import Modal from 'react-modal';
import MainForm from '../MainForm';
import { AddExpense } from './AddExpense';
import { Income } from './Income';
import {Link,useHistory} from 'react-router-dom';
import { propTypes } from 'react-bootstrap/esm/Image';

const AddExpenseModal = (props) => {
    const [modalIsOpen, setModalIsOpen] = useState(false)
    const customStyles = {
        overlay: {
            backgroundColor: 'rgb(15, 15, 15, 0.8)',
        },
        content: {
            backgroundColor: 'rgb(95, 95, 95)',
            color: '#f2e0ff',
            width: '60%',
            height: '40%',
            opacity: '1',
            display: 'flex',
            justifyContent: 'center',
            flexDirection: 'column',
            borderRadius: '25px',
            borderSize: '10px',
            border: 'solid 15px rgb(204, 92, 0)',
            position: 'absolete',
            marginTop: '10%',
            marginLeft: '20%',
        },
    }

    function refreshPage() {
        window.location.reload();
      }

    return (

        <div class="add-expense-modal-frame">
            <button class="expense-add-button" onClick = {() => setModalIsOpen(true)}>Add  </button >
            <Modal portalClassName="add-expense-modal" style={customStyles} centered
            isOpen={modalIsOpen} onRequestClose={() => setModalIsOpen(false)}>
                <AddExpense name = {props.name}/>
                <button class="modal-button" onClick = {()=> setModalIsOpen(false)}  onClick = {refreshPage} >Close </button>  
            </Modal>
        </div>
    )
}
export default AddExpenseModal;
