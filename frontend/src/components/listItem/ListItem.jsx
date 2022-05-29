import "./listItem.scss";
import React, { useState } from "react";
import {
  Add,
  PlayArrow,
  ThumbDownAltOutlined,
  ThumbUpAltOutlined,
} from "@material-ui/icons";

const ListItem = () => {
  const [isHovered, setIsHovered] = useState(false);
  return (
    <div
      className="listItem"
      // style={{ left: isHovered && index * 225 - 50 + index * 2.5 }}
      onMouseEnter={() => setIsHovered(true)}
      onMouseLeave={() => setIsHovered(false)}
    >
      <img
        src="https://www.gamespot.com/a/uploads/original/1562/15626911/3776884-image%285%29.png"
        alt=""
      />
      {isHovered && (
        <>
          {/* put trailer here */}
          <video src="" autoPlay={true} loop />
          <div className="itemInfo">
            <div className="icons">
              <PlayArrow className="icon" />
              <Add className="icon" />
              <ThumbUpAltOutlined className="icon" />
              <ThumbDownAltOutlined className="icon" />
            </div>
            <div className="itemInfoTop">
              <span>1 hour 35 mins</span>
              <span className="limit">+18</span>
              <span>1999</span>
            </div>
            <div className="desc">
              Lorem ipsum dolor sit, amet consectetur adipisicing elit. Aliquid,
              repellat totam nemo fugit deserunt sequi ab accusamus tempora
              laudantium repellendus consectetur porro aspernatur voluptas illum
              quisquam itaque neque, exercitationem alias obcaecati aliquam sit
              amet quibusdam rerum? Saepe itaque quasi dolor, blanditiis
              corrupti eum vero autem, doloribus molestiae sunt, officia
              incidunt.
            </div>
          </div>
        </>
      )}
    </div>
  );
};

export default ListItem;
