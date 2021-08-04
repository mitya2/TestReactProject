import React, { useEffect } from "react";
import Loading from "./Components/Loading";

export default function SalesOrders() {
  const [sales_orders, setSalesOrders] = React.useState([]);
  const [isLoading, setLoading] = React.useState(true);

  useEffect(() => {
    fetch("/api/sales_orders")
      .then((response) => response.json())
      .then((orders) => {
        setTimeout(() => {
          setSalesOrders(sales_orders);
          setLoading(false);
        }, 500); // задержка для демонстрации отображения процесса загрузки данных
      });
  }, []);

  console.log(sales_orders);

  return (
    <div>
      <h1>Page Sales Orders</h1>
      <ul>
        {isLoading && <Loading />}
        {sales_orders.map((item) => (
          <li key={item.orderId}>{item.name}</li>
        ))}
      </ul>
    </div>
  );
}
