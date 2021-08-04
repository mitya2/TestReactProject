import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import NaviBar from "./Components/Navibar";

import { 
  BrowserRouter as Router, 
  Switch,
  Route} 
  from "react-router-dom";

import SalesOrders from './SalesOrders'
import Products from './Products'
import About from './About'

function App() {
  return (
    <>
      <Router>
        <NaviBar />
        <Switch>
          <Route exact path="/" component={SalesOrders} />
          <Route exact path="/products" component={Products} />
          <Route exact path="/about" component={About} />
        </Switch>
      </Router>
    </>
  );
}

export default App;
