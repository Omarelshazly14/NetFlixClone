import "./home.scss";
import React, { useEffect, useState } from "react";
import Navbar from "../../components/navbar/Navbar";
import Featured from "../../components/featured/Featured";
import List from "../../components/list/List";
import { MovieAPI } from "../../APIs/MoviesAPI.js";

const Home = () => {
  // const [Drama, setDrama] = useState([]);
  // const [Adventure, setAdventure] = useState([]);
  // const [Action, setAction] = useState([]);
  // const [Animation, setAnimation] = useState([]);

  const [data, setData] = useState([]);

  useEffect(() => {
    getMoviesList();
  }, []);

  const getMoviesList = async () => {
    try {
      const res = await MovieAPI.get();
      const Drama = res.data.filter((item) => item.genre === "Drama");
      const Adventure = res.data.filter((item) => item.genre === "Adventure");
      const Action = res.data.filter((item) => item.genre === "Action");
      const Animation = res.data.filter((item) => item.genre === "Animation");

      setData([
        { title: "Drama", movies: Drama },
        { title: "Adventure", movies: Adventure },
        { title: "Action", movies: Action },
        { title: "Animation", movies: Animation },
      ]);
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="home">
      <Navbar />
      <Featured />
      {data &&
        data.map((object, index) => {
          return <List list={object.movies} genre={object.title} key={index} />;
        })}
    </div>
  );
};

export default Home;
