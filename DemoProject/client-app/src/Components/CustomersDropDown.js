import React from "react";
import { Dropdown, Form } from "react-bootstrap";

const CustomersDropDown = ({
  title,
  currentCustomer,
  customers,
  updateCustomer,
}) => {
  return (
    <Form.Group className="mb-1">
      <Form.Label>{title}</Form.Label>
      <Dropdown className="d-grid">
        <Dropdown.Toggle variant="secondary">{currentCustomer}</Dropdown.Toggle>
        <Dropdown.Menu style={{ width: "100%", textAlign: "center" }}>
          {customers.map((item) => (
            <Dropdown.Item
              key={item.customerId}
              onClick={() => {
                updateCustomer(item.customerId, item.name);
              }}
            >
              {item.name}
            </Dropdown.Item>
          ))}
        </Dropdown.Menu>
      </Dropdown>
    </Form.Group>
  );
};

export default CustomersDropDown;
