import React from "react";
import { Dropdown, DropdownButton, Form } from "react-bootstrap";

const StatusesDropDown = ({ title, currentStatus, statuses, updateStatus }) => {
  return (
    <Form.Group className="mb-1">
      <Form.Label>{title}</Form.Label>
      <Dropdown className="d-grid">
        <Dropdown.Toggle variant="secondary">{currentStatus}</Dropdown.Toggle>
        <Dropdown.Menu style={{ width: "100%", textAlign: "center" }}>
          {statuses.map((item) => (
            <Dropdown.Item
              key={item.salesStatusId}
              onClick={() => {
                updateStatus(item.salesStatusId, item.name);
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

export default StatusesDropDown;
