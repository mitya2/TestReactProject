import React, { useEffect } from "react";
import { Switch, Route, useLocation } from "react-router-dom";

import SalesOrders from "./Pages/SalesOrders";
import Products from "./Pages/Products";
import About from "./Pages/About";

const Routing = () => {
  const location = useLocation();

  useEffect(() => {
    if (location.pathname !== "/products")
      localStorage.removeItem("productsPageNumber");
    if (location.pathname !== "/")
      localStorage.removeItem("salesOrdersPageNumber");
  }, [location]);

  return (
    <Switch>
      <Route exact path="/" component={About} />
      <Route exact path="/about" component={About} />
      <Route exact path="/products" component={Products} />
      <Route exact path="/sales_orders" component={SalesOrders} />
    </Switch>
  );
};

export default Routing;

//      <Route exact path="/products" component={Products} />
