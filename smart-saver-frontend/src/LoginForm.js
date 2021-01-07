import React from "react";

export default class LoginPage extends React.Component {
  sendData = () => {
    this.props.parentCallback("suveike");
  }

  constructor(LoginDetails) {
    super(LoginDetails);
    this.state = {
      Username: "",
      password: "",
      loginStatus: false
    };
  }

  changeHandler = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  };

  submitHandler = (e) => {
    
    e.preventDefault()
        const url="https://localhost:44317/Login/AttemptLogin?userName=" + this.state.Username + "&password=" + this.state.Password

        fetch(url,
            {
                method:'GET',
                headers:{'Content-Type':'application/json'}
            })
            .then(res => res.json()).then(
              result => {
                  this.setState({loginStatus:result});
                  alert(this.state.loginStatus);
                  this.sendData();
              }
          )
            
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
