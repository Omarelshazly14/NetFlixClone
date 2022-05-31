import "./app.scss";
import Home from "./pages/home/Home";
import Watch from "./pages/watch/Watch";
import Register from "./pages/register/Register";
import Login from "./pages/login/Login";
import { Route, Routes } from "react-router-dom";

function App() {
  const user = true;
  return (
    <Routes>
      <Route exact path="/" element={<Home />} />
      <Route exact path="/register" element={<Register />} />
      <Route exact path="/login" element={<Login />} />
      <Route exact path="/watch" element={<Watch />} />
    </Routes>
    // <Router>
    //   <Switch>
    //     <Route exact path="/">
    //       {user ? <Home /> : <Redirect to="register" />}
    //     </Route>
    //     <Route exact path="/register">
    //       {!user ? <Register /> : <Redirect to="/" />}
    //     </Route>
    //     <Route exact path="/login">
    //       {!user ? <Login /> : <Redirect to="/" />}
    //     </Route>
    //     {user && (
    //       <>
    //         <Route exact path="/watch">
    //           <Watch />
    //         </Route>
    //       </>
    //     )}
    //   </Switch>
    // </Router>
  );
}

export default App;
