import React, { useState } from "react";
import { Modal, Button } from "react-bootstrap";

const SalesOrderDeleteModal = ({ id, updateData }) => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleDelete = () => {
    fetch("/api/sales_orders/" + id, {
      method: "DELETE",
      headers: { "Content-Type": "application/json" },
    }).then((result) => {
      setShow(false);
      updateData();
    });
  };

  return (
    <>
      <Button onClick={handleShow} size="sm" variant="danger">
        &times;
      </Button>

        <Modal
          centered
          show={show}
          onHide={handleClose}
        >
          <Modal.Header style={{ backgroundColor: "#e46774" }}>
            <Modal.Title style={{ color: "white" }}>
              Удаление заказа
            </Modal.Title>
          </Modal.Header>
          <Modal.Body>
            {"Вы действительно хотите удалить заказ номер: " + id + "?"}
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
              Отмена
            </Button>
            <Button variant="danger" onClick={handleDelete}>
              Удалить
            </Button>
          </Modal.Footer>
        </Modal>
    </>
  );
};

export default SalesOrderDeleteModal;
