import { useState, useEffect } from "react";
import { useValidation } from "./useValidation";

const useInput = (initialValue, validations, validated) => {
  const [value, setValue] = useState(initialValue);
  const [isDirty, setIsDirty] = useState(false);
  
  const valid = useValidation(value, validations, validated);

  const onChange = (e) => {
    setValue(e.target.value);
  };
  
  const onBlur = (e) => {
    setIsDirty(true);
  };

  return {value, onChange, onBlur, isDirty, ...valid};
}

export { useInput };
