import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import ProjectNavbar from "./Components/ProjectNavbar";
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
