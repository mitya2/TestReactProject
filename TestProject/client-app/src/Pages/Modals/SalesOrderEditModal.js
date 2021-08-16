import React, { useEffect, useState } from "react";
import { Modal, Button, Form, Container, Row, Col } from "react-bootstrap";
import CustomersDropDown from "../../Components/CustomersDropDown";
import StatusesDropDown from "../../Components/StatusesDropDown";
import ValidatedInput from "../../Components/ValidatedInput";
import "react-datetime/css/react-datetime.css";
import Datetime from "react-datetime";
import moment from "moment";
import "../../css/FixedHeader.css";
import SalesOrderDetails from "../../Components/SalesOrderDetails";
import OrderDetailAddModal from "./OrderDetailAddModal";

const SalesOrderEditModal = ({ show, id, setShowUpdateModal, updateData }) => {
  const [currentSalesOrder, setCurrentSalesOrder] = useState({});
  const [statuses, setStatuses] = useState([]);
  const [customers, setCustomers] = useState([]);

  const [showProductsList, setShowProductsList] = useState(false);

  // обработка валидации формы
  const [formValidated, setFormValidated] = useState(false);
  const [orderValidated, setOrderValidated] = useState(false);
  const [orderDetailsValidated, setOrderDetailsValidated] = useState(false);

  const checkOrderDetailsValid = (orderDetails) => {
    let isValid = true;
    orderDetails.forEach((element) => {
      let re = /^(1|[1-9][0-9]*)$/; // проверка на цифры
      if (!re.test(String(element["orderQuantity"]).trim())) {
        isValid = false;
      }
      re = /(?<=^| )\d+(\.\d+)?(?=$| )/; // проверка на цену
      if (!re.test(String(element["unitPrice"]).trim())) {
        isValid = false;
      }
    });
    setOrderDetailsValidated(isValid);
  };

  useEffect(() => {
    if (orderValidated && orderDetailsValidated) {
      setFormValidated(true);
    } else {
      setFormValidated(false);
    }
  }, [orderValidated, orderDetailsValidated]);
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
      // загружаем редактируемый заказ
      fetch("/api/sales_orders/" + id, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      })
        .then((response) => response.json())
        .then((order) => {
          checkOrderDetailsValid(order.salesOrderDetails);
          setCurrentSalesOrder(order);
        });
    } else {
      // создаем новый заказ для добавления
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
          name: "Иванов Иван Иванович",
        },
        salesOrderDetails: [],
        comment: null,
      };
      checkOrderDetailsValid(newSalesOrder.salesOrderDetails);
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

  const addProductToOrder = (id, name, price) => {
    currentSalesOrder.salesOrderDetails.push({
      salesOrderId: currentSalesOrder.salesOrderId,
      productId: id,
      orderQuantity: 1,
      unitPrice: price,
      modifyDate: new Date(),
      product: {
        productId: id,
        name: name,
        price: price,
      },
    });
    setCurrentSalesOrder({ ...currentSalesOrder });
  };

  const deleteOrderProduct = (index) => {
    currentSalesOrder.salesOrderDetails.splice(index, 1);
    checkOrderDetailsValid(currentSalesOrder.salesOrderDetails);
    setCurrentSalesOrder({ ...currentSalesOrder });
  };

  const setOrderDetailUpdate = (index, name, value) => {
    currentSalesOrder.salesOrderDetails[index][name] = value;
    checkOrderDetailsValid(currentSalesOrder.salesOrderDetails);
    setCurrentSalesOrder({ ...currentSalesOrder });
  };

  useEffect(() => {}, [currentSalesOrder]);

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
    <>
      <Modal
        size="lg"
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
          <Container className="p-0">
            <Row>
              <Col>
                <Form.Group className="mb-1">
                  <Form.Label>Дата заказа</Form.Label>
                  {currentSalesOrder && (
                    <Datetime
                      closeOnSelect
                      input="false"
                      locale="ru"
                      onChange={updateOrderDate}
                      dateFormat="DD-MM-YYYY"
                      value={moment(currentSalesOrder.orderDate).format(
                        "DD-MM-YYYY"
                      )}
                      timeFormat={false}
                    />
                  )}
                </Form.Group>
              </Col>
              <Col>
                {currentSalesOrder.salesStatus && (
                  <StatusesDropDown
                    title={"Статус заказа"}
                    currentStatus={currentSalesOrder.salesStatus.name}
                    statuses={statuses}
                    updateStatus={updateStatus}
                  />
                )}
              </Col>
              {currentSalesOrder.salesOrderId && (
                <Col xs={2}>
                  <Form.Group className="mb-3">
                    <Form.Label>Номер заказа</Form.Label>
                    <Form.Control
                      className="text-center"
                      readOnly
                      value={currentSalesOrder.salesOrderId || ""}
                      type="text"
                      as="input"
                    />
                  </Form.Group>
                </Col>
              )}
            </Row>

            <Row className="mb-1">
              <Col>
                {currentSalesOrder.customer && (
                  <CustomersDropDown
                    title={"Клиент"}
                    currentCustomer={currentSalesOrder.customer.name}
                    customers={customers}
                    updateCustomer={updateCustomer}
                  />
                )}
              </Col>
            </Row>
            <Row>
              <Col>
                <SalesOrderDetails
                  salesOrderDetails={currentSalesOrder.salesOrderDetails}
                  setShowProductsList={setShowProductsList}
                  deleteOrderProduct={deleteOrderProduct}
                  setOrderDetailUpdate={setOrderDetailUpdate}
                  inputValid={orderDetailsValidated}
                />
                <Form.Group className="mb-1">
                  <Form.Label>Примечание</Form.Label>
                  <ValidatedInput
                    fieldname="comment"
                    type="text"
                    placeholder=""
                    value={currentSalesOrder.comment || ""}
                    textarea="textarea"
                    validations={{
                      maxLength: 50,
                    }}
                    setUpdate={updateValue}
                    setValidated={setOrderValidated}
                  />
                </Form.Group>
              </Col>
            </Row>
          </Container>
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
            {id ? "Сохранить" : "Добавить"}
          </Button>
        </Modal.Footer>
      </Modal>

      <OrderDetailAddModal
        show={showProductsList}
        addProductToOrder={addProductToOrder}
        setShowProductsList={setShowProductsList}
      />
    </>
  );
};

export default SalesOrderEditModal;
