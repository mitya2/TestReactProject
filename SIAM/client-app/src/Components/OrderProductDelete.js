import React, { useState } from "react";
import { Modal, Button } from "react-bootstrap";

const OrderProductDelete = ({ index, name, deleteOrderProduct }) => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <>
      <Button
        style={{ fontSize: "1em", width: "25px", height: "25px" }}
        className="p-0 m-0"
        onClick={handleShow}
        size="sm"
        variant="danger"
      >
        &times;
      </Button>

      <Modal centered show={show} onHide={handleClose}>
        <Modal.Header style={{ backgroundColor: "#e46774" }}>
          <Modal.Title style={{ color: "white" }}>
            Удаление позиции заказа
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {"Вы действительно хотите удалить позицию заказа: " + name + "?"}
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Отмена
          </Button>
          <Button
            variant="danger"
            onClick={() => {
              deleteOrderProduct(index);
              setShow(false);
            }}
          >
            Удалить
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
};

export default OrderProductDelete;
