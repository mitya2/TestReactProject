import React from "react";
import { Modal, Button } from "react-bootstrap";

const UpdateProductModal = ({ show, id, setShowModal, updateData }) => {
  
  const handleClose = () => {
    setShowModal(false)
  };

  const handleSave = () => {
    fetch("/api/products/" + id, { method: "DELETE" }).then((result) => {
      setShowModal(false)
      updateData();
    });
  };

  return (
    <>
      <Modal
        //size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
        show={show}
        onHide={handleClose}
      >
        <Modal.Header>
          <Modal.Title>
            {id ? "Редактирование продукта": "Добавление продукта"}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Отмена
          </Button>
          <Button variant="success" onClick={handleSave}>
            {id ? "Сохранить" : "Добавить"}
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
};

export default UpdateProductModal;
