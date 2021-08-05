import React, {useState,  useEffect } from "react";
import Loading from "../Components/Loading";

export default function SalesOrders() {
  const [sales_orders, setSalesOrders] = useState([]);
  const [isLoading, setLoading] = useState(true);

  useEffect(() => {
    fetch("/api/sales_orders")
      .then((response) => response.json())
      .then((sales_orders) => {
        setTimeout(() => {
          setSalesOrders(sales_orders);
          setLoading(false);
        }, 500); // задержка для демонстрации отображения процесса загрузки данных
      });
  }, []);

  return (
    <div className="m-2">
      <h4>Список заказов</h4>
      <ul>
        {isLoading && <Loading />}
        {sales_orders.map((item) => (
          <li key={item.orderId}>{item.name}</li>
        ))}
      </ul>
    </div>
  );
}
