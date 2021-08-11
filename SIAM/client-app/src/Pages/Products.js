import React, { useState, useEffect } from "react";
import { Table, OverlayTrigger, Tooltip, Button } from "react-bootstrap";
import Loading from "../Components/Loading";
import UPagination from "../Components/UPagination";
import ProductDelete from "../Components/ProductDelete";
import ProductModal from "../Components/ProductModal";
import { useLocalStorage } from "../Hooks/useLocalStorage";

const Products = () => {
  const [products, setProducts] = useState([]);
  const [isLoading, setLoading] = useState(true);

  const [currentPage, setCurrentPage] = useLocalStorage(
    1,
    "productsPageNumber"
  );
  const [itemsPerPage] = useState(4);

  const lastItemIndex = currentPage * itemsPerPage;
  const firstItemIndex = lastItemIndex - itemsPerPage;
  const currentItems = products.slice(firstItemIndex, lastItemIndex);

  const paginate = (PageNumber) => {
    setCurrentPage(PageNumber);
  };

  const [showUpdateModal, setShowUpdateModal] = useState(false);
  const [currentProductId, setCurrentProductId] = useState(null);

  const updateData = (isAdding) => {
    fetch("/api/products", {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    })
      .then((response) => response.json())
      .then((products) => {
        setProducts(products);
        // если было добавление то перемещаемся в конец списка
        if (isAdding) {
          setCurrentPage(Math.ceil(products.length / itemsPerPage));
        }
        // если удалили последний элемент на странице - переходим на предыдущую
        if (Math.ceil(products.length / itemsPerPage) < currentPage)
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
      <h4>Список продуктов</h4>
      {isLoading && <Loading />}
      {!isLoading && (
        <>
          <Table className="me-auto" striped bordered hover>
            <thead>
              <tr className="align-middle">
                <th className="text-center" width="50px">Артикул</th>
                <th>Наименование продукта</th>
                <th className="text-center" width="150px">Цена, руб</th>
                <th width="40px" />
              </tr>
            </thead>
            <tbody>
              {currentItems.map((item) => (
                <tr className="align-middle" key={item.productId}>
                  <td className="text-center">{item.productId}</td>
                  <td
                    style={{
                      cursor: "pointer",
                    }}
                    onClick={() => {
                      setCurrentProductId(item.productId);
                      setShowUpdateModal(true);
                    }}
                  >
                    {item.name}&nbsp;&nbsp;
                    <OverlayTrigger
                      overlay={
                        <Tooltip id="tooltip-disabled">{item.comment}</Tooltip>
                      }
                    >
                      {item.comment ? (
                        <span className="d-inline-block">
                          <Button
                            style={{
                              pointerEvents: "none",
                              borderRadius: "1em",
                            }}
                            disabled
                            size="sm"
                            variant="secondary"
                          >
                            &nbsp;i&nbsp;
                          </Button>
                        </span>
                      ) : (
                        <span></span>
                      )}
                    </OverlayTrigger>
                  </td>
                  <td className="text-center">{item.price}</td>
                  <td className="text-center">
                    <ProductDelete
                      id={item.productId}
                      name={item.name}
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
                setCurrentProductId(null);
                setShowUpdateModal(true);
              }}
              variant="primary"
            >
              Добавить
            </Button>

            <UPagination
              currentPage={currentPage}
              itemsPerPage={itemsPerPage}
              totalItems={products.length}
              paginate={paginate}
            />
          </div>
        </>
      )}

      <ProductModal
        show={showUpdateModal}
        id={currentProductId}
        setShowUpdateModal={setShowUpdateModal}
        updateData={updateData}
      />
    </div>
  );
};

export default Products;
