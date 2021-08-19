import React from "react";
import { Navbar, Nav } from "react-bootstrap";
import { Link } from "react-router-dom";

const ProjectNavbar = () => {
  return (
    <Navbar
      sticky="top"
      fixed="top"
      collapseOnSelect
      expand="lg"
      bg="dark"
      variant="dark"
    >
      <Navbar.Brand className="ms-2">Система управления заказами</Navbar.Brand>
      <Navbar.Toggle aria-controls="responsive-navbar-nav" />
      <Navbar.Collapse id="responsive-navbar-nav">
        <Nav className="me-auto">
          <Nav.Link eventKey="1" className="ms-2" as={Link} to="/sales_orders">
            Список заказов
          </Nav.Link>
          <Nav.Link eventKey="2" className="ms-2" as={Link} to="/products">
            Товары
          </Nav.Link>
        </Nav>
        <Nav>
          <Nav.Link eventKey="3" className="btn btn-success m-2" as={Link} to="/about">
            О проекте...
          </Nav.Link>
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
};

export default ProjectNavbar;
