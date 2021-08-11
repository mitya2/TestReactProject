import React from 'react'
import { Alert } from 'react-bootstrap'

const Status = (status) => {
    let _variant = "light";
    //console.log()
    

    switch (String(Object.values(status)))
    {
        case "Создан": 
        _variant = "light"
        break;
        case "Обрабатывается": 
        _variant = "secondary"
        break;
        case "Принят": 
        _variant = "primary"
        break;
        case "Оплачен": 
        _variant = "danger"
        break;
        case "Готов к отгрузке": 
        _variant = "warning"
        break;
        case "Отгружен": 
        _variant = "success"
        break;
    }
    
    return (
        <Alert className="m-0 p-0" variant={_variant}>
            <span style={{fontSize: '.85em'}}> {String(Object.values(status))} </span>
        </Alert>
    )
}

export default Status;