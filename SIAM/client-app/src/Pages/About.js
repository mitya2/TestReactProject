import React from "react";
import { Button } from "react-bootstrap";

const About = () => {
  return (
   <div className="m-2">
     
      <p>Проект выполнен в качестве тестового задания.</p> <hr/>
        <p><b>Использованы следующие технологии</b></p>
        <div>Back-end: ASP.net Сore 5, MS SQL, Entity Framework, MVC, LINQ, веб-API</div>
        <p>Front-End: React, React-Bootstrap, Hooks</p>
        <p><b>Реализован следующий функционал</b></p>
        <div>Создание заказа и редактирование заказа (нескольколько позиций в заказе)</div>
        <div>Создание и редактирование списка продуктов</div>
        <div>Валидация введенных значений (на стороне клиента)</div>
        <div>Модальные окна диалогов</div>
        <div>Пейджинг таблиц (на стороне клиента)</div>
        <p>Адаптивная верстка</p><hr/>
        <p><b>Автор</b></p>
        <div>Панов Дмитрий</div>
        <p>+7 916 604 30 64</p>
        <div><Button size="sm" href="mailto:mitya2@yahoo.com">mitya2@yahoo.com</Button></div>
        </div>
  );
};

export default About;
