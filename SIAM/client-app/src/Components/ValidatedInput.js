import React, { useState } from "react";
import { Form } from "react-bootstrap";
import { useValidation } from "../Hooks/useValidation";

const ValidatedInput = ({
  fieldname,
  type,
  textarea,
  placeholder,
  value,
  validations,
  setValidated,
  setUpdate,
}) => {
  const [isDirty, setIsDirty] = useState(false);
  const valid = useValidation(String(value), validations, setValidated);
  
  const onChange = (e) => {
    setUpdate(e.currentTarget.name, e.currentTarget.value);
  };

  const onBlur = (e) => {
    setIsDirty(true);
  };

  return (
    <>
        <Form.Control
          name={fieldname}
          value={value}
          type={type}
          as={textarea}
          placeholder={placeholder}
          onChange={(e) => onChange(e)}
          onBlur={(e) => onBlur(e)}
        />
        {isDirty && !valid.inputValid && (
          <Form.Text className="text-danger">{valid.errorMessage}</Form.Text>
        )}
    </>
  );
};

export default ValidatedInput;
