import React, { useState, useEffect } from "react";
import Loading from "../Components/Loading";
import UPagination from "../Components/UPagination";
import { Table, OverlayTrigger, Tooltip, Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import DeleteProductButton from "../Components/DelectProductButton";
//import Context from "../Context";
import { useLocalStorage } from "../Hooks/useLocalStorage";


const Products = () => {
  const [products, setProducts] = useState([]);
  const [isLoading, setLoading] = useState(true);

  //const [currentPage, setCurrentPage] = useState(1);
  const [currentPage, setCurrentPage] = useLocalStorage(1, 'productsPageNumber');

  const [itemsPerPage] = useState(10);

  const lastItemIndex = currentPage * itemsPerPage;
  const firstItemIndex = lastItemIndex - itemsPerPage;
  const currentItems = products.slice(firstItemIndex, lastItemIndex);
  const paginate = (PageNumber) => setCurrentPage(PageNumber);

  useEffect(() => {
    fetch("/api/products")
      .then((response) => response.json())
      .then((products) => {
        setTimeout(() => {
          setProducts(products);
          setLoading(false);
        }, 500); // задержка для демонстрации отображения процесса загрузки данных
      });
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
                <th>Наименование товара</th>
                <th width="150px">Цена, руб</th>
                <th width="40px" />
              </tr>
            </thead>
            <tbody>
              {currentItems.map((item) => (
                <tr key={item.productId}>
                  <td>{item.productId}</td>
                  <td>
                    <Link
                      style={{
                        cursor: "pointer",
                        textDecoration: "none",
                        color: "black",
                      }}
                      to={"/EditProduct/" + item.productId}
                    >
                      {item.name}&nbsp;&nbsp;
                    </Link>
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
                    <DeleteProductButton id={item.productId} name={item.name} />
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>

          <div className="d-sm-flex justify-content-between">
            <div className="bd-highlight">
              <Link to="/addProduct" className="btn btn-primary">
                Добавить
              </Link>
            </div>
            <div className="bd-highlight">
              <UPagination
                currentPage={currentPage}
                itemsPerPage={itemsPerPage}
                totalItems={products.length}
                paginate={paginate}
              />
            </div>
          </div>
        </>
      )}
    </div>
  );
};

export default Products;
