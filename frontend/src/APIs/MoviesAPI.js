import axios from "axios";

let BaseURL = "http://localhost:3001";

let get = () => axios.get(`${BaseURL}/movies`);
let getById = (movieID) => axios.get(`${BaseURL}/movies/${movieID}`);
let post = (movie) => axios.post(`${BaseURL}/movies`, movie);
let edit = (movie, movieID) => axios.put(`${BaseURL}/movies/${movieID}`, movie);
let remove = (movieID) => axios.delete(`${BaseURL}/movies/${movieID}`);

export let MovieAPI = {
  get,
  getById,
  post,
  edit,
  remove,
};
