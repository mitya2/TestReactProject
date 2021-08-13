import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import ProjectNavbar from "./Components/ProjectNavbar";
//import Draggable from "react-draggable";

import { BrowserRouter as Router } from "react-router-dom";

import Routing from "./Routing";

function App() {
  return (
    <Router>
      <ProjectNavbar />
      <Routing />
   </Router>
  );
}

export default App;

/*<Draggable
      handle=".handle"
    >
      <div className="m-2">
      <h4 className="handle m-2">О проекте...</h4>
      <h4>О2222 проекте...</h4>
      </div>
    </Draggable> */
