import React from "react";
import { Form, Table, Button } from "react-bootstrap";
import OrderProductDelete from "../Components/OrderProductDelete";

const SalesOrderDetails = ({ salesOrderDetails, setShowProductsList, deleteOrderProduct }) => {
  console.log("salesOrderDetails")
  console.log(salesOrderDetails)
  return (
    <Form.Group className="mb-1">
      <Form.Label>Позиции заказа</Form.Label>
      <div
        className="mb-2"
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
                    />
                  </td>
                  <td className="text-center">
                    <Form.Control
                      style={{ fontSize: ".85em" }}
                      className="text-center p-0"
                      value={item.unitPrice || ""}
                      type="text"
                      as="input"
                    />
                  </td>
                  <td width="40px">
                    <OrderProductDelete
                      index={salesOrderDetails.indexOf(item)}
                      name={item.product.name}
                      deleteOrderProduct = {deleteOrderProduct}
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

      <Button
        onClick={() => {
          setShowProductsList(true);
        }}
        variant="primary"
      >
        Добавить продукт
      </Button>
    </Form.Group>
  );
};

export default SalesOrderDetails;
