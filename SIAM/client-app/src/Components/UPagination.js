import React from "react";
import { Pagination } from "react-bootstrap";

// currentPage - текущая страница
// itemsPerPage - элементов на странице
// totalItems - всего элементов
// paginate - делегат функции переключени страницы
const UPagination = ({ currentPage, itemsPerPage, totalItems, paginate }) => {
  const pageNumbers = []; // массив кнопок Paginator-а

  // формируем массив кнопок страниц (с округлением вверх)
  for (let i = 1; i <= Math.ceil(totalItems / itemsPerPage); i++) {
    pageNumbers.push(
      <Pagination.Item
        onClick={() => paginate(i)}
        key={i}
        activeLabel=""
        active={i === currentPage}
      >
        {i}
      </Pagination.Item>
    );
  }

  return <Pagination>{pageNumbers}</Pagination>;
};

export default UPagination;
