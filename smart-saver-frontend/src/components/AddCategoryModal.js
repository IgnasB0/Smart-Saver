import React, { useState } from 'react';
import Modal from 'react-modal';
import { AddCategory } from './AddCategory';
import { Income } from './Income'

export default function AddCategoryModal(){
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

        <div class="add-category-modal-frame">
           <button class="modal-button" onClick = {() => setModalIsOpen(true)}>Add Category </button >
            <Modal portalClassName="add-category-modal" style={customStyles} centered
            isOpen={modalIsOpen} onRequestClose={() => setModalIsOpen(false)}>
                <AddCategory/>
                <button class="modal-button" onClick = {()=> setModalIsOpen(false)}  >Close </button>
            </Modal>
        </div>
    )
}
