import React, { useEffect, useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";
import ValidatedInput from "./ValidatedInput";

const SalesOrderModal = ({ show, id, setShowUpdateModal, updateData }) => {
  // обработка валидации формы
  const [formValidated, setFormValidated] = useState(false);
  const [validated1, setValidated1] = useState(false);
  const [validated2, setValidated2] = useState(false);
  const [validated3, setValidated3] = useState(false);

  const [currentSalesOrder, setCurrentSalesOrder] = useState({});

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

  // обработка добавления/редактирования заказа
  const handleEntering = () => {
    if (id != null) {
      // загружаем редактируемый заказа
      fetch("/api/sales_orders/" + id, {
        method: "GET",
        headers: { 'Content-Type': 'application/json' },
        })
        .then((response) => response.json())
        .then((order) => {
            setCurrentSalesOrder(order);
        });
    } else {
      // создаем новый продукт для добавления
      const newSalesOrder = {
        id: null,
        //name: "",
        //price: "",
        //comment: "",
      };
      setCurrentSalesOrder(newSalesOrder);
    }
    // открываем модальное окно редактирования/добавления
    setShowUpdateModal(true);
  };

  // изменяем поле продукта по ключу "name"
  const updateValue = (e) => {
    const updateSalesOrder = {
      ...currentSalesOrder,
      [e.currentTarget.name]: e.currentTarget.value,
    };
    setCurrentSalesOrder(updateSalesOrder);
  };

  // сохраняем изменения на сервере
  const handleSave = () => {
    fetch("/api/sales_orders", {
      method: "POST",
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(currentSalesOrder),
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
          {id ? "Редактирование заказа" : "Добавление заказа"}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
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

export default SalesOrderModal;
