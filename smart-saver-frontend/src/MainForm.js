import React from 'react';
import './MainForm.css';

export default function MainForm() {
    return (
        <div>
            <div class="row">
                <div class="user-column">
                    <p class="user-label">User: {'user'}</p>
                </div>
                <div class="user-column">

                </div>
            </div>
            <div class="row">
                <div class="status-column">
                    <p class="status-label">Monthly Income: {0}</p>
                </div>
                <div class="status-column">
                    <p class="status-label">Monthly Expenses Amount: {0}</p>
                </div>
                <div class="status-column">
                    <p class="status-label">Monthly Balance: {0}</p>
                </div>
            </div>
            <div class="row">
                <div class="option-column">
                    <button>Add Income</button>
                </div>
                <div class="option-column">
                    <button>Manage Recurring Income</button>
                </div>
                <div class="option-column">
                    <button>Add Expense</button>
                </div>
                <div class="option-column">
                    <button>Set Goal</button>
                </div>
            </div>
            <div class="row">
                <p>*Here we can place graph*</p>
                <p>(Don't know how, though)</p>
            </div>
            <div class="row">
                <p>Time left until goal is reached: {'N/A'} months</p>
            </div>
        </div>
    )
}
