import "./navbar.scss";
import React, { useState } from "react";
import { ArrowDropDown, Notifications, Search } from "@material-ui/icons";
import { Link } from "react-router-dom";

const Navbar = () => {
  const [isScrolled, setIsScrolled] = useState(false);

  window.onscroll = () => {
    setIsScrolled(window.scrollY < 10 ? false : true);
    console.log(window.scrollY);
    console.log(isScrolled);
    return () => (window.onscroll = null);
  };
  return (
    <div className="navbar">
      <div className="container">
        <div className="left">
          <img
            src="https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/Netflix_2015_logo.svg/1280px-Netflix_2015_logo.svg.png"
            alt=""
          />
          <Link to="/" className="link">
            <span>Home</span>
          </Link>
          <span>Movies</span>
          <span>Popular</span>
          <span>New</span>
        </div>
        <div className="right">
          <Search className="icon" />
          {/* <span> KID</span> */}
          <Notifications className="icon" />
          <img
            src="https://images.pexels.com/photos/1704488/pexels-photo-1704488.jpeg?cs=srgb&dl=pexels-suliman-sallehi-1704488.jpg&fm=jpg"
            alt=""
          />
          <div className="profile">
            <ArrowDropDown className="icon" />
            <div className="options">
              <span className="optionsItem">Settings</span>
              <span className="optionsItem">Logout</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Navbar;
