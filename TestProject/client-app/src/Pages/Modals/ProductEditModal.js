import React, { useEffect, useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";
import ValidatedInput from "../../Components/ValidatedInput";

const ProductEditModal = ({ show, id, setShowUpdateModal, updateData }) => {
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

  const handleHide = () => {
    setShowUpdateModal(false);
  };

  // обработка добавления/редактирования товара
  const handleEntering = () => {
    if (id != null) {
      // загружаем редактируемый товар
      fetch("/api/products/" + id, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      })
        .then((response) => response.json())
        .then((product) => {
          setCurrentProduct(product);
        });
    } else {
      // создаем новый товар для добавления
      const newProduct = {
        //productId: 0,
        name: "",
        price: "",
        comment: null,
      };
      setCurrentProduct(newProduct);
    }
    // открываем модальное окно редактирования/добавления
    setShowUpdateModal(true);
  };

  // изменяем поле товара по ключу "name"
  const updateValue = (key, value) => {
    const updateProduct = {
      ...currentProduct,
      [key]: value,
    };
    setCurrentProduct(updateProduct);
  };

  // сохраняем изменения на сервере
  const handleSave = () => {
    fetch("/api/products", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(currentProduct),
    }).then((result) => {
      // закрываем модальное окно
      setShowUpdateModal(false);
      updateData(id == null);
    });
  };

  return (
    <Modal
      aria-labelledby="contained-modal-title-vcenter"
      centered
      show={show}
      onEntering={handleEntering}
      onHide={handleHide}
    >
      <Modal.Header>
        <Modal.Title>
          {id ? "Редактирование товара" : "Создание товара"}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group className="mb-1">
            <Form.Label>Наименование товара</Form.Label>
            <ValidatedInput
              fieldname="name"
              type="text"
              placeholder="Введите наименование товара"
              value={currentProduct.name || ""}
              textarea="input"
              validations={{
                maxLength: 20,
                minLength: 3,
                isEmpty: false,
              }}
              setUpdate={updateValue}
              setValidated={setValidated1}
            />
          </Form.Group>
          <Form.Group className="mb-1">
            <Form.Label>Цена за ед, руб.</Form.Label>
            <ValidatedInput
              fieldname="price"
              type="text"
              placeholder="Введите цену товара"
              value={currentProduct.price || ""}
              textarea="input"
              validations={{
                isPrice: false,
              }}
              setUpdate={updateValue}
              setValidated={setValidated2}
            />
          </Form.Group>
          <Form.Group className="mb-1">
            <Form.Label>Примечание</Form.Label>
            <ValidatedInput
              fieldname="comment"
              type="text"
              placeholder=""
              value={currentProduct.comment || ""}
              textarea="textarea"
              validations={{
                maxLength: 50,
              }}
              setUpdate={updateValue}
              setValidated={setValidated3}
            />
          </Form.Group>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleHide}>
          Отмена
        </Button>
        <Button
          disabled={!formValidated}
          variant="success"
          onClick={handleSave}
        >
          {id ? "Сохранить" : "Создать"}
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ProductEditModal;
