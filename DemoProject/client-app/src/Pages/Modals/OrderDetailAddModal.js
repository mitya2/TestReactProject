import React, { useState } from "react";
import { Modal, Button, Table } from "react-bootstrap";

const OrderDetailAddModal = ({ show, addProductToOrder, setShowProductsList }) => {
  const handleClose = () => {
    setShowProductsList(false);
  };
  const [products, setProducts] = useState([]);

  const handleSelect = (id, name, price) => {
    addProductToOrder(id, name, price);
    setShowProductsList(false);
  };

  // обработка добавления товара в заказ
  const handleEntering = () => {
    //загружаем товары
    fetch("/api/products", {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    })
      .then((response) => response.json())
      .then((data) => {
        setProducts(data);
      });
  };

  return (
    <Modal
      centered
      show={show}
      onHide={handleClose}
      onEntering={handleEntering}
    >
      <Modal.Header style={{ backgroundColor: "#43a047" }}>
        <Modal.Title style={{ color: "white" }}>
          Добавление товара в заказ
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <div
          style={{
            border: "1px solid #dee2e6",
            maxHeight: "400px",
            overflowY: "scroll",
            fontSize: "1em",
          }}
        >
          <Table className="p-1 m-0" striped bordered hover>
            <thead>
              <tr className="align-middle">
                <th className="text-center" width="100px">
                  Артикул
                </th>
                <th>Наименование товара</th>
                <th className="text-center" width="100px">
                  Цена, руб
                </th>
              </tr>
            </thead>
            {products && (
              <tbody>
                {products.map((item) => (
                  <tr
                    key={item.productId}
                    onClick={() =>
                      handleSelect(item.productId, item.name, item.price)
                    }
                    className="align-middle"
                    style={{
                      cursor: "pointer",
                    }}
                  >
                    <td className="text-center">{item.productId}</td>
                    <td>{item.name}</td>
                    <td className="text-center">{item.price}</td>
                  </tr>
                ))}
              </tbody>
            )}
          </Table>
          {products && products.length === 0 && (
            <div className="m-2 text-center">Нет записей</div>
          )}
        </div>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          Отмена
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default OrderDetailAddModal;
