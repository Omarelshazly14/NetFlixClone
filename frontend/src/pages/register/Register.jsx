import "./register.scss";
import React, { useRef, useState } from "react";
import { ArrowBackOutlined } from "@material-ui/icons";
import { Link } from "react-router-dom";

const Register = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const emailRef = useRef();
  const passwordRef = useRef();

  const handleStart = () => {
    setEmail(emailRef.current.value);
  };
  const handleFinish = () => {
    setEmail(passwordRef.current.value);
  };
  return (
    <div
      className="register"
      style={{
        background:
          "linear-gradient(to bottom, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 1) 90%),url('/assets/register-background.PNG')",
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
          <button className="loginButton">Sign In</button>
        </div>
      </div>
      <div className="container">
        <h1>Unlimited Movies, TV Shows, and more.</h1>
        <h2>Watch anywhere, Cancel anytime</h2>
        <p>
          Ready to watch? Enter your email to create or restart your membership
        </p>
        {!email ? (
          <div className="input">
            <input type="email" placeholder="email address" ref={emailRef} />
            <button className="registerButton" onClick={handleStart}>
              Get Started
            </button>
          </div>
        ) : (
          <form className="input">
            <input type="password" placeholder="password" ref={passwordRef} />
            <button className="registerButton" onClick={handleFinish}>
              Finish
            </button>
          </form>
        )}
      </div>
    </div>
  );
};

export default Register;
