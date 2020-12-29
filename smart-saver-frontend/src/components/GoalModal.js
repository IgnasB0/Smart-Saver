import React, { useState } from 'react';
import Modal from 'react-modal';
import { Goal } from './Goal'

export default function GoalModal(){
    const [modalIsOpen, setModalIsOpen] = useState(false)
    const customStyles = {
        overlay: {
            backgroundColor: 'rgb(15, 15, 15, 0.8)',
        },
        content: {
            backgroundColor: 'rgb(95, 95, 95)',
            color: '#f2e0ff',
            width: '60%',
            height: '30%',
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
        <div class="set-goal-modal-frame">
            <button class="main-form-button-right" onClick = {() => setModalIsOpen(true)}>Set Goal</button >
            <Modal portalClassName="set-goal-modal" style={customStyles} centered
            isOpen={modalIsOpen} onRequestClose={() => setModalIsOpen(false)}>
                <Goal/>
                <button class="modal-button" onClick = {()=> setModalIsOpen(false)}>Close</button>
            </Modal>
        </div>
    )
}
