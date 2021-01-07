import React, { useState } from 'react';
import Modal from 'react-modal';

export default function LoginModal(){
    function refreshPage() {
        window.location.reload();
      }
    const [modalIsOpen, setModalIsOpen] = useState(false)
    const customStyles = {
        overlay: {
            backgroundColor: 'rgb(15, 15, 15, 0.8)',
        },
        content: {
            backgroundColor: 'rgb(95, 95, 95)',
            color: '#FFFFFF',
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

        <div class="add-income-modal-frame">
            <button class="main-form-button-left" onClick = {() => setModalIsOpen(true)}>Log In </button >
            <Modal portalClassName="add-income-modal" style={customStyles} centered
            isOpen={modalIsOpen} onRequestClose={() => setModalIsOpen(false)}>
                LOGIN TEST
                <button class="modal-button" onClick = {()=> setModalIsOpen(false)}  onClick = {refreshPage} >Close </button>
            </Modal>
        </div>
    )
}
