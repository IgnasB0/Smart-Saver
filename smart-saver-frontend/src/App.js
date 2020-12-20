import logo from './logo.svg';
import './App.css';
import MainForm from './MainForm';
import ExpenseForm from './ExpenseForm';
import ExpenseInputForm from './ExpenseInputForm';

function App() {
  return (
    <div className="App">
      <MainForm/>
      <ExpenseForm/> (/*Temporary location. Component spawn should be automized and in different window. This is just for representation.*/)
      <ExpenseInputForm/>
    </div>
  );
}

export default App;
