import React, {useEffect} from "react";
import { Switch, Route, useLocation } from "react-router-dom";

import SalesOrders from "./Pages/SalesOrders";
import Products from "./Pages/Products";
import About from "./Pages/About";
import AddProduct from "./Pages/AddProduct";
import EditProduct from "./Pages/EditProduct";


const Routing = () => {
    const location = useLocation();
    
   
    useEffect(() => {
      console.log(location)
      if (location.pathname != '/products') localStorage.removeItem("productsPageNumber");
      }, [location]);

    return (
    <Switch>
      <Route exact path="/" component={SalesOrders} />
      <Route exact path="/products" component={Products} />
      <Route exact path="/about" component={About} />
      <Route exact path="/addProduct" component={AddProduct} />
      <Route path="/editProduct" component={EditProduct} />
    </Switch>
  );
};

export default Routing;
