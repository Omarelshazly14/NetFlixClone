import "./listItem.scss";
import React, { useState } from "react";
import {
  Add,
  PlayArrow,
  ThumbDownAltOutlined,
  ThumbUpAltOutlined,
} from "@material-ui/icons";
import { Link } from "react-router-dom";

const ListItem = ({ index, item }) => {
  const [isHovered, setIsHovered] = useState(false);
  return (
    <div
      className="listItem"
      style={{ left: isHovered && index * 225 - 50 + index * 2.5 }}
      onMouseEnter={() => setIsHovered(true)}
      onMouseLeave={() => setIsHovered(false)}
    >
      <img src={item.image} alt="" />
      {isHovered && (
        <>
          <video src={item.trailer} autoPlay={true} loop />
          <div className="itemInfo">
            <div className="icons">
              <PlayArrow className="icon" />
              <Add className="icon" />
              <ThumbUpAltOutlined className="icon" />
              <ThumbDownAltOutlined className="icon" />
            </div>
            <div className="itemInfoTop">
              <span>{item.duration}</span>
              <span className="limit">+{item.limit}</span>
              <span>item.date</span>
            </div>
            <div className="desc">{item.description}</div>
          </div>
        </>
      )}
    </div>
  );
};

export default ListItem;
