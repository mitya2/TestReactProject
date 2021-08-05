import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import NaviBar from "./Components/Navibar";

import { 
  BrowserRouter as Router, 
  Switch,
  Route} 
  from "react-router-dom";

import SalesOrders from './Pages/SalesOrders'
import Products from './Pages/Products'
import About from './Pages/About'
import AddProduct from './Pages/AddProduct'
import EditProduct from './Pages/EditProduct'

function App() {
  return (
    <>
      <Router>
        <NaviBar />
        <Switch>
          <Route exact path="/" component={SalesOrders} />
          <Route exact path="/products" component={Products} />
          <Route exact path="/about" component={About} />
          <Route exact path="/addProduct" component={AddProduct} />
          <Route path="/editProduct" component={EditProduct} />
        </Switch>
      </Router>
    </>
  );
}

export default App;
