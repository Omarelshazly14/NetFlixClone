import "./listItem.scss";
import React, { useState } from "react";
import {
  Add,
  PlayArrow,
  ThumbDownAltOutlined,
  ThumbUpAltOutlined,
} from "@material-ui/icons";
import { Link, useLocation } from "react-router-dom";

const ListItem = ({ index, item }) => {
  const [isHovered, setIsHovered] = useState(false);

  return (
    <Link to="/watch" state={{ movie: item.trailer }}>
      <div
        className="listItem"
        style={{ left: isHovered && index * 225 - 50 + index * 2.5 }}
        onMouseEnter={() => setIsHovered(true)}
        onMouseLeave={() => setIsHovered(false)}
      >
        <img
          src={`/assets/${item.image}`}
          alt=""
          defaultValue={`/assets/Dune.jpeg`}
        />
        {isHovered && (
          <>
            <video src={`/assets/${item.trailer}`} autoPlay={true} loop muted />
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
                <span>{item.date}</span>
              </div>
              <div className="title">{item.title}</div>
              <div className="desc">{item.description}</div>
            </div>
          </>
        )}
      </div>
    </Link>
  );
};

export default ListItem;
