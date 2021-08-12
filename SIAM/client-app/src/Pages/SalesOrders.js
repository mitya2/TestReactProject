import React, { useState, useEffect } from "react";
import { Table, Alert, Button } from "react-bootstrap";
import Loading from "../Components/Loading";
import UPagination from "../Components/UPagination";
import SalesOrderDelete from "../Components/SalesOrderDelete";
import SalesOrderModal from "../Components/SalesOrderModal";
import StatusColor from "../Components/StatusColor";
import { useLocalStorage } from "../Hooks/useLocalStorage";
import moment from "moment";
import "moment/locale/ru";

const SalesOrders = () => {
  const [salesOrders, setSalesOrders] = useState([]);
  const [isLoading, setLoading] = useState(true);

  const [currentPage, setCurrentPage] = useLocalStorage(
    1,
    "salesOrdersPageNumber"
  );
  const [itemsPerPage] = useState(4);

  const lastItemIndex = currentPage * itemsPerPage;
  const firstItemIndex = lastItemIndex - itemsPerPage;
  const currentItems = salesOrders.slice(firstItemIndex, lastItemIndex);

  const paginate = (PageNumber) => {
    setCurrentPage(PageNumber);
  };

  const [showUpdateModal, setShowUpdateModal] = useState(false);
  const [currentSalesOrderId, setCurrentSalesOrderId] = useState(null);

  const updateData = (isAdding) => {
    fetch("/api/sales_orders", {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    })
      .then((response) => response.json())
      .then((salesOrders) => {
        setSalesOrders(salesOrders);
        // если было добавление то перемещаемся в конец списка
        if (isAdding) {
          setCurrentPage(Math.ceil(salesOrders.length / itemsPerPage));
        }
        // если удалили последний элемент на странице - переходим на предыдущую
        if (Math.ceil(salesOrders.length / itemsPerPage) < currentPage)
          setCurrentPage(currentPage - 1);
      });
  };

  useEffect(() => {
    setLoading(true);
    setTimeout(() => {
      updateData();
      setLoading(false);
    }, 500); // задержка для демонстрации отображения процесса загрузки данных
  }, []);

  return (
    <div className="m-2">
      <h4>Список заказов</h4>
      {isLoading && <Loading />}
      {!isLoading && (
        <>
          <Table className="me-auto" striped bordered hover>
            <thead>
              <tr className="align-middle">
                <th className="text-center" width="100px">
                  Номер заказа
                </th>
                <th>ФИО клиента</th>
                <th className="text-center" width="200px">
                  Дата заказа
                </th>
                <th className="text-center" width="160px">
                  Статус заказа
                </th>
                <th width="40px" />
              </tr>
            </thead>
            <tbody>
              {currentItems.map((item) => (
                <tr className="align-middle" key={item.salesOrderId}>
                  <td className="text-center">{item.salesOrderId}</td>
                  <td
                    onClick={() => {
                      setCurrentSalesOrderId(item.salesOrderId);
                      setShowUpdateModal(true);
                    }}
                    style={{
                      cursor: "pointer",
                    }}
                  >
                    {item.customer.name}
                  </td>
                  <td className="text-center">
                    {moment(item.orderDate).locale("ru").format("DD MMMM YYYY")}
                  </td>
                  <td className="text-center">
                    <Alert
                      className="m-0 p-0"
                      variant={StatusColor(item.salesStatus.name)}
                    >
                      <span style={{ fontSize: ".85em" }}>
                        {String(item.salesStatus.name)}
                      </span>
                    </Alert>
                  </td>
                  <td className="text-center">
                    <SalesOrderDelete
                      id={item.salesOrderId}
                      updateData={updateData}
                    />
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>

          {currentItems.length === 0 && (
            <div className="text-center">Нет записей</div>
          )}

          <div className="d-sm-flex justify-content-between">
            <Button
              onClick={() => {
                setCurrentSalesOrderId(null);
                setShowUpdateModal(true);
              }}
              variant="primary"
            >
              Добавить
            </Button>

            <UPagination
              currentPage={currentPage}
              itemsPerPage={itemsPerPage}
              totalItems={salesOrders.length}
              paginate={paginate}
            />
          </div>
        </>
      )}
      <SalesOrderModal
        show={showUpdateModal}
        id={currentSalesOrderId}
        setShowUpdateModal={setShowUpdateModal}
        updateData={updateData}
      />
    </div>
  );
};

export default SalesOrders;
