import React, { useState, useEffect } from "react";
import { Table, OverlayTrigger, Tooltip, Button } from "react-bootstrap";
import Loading from "../Components/Loading";
import UPagination from "../Components/UPagination";
import SalesOrderDelete from "../Components/SalesOrderDelete";
import SalesOrderModal from "../Components/SalesOrderModal";
import { useLocalStorage } from "../Hooks/useLocalStorage";

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

  function FormateDate(value) {
    let result = new Intl.DateTimeFormat("ru", {
      year: "numeric",
      month: "long",
      day: "2-digit"
    }).format(value);
    return result;
  };

  useEffect(() => {
    //FormateDate(Date(2010, 7, 5));
    //console.log(FormateDate(Date(2010, 7, 5)));

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
              <tr>
                <th width="100px">Номер заказа</th>
                <th>ФИО клиента</th>
                <th width="200px">Дата заказа</th>
                <th width="160px">Статус заказа</th>
                <th width="40px" />
              </tr>
            </thead>
            <tbody>
              {currentItems.map((item) => (
                <tr key={item.salesOrderId}>
                  <td>{item.salesOrderId}</td>
                  <td
                    onClick={() => {
                      setCurrentSalesOrderId(item.salesOrderId);
                      setShowUpdateModal(true);
                    }}
                    style={{
                      cursor: "pointer",
                      textDecoration: "none",
                      color: "black",
                    }}
                  >
                    {item.customer.name}
                  </td>
                  <td>{item.orderDate}</td>
                  <td>{item.salesStatus.name}</td>
                  <td>
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
