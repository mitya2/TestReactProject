import React, { useEffect, useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";
import ValidatedInput from "../Components/ValidatedInput";

const UpdateProductModal = ({ show, id, setShowModal, updateData }) => {
  // обработка валидации формы
  const [formValidated, setFormValidated] = useState(false);
  const [validated1, setValidated1] = useState(false);
  const [validated2, setValidated2] = useState(false);
  const [validated3, setValidated3] = useState(false);

  useEffect(() => {
    if (validated1 && validated2 && validated3) {
      setFormValidated(true);
    } else {
      setFormValidated(false);
    }
  }, [validated1, validated2, validated3]);
  /////////////////////////////////////////////////

  const handleClose = () => {
    setShowModal(false);
  };

  const handleSave = () => {
       fetch("/api/products/" + id, {
      method: "POST",
      body: JSON.stringify({
         productID: id
      })
    }).then((result) => {
      setShowModal(false);
      updateData();
    });
  };

  return (
    <Modal
      aria-labelledby="contained-modal-title-vcenter"
      centered
      show={show}
      onHide={handleClose}
    >
      <Modal.Header>
        <Modal.Title>
          {id ? "Редактирование продукта" : "Добавление продукта"}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <ValidatedInput
            title="Наименование продукта"
            type="text"
            placeHolderValue="Введите наименование продукта"
            value=""
            textarea="input"
            validations={{
              maxLength: 10,
              minLength: 3,
              isEmpty: false,
            }}
            validated={setValidated1}
          />
          <ValidatedInput
            title="Цена за ед, руб."
            type="text"
            placeHolderValue="Введите цену продукта"
            value=""
            textarea="input"
            validations={{
              isPrice: false,
            }}
            validated={setValidated2}
          />
          <ValidatedInput
            title="Примечание"
            type="text"
            placeHolderValue=""
            value=""
            textarea="textarea"
            validations={{
              maxLength: 50,
            }}
            validated={setValidated3}
          />
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          Отмена
        </Button>
        <Button
          disabled={!formValidated}
          variant="success"
          onClick={handleSave}
        >
          {id ? "Сохранить" : "Добавить"}
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default UpdateProductModal;
