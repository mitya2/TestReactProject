function StatusColor(status) {
  let _variant;
  switch (status) {
    case "Создан":
      _variant = "light";
      break;
    case "Обрабатывается":
      _variant = "secondary";
      break;
    case "Принят":
      _variant = "primary";
      break;
    case "Оплачен":
      _variant = "danger";
      break;
    case "Готов к отгрузке":
      _variant = "warning";
      break;
    case "Отгружен":
      _variant = "success";
      break;
    default:
      _variant = "light";
      break;
  }

  return _variant;
}

export default StatusColor;
