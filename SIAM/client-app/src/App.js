import React, { useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import NaviBar from "./Components/Navibar";

import {
  BrowserRouter as Router
} from "react-router-dom";

import Routing from "./Routing";

function App() {
  return (
    <>
      <Router>
        <NaviBar />
        <Routing/>>
      </Router>
    </>
  );
}

export default App;
