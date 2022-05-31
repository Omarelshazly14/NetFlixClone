import axios from "axios";

let BaseURL = "http://localhost:5067";

// let get = () => axios.get(`${BaseURL}/movies`,{headers:{token:"Bearer "}});
let get = () => axios.get(`${BaseURL}/api/Movie`);
let getById = (movieID) => axios.get(`${BaseURL}/movie/${movieID}`);
let post = (movie) => axios.post(`${BaseURL}/movie`, movie);
let edit = (movie, movieID) => axios.put(`${BaseURL}/movie/${movieID}`, movie);
let remove = (movieID) => axios.delete(`${BaseURL}/movie/${movieID}`);

export let MovieAPI = {
  get,
  getById,
  post,
  edit,
  remove,
};
