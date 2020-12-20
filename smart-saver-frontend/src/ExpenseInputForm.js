import React from 'react';
import './ExpenseInputForm.css';

export default function ExpenseInputForm() {
    return (
        <div>
            <div class="input-row">
                <p> Expense Name:</p>
                <input type="text"></input>
            </div>
            <div class="input-row">
                <p> Expense Amount:</p>
                <input type="number" step="any"></input>
            </div>
            <div class="input-row">
                <p> Expense Category:</p>
                <select>
                    <option value="food">Food</option>
                    <option value="clothing">Clothing</option>
                </select>
            </div>
        </div>
    )
}
