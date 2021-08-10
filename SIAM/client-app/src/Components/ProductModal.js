import React, { useEffect, useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";
import ValidatedInput from "./ValidatedInput";

const ProductModal = ({ show, id, setShowUpdateModal, updateData }) => {
  // обработка валидации формы
  const [formValidated, setFormValidated] = useState(false);
  const [validated1, setValidated1] = useState(false);
  const [validated2, setValidated2] = useState(false);
  const [validated3, setValidated3] = useState(false);

  const [currentProduct, setCurrentProduct] = useState({});

  useEffect(() => {
    if (validated1 && validated2 && validated3) {
      setFormValidated(true);
    } else {
      setFormValidated(false);
    }
  }, [validated1, validated2, validated3]);
  /////////////////////////////////////////////////

  const handleClose = () => {
    setShowUpdateModal(false);
  };

  // обработка добавления/редактирования продукта
  const handleEntering = () => {
    if (id != null) {
      // загружаем редактируемый продукт
      fetch("/api/products/" + id, {
        method: "GET",
        headers: { 'Content-Type': 'application/json' },
        })
        .then((response) => response.json())
        .then((product) => {
          setCurrentProduct(product);
        });
    } else {
      // создаем новый продукт для добавления
      const newProduct = {
        id: null,
        name: "",
        price: "",
        comment: "",
      };
      setCurrentProduct(newProduct);
    }
    // открываем модальное окно редактирования/добавления
    setShowUpdateModal(true);
  };

  // изменяем поле продукта по ключу "name"
  const updateValue = (e) => {
    const updateProduct = {
      ...currentProduct,
      [e.currentTarget.name]: e.currentTarget.value,
    };
    setCurrentProduct(updateProduct);
  };

  // сохраняем изменения на сервере
  const handleSave = () => {
    fetch("/api/products", {
      method: "POST",
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(currentProduct),
    }).then((result) => {
      console.log(result);
      // закрываем модальное окно
      setShowUpdateModal(false);
      updateData(id==null);
    });
  };

  return (
    <Modal
      aria-labelledby="contained-modal-title-vcenter"
      centered
      show={show}
      onEntering={handleEntering}
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
            fieldname="name"
            title="Наименование продукта"
            type="text"
            placeholder="Введите наименование продукта"
            value={currentProduct.name}
            textarea="input"
            validations={{
              maxLength: 20,
              minLength: 3,
              isEmpty: false,
            }}
            setUpdate={updateValue}
            setValidated={setValidated1}
          />
          <ValidatedInput
            fieldname="price"
            title="Цена за ед, руб."
            type="text"
            placeholder="Введите цену продукта"
            value={currentProduct.price}
            textarea="input"
            validations={{
              isPrice: false,
            }}
            setUpdate={updateValue}
            setValidated={setValidated2}
          />
          <ValidatedInput
            fieldname="comment"
            title="Примечание"
            type="text"
            placeholder=""
            value={currentProduct.comment}
            textarea="textarea"
            validations={{
              maxLength: 50,
            }}
            setUpdate={updateValue}
            setValidated={setValidated3}
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

export default ProductModal;
