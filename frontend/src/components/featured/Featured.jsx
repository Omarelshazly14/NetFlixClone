import "./featured.scss";
import React from "react";
import { InfoOutlined, PlayArrow } from "@material-ui/icons";

const Featured = () => {
  return (
    <div className="featured">
      <img src="https://wallpaperaccess.com/full/2116417.jpg" alt="" />
      <div className="info">
        <img
          src="https://www.pngall.com/wp-content/uploads/5/Joker-Movie-PNG-Image.png"
          alt=""
        />
        <span className="desc">
          A mentally troubled stand-up comedian embarks on a downward spiral
          that leads to the creation of an iconic villain.
        </span>
        <div className="buttons">
          <button className="play">
            <PlayArrow />
            <span>Play</span>
          </button>
          <button className="more">
            <InfoOutlined />
            <span>Info</span>
          </button>
        </div>
      </div>
    </div>
  );
};

export default Featured;
