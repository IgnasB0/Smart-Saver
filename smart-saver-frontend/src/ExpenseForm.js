import React from 'react';
import ExpenseComponent from './ExpenseComponent';
import './ExpenseForm.css';

export default function ExpenseForm() {
    return (
        <div>
            <div class="row">
                <div class="status-column">
                    <ExpenseComponent/>
                </div>
                <div class="status-column">
                    <ExpenseComponent/>
                </div>
                <div class="status-column">
                    <ExpenseComponent/>
                </div>
            </div>
        </div>
    )
}
