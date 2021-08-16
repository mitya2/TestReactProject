import React from "react";
import { Form, Table, Button } from "react-bootstrap";
import OrderProductDeleteModal from "../Pages/Modals/OrderDetailDeleteModal";

const SalesOrderDetails = ({
  salesOrderDetails,
  setShowProductsList,
  deleteOrderProduct,
  setOrderDetailUpdate,
  inputValid
}) => {

  const onChange = (e, name, index) => {
    setOrderDetailUpdate(index, name, e.currentTarget.value);
  };

  return (
    <Form.Group className="mb-1">
      <Form.Label>Позиции заказа</Form.Label>
      <div
        style={{
          border: "1px solid #dee2e6",
          maxHeight: "200px",
          overflowY: "scroll",
          fontSize: ".85em",
        }}
      >
        <Table
          className="p-1 m-0"
          striped
          bordered
          //hover
        >
          <thead>
            <tr className="align-middle">
              <th className="text-center" width="100px">
                Артикул
              </th>
              <th>Наименование продукта</th>
              <th className="text-center" width="80px">
                Кол-во
              </th>
              <th className="text-center" width="100px">
                Цена, руб
              </th>
              <th width="40px" />
            </tr>
          </thead>
          {salesOrderDetails && (
            <tbody>
              {salesOrderDetails.map((item) => (
                <tr className="align-middle" key={item.salesOrderDetailId}>
                  <td className="text-center">{item.productId}</td>
                  <td>{item.product.name}</td>
                  <td className="text-center">
                    <Form.Control
                      style={{ fontSize: ".85em" }}
                      className="text-center p-0"
                      value={item.orderQuantity || ""}
                      type="text"
                      as="input"
                      onChange = {(e) => onChange(e, "orderQuantity", salesOrderDetails.indexOf(item))}
                    />
                  </td>
                  <td className="text-center">
                    <Form.Control
                      style={{ fontSize: ".85em" }}
                      className="text-center p-0"
                      value={item.unitPrice || ""}
                      type="text"
                      as="input"
                      onChange = {(e) => onChange(e, "unitPrice", salesOrderDetails.indexOf(item))}
                    />
                  </td>
                  <td width="40px">
                    <OrderProductDeleteModal
                      index={salesOrderDetails.indexOf(item)}
                      name={item.product.name}
                      deleteOrderProduct={deleteOrderProduct}
                    />
                  </td>
                </tr>
              ))}
            </tbody>
          )}
        </Table>
        {salesOrderDetails && salesOrderDetails.length === 0 && (
          <div className="m-2 text-center">Нет записей</div>
        )}
      </div>
      <div>
      {!inputValid && (
          <Form.Text className="text-danger">Ошибка в количестве или цене позиции!</Form.Text>
        )}
        </div>

      <Button className="mt-2" onClick={() => setShowProductsList(true)} variant="primary">
        Добавить продукт
      </Button>
    </Form.Group>
  );
};

export default SalesOrderDetails;
