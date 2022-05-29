import "./home.scss";
import React, { useEffect, useState } from "react";
import Navbar from "../../components/navbar/Navbar";
import Featured from "../../components/featured/Featured";
import List from "../../components/list/List";
import MovieAPI from "../../APIs/MoviesAPI.js";

const Home = () => {
  const [lists, setLists] = useState([]);

  useEffect(() => {
    getMoviesLists();
  }, []);

  const getMoviesLists = async () => {
    try {
      const res = await MovieAPI.get();
      setLists(res.data);
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="home">
      <Navbar />
      <Featured />
      {lists.map((list, index) => {
        <List list={list} />;
      })}
    </div>
  );
};

export default Home;
