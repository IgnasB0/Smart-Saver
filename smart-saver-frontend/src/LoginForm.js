import React from "react";

export default class LoginPage extends React.Component {
  constructor(LoginDetails) {
    super(LoginDetails);
    this.state = {
      Username: "",
      password: ""
    };
  }

  changeHandler = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  };

  submitHandler = (e) => {
    
    e.preventDefault()
        const url="https://localhost:44317/Login"

        fetch(url,
            {
                method:'POST',
                body: expensespost,
                headers:{'Content-Type':'application/json'}
            })
            .then(res => res)
            .catch(error => console.error('Error:',error))
            .then(alert("Success"));
  };

  render() {
    const { Username, Password } = this.state;
    return (
      <div>
        <form onSubmit={this.submitHandler}>
          <div>
            Username:
            <input
              type="text"
              name="Username"
              value={Username}
              onChange={this.changeHandler}
            />
          </div>
          <div>
            Password:
            <input
              type="password"
              name="Password"
              value={Password}
              onChange={this.changeHandler}
            />
          </div>
          <button type="submit">Log In</button>
        </form>
      </div>
    );
  }
}
