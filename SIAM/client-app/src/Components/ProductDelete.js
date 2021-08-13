import React, { useState } from "react";
import { Modal, Button } from "react-bootstrap";

const ProductDelete = ({ id, name, updateData }) => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleDelete = () => {
    fetch("/api/products/" + id, {
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

      <Modal centered show={show} onHide={handleClose}>
      <Modal.Header style={{ backgroundColor: "#e46774" }}>
          <Modal.Title style={{ color: "white"}}>Удаление продукта</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {"Вы действительно хотите удалить позицию: «" + name + "»?"}
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

export default ProductDelete;
