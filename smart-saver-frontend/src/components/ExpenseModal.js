import React, { useState } from 'react';
import Modal from 'react-modal';
import Expense from './Expense';

export default function ExpenseModal(){

    const [modalIsOpen, setModalIsOpen] = useState(false)
    const customStyles = {
        overlay: {
            backgroundColor: 'rgb(15, 15, 15, 0.8)',
        },
        content: {
            backgroundColor: 'rgb(95, 95, 95)',
            color: '#f2e0ff',
            width: '60%',
            height: '60%',
            opacity: '1',
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'center',
            borderRadius: '25px',
            fontSize: '20px',
            borderSize: '10px',
            border: 'solid 15px rgb(204, 92, 0)',
            position: 'absolete',
            marginTop: '10%',
            marginLeft: '20%',
        },
    }
    return (

        <div class="add-expense-modal-frame">
            <button class="main-form-button-left" onClick = {() => setModalIsOpen(true)}>Add Expense </button >
            <Modal portalClassName="add-expense-modal" style={customStyles} centered
            isOpen={modalIsOpen} onRequestClose={() => setModalIsOpen(false)}>
                <Expense/>
                <button class="modal-button" onClick = {()=> setModalIsOpen(false)} >Close </button>
            </Modal>
        </div>
    )
}
