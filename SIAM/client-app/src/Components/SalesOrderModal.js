import React, { useEffect, useState } from "react";
import { Modal, Button, Form, Dropdown } from "react-bootstrap";
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
        headers: { "Content-Type": "application/json" },
      })
        .then((response) => response.json())
        .then((order) => {
          setCurrentSalesOrder(order);
          console.log(order);
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
      //console.log(currentSalesOrder.salesStatus.name);
    }
    // открываем модальное окно редактирования/добавления
    setShowUpdateModal(true);
  };

  // изменяем поле заказа по ключу "name"
  const updateValue = (key, value) => {
    const updateSalesOrder = {
      ...currentSalesOrder,
      [key]: value,
    };
    setCurrentSalesOrder(updateSalesOrder);
  };

  // изменяем статус заказа
  const updateStatusValue = (id, status) => {
    const updateSalesOrder = {
      ...currentSalesOrder,
      salesStatusId: id,
      salesStatus: {
        ...currentSalesOrder.salesStatus,
        salesStatusId: id,
        name: status,
      },
    };
    setCurrentSalesOrder(updateSalesOrder);
  };

  useEffect(() => {
    console.log(currentSalesOrder);
  }, [currentSalesOrder]);

  // сохраняем изменения на сервере
  const handleSave = () => {
    fetch("/api/sales_orders", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(currentSalesOrder),
    }).then((result) => {
      //console.log(result);
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
      onHide={handleClose}
    >
      <Modal.Header>
        <Modal.Title>
          {id ? "Редактирование заказа" : "Добавление заказа"}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          {currentSalesOrder.salesStatus && (
            <Dropdown style={{width: '100% !important'}}>
              <Dropdown.Toggle variant="success" id="dropdown-basic">
                {currentSalesOrder.salesStatus.name ?? ""}
              </Dropdown.Toggle>

              <Dropdown.Menu>
                <Dropdown.Item
                  onClick={() => {
                    updateStatusValue(1, "Создан");
                  }}
                >
                  Создан
                </Dropdown.Item>
                <Dropdown.Item
                  onClick={() => {
                    updateStatusValue(2, "Обрабатывается");
                  }}
                >
                  Обрабатывается
                </Dropdown.Item>
                <Dropdown.Item
                  onClick={() => {
                    updateStatusValue(3, "Принят");
                  }}
                >
                  Принят
                </Dropdown.Item>
                <Dropdown.Item
                  onClick={() => {
                    updateStatusValue(4, "Оплачен");
                  }}
                >
                  Оплачен
                </Dropdown.Item>
                <Dropdown.Item
                  onClick={() => {
                    updateStatusValue(5, "Готов к отгрузке");
                  }}
                >
                  Готов к отгрузке
                </Dropdown.Item>
                <Dropdown.Item
                  onClick={() => {
                    updateStatusValue(6, "Отгружен");
                  }}
                >
                  Отгружен
                </Dropdown.Item>
              </Dropdown.Menu>
            </Dropdown>
          )}
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
