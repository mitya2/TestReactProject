import React, { useEffect } from "react";
import Loading from "./Components/Loading";

export default function Products() {
  const [products, setProducts] = React.useState([]);
  const [isLoading, setLoading] = React.useState(true);

  useEffect(() => {
    fetch("/api/products")
      .then((response) => response.json())
      .then((products) => {
        setTimeout(() => {
          setProducts(products);
          setLoading(false);
        }, 500); // задержка для демонстрации отображения процесса загрузки данных
      });
  }, []);

  return (
    <div>
      <h1>Page Products</h1>
      <ul>
        {isLoading && <Loading />}
        {products.map((item) => (
          <li key={item.productId}>{item.name}</li>
        ))}
      </ul>
    </div>
  );
}
