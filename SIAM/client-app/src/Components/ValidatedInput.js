import React from "react";
import { Form } from "react-bootstrap";
import { useInput } from "../Hooks/useInput";

const ValidatedInput = ({
  title,
  type,
  textarea,
  placeHolderValue,
  value,
  validations,
  validated,
}) => {
  const Input = useInput(value, validations, validated);

  return (
    <>
      <Form.Group className="mb-1">
        <Form.Label>{title}</Form.Label>
        <Form.Control
          className="form-control was-validated"
          onBlur={(e) => Input.onBlur(e)}
          onChange={(e) => Input.onChange(e)}
          value={Input.value}
          as={textarea}
          type={type}
          placeholder={placeHolderValue}
        />
        {Input.isDirty && !Input.inputValid && (
          <Form.Text className="text-danger">{Input.errorMessage}</Form.Text>
        )}
      </Form.Group>
    </>
  );
};

export default ValidatedInput;
