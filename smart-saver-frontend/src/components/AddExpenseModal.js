import React, { useState } from 'react';
import Modal from 'react-modal';
import MainForm from '../MainForm';
import { AddExpense } from './AddExpense';

export default function AddExpenseModal(){
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
            borderSize: '10px',
            border: 'solid 15px rgb(204, 92, 0)',
            position: 'absolete',
            marginTop: '10%',
            marginLeft: '20%',
        },
    }

    return (

        <div class="add-expense1-modal-frame">
            <Modal portalClassName="add-expense1-modal" style={customStyles} centered
            isOpen={() => setModalIsOpen(true)} onRequestClose={() => setModalIsOpen(false)}>
                <AddExpense/>
            </Modal>
        </div>
    )
}
