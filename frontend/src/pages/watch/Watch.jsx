import "./watch.scss";
import React from "react";
import { ArrowBackOutlined } from "@material-ui/icons";

const watch = () => {
  return (
    <div className="watch">
      <div className="back">
        <ArrowBackOutlined />
        Home
      </div>
      <video className="video" autoPlay progress controls src="" />
    </div>
  );
};

export default watch;
