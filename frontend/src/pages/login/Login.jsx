import { ArrowBackOutlined } from "@material-ui/icons";
import { useState } from "react";
import { Link } from "react-router-dom";
import "./login.scss";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = (e) => {
    e.preventDefault();
  };

  return (
    <div
      className="login"
      style={{
        background:
          "linear-gradient(to bottom, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 1) 100%),url('/assets/register-background.PNG')",
      }}
    >
      <div className="top">
        <div className="wrapper">
          <img src="" alt="" className="logo" />
          <Link to="/">
            <div className="back">
              <ArrowBackOutlined />
              Home
            </div>
          </Link>
          <button className="loginButton">Sign Up</button>
        </div>
      </div>
      <div className="container">
        <form action="">
          <h1>Sign In</h1>
          <input
            type="email"
            placeholder="Email or Phone Number"
            onChange={(e) => setEmail(e.target.value)}
          />
          <input
            type="password"
            placeholder="password"
            onChange={(e) => setPassword(e.target.value)}
          />
          <button className="loginButton" onClick={handleLogin}>
            Sign In
          </button>
          <span>
            New to Netflix? <b>Sign Up</b>
          </span>
        </form>
      </div>
    </div>
  );
};

export default Login;
