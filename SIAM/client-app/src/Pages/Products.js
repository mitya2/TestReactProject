import React, { useState, useEffect } from "react";
import { Table, OverlayTrigger, Tooltip, Button } from "react-bootstrap";
import Loading from "../Components/Loading";
import UPagination from "../Components/UPagination";
import DeleteProductButton from "../Components/DelectProductButton";
import UpdateProductModal from "../Components/UpdateProductModal";
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

  const [showUpdate, setShowUpdate] = useState(false);
  const [curentProductID, setСurentProductID] = useState(null);

  const [curentProduct, SetCurentProduct] = useState([]);

  const GetCurentProduct = (id) => {
    setСurentProductID(id);
    //const headers = { 'Content-Type': 'application/json', 'Accept': 'application/json' }

    fetch("/api/products/" + id, {})
      .then((response) => response.json())
      .then((curentProduct) => {
        console.log(curentProduct);
        SetCurentProduct(curentProduct);
      });
  };

  const paginate = (PageNumber) => {
    setCurrentPage(PageNumber);
  };

  const updateData = () => {
    fetch("/api/products")
      .then((response) => response.json())
      .then((products) => {
        setProducts(products);
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
              <tr>
                <th width="50px">Артикул</th>
                <th>Наименование продукта</th>
                <th width="150px">Цена, руб</th>
                <th width="40px" />
              </tr>
            </thead>
            <tbody>
              {currentItems.map((item) => (
                <tr key={item.productId}>
                  <td>{item.productId}</td>
                  <td>
                    <span
                      onClick={() => {
                        //setСurentProductID(item.productId);
                        GetCurentProduct(item.productId);
                        setShowUpdate(true);
                      }}
                      style={{
                        cursor: "pointer",
                        textDecoration: "none",
                        color: "black",
                      }}
                    >
                      {item.name}&nbsp;&nbsp;
                    </span>
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
                  <td>{item.price}</td>
                  <td>
                    <DeleteProductButton
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
                setСurentProductID(null);
                setShowUpdate(true);
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
      <UpdateProductModal
        show={showUpdate}
        id={curentProductID}
        setShowModal={setShowUpdate}
        updateData={updateData}
      />
    </div>
  );
};

export default Products;
