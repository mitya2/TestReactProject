import React from "react";
import { Button } from "react-bootstrap";

const About = () => {
  return (
   <div className="m-2">
      <p>Проект выполнен с целью изучения технологий и демонстрации уровня их владения.</p> <hr/>
        <p className="mb-0"><b>Использованы следующие технологии</b></p>
        <div>Back-end: <span className="fst-italic">ASP.net Сore 5, MS SQL, Entity Framework, MVC, LINQ, веб-API</span></div>
        <p>Front-End: <span className="fst-italic">React, React-Bootstrap, Hooks</span></p>
        <p className="mb-0"><b>Реализован следующий функционал</b></p>
        <div>Создание и редактирование заказа (нескольколько позиций в заказе)</div>
        <div>Создание и редактирование списка товаров</div>
        <div>Валидация введенных значений (на стороне клиента)</div>
        <div>Модальные окна диалогов</div>
        <div>Пейджинг таблиц (на стороне клиента)</div>
        <p>Адаптивная верстка</p><hr/>
        <div className="me-2 position-absolute end-0">
          <p className="mb-0"><b>Автор</b></p>
          <div>Панов Дмитрий</div>
          <p>+7 916 604 30 64</p>
          <div><Button size="sm" href="mailto:mitya2@yahoo.com">mitya2@yahoo.com</Button></div>
        </div>
        </div>
  );
};

export default About;
