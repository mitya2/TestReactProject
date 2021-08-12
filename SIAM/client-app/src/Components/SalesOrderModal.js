import React, { useEffect, useState } from "react";
import { Modal, Button, Form, FormControl } from "react-bootstrap";
import CustomersDropDown from "./CustomersDropDown";
import StatusesDropDown from "./StatusesDropDown";
import ValidatedInput from "./ValidatedInput";
import "react-datetime/css/react-datetime.css";
import Datetime from "react-datetime";
import moment from "moment";

const SalesOrderModal = ({ show, id, setShowUpdateModal, updateData }) => {
  // обработка валидации формы
  const [formValidated, setFormValidated] = useState(false);
  const [validated1, setValidated1] = useState(false);
  const [validated2, setValidated2] = useState(false);
  const [validated3, setValidated3] = useState(false);

  const [currentSalesOrder, setCurrentSalesOrder] = useState({});
  const [statuses, setStatuses] = useState([]);
  const [customers, setCustomers] = useState([]);

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

  // обработка добавления/редактирования заказа
  const handleEntering = () => {
    //загружаем клиентов
    fetch("/api/customers", {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    })
      .then((response) => response.json())
      .then((data) => {
        setCustomers(data);
      });

    //загружаем статусы заказа
    fetch("/api/sales_statuses", {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    })
      .then((response) => response.json())
      .then((data) => {
        setStatuses(data);
      });

    if (id != null) {
      // загружаем редактируемый заказа
      fetch("/api/sales_orders/" + id, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      })
        .then((response) => response.json())
        .then((order) => {
          setCurrentSalesOrder(order);
        });
    } else {
      // создаем новый продукт для добавления
      const newSalesOrder = {
        orderDate: moment(new Date()).format("YYYY-MM-DD"),
        salesStatusId: 1,
        customerId: 1,
        salesStatus: {
          salesStatusId: 1,
          name: "Создан",
        },
        customer: {
          customerId: 1,
          name: "Иванов",
        },
        salesOrderDetails: [],
        comment: null,
      };
      setCurrentSalesOrder(newSalesOrder);
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
  const updateStatus = (id, status) => {
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

  // изменяем статус заказа
  const updateCustomer = (id, customer) => {
    const updateSalesOrder = {
      ...currentSalesOrder,
      customerId: id,
      customer: {
        ...currentSalesOrder.customer,
        customerId: id,
        name: customer,
      },
    };
    setCurrentSalesOrder(updateSalesOrder);
  };

  // изменяем дату заказа
  const updateOrderDate = (e) => {
    try {
      const updateSalesOrder = {
        ...currentSalesOrder,
        orderDate: e.format("YYYY-MM-DD"),
      };

      setCurrentSalesOrder(updateSalesOrder);
    } catch {}
  };

  useEffect(() => {
    //console.log(currentSalesOrder);
  }, [currentSalesOrder]);

  // сохраняем изменения на сервере
  const handleSave = () => {
    fetch("/api/sales_orders", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(currentSalesOrder),
    }).then((result) => {
      //      console.log(result);
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
          {id ? "Редактирование заказа" : "Добавление заказа"}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group className="mb-1">
            <Form.Label>Дата заказа</Form.Label>
            {currentSalesOrder && (
              <Datetime
                closeOnSelect
                input="false"
                locale="ru"
                onChange={updateOrderDate}
                dateFormat="DD-MM-YYYY"
                value={moment(currentSalesOrder.orderDate).format("DD-MM-YYYY")}
                timeFormat={false}
              />
            )}
          </Form.Group>
          {currentSalesOrder.customer && (
            <CustomersDropDown
              title={"Клиент"}
              currentCustomer={currentSalesOrder.customer.name}
              customers={customers}
              updateCustomer={updateCustomer}
            />
          )}
          {currentSalesOrder.salesStatus && (
            <StatusesDropDown
              title={"Статус заказа"}
              currentStatus={currentSalesOrder.salesStatus.name}
              statuses={statuses}
              updateStatus={updateStatus}
            />
          )}
          <Form.Group className="mb-1">
            <Form.Label>Позиции заказа</Form.Label>
          <div className="d-sm-flex justify-content-between">
            <Button
              onClick={() => {
                //setCurrentSalesOrderId(null);
                //setShowUpdateModal(true);
              }}
              variant="primary"
            >
              Добавить продукт
            </Button>
          </div>
          </Form.Group>
          <ValidatedInput
            fieldname="comment"
            title="Примечание"
            type="text"
            placeholder=""
            value={currentSalesOrder.comment || ''}
            textarea="textarea"
            validations={{
              maxLength: 50,
            }}
            setUpdate={updateValue}
            setValidated={setValidated1}
          />
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleHide}>
          Отмена
        </Button>
        <Button
          //disabled={!formValidated}
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
