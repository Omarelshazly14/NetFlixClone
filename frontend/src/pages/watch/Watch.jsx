import "./watch.scss";
import React from "react";
import { ArrowBackOutlined } from "@material-ui/icons";
import { Link, useLocation } from "react-router-dom";

const Watch = () => {
  const location = useLocation();
  const { movie } = location.state;
  return (
    <div className="watch">
      <Link to="/">
        <div className="back">
          <ArrowBackOutlined />
          Home
        </div>
      </Link>
      <video
        className="video"
        autoPlay
        progress="true"
        controls
        src={`/assets/${movie}`}
      />
    </div>
  );
};

export default Watch;
