import React from "react";
import { Pagination } from "react-bootstrap";

// currentPage - текущая страница
// itemsPerPage - элементов на странице
// totalItems - всего элементов
// paginate - делегат функции переключени страницы
const UPagination = ({ currentPage, itemsPerPage, totalItems, paginate }) => {
  const pageNumbers = []; // массив кнопок Paginator-а

  const pagesCount = Math.ceil(totalItems / itemsPerPage); // кол-во страниц

  if (pagesCount > 1) { 
    // если страниц больше 1, то формируем массив кнопок страниц
    for (let i = 1; i <= pagesCount; i++) {
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
    return <Pagination className="m-0">{pageNumbers}</Pagination>;
  } else { 
    return <></>;
  }
};

export default UPagination;
