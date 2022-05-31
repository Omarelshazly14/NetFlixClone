import "./home.scss";
import React, { useEffect, useState } from "react";
import Navbar from "../../components/navbar/Navbar";
import Featured from "../../components/featured/Featured";
import List from "../../components/list/List";
import { MovieAPI } from "../../APIs/MoviesAPI.js";

const Home = () => {
  const [list, setList] = useState([]);
  const [Drama, setDrama] = useState([]);
  const [Adventure, setAdventure] = useState([]);
  const [Action, setAction] = useState([]);
  const [Animation, setAnimation] = useState([]);
  // const DramaList = list.filter((item) => item.genre == "Drama");
  useEffect(() => {
    getMoviesList();
  }, []);

  const getMoviesList = async () => {
    try {
      const res = await MovieAPI.get();
      setList(res.data);
      setDrama(list.filter((item) => item.genre == "Drama"));
      setAdventure(list.filter((item) => item.genre == "Adventure"));
      setAction(list.filter((item) => item.genre == "Action"));
      setAnimation(list.filter((item) => item.genre == "Animation"));
      console.log(res.data[0].genre);
      console.log(Drama);
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="home">
      <Navbar />
      <Featured />
      <List list={Drama} genre="Drama" />
      <List list={Adventure} genre="Adventure" />
      <List list={Action} genre="Action" />
      <List list={Animation} genre="Animation" />
    </div>
  );
};

export default Home;
