import React from "react";
import { Navbar, Nav, Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import styled from "styled-components";

const Styles = styled.div`
    a, .navbar-brand, .navbar-nav .navbar-link {
        color: #adb1b8;
        text-decoration: none;
        &:hover {
            color: white;
        }
    }
)`;

export default function NaviBar() {
  return (
    <>
      <Styles>
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
          <Navbar.Brand className="ms-2">Список заказов овощей</Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto">
            <Nav.Link as={Link} to="/">Список заказов</Nav.Link>
            <Nav.Link as={Link}  to="/products">Продукты</Nav.Link>
            <Nav.Link as={Link}  to="/about">О проекте</Nav.Link>
            </Nav>
            <Nav>
              <Button variant="primary" className="me-2">
                Log In
              </Button>
              <Button variant="primary" className="me-2">
                Sign Out
              </Button>
            </Nav>
          </Navbar.Collapse>
        </Navbar>
      </Styles>
    </>
  );
}
